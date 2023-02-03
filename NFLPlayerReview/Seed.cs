using NFLPlayerReview.Data;
using NFLPlayerReview.Models;

namespace NFLPlayerReview
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.PlayerTeams.Any())
            {
                var playerTeams = new List<PlayerTeam>()
                {
                    new PlayerTeam()
                    {
                        Player = new NFLPlayer()
                        {
                            Name = "Kyler Murray",
                            PositionalRank = 19,
                            PlayerPositions = new List<PlayerPosition>()
                            {
                                new PlayerPosition { Position = new NFLPosition() { Name = "QB"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review() { Title = "2022 Season", Text = "Season ended early due to ACL/MCL tear.", Reviewer = new Reviewer() { FirstName = "Action", LastName = "Jackson" } },
                                new Review() { Title = "2022 Season", Text = "199.52 total (Half-PPR) fantasy points in 2022.", Reviewer = new Reviewer() { FirstName = "Josh", LastName = "McCown" } },
                                new Review() { Title = "2022 Season", Text = "Combined for nearly 2,800 yards in the air and on the ground in 2022.", Reviewer = new Reviewer() { FirstName = "Jim", LastName = "Irsay" } },
                            }
                        },
                        Team = new NFLTeam()
                        {
                            Name = "Cardinals",
                            City = "Arizona",
                            Division = new NFLDivision()
                            {
                                Name = "NFC West"
                            }
                        }
                    },
                    new PlayerTeam()
                    {
                        Player = new NFLPlayer()
                        {
                            Name = "CeeDee Lamb",
                            PositionalRank = 5,
                            PlayerPositions = new List<PlayerPosition>()
                            {
                                new PlayerPosition { Position = new NFLPosition() { Name = "WR"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review() { Title = "2022 Season", Text = "Broke out as a top five wide receiver in 2022.", Reviewer = new Reviewer() { FirstName = "Action", LastName = "Jackson" } },
                                new Review() { Title = "2022 Season", Text = "248 total (Half-PPR) fantasy points in 2022.", Reviewer = new Reviewer() { FirstName = "Josh", LastName = "McCown" } },
                                new Review() { Title = "2022 Season", Text = "107 receptions for 1,359 yards in 2022.", Reviewer = new Reviewer() { FirstName = "Jim", LastName = "Irsay" } },
                            }
                        },
                        Team = new NFLTeam()
                        {
                            Name = "Cowboys",
                            City = "Dallas",
                            Division = new NFLDivision()
                            {
                                Name = "NFC East"
                            }
                        }
                    },
                    new PlayerTeam()
                    {
                        Player = new NFLPlayer()
                        {
                            Name = "Josh Jacobs",
                            PositionalRank = 1,
                            PlayerPositions = new List<PlayerPosition>()
                            {
                                new PlayerPosition { Position = new NFLPosition() { Name = "RB"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review() { Title = "2022 Season", Text = "Took the top spot amongst all running backs in standard scoring formats.", Reviewer = new Reviewer() { FirstName = "Action", LastName = "Jackson" } },
                                new Review() { Title = "2022 Season", Text = "298.80 total (Half-PPR) fantasy points in 2022.", Reviewer = new Reviewer() { FirstName = "Josh", LastName = "McCown" } },
                                new Review() { Title = "2022 Season", Text = "Averaged 4.86 yards per carry for 1,653 rushing yards in 2022.", Reviewer = new Reviewer() { FirstName = "Jim", LastName = "Irsay" } },
                            }
                        },
                        Team = new NFLTeam()
                        {
                            Name = "Raiders",
                            City = "Las Vegas",
                            Division = new NFLDivision()
                            {
                                Name = "AFC West"
                            }
                        }
                    },
                };
                dataContext.PlayerTeams.AddRange(playerTeams);
                dataContext.SaveChanges();
            }
        }
    }
}
