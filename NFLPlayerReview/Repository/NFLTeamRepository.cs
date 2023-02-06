using Microsoft.EntityFrameworkCore.Diagnostics;
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

        public ICollection<NFLTeam> GetNFLTeamByPlayer(int playerID)
        {
            return _context.PlayerTeams.Where(p => p.Player.Id == playerID).Select(t => t.Team).ToList();
        }

        public ICollection<NFLPlayer> GetNFLPlayerByTeam(int teamID)
        {
            return _context.PlayerTeams.Where(t => t.Team.Id == teamID).Select(p => p.Player).ToList();
        }

        public bool NFLTeamExists(int id)
        {
            return _context.NFLTeams.Any(t => t.Id == id);
        }

        public bool CreateTeam(NFLTeam team)
        {
            _context.Add(team);
            return Save();
        }

        public bool UpdateTeam(NFLTeam team)
        {
            _context.Update(team);
            return Save();
        }

        public bool DeleteTeam(NFLTeam team)
        {
            _context.Remove(team);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
