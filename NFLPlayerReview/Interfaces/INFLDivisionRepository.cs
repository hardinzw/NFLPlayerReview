using NFLPlayerReview.Models;

namespace NFLPlayerReview.Interfaces
{
    public interface INFLDivisionRepository
    {
        ICollection<NFLDivision> GetNFLDivisions();
        NFLDivision GetNFLDivisionByID(int id);
        NFLDivision GetNFLDivisionByTeam(int teamID);
        ICollection<NFLTeam> GetNFLTeamByDivision(int divisionID);
        bool NFLDivisionExists(int id);
        bool CreateDivision(NFLDivision division);
        bool UpdateDivision(NFLDivision division);
        bool Save();
    }
}
