// ============================================================================
// SHARED LAYOUT, NAVIGATION & ARTICLE RENDERING
// ============================================================================

const NAV_ITEMS = [
    { label: 'Home', href: '/index.html', page: 'home' },
    { label: 'My Pet', href: '/MyPet/index.html', page: 'pet' },
    { label: 'Movie Reviews', href: '/MovieReviews/index.html', page: 'reviews' },
    { label: 'Tech Articles', href: '/MyArticle/index.html', page: 'tech' },
    { label: 'About Me', href: '/AboutMe.html', page: 'about' }
];

function buildHeaderHTML() {
    const desktopLinks = NAV_ITEMS.map(item =>
        `<a href="${item.href}" class="text-gray-600 hover:text-blue-600 nav-link transition-colors" data-page="${item.page}">${item.label}</a>`
    ).join('\n            ');

    const mobileLinks = NAV_ITEMS.map(item =>
        `<a href="${item.href}" class="block px-3 py-2 text-gray-600 hover:bg-gray-100 rounded-md nav-link" data-page="${item.page}">${item.label}</a>`
    ).join('\n        ');

    return `
<nav class="container mx-auto px-4 sm:px-6 lg:px-8 py-4">
    <div class="flex items-center justify-between">
        <!-- Site Title / Logo -->
        <a href="/index.html" class="flex items-center space-x-2 text-2xl font-bold text-blue-600">
            <img src="/images/logo.svg" alt="MyLife Logo" class="h-20 w-20">
            <span>MyLife</span>
        </a>

        <!-- Desktop Navigation -->
        <div class="hidden md:flex space-x-6">
            ${desktopLinks}
        </div>

        <!-- Mobile Menu Button (Hamburger) -->
        <div class="md:hidden">
            <button id="mobile-menu-button" class="text-gray-700 focus:outline-none" aria-label="Toggle Menu">
                <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6h16M4 12h16m-7 6h7"></path>
                </svg>
            </button>
        </div>
    </div>

    <!-- Mobile Menu (Hidden by default) -->
    <div id="mobile-menu" class="hidden md:hidden mt-4">
        ${mobileLinks}
    </div>
</nav>
`;
}

const footerHTML = `
<div class="container mx-auto px-4 sm:px-6 lg:px-8 text-center text-gray-500 space-y-2">
    <div class="flex justify-center flex-wrap gap-6 text-sm mb-2">
        ${NAV_ITEMS.map(item => `<a href="${item.href}" class="hover:text-blue-600 transition-colors">${item.label}</a>`).join('')}
    </div>
    <p>&copy; 2026 Tony Gyles. All rights reserved.</p>
</div>
`;

// Determine active navigation section from current URL path
function setActiveLink() {
    const navLinks = document.querySelectorAll('.nav-link');
    const currentPath = window.location.pathname.toLowerCase();

    let activePage = 'home';

    if (currentPath.includes('/mypet/')) {
        activePage = 'pet';
    } else if (currentPath.includes('/moviereviews/')) {
        activePage = 'reviews';
    } else if (currentPath.includes('/myarticle/')) {
        activePage = 'tech';
    } else if (currentPath.includes('/aboutme.html')) {
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

// Render a single article card
function createArticleCardHTML(article, isHomePage = false) {
    const categoryInfo = (typeof CATEGORIES !== 'undefined' && CATEGORIES[article.category]) || {
        name: article.category,
        homeBadgeLabel: article.category,
        folderUrl: '#',
        badgeClasses: 'bg-blue-100 text-blue-800 hover:bg-blue-200'
    };

    const badgeContent = isHomePage
        ? `<a href="${categoryInfo.folderUrl}" class="inline-block ${categoryInfo.badgeClasses} text-xs font-semibold px-2.5 py-0.5 rounded-full mb-2 transition-colors">${categoryInfo.homeBadgeLabel}</a>`
        : `<span class="inline-block ${categoryInfo.badgeClasses} text-xs font-semibold px-2.5 py-0.5 rounded-full mb-2">${article.date}</span>`;

    const displayTitle = (isHomePage && article.homeTitle) ? article.homeTitle : article.title;

    return `
    <div class="bg-white rounded-lg shadow-md overflow-hidden transition-shadow duration-300 hover:shadow-xl flex flex-col justify-between">
        <div>
            <a href="${article.url}">
                <img src="${article.image}" alt="${article.imageAlt || article.title}" class="w-full h-48 object-cover">
            </a>
            <div class="p-6">
                <div class="flex items-center justify-between mb-2">
                    ${badgeContent}
                    ${isHomePage && article.date ? `<span class="text-xs text-gray-400">${article.date}</span>` : ''}
                </div>
                <h3 class="text-xl font-bold mb-2">
                    <a href="${article.url}" class="hover:text-blue-600 transition-colors">${displayTitle}</a>
                </h3>
                <p class="text-gray-600 mb-4">${article.summary}</p>
            </div>
        </div>
        <div class="px-6 pb-6 pt-0">
            <a href="${article.url}" class="text-blue-600 font-semibold hover:underline">Read More &rarr;</a>
        </div>
    </div>
    `;
}

// Populate Home Page "Recent Posts" (latest post from each category)
function renderHomeRecentPosts() {
    const container = document.getElementById('home-recent-posts');
    if (!container || typeof ARTICLES === 'undefined' || typeof CATEGORIES === 'undefined') return;

    const categoryOrder = ['pet', 'reviews', 'tech'];
    const featuredArticles = categoryOrder
        .map(catId => ARTICLES.find(a => a.category === catId))
        .filter(Boolean);

    container.innerHTML = featuredArticles
        .map(article => createArticleCardHTML(article, true))
        .join('');
}

// Populate Category Listing Page Grid
function renderCategoryListing() {
    const container = document.getElementById('category-articles-grid');
    if (!container || typeof ARTICLES === 'undefined') return;

    const categoryId = container.dataset.category;
    const categoryArticles = ARTICLES.filter(a => a.category === categoryId);

    if (categoryArticles.length === 0) {
        container.innerHTML = `<p class="text-gray-500 col-span-full">No articles published in this category yet. Check back soon!</p>`;
        return;
    }

    container.innerHTML = categoryArticles
        .map(article => createArticleCardHTML(article, false))
        .join('');
}

// Inject Breadcrumb & Prev/Next links on individual article pages
function renderArticleNavigation() {
    if (typeof ARTICLES === 'undefined' || typeof CATEGORIES === 'undefined') return;

    const currentPath = window.location.pathname.toLowerCase();
    const currentArticle = ARTICLES.find(a => currentPath.endsWith(a.url.toLowerCase()));
    if (!currentArticle) return;

    const categoryInfo = CATEGORIES[currentArticle.category];
    if (!categoryInfo) return;

    const categoryArticles = ARTICLES.filter(a => a.category === currentArticle.category);
    const currentIndex = categoryArticles.findIndex(a => a.url === currentArticle.url);

    // Next/Prev within the same category
    const newerArticle = currentIndex > 0 ? categoryArticles[currentIndex - 1] : null;
    const olderArticle = currentIndex < categoryArticles.length - 1 ? categoryArticles[currentIndex + 1] : null;

    const mainContent = document.querySelector('main');
    if (!mainContent) return;

    // 1. Top Breadcrumb Navigation
    if (!document.getElementById('article-breadcrumb')) {
        const breadcrumb = document.createElement('nav');
        breadcrumb.id = 'article-breadcrumb';
        breadcrumb.setAttribute('aria-label', 'Breadcrumb');
        breadcrumb.className = 'mb-6 flex flex-wrap items-center justify-between text-sm text-gray-600 bg-white px-4 py-3 rounded-lg shadow-sm';
        breadcrumb.innerHTML = `
            <div class="flex items-center space-x-2">
                <a href="/index.html" class="hover:text-blue-600 transition-colors">Home</a>
                <span>/</span>
                <a href="${categoryInfo.folderUrl}" class="hover:text-blue-600 transition-colors">${categoryInfo.name}</a>
                <span>/</span>
                <span class="text-gray-900 font-medium truncate max-w-xs sm:max-w-md">${currentArticle.title}</span>
            </div>
            <a href="${categoryInfo.folderUrl}" class="text-blue-600 font-medium hover:underline mt-2 sm:mt-0">&larr; Back to ${categoryInfo.name}</a>
        `;
        mainContent.insertBefore(breadcrumb, mainContent.firstChild);
    }

    // 2. Bottom Prev/Next Navigation
    if (!document.getElementById('article-prev-next')) {
        const bottomNav = document.createElement('div');
        bottomNav.id = 'article-prev-next';
        bottomNav.className = 'mt-8 bg-white p-6 rounded-lg shadow-md flex flex-col sm:flex-row items-center justify-between gap-4 border-t border-gray-100';

        const prevHTML = olderArticle
            ? `<a href="${olderArticle.url}" class="text-left group">
                   <span class="block text-xs text-gray-400 uppercase tracking-wider">&larr; Older in ${categoryInfo.name}</span>
                   <span class="text-blue-600 font-semibold group-hover:underline">${olderArticle.title}</span>
               </a>`
            : `<div></div>`;

        const nextHTML = newerArticle
            ? `<a href="${newerArticle.url}" class="text-right group">
                   <span class="block text-xs text-gray-400 uppercase tracking-wider">Newer in ${categoryInfo.name} &rarr;</span>
                   <span class="text-blue-600 font-semibold group-hover:underline">${newerArticle.title}</span>
               </a>`
            : `<div></div>`;

        bottomNav.innerHTML = `
            ${prevHTML}
            <a href="${categoryInfo.folderUrl}" class="px-4 py-2 bg-gray-100 hover:bg-gray-200 text-gray-700 rounded-md text-sm font-medium transition-colors">
                All ${categoryInfo.name}
            </a>
            ${nextHTML}
        `;
        mainContent.appendChild(bottomNav);
    }
}

// Initialize layout when DOM is ready
document.addEventListener('DOMContentLoaded', () => {
    const header = document.getElementById('main-header');
    const footer = document.getElementById('main-footer');

    if (header) {
        header.innerHTML = buildHeaderHTML();
    }
    if (footer) {
        footer.innerHTML = footerHTML;
    }

    // Mobile menu toggle
    const mobileMenuButton = document.getElementById('mobile-menu-button');
    const mobileMenu = document.getElementById('mobile-menu');

    if (mobileMenuButton && mobileMenu) {
        mobileMenuButton.addEventListener('click', () => {
            mobileMenu.classList.toggle('hidden');
        });
    }

    setActiveLink();
    renderHomeRecentPosts();
    renderCategoryListing();
    renderArticleNavigation();
});
