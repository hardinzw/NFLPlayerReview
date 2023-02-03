namespace NFLPlayerReview.Models
{
    public class NFLPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PositionalRank { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<PlayerPosition> PlayerPositions { get; set; }
        public ICollection<PlayerTeam> PlayerTeams { get; set; }
    }
}
