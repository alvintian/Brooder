namespace CookAlongAcademy.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public void ChangePassword(string newPassword)
        {
            // Implement password change logic here
        }

        public void UpdateEmail(string newEmail)
        {
            // Implement email update logic here
        }
    }

}
