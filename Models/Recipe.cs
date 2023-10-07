namespace CookAlongAcademy.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; }
        public string? Title { get; set; }
        public string? Ingredients { get; set; }  // Consider changing to a List<string> or another structure
        public string? Steps { get; set; }        // Consider changing to a List<string> or another structure
        public int AuthorID { get; set; }        // This assumes you're linking the recipe to the author via an ID

        public void AddIngredient(string ingredient)
        {
            // Implement ingredient addition logic here
        }

        public void AddStep(string step)
        {
            // Implement step addition logic here
        }
    }

}
