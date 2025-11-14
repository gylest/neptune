// This file contains the shared HTML for the header and footer,
// and the JavaScript to make them work.

const headerHTML = `
<nav class="container mx-auto px-4 sm:px-6 lg:px-8 py-4">
    <div class="flex items-center justify-between">
        
        <!-- Site Title / Logo -->
        <a href="/" class="text-2xl font-bold text-blue-600">MyLife</a>

        <!-- Desktop Navigation -->
        <div class="hidden md:flex space-x-6">
            <a href="/" class="text-gray-600 hover:text-blue-600 nav-link" data-page="home">Home</a>
            <!-- This link points to the MyPet/ folder, which loads MyPet/index.html -->
            <a href="/MyPet/" class="text-gray-600 hover:text-blue-600 nav-link" data-page="pet">My Pet</a>
            <a href="#" class="text-gray-600 hover:text-blue-600 nav-link" data-page="reviews">Movie Reviews</a>
                <a href="/MyArticle/index.html" class="text-gray-600 hover:text-blue-600 nav-link" data-page="tech">Tech Articles</a>
            <a href="#" class="text-gray-600 hover:text-blue-600 nav-link" data-page="news">News</a>
            <!-- UPDATED: Link now points to the new AboutMe.html page -->
            <a href="/AboutMe.html" class="text-gray-600 hover:text-blue-600 nav-link" data-page="about">About Me</a>
        </div>

        <!-- Mobile Menu Button (Hamburger) -->
        <div class="md:hidden">
            <button id="mobile-menu-button" class="text-gray-700 focus:outline-none">
                <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6h16M4 12h16m-7 6h7"></path>
                </svg>
            </button>
        </div>
    </div>

    <!-- Mobile Menu (Hidden by default) -->
    <div id="mobile-menu" class="hidden md:hidden mt-4">
        <a href="/" class="block px-3 py-2 text-gray-600 hover:bg-gray-100 rounded-md nav-link" data-page="home">Home</a>
        <!-- This link points to the MyPet/ folder, which loads MyPet/index.html -->
        <a href="/MyPet/" class="block px-3 py-2 text-gray-600 hover:bg-gray-100 rounded-md nav-link" data-page="pet">My Pet</a>
        <a href="#" class="block px-3 py-2 text-gray-600 hover:bg-gray-100 rounded-md nav-link" data-page="reviews">Movie Reviews</a>
            <a href="/MyArticle/index.html" class="block px-3 py-2 text-gray-600 hover:bg-gray-100 rounded-md nav-link" data-page="tech">Tech Articles</a>
        <a href="#" class="block px-3 py-2 text-gray-600 hover:bg-gray-100 rounded-md nav-link" data-page="news">News</a>
        <!-- UPDATED: Link now points to the new AboutMe.html page -->
        <a href="/AboutMe.html" class="block px-3 py-2 text-gray-600 hover:bg-gray-100 rounded-md nav-link" data-page="about">About Me</a>
    </div>
</nav>
`;

const footerHTML = `
<div class="container mx-auto px-4 sm:px-6 lg:px-8 text-center text-gray-500">
    <p>&copy; 2025 Tony Gyles. All rights reserved.</p>
</div>
`;

// Function to find the current page and set the active link
function setActiveLink() {
    const navLinks = document.querySelectorAll('.nav-link');
    const currentPath = window.location.pathname;

    let activePage = 'home'; // Default to home

    if (currentPath.includes("/MyPet/")) {
        activePage = 'pet';
    } else if (currentPath.includes("/reviews/")) {
        activeHage = 'reviews';
    } else if (currentPath.includes("/tech/")) {
        activePage = 'tech';
    } else if (currentPath.includes("/news/")) {
        activePage = 'news';
    } else if (currentPath.includes("/about.html")) {
        activePage = 'about';
    }
    
    navLinks.forEach(link => {
        if (link.dataset.page === activePage) {
            link.classList.add('nav-link-active');
        } else {
            link.classList.remove('nav-link-active');
        }
    });
}

// Wait for the DOM to be fully loaded
document.addEventListener('DOMContentLoaded', () => {
    // Inject header and footer
    const header = document.getElementById('main-header');
    const footer = document.getElementById('main-footer');
    
    if (header) {
        header.innerHTML = headerHTML;
    }
    if (footer) {
        footer.innerHTML = footerHTML;
    }

    // Add mobile menu toggle logic
    const mobileMenuButton = document.getElementById('mobile-menu-button');
    const mobileMenu = document.getElementById('mobile-menu');

    if (mobileMenuButton && mobileMenu) {
        mobileMenuButton.addEventListener('click', () => {
            mobileMenu.classList.toggle('hidden');
        });
    }

    // Set the active navigation link
    setActiveLink();
});