namespace NFLPlayerReview.Models
{
    public class NFLPosition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PlayerPosition> Positions { get; set; }
    }
}
