namespace Brooder.Models
{
    public class DashboardViewModel
    {
        public ApplicationUser? User { get; set; } 
        public IEnumerable<Recipe>? Recipes { get; set; }
    }
}
