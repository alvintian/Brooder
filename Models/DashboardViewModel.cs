namespace CookAlongAcademy.Models
{
    public class DashboardViewModel
    {
        public User? User { get; set; }
        public IEnumerable<Recipe>? Recipes { get; set; }
    }

}
