using Brooder.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

public class ApplicationUser : IdentityUser
{
    // Add new properties to match the user information you want to store
    public string? Name { get; set; }
    public int? Age { get; set; } // It's better to store the date of birth instead of age, as age changes over time
    public string? Bio { get; set; }
    public string? ProfileImagePath { get; set; }
    public BloodType BloodType { get; set; } // Use the BloodType enum here

    // Other properties...
}
