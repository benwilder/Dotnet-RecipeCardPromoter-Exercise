using Microsoft.AspNetCore.Mvc;
using RecipeCardPromoter.Api.Models;
using RecipeCardPromoter.Api.Controllers;
using RecipeCardPromoter.Api.Contracts;

namespace RecipeCardPromoter.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeSearchController : ControllerBase
    {
        private readonly ILogger<RecipeSearchController> _logger;
        private readonly IRecipeSearchService _service;
        
        private int _status;

        public RecipeSearchController(ILogger<RecipeSearchController> logger, IRecipeSearchService service)
        {
            _logger = logger;
            _service = service;        
        }

        [HttpGet]
        public ActionResult<IEnumerable<RecipeCard>> Search([FromQuery]string[] ingredients)
        {
            var debugMessage = string.Join(",", ingredients);
            var numItems = ingredients.Count();
            _logger.LogDebug("Search run: {debugMessage}",debugMessage,numItems);
            Console.WriteLine("Search run: {debugMessage}",debugMessage,numItems);

            var items = _service.SearchBasedOnIngredients(ingredients);
            return Ok(items);
        }

    }
}

