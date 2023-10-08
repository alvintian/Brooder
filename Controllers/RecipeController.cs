using CookAlongAcademy.Services;
using Microsoft.AspNetCore.Mvc;

namespace CookAlongAcademy.Controllers
{
    public class RecipeController : Controller
    {

        private RecipeService _recipeService;
        public RecipeController(RecipeService recipeService) 
        { 
            _recipeService = recipeService;
        }
        public IActionResult ViewRecipe(int recipeID)
        {
            return View();
        }

        /*
        public IActionResult AddRecipe() 
        { 
        
        }

        public IActionResult UpdateRecipe() 
        {
        
        }
        */
    }
}
