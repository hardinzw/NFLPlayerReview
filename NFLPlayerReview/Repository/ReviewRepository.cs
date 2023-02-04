using NFLPlayerReview.Data;
using NFLPlayerReview.Interfaces;
using NFLPlayerReview.Models;

namespace NFLPlayerReview.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;
        public ReviewRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public Review GetReviewByID(int id)
        {
            return _context.Reviews.Where(r => r.Id == id).FirstOrDefault();
        }

        public ICollection<Review> GetReviewsOfPlayer(int playerId)
        {
            return _context.Reviews.Where(p => p.Player.Id == playerId).ToList();
        }

        public bool ReviewExists(int id)
        {
            return _context.Reviews.Any(r => r.Id == id);
        }
    }
}
