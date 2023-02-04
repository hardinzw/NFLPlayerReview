using NFLPlayerReview.Data;
using NFLPlayerReview.Interfaces;
using NFLPlayerReview.Models;

namespace NFLPlayerReview.Repository
{
    public class NFLDivisionRepository : INFLDivisionRepository
    {
        private readonly DataContext _context;
        public NFLDivisionRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<NFLDivision> GetNFLDivisions()
        {
            return _context.NFLDivisions.ToList();
        }

        public NFLDivision GetNFLDivisionByID(int id)
        {
            return _context.NFLDivisions.Where(t => t.Id == id).FirstOrDefault();
        }

        public bool NFLDivisionExists(int id)
        {
            return _context.NFLDivisions.Any(t => t.Id == id);
        }
    }
}
