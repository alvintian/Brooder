﻿using Brooder.DataAccess;
using Brooder.Models;

namespace Brooder.Services
{
    public class FeedbackService
    {
        private SubmissionDAO submissionDao;

        public FeedbackService()
        {
            this.submissionDao = new SubmissionDAO();
        }

        public bool ProvideFeedback(Feedback feedback)
        {
            return submissionDao.SaveFeedback(feedback);
        }

        /*
        public Recipe GetFeedbackForSubmission(int recipeId)
        {
            
        }
        */
    }

}
