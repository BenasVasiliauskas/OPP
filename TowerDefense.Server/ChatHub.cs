using Microsoft.AspNetCore.SignalR;
using TowerDefense.Server.Models;
using TowerDefense.Server.Models.Levels;
using TowerDefense.Server.Models.Levels.Map;

namespace TowerDefense.Server
{
    public class ChatHub : Hub
    {
        private readonly GameSession _gameSession = GameSession.GetIstance();
        public async Task SendMessage(string message)
        {
            if (!_gameSession.IsGameStarted)
            {
                _gameSession.AddPlayer(new Player
                {
                    ConnectionId = Context.ConnectionId,
                    Username = message
                });

                var sessionUsernames = _gameSession.GetSessionPlayers()
                    .Select(p => p.Username)
                    .ToList();

                await Clients.All.SendAsync("PlayerJoined", sessionUsernames);

                if (_gameSession.IsGameStarted)
                {
                    var creator = new LevelCreator();
                    AbstractFactory abstractFactory = creator.FactoryMethod(_gameSession.CurrentGameLevel).GetAbstractFactory();
                    Map map = abstractFactory.CreateMap();

                    await Clients.Clients(_gameSession.GetSessionIds()).SendAsync("GameStarted", map);
                }
            }
            else
            {
                await Clients.Caller.SendAsync("FullLobby");
            }
        }

        public async Task CreateTower(string towerType, int x, int y)
        {
            var creator = new LevelCreator();
            AbstractFactory unitFactory = creator.FactoryMethod(_gameSession.CurrentGameLevel).GetAbstractFactory();

            Unit tower = unitFactory.CreateTower(towerType);
            tower.Level = null;

            await Clients.Caller.SendAsync("TowerBuilt", tower, x, y);
        }

        public async Task CreateEnemy(string enemyType)
        {
            var creator = new LevelCreator();
            AbstractFactory unitFactory = creator.FactoryMethod(_gameSession.CurrentGameLevel).GetAbstractFactory();

            Unit enemy = unitFactory.CreateEnemy(enemyType);
            enemy.Level = null;

            _gameSession.Subject.Attach(enemy);

            await Clients.Others.SendAsync("EnemyCreated", enemy);
        }

        public async Task ChangeLevel()
        {
            _gameSession.ChangeLevel();

            await Clients.All.SendAsync("LevelChanged", _gameSession.CurrentGameLevel);
        }

        public async Task GameTimerTick()
        {
            await Clients.All.SendAsync("Ticked", _gameSession.GetSessionPlayers()[0]);
        }

        public async Task PowerUp()
        {
            _gameSession.Subject.IncreasePower();
        }
    }
}
