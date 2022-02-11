namespace RecipeCardPromoter.Api.Models
{
    public class RecipeCard
    {
        public long Id {get;set;}
        public string RecipeName {get;set;}
        public List<string> Ingredients {get;set;} = new List<string>();
    }
}

