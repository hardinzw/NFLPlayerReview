﻿namespace NFLPlayerReview.Models
{
    public class NFLDivision
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<NFLTeam>  Teams { get; set; }
    }
}
