using NFLPlayerReview.Models;

namespace NFLPlayerReview.Interfaces
{
    public interface INFLPlayerRepository
    {
        ICollection<NFLPlayer> GetNFLPlayers();
        NFLPlayer GetNFLPlayerByID(int id);
        NFLPlayer GetNFLPlayerByName(string name);
        string GetNFLPlayerReview(int id);
        bool NFLPlayerExists(int id);
    }
}
