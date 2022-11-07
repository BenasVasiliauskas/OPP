using Microsoft.AspNetCore.SignalR;
using TowerDefense.Server.Models;
using TowerDefense.Server.Models.Levels;

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
                    ILevel level = creator.FactoryMethod(_gameSession.CurrentGameLevel);
                    var path = level.GetMapMoveset();

                    await Clients.Clients(_gameSession.GetSessionIds()).SendAsync("GameStarted", path);
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

            await Clients.Caller.SendAsync("TowerBuilt", tower, x, y);
        }

        public async Task CreateEnemy(string enemyType)
        {
            var creator = new LevelCreator();
            AbstractFactory unitFactory = creator.FactoryMethod(_gameSession.CurrentGameLevel).GetAbstractFactory();

            Unit enemy = unitFactory.CreateEnemy(enemyType);

            var player = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId == Context.ConnectionId).SingleOrDefault();
            player.Subject.Attach(enemy);

            player.Enemies.Add(enemy);

            await Clients.Others.SendAsync("EnemyCreated", enemy);
        }

        public async Task ChangeLevel()
        {
            _gameSession.ChangeLevel();

            await Clients.All.SendAsync("LevelChanged", _gameSession.CurrentGameLevel);
        }

        public async Task PowerUp()
        {
            var player = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId == Context.ConnectionId).SingleOrDefault();

            player.Subject.IncreasePower();
            await Clients.Others.SendAsync("PoweredUp");
        }

        public async Task GameTimerTick()
        {
            var player = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId == Context.ConnectionId).SingleOrDefault();

            foreach (var enemy in player.Enemies)
            {
                //double moveX = 0;
                //double moveY = 0;
                //var direction = "";

                //var currentInterval = map.Move.Where(map => enemy.X >= map.FromX && enemy.X <= map.ToX && enemy.Y >= map.FromY && enemy.Y <= map.ToY).SingleOrDefault();

                //direction = currentInterval.Direction;

                //switch (direction)
                //{
                //    case "right":
                //        moveX = enemy.Speed;
                //        break;
                //    case "down":
                //        moveY = enemy.Speed;
                //        break;
                //    default:
                //        break;
                //}

                //enemy.X += moveX;
                //enemy.Y += moveY;

            }
            await Clients.Others.SendAsync("Ticked", player);
        }

        public void EnemyDied(int index)
        {
            var player = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId != Context.ConnectionId).SingleOrDefault();
            player.Enemies.RemoveAt(index);
        }
    }
}
