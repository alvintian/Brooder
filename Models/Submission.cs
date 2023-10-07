namespace CookAlongAcademy.Models
{
    public class Submission
    {
        public int SubmissionID { get; set; }
        public int UserID { get; set; }
        public int RecipeID { get; set; }
        public string? SubmissionImage { get; set; }  // Consider using a more complex type to handle images
        public string? Notes { get; set; }

        public void AttachImage(string imgPath)  // Adjust parameter type as needed
        {
            // Implement image attachment logic here
        }

        public void AddNotes(string note)
        {
            // Implement notes addition logic here
        }
    }

}
