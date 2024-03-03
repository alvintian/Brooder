using System.ComponentModel.DataAnnotations;

namespace Brooder.Models
{
    public class ProfileImageUploadViewModel
    {
        [Required]
        public IFormFile? ProfileImage { get; set; }
    }
}