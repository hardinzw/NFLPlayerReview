namespace NFLPlayerReview.Models
{
    public class NFLTeam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public ICollection<NFLPosition> States { get; set; }
        public ICollection<PlayerTeam> Teams { get; set; }
    }
}
