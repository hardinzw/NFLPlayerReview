using NFLPlayerReview.Models;

namespace NFLPlayerReview.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewerByID(int id);
        ICollection<Review> GetReviewsByReviewer(int reviewerID);
        bool ReviewerExists(int id);
    }
}
