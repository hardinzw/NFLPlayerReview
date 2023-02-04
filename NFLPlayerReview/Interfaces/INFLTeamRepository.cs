using NFLPlayerReview.Models;

namespace NFLPlayerReview.Interfaces
{
    public interface INFLTeamRepository
    {
        ICollection<NFLTeam> GetNFLTeams();
        NFLTeam GetNFLTeamByID(int id);
        NFLTeam GetNFLTeamByName(string name);
        bool NFLTeamExists(int id);
    }
}
