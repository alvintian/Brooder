namespace Brooder.Models
{
    public class EditProfileViewModel
    {
        public string? Name { get; set; }
        public int? Age { get; set; } 
        public string? Bio { get; set; }
        public IFormFile? ProfileImage { get; set; }
        public string? ProfileImagePath { get; set; } // To display the existing image
        public string? BloodType { get; set; } 

        // Add any other properties you need for the profile
    }
}