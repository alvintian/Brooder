using System.Collections.Generic;

namespace CookAlongAcademy.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; }
        public string? Title { get; set; }
        public List<string>? Ingredients { get; set; } = new List<string>();
        public List<string>? Steps { get; set; } = new List<string>();
        public int AuthorID { get; set; } // Assuming you're linking the recipe to the author via an ID
    }
}
