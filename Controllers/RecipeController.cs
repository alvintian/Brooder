using CookAlongAcademy.Models;
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

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Process the file as needed for your application

                return RedirectToAction("RecipeList");
            }

            return View("RecipeList", await GetRecipesAsync());
        }

        // Implement this method according to your data access logic
        private async Task<IEnumerable<Recipe>> GetRecipesAsync()
        {
            // Your logic to fetch recipes
            // Example:
            // return await _recipeService.GetAllRecipesAsync();
            return new List<Recipe>(); // Placeholder

            /*
            public IActionResult UpdateRecipe() 
            {

            }
            */
        }
    }
    }
