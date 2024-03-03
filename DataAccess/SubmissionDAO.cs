using Brooder.Models;

namespace Brooder.DataAccess
{
    public class SubmissionDAO
    {

        public Submission getSubmissionById(int submissionID)
        {
            // To get a specific submission object by submissionId
            Submission? submission = null;
            return submission;
        }

        public bool SaveRecipe(Submission submission)
        {
            // Logic to save submission

            bool isSaved = false; // check if the submission is saved successfully
            return isSaved;
        }

        public bool SaveFeedback(Feedback feedback)
        {
            
            // Logic to save feedback (when user is a teacher)

            bool isSaved = false; // check if the submission is saved successfully
            return isSaved;
        }
    }
}
