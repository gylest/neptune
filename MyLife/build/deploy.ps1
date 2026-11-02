#Requires -Version 5.1
<#
.SYNOPSIS
    Deploys the local dist/ directory to the S3 bucket octobridge.co.uk and creates a CloudFront invalidation.
#>

$ErrorActionPreference = "Stop"

# Define Script Variables
$LocalDistPath = Join-Path (Split-Path -Parent $PSScriptRoot) "dist"
if (!(Test-Path $LocalDistPath)) {
    # Fallback if run directly where current working directory contains dist/
    $LocalDistPath = "dist"
}
$BucketName = "octobridge.co.uk"
$Region = "eu-west-2"
$CloudFrontDomain = "d1zhb64xsotj29.cloudfront.net"

function Write-StepStatus {
    param (
        [string]$StepName,
        [bool]$Success,
        [string]$Details = ""
    )
    if ($Success) {
        Write-Host "[SUCCESS] $StepName" -ForegroundColor Green
        if ($Details) {
            Write-Host "          $Details" -ForegroundColor Gray
        }
    } else {
        Write-Host "[FAILURE] $StepName" -ForegroundColor Red
        if ($Details) {
            Write-Host "          $Details" -ForegroundColor Yellow
        }
    }
}

Write-Host "=====================================================" -ForegroundColor Cyan
Write-Host " Starting AWS S3 & CloudFront Deployment Script" -ForegroundColor Cyan
Write-Host "=====================================================" -ForegroundColor Cyan
Write-Host ""

# -------------------------------------------------------------------------
# 1. Checks
# -------------------------------------------------------------------------
Write-Host "--- Step 1: Running Pre-deployment Checks ---" -ForegroundColor Cyan

# 1a. Check AWS CLI v2 is installed
try {
    $awsCmd = Get-Command aws -ErrorAction Stop
    $awsVersionOutput = & aws --version 2>&1 | Out-String
    $awsVersionOutput = $awsVersionOutput.Trim()
    
    if ($awsVersionOutput -match "^aws-cli/2\.") {
        Write-StepStatus -StepName "Check 1.1: AWS CLI v2 installed" -Success $true -Details $awsVersionOutput
    } else {
        Write-StepStatus -StepName "Check 1.1: AWS CLI v2 installed" -Success $false -Details "Found version: $awsVersionOutput. AWS CLI v2 is required."
        exit 1
    }
} catch {
    Write-StepStatus -StepName "Check 1.1: AWS CLI v2 installed" -Success $false -Details "AWS CLI is not installed or not found in PATH."
    exit 1
}

# 1b. Check local folder "dist/" exists and is not empty
try {
    if (!(Test-Path -Path $LocalDistPath -PathType Container)) {
        Write-StepStatus -StepName "Check 1.2: Local folder 'dist/' is not empty" -Success $false -Details "Folder '$LocalDistPath' does not exist."
        exit 1
    }

    $distItems = Get-ChildItem -Path $LocalDistPath -Force
    if ($null -eq $distItems -or @($distItems).Count -eq 0) {
        Write-StepStatus -StepName "Check 1.2: Local folder 'dist/' is not empty" -Success $false -Details "Folder '$LocalDistPath' is empty."
        exit 1
    }

    Write-StepStatus -StepName "Check 1.2: Local folder 'dist/' is not empty" -Success $true -Details "Found $(@($distItems).Count) top-level item(s) in '$LocalDistPath'."
} catch {
    Write-StepStatus -StepName "Check 1.2: Local folder 'dist/' is not empty" -Success $false -Details $_.Exception.Message
    exit 1
}

# 1c. Check access to S3 bucket: octobridge.co.uk (eu-west-2)
try {
    $headOutput = & aws s3api head-bucket --bucket $BucketName --region $Region 2>&1
    if ($LASTEXITCODE -ne 0) {
        $errDetails = ($headOutput | Out-String).Trim()
        Write-StepStatus -StepName "Check 1.3: Access to S3 bucket '$BucketName'" -Success $false -Details "Cannot access bucket https://$Region.console.aws.amazon.com/s3/buckets/$BucketName. $errDetails"
        exit 1
    }
    Write-StepStatus -StepName "Check 1.3: Access to S3 bucket '$BucketName'" -Success $true -Details "Verified access to s3://$BucketName ($Region)."
} catch {
    Write-StepStatus -StepName "Check 1.3: Access to S3 bucket '$BucketName'" -Success $false -Details $_.Exception.Message
    exit 1
}

Write-StepStatus -StepName "Step 1: All pre-deployment checks" -Success $true
Write-Host ""

# -------------------------------------------------------------------------
# 2. Delete all files and folders in the S3 bucket
# -------------------------------------------------------------------------
Write-Host "--- Step 2: Deleting all files and folders in s3://$BucketName ---" -ForegroundColor Cyan
try {
    & aws s3 rm "s3://$BucketName" --recursive --region $Region
    if ($LASTEXITCODE -ne 0) {
        Write-StepStatus -StepName "Step 2: Delete all files and folders in bucket '$BucketName'" -Success $false -Details "aws s3 rm exited with code $LASTEXITCODE."
        exit 1
    }
    Write-StepStatus -StepName "Step 2: Delete all files and folders in bucket '$BucketName'" -Success $true
} catch {
    Write-StepStatus -StepName "Step 2: Delete all files and folders in bucket '$BucketName'" -Success $false -Details $_.Exception.Message
    exit 1
}
Write-Host ""

# -------------------------------------------------------------------------
# 3. Copy all files and folders in local "dist/" to S3 destination
# -------------------------------------------------------------------------
Write-Host "--- Step 3: Copying files from '$LocalDistPath/' to s3://$BucketName ---" -ForegroundColor Cyan
try {
    & aws s3 cp "$LocalDistPath/" "s3://$BucketName/" --recursive --region $Region
    if ($LASTEXITCODE -ne 0) {
        Write-StepStatus -StepName "Step 3: Copy files from 'dist/' to S3 bucket '$BucketName'" -Success $false -Details "aws s3 cp exited with code $LASTEXITCODE."
        exit 1
    }
    Write-StepStatus -StepName "Step 3: Copy files from 'dist/' to S3 bucket '$BucketName'" -Success $true
} catch {
    Write-StepStatus -StepName "Step 3: Copy files from 'dist/' to S3 bucket '$BucketName'" -Success $false -Details $_.Exception.Message
    exit 1
}
Write-Host ""

# -------------------------------------------------------------------------
# 4. Create CloudFront Invalidation
# -------------------------------------------------------------------------
Write-Host "--- Step 4: CloudFront Invalidation ---" -ForegroundColor Cyan
Write-Host "  Distribution Domain Name : $CloudFrontDomain"
Write-Host "  Selection Method         : By Paths"
Write-Host "  Object Paths             : /*"
Write-Host ""

$confirmation = Read-Host "Do you want to create this CloudFront invalidation? (Y/N)"
if ($confirmation -notmatch "^[Yy](es)?$") {
    Write-Host "[SKIPPED] Step 4: CloudFront invalidation cancelled by user." -ForegroundColor Yellow
    exit 0
}

try {
    # Look up the Distribution ID from the Distribution Domain Name
    $distIdOutput = & aws cloudfront list-distributions --query "DistributionList.Items[?DomainName=='$CloudFrontDomain'].Id | [0]" --output text 2>&1
    if ($LASTEXITCODE -ne 0) {
        $errDetails = ($distIdOutput | Out-String).Trim()
        Write-StepStatus -StepName "Step 4: Create CloudFront invalidation" -Success $false -Details "Failed to query CloudFront distributions: $errDetails"
        exit 1
    }

    $DistributionId = ($distIdOutput | Out-String).Trim()
    if ([string]::IsNullOrWhiteSpace($DistributionId) -or $DistributionId -eq "None" -or $DistributionId -eq "null") {
        Write-StepStatus -StepName "Step 4: Create CloudFront invalidation" -Success $false -Details "Could not find a CloudFront distribution matching domain '$CloudFrontDomain'."
        exit 1
    }

    Write-Host "Found Distribution ID: $DistributionId" -ForegroundColor Gray

    $invalidationOutput = & aws cloudfront create-invalidation --distribution-id $DistributionId --paths "/*" 2>&1
    if ($LASTEXITCODE -ne 0) {
        $errDetails = ($invalidationOutput | Out-String).Trim()
        Write-StepStatus -StepName "Step 4: Create CloudFront invalidation" -Success $false -Details $errDetails
        exit 1
    }

    Write-StepStatus -StepName "Step 4: Create CloudFront invalidation for $CloudFrontDomain ($DistributionId) with path '/*'" -Success $true
} catch {
    Write-StepStatus -StepName "Step 4: Create CloudFront invalidation" -Success $false -Details $_.Exception.Message
    exit 1
}

Write-Host ""
Write-Host "=====================================================" -ForegroundColor Green
Write-Host " Deployment Completed Successfully!" -ForegroundColor Green
Write-Host "=====================================================" -ForegroundColor Green
