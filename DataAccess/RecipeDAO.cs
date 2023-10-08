using CookAlongAcademy.Models;

namespace CookAlongAcademy.DataAccess
{
    public class RecipeDAO
    {
        public Recipe GetRecipeByID(int recipeID)
        {
            // To get a specific recipe object by recipeId
            Recipe? recipe = null;
            return recipe;
        }

        public bool SaveRecipe(Recipe recipe)
        {
            // Logic to save recipe 

            bool isSaved = false; // check if the recipe is saved successfully
            return isSaved;
        }

        public bool UpdateRecipe(Recipe recipe)
        {
            // Logic to update recipe 

            bool isUpdated = false; // Check if the recipe is updated successfully
            return isUpdated;
        }

        public bool DeleteRecipe(Recipe recipe)
        {
            // Logic to delete recipe

            bool isDelete = false; // Check if the recipe is deleted successfully
            return isDelete; 

        }
    }
}
