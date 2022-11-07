using TowerDefense.Server.Models;

namespace TowerDefense.Server
{
    public class GameSession
    {
        private static GameSession _instance = new GameSession();
        private List<Player> _players;
        private List<string> _levels = new()
        {
            "water", "lava", "desert"
        };

        public bool IsGameStarted { get; set; }
        public string CurrentGameLevel { get; set; }
        private GameSession()
        {
            _players = new List<Player>();
        }

        public static GameSession GetIstance()
        {
            return _instance;
        }

        public void AddPlayer(Player player)
        {
            _players.Add(player);

            if(_players.Count == 2)
            {
                StartGame();
            }
        }

        public List<string> GetSessionIds()
        {
            return _players.Select(p => p.ConnectionId).ToList();
        }

        public List<Player> GetSessionPlayers()
        {
            return _players;
        }

        private void StartGame()
        {
            IsGameStarted = true;
            CurrentGameLevel = _levels[0];
        }

        public void ChangeLevel()
        {
            var index = _levels.IndexOf(CurrentGameLevel);

            if(index == _levels.Count - 1)
            {
                CurrentGameLevel = _levels[0];
            }
            else
            {
                CurrentGameLevel = _levels[index + 1];
            }
        }
    }
}
