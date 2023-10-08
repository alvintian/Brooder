using CookAlongAcademy.DataAccess;
using CookAlongAcademy.Models;

namespace CookAlongAcademy.Services
{
    public class RecipeService
    {

        private RecipeDAO recipeDao;

        public RecipeService()
        {
            this.recipeDao = new RecipeDAO();
        }

        public Recipe GetRecipe(int recipeId)
        {
            return recipeDao.GetRecipeByID(recipeId);
        }

        public Recipe SearchRecipes(int recipeId)
        {
            return recipeDao.GetRecipeByID(recipeId);
        }

        public bool AddRecipe(Recipe recipe)
        {

            return recipeDao.SaveRecipe(recipe);
        }

    }
}
