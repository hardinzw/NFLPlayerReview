using NFLPlayerReview.Models;

namespace NFLPlayerReview.Interfaces
{
    public interface INFLTeamRepository
    {
        ICollection<NFLTeam> GetNFLTeams();
        NFLTeam GetNFLTeamByID(int id);
        ICollection<NFLTeam> GetNFLTeamByPlayer(int playerID);
        ICollection<NFLPlayer> GetNFLPlayerByTeam(int teamID);
        bool NFLTeamExists(int id);
        bool CreateTeam(NFLTeam team);
        bool UpdateTeam(NFLTeam team);
        bool Save();   
    }
}
