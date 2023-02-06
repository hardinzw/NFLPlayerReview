using NFLPlayerReview.Models;

namespace NFLPlayerReview.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReviewByID(int id);
        ICollection<Review> GetReviewsOfPlayer(int playerID);
        bool ReviewExists(int id);
        bool CreateReview(Review review);
        bool UpdateReview(Review review);
        bool DeleteReview(Review review);
        bool Save();
    }
}
