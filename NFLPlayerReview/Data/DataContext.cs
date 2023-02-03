using Microsoft.EntityFrameworkCore;
using NFLPlayerReview.Models;

namespace NFLPlayerReview.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<NFLPlayer> NFLPlayers { get; set; }
        public DbSet<NFLTeam> NFLTeams { get; set;}
        public DbSet<NFLDivision> NFLDivisions { get; set; }
        public DbSet<NFLPosition> NFLPositions { get; set; }
        public DbSet<PlayerPosition> PlayerPositions { get; set;}
        public DbSet<PlayerTeam> PlayerTeams { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerPosition>().HasKey(pp => new { pp.PlayerId, pp.PositionId });
            modelBuilder.Entity<PlayerPosition>().HasOne(p => p.Player).WithMany(pp => pp.PlayerPositions).HasForeignKey(x => x.PositionId);
            modelBuilder.Entity<PlayerTeam>().HasKey(pt => new { pt.PlayerId, pt.TeamId });
        }
    }
}
