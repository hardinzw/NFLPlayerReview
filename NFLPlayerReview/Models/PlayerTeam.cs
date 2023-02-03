namespace NFLPlayerReview.Models
{
    public class PlayerTeam
    {
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
        public NFLPlayer Player { get; set; }
        public NFLTeam Team { get; set; }
    }
}
