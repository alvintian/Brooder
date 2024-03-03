using System.ComponentModel.DataAnnotations;

namespace Brooder.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        // Optional Username
        public string? Username { get; set; }
    }
}
