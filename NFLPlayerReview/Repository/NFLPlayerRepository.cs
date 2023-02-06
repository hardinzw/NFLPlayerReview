using NFLPlayerReview.Data;
using NFLPlayerReview.Interfaces;
using NFLPlayerReview.Models;

namespace NFLPlayerReview.Repository
{
    public class NFLPlayerRepository : INFLPlayerRepository
    {
        private readonly DataContext _context;
        public NFLPlayerRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<NFLPlayer> GetNFLPlayers()
        {
            return _context.NFLPlayers.OrderBy(p => p.Id).ToList();
        }

        public NFLPlayer GetNFLPlayerByID(int id)
        {
            return _context.NFLPlayers.Where(p => p.Id == id).FirstOrDefault();
        }
        
        public NFLPlayer GetNFLPlayerByName(string name)
        {
            return _context.NFLPlayers.Where(p => p.Name == name).FirstOrDefault();
        }

        public string GetNFLPlayerReview(int id)
        {
            return _context.Reviews.Where(p => p.Player.Id == id).Select(r => r.Text).ToString();
        }

        public bool NFLPlayerExists(int id)
        {
            return _context.NFLPlayers.Any(p => p.Id == id);
        }

        public bool CreatePlayer(int teamID, int positionID, NFLPlayer player)
        {
            var playerTeamEntity = _context.NFLTeams.Where(t => t.Id == teamID).FirstOrDefault();
            var playerPositionEntity = _context.NFLPositions.Where(p => p.Id == positionID).FirstOrDefault();
            var playerTeam = new PlayerTeam()
            {
                Team = playerTeamEntity,
                Player = player
            };

            _context.Add(playerTeam);

            var playerPosition = new PlayerPosition()
            {
                Position = playerPositionEntity,
                Player = player
            };

            _context.Add(playerPosition);

            _context.Add(player);

            return Save();
        }

        public bool UpdatePlayer(int teamID, int positionID, NFLPlayer player)
        {
            _context.Update(player);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
