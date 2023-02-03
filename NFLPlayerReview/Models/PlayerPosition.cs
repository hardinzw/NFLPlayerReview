namespace NFLPlayerReview.Models
{
    public class PlayerPosition
    {
        public int PlayerId { get; set; }
        public int PositionId { get; set; }
        public NFLPlayer Player { get; set; }
        public NFLPosition Position { get; set; }
    }
}
