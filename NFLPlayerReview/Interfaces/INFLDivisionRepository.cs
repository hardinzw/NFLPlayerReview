using NFLPlayerReview.Models;

namespace NFLPlayerReview.Interfaces
{
    public interface INFLDivisionRepository
    {
        ICollection<NFLDivision> GetNFLDivisions();
        NFLDivision GetNFLDivisionByID(int id);
        bool NFLDivisionExists(int id);
    }
}
