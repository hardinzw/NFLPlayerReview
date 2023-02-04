using NFLPlayerReview.Data;
using NFLPlayerReview.Interfaces;
using NFLPlayerReview.Models;
using SQLitePCL;

namespace NFLPlayerReview.Repository
{
    public class NFLTeamRepository : INFLTeamRepository
    {
        private readonly DataContext _context;
        public NFLTeamRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<NFLTeam> GetNFLTeams()
        {
            return _context.NFLTeams.OrderBy(t => t.Id).ToList();
        }

        public NFLTeam GetNFLTeamByID(int id)
        {
            return _context.NFLTeams.Where(t => t.Id == id).FirstOrDefault();
        }

        public NFLTeam GetNFLTeamByName(string name)
        {
            return _context.NFLTeams.Where(t => t.Name == name).FirstOrDefault();
        }

        public bool NFLTeamExists(int id)
        {
            return _context.NFLTeams.Any(t => t.Id == id);
        }
    }
}
