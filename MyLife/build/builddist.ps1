# Remove all contents from dist/
Remove-Item -Path "dist/*" -Recurse -Force -ErrorAction SilentlyContinue

# Ensure dist/ exists
if (!(Test-Path "dist")) {
    New-Item -ItemType Directory -Path "dist" | Out-Null
}

# Copy root folder items
Copy-Item -Path "index.html" -Destination "dist/" -Force
Copy-Item -Path "AboutMe.html" -Destination "dist/" -Force
Copy-Item -Path "articles-data.js" -Destination "dist/" -Force
Copy-Item -Path "layout.js" -Destination "dist/" -Force

# Copy category folders
Copy-Item -Path "MyPet" -Destination "dist/" -Recurse -Force
Copy-Item -Path "MovieReviews" -Destination "dist/" -Recurse -Force
Copy-Item -Path "MyArticle" -Destination "dist/" -Recurse -Force

# Copy images/ folder (includes category subfolders)
Copy-Item -Path "images" -Destination "dist/" -Recurse -Force
