using NFLPlayerReview.Models;

namespace NFLPlayerReview.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReviewByID(int id);
        ICollection<Review> GetReviewsOfPlayer(int playerID);
        bool ReviewExists(int id);
    }
}
