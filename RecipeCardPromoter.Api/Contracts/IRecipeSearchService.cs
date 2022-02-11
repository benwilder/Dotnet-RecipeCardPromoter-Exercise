using RecipeCardPromoter.Api.Models;

namespace RecipeCardPromoter.Api.Contracts
{
    public interface IRecipeSearchService
    {
        IEnumerable<RecipeSearchResult> SearchBasedOnIngredients(string[] ingredients);
    }
}



