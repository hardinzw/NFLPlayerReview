using NFLPlayerReview.Models;

namespace NFLPlayerReview.Interfaces
{
    public interface INFLTeamRepository
    {
        ICollection<NFLTeam> GetNFLTeams();
        NFLTeam GetNFLTeamByID(int id);
        bool NFLTeamExists(int id);
    }
}
