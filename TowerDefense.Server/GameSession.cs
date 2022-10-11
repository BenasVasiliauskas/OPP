using TowerDefense.Server.Models;

namespace TowerDefense.Server
{
    public class GameSession
    {
        private static GameSession _instance = new GameSession();
        private List<Player> _players;
        private GameSession()
        {
            _players = new List<Player>();
        }

        public static GameSession GetIstance()
        {
            return _instance;
        }

        public bool AddPlayer(Player player)
        {
            _players.Add(player);

            if(_players.Count == 2)
            {
                return true;
            }
            return false;
        }

        public List<string> GetSessionIds()
        {
            return _players.Select(p => p.ConnectionId).ToList();
        }

        public List<Player> GetSessionPlayers()
        {
            return _players;
        }
    }
}
