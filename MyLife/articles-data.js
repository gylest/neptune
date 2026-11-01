// ============================================================================
// ARTICLES DATA - Single Source of Truth
// ============================================================================
// HOW TO ADD A NEW WEEKLY ARTICLE:
// 1. Copy "article-template.html" into the appropriate category folder
//    (MyPet/, MovieReviews/, or MyArticle/) and write your article content.
// 2. Add a new object to the TOP of the ARTICLES array below.
// 3. The main index.html page and the category's index.html page will
//    automatically update with your new article!
// ============================================================================

const CATEGORIES = {
    pet: {
        id: 'pet',
        name: 'My Pet',
        homeBadgeLabel: 'My Pet',
        folderUrl: '/MyPet/index.html',
        badgeClasses: 'bg-blue-100 text-blue-800 hover:bg-blue-200',
        placeholderColor: '93c5fd'
    },
    reviews: {
        id: 'reviews',
        name: 'Movie Reviews',
        homeBadgeLabel: 'Movie Reviews',
        folderUrl: '/MovieReviews/index.html',
        badgeClasses: 'bg-red-100 text-red-800 hover:bg-red-200',
        placeholderColor: 'fca5a5'
    },
    tech: {
        id: 'tech',
        name: 'Tech Articles',
        homeBadgeLabel: 'Tech Articles',
        folderUrl: '/MyArticle/index.html',
        badgeClasses: 'bg-purple-100 text-purple-800 hover:bg-purple-200',
        placeholderColor: 'a78bfa'
    }
};

// Keep newest articles at the top of each category.
// The first article found for each category is automatically shown on the Home page.
const ARTICLES = [
    // --- FUN FACTS / MY PET ---
    {
        title: '10 Interesting Facts About Shih Tzu',
        homeTitle: 'Fun Facts',
        category: 'pet',
        date: 'Nov 8, 2025',
        summary: '10 Interesting Facts About Shih Tzu — this week, I researched the breed and discovered some fascinating facts...',
        image: 'https://placehold.co/600x400/93c5fd/ffffff?text=Fun+Facts',
        imageAlt: 'Fun Facts',
        url: '/MyPet/MyPetStory1.html'
    },
    {
        title: 'A Day at the Park',
        category: 'pet',
        date: 'Nov 15, 2025',
        summary: 'We had a great time playing fetch and meeting other dogs...',
        image: 'https://placehold.co/600x400/93c5fd/ffffff?text=Day+at+Park',
        imageAlt: 'Day at Park',
        url: '/MyPet/MyPetStory2.html'
    },

    // --- MOVIE REVIEWS ---
    {
        title: 'Review: Predator: Badlands',
        category: 'reviews',
        date: 'Nov 1, 2026',
        summary: 'A bold perspective shift turns a young outcast Yautja and a damaged Weyland-Yutani android into an unlikely sci-fi adventure duo...',
        image: '/images/movie-reviews/pbl_1.jpg',
        imageAlt: 'Movie Review: Predator: Badlands',
        url: '/MovieReviews/PredatorBadlands.html'
    },

    // --- TECH ARTICLES ---
    {
        title: 'Understanding Topological Sort',
        category: 'tech',
        date: 'Nov 1, 2025',
        summary: 'A deep dive into how topological sorting works to order database scripts by dependency...',
        image: 'https://placehold.co/600x400/a78bfa/ffffff?text=Tech+Article',
        imageAlt: 'Tech Article: Understanding Topological Sort',
        url: '/MyArticle/TechArticle1.html'
    }
];
