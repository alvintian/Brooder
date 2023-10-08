namespace CookAlongAcademy.Models
{
    public class DashboardViewModel
    {
        public User? User { get; set; }
        public IEnumerable<Recipe>? Recipes { get; set; }   // To show All the recipes in the main page.
    }

}
