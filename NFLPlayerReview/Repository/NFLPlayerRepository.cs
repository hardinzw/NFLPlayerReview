using NFLPlayerReview.Data;
using NFLPlayerReview.Interfaces;
using NFLPlayerReview.Models;

namespace NFLPlayerReview.Repository
{
    public class NFLPlayerRepository : INFLPlayerRepository
    {
        private readonly DataContext _context;
        public NFLPlayerRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<NFLPlayer> GetNFLPlayers()
        {
            return _context.NFLPlayers.OrderBy(p => p.Id).ToList();
        }

        public NFLPlayer GetNFLPlayerByID(int id)
        {
            return _context.NFLPlayers.Where(p => p.Id == id).FirstOrDefault();
        }
        
        public NFLPlayer GetNFLPlayerByName(string name)
        {
            return _context.NFLPlayers.Where(p => p.Name == name).FirstOrDefault();
        }

        public string GetNFLPlayerReview(int id)
        {
            return _context.Reviews.Where(p => p.Player.Id == id).Select(r => r.Text).ToString();
        }

        public bool NFLPlayerExists(int id)
        {
            return _context.NFLPlayers.Any(p => p.Id == id);
        }
    }
}
