using RecipeCardPromoter.Api.Contracts;
using RecipeCardPromoter.Api.Models;

namespace RecipeCardPromoter.Api.Services
{
    public class RecipeSearchService : IRecipeSearchService
    {
        private readonly List<RecipeCard> _recipeCards;

        private readonly ILogger<RecipeSearchService> _logger;


        public RecipeSearchService(ILogger<RecipeSearchService> logger)
        {
            _logger = logger;
            _recipeCards = GenerateRecipeCards();
        }

    public IEnumerable<RecipeSearchResult> SearchBasedOnIngredients(string[] ingredients)
    {

        var recipeSearchMatches = new List<RecipeSearchResult>();

        // Check each recipe card against our searched for ingredients
        foreach(RecipeCard recipeCard in _recipeCards)
        {
            // Get a set of overlapping ingredients
            var resultsList = ingredients.ToList().Intersect(recipeCard.Ingredients).ToList();

            if(resultsList.Count()>=0)
                // Add the recipe search result to our matches
                recipeSearchMatches.Add(new RecipeSearchResult()
                {
                    recipeCard = recipeCard,
                    matches = resultsList.Count()
                });

        }
        return recipeSearchMatches;
    }

        private List<RecipeCard> GenerateRecipeCards()
        {
            _logger.LogInformation("Generating recipe cards");

            var cards = new List<RecipeCard>();

            cards.Add(new RecipeCard()
            {
                Id=1,
                RecipeName = "BLT sandwich",
                Ingredients = new List<String> { "bacon", "white bread", "lettuce", "tomatoes", "butter", "mayonnaise","oil"},
            });
            cards.Add(new RecipeCard()
            {
                Id=2,
                RecipeName = "Yankee Rancheros",
                Ingredients = new List<String> { "naan", "cheese", "salsa", "tomatoes", "eggs", "refried beans","oil"},
            });
            cards.Add(new RecipeCard()
            {
                Id=3,
                RecipeName = "Kedgeree",
                Ingredients = new List<String> { "rice", "curry powder", "chicken stock", "smoked haddock", "peas","oil"},
            });
            cards.Add(new RecipeCard()
            {
                Id=4,
                RecipeName = "Saucy eggs",
                Ingredients = new List<String> { "tomatoes", "salad", "spinach", "eggs", "ham", "bread","oil"},
            });
            cards.Add(new RecipeCard()
            {
                Id=5,
                RecipeName = "Kale pasta",
                Ingredients = new List<String> { "onions", "kale", "pasta", "cream cheese", "pesto","oil"},
            });
            

            return cards;
        }
    }
}
