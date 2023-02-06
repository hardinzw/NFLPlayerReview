using Microsoft.EntityFrameworkCore.Diagnostics;
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

        public NFLDivision GetNFLDivisionByTeam(int teamID)
        {
            return _context.NFLTeams.Where(t => t.Id == teamID).Select(d => d.Division).FirstOrDefault();
        }

        public ICollection<NFLTeam> GetNFLTeamByDivision(int divisionID)
        {
            return _context.NFLTeams.Where(d => d.Division.Id == divisionID).ToList();
        }

        public bool NFLDivisionExists(int id)
        {
            return _context.NFLDivisions.Any(t => t.Id == id);
        }

        public bool CreateDivision(NFLDivision division)
        {
            _context.Add(division);
            return Save();
        }

        public bool UpdateDivision(NFLDivision division)
        {
            _context.Update(division);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
