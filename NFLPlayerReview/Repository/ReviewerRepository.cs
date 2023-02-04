using NFLPlayerReview.Data;
using NFLPlayerReview.Interfaces;
using NFLPlayerReview.Models;

namespace NFLPlayerReview.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly DataContext _context;
        public ReviewerRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _context.Reviewers.ToList();
        }

        public Reviewer GetReviewerByID(int id)
        {
            return _context.Reviewers.Where(r => r.Id == id).FirstOrDefault();
        }

        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            return _context.Reviews.Where(p => p.Reviewer.Id == reviewerId).ToList();
        }

        public bool ReviewerExists(int id)
        {
            return _context.Reviewers.Any(r => r.Id == id);
        }
    }
}
