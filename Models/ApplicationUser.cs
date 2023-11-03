using Microsoft.AspNetCore.Identity;

namespace CookAlongAcademy.Models
{
    // ApplicationUser class extends IdentityUser to include additional properties.
    public class ApplicationUser : IdentityUser
    {
        // Add additional properties here. For example:
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
