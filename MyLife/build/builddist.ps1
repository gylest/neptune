# Remove all contents from dist/
Remove-Item -Path "dist/*" -Recurse -Force -ErrorAction SilentlyContinue

# Ensure dist/ exists
if (!(Test-Path "dist")) {
    New-Item -ItemType Directory -Path "dist" | Out-Null
}

# Copy root folder items
Copy-Item -Path "index.html" -Destination "dist/" -Force
Copy-Item -Path "AboutMe.html" -Destination "dist/" -Force
Copy-Item -Path "layout.js" -Destination "dist/" -Force
Copy-Item -Path "portrait.jpg" -Destination "dist/" -Force

# Copy MyPet/ folder
Copy-Item -Path "MyPet" -Destination "dist/" -Recurse -Force
