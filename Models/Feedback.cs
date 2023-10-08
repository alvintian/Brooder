namespace CookAlongAcademy.Models
{
    public class Feedback
    {

        public int FeedbackId { get; set; }

        public string Content { get; set; }

        public DateTime FeedbackDate { get; set; }

        public string UserId { get; set; } // Teacher's Id. Teacher leaves a comment as a feedback

        public int RecipeId { get; set; }

    }
}
