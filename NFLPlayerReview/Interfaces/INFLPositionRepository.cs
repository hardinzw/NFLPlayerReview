using NFLPlayerReview.Models;

namespace NFLPlayerReview.Interfaces
{
    public interface INFLPositionRepository
    {
        ICollection<NFLPosition> GetNFLPositions();
        NFLPosition GetNFLPositionByID(int id);
        ICollection<NFLPlayer> GetNFLPlayerByPosition(int positionId);
        bool NFLPositionExists(int id);
    }
}
