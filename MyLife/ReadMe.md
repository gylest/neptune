# MyLife Web Site

## Layout

This MPA contains the following assets:-  

* **Index Page**  
    Home page for web site.  

* **AboutMe Page**  
    Biography page.  

* **MyPet**  
    Articles about Ella our pet Shih Tzu.  

## Packaging the Site

At PowerShell command prompt: `./build/builddist.ps1`  

## Deployment to AWS

### Create AWS S3 Bucket to Host Website

1. General Configuration
   * Login to AWS S3
   * Create unique bucket `octobridge.co.uk`
   * Select region: Europe(London) eu-west-2
2. Configure Public Access
   * Uncheck the box for Block all public access.
   * Check the acknowledgment box and Save changes
3. Bucket versinoning
   * Disable
4. Add a bucket policy:

   ```json
   {
     "Version": "2012-10-17",
     "Statement": [
       {
         "Sid": "PublicReadGetObject",
         "Effect": "Allow",
         "Principal": "*",
         "Action": ["s3:GetObject"],
         "Resource": ["arn:aws:s3:::octobridge.co.uk/*"]
       }
     ]
   }
   ```

5. Enable Static Website Hosting
   * Goto properties tab of bucket
   * Scroll down to static website hosting and click edit
   * Select `Enable`
   * Specify index document
   * Select `Save`

6. Upload Website Files
   * Go to the Objects tab of your bucket.
   * Click Upload.
   * Upload all your static website files (HTML, CSS, JavaScript, images, etc.). Make sure your main page is named the same as your specified index document (index.html).
   * The web site address is <http://octobridge.co.uk.s3-website.eu-west-2.amazonaws.com/>

   Repeat the above by creating a bucket `www.octobridge.co.uk`. The main difference  being in the bucket properties set the hosting type to `Redirect requests for an object` and give hostname `octobridge.co.uk`.  

### Create Route 53 Hosted Zone

To use the registered domain `octobridge.co.uk` for the S3 static website, you'll need to create a Hosted Zone in AWS Route 53 for your domain  and then create an Alias record that points to your S3 bucket's website endpoint.

A second alias record is created for `www.octobridge.co.uk` for redirection to `octobridge.co.uk`.  

1. Create the hosted zone `octobridge.co.uk`  
      * Make note of NS records  
      * In the domain registrar for `octobridge.co.uk` enter these NS records  
2. Create the Alias record:  
      * Record name: blank  
      * Record type: `A` (routes traffic to IPV4 address or AWS resource)  
      * Alias: `On`  
      * Route traffic to: `Alias to AWS S3 Endpoint`  
      * Region: `eu-west-2`  
      * Endpoint: `octobridge.co.uk.s3-website.eu-west-2.amazonaws.com`  
      * Routing policy: `Simple`  
3. Create another alias record:  
      * Record name: `www`  
      * Record type:`A`  
      * Alias: `On`  
      * Route traffic to: `Alias to AWS S3 Endpoint`  
      * Region: `eu-west-2`  
      * Endpoint: `www.octobridge.co.uk.s3-website.eu-west-2.amazonaws.com`  
      * Routing policy: `Simple`  

### Create SSL Certificate in Certificate Manager

1. General Configuration:  
      * Login to AWS Certificate Manager  
      * Select region `us-east-1`  
      * Click button `Create Certificate`  
2. Request Certificate:  
      * Fully qualified domain name: `octobridge.co.uk`  
      * Add another domain name: `www.octobridge.co.uk`  
      * Allow Export: `Disable`  
      * Validation Method: `DNS`  
      * Key Algorithm: `RSA 2048`  
      * Click button `Request Certificate`  

To ensure the certificate is `Issued` CName records must be created in Route 53.  
This can be done by manually clicking button `Create Records in Route 53` whilst viewing certificate details.  

### Create CloudFront Distribution

The SSL certificate cannot be used diretcly in S3 bucket but must be setup in `CloudFront`.  

1. General Configuration:  
      * Login to AWS CloudFront.  
      * Click button `Create Distribution`  
2. Create CloudFront Distribution:  
      * Distribution Name: `EvaluateJavaScriptDistribution`  
      * Distribution Type: `Single Website`  
      * Origin Type: `Amazon S3`  
      * S3 Origin: `octobridge.co.uk.s3-website.eu-west-2.amazonaws.com`  
      * Origin Settings: `Use recommended`
      * Cache Settings: `Use recommended`
      * Default Root Object: `index.html`
      * Security - Enable WAF: `Disable`  
      * TLS Certificate: Select certificate created in Certificate Manager  
      * Click button `Create Distribution`  

Click button `Route Domains to CloudFront` to ensure the following links will work:  

<https://octobridge.co.uk>  
<https://www.octobridge.co.uk>
