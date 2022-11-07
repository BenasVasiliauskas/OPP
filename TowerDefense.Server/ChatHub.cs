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

            var player = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId == Context.ConnectionId).SingleOrDefault();
            var receiver = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId != Context.ConnectionId).SingleOrDefault();

            player.Towers.Add(tower);

            await Clients.Caller.SendAsync("TowerBuilt", tower, receiver, Context.ConnectionId, x, y);
            await Clients.Others.SendAsync("TowerBuilt", tower, player, Context.ConnectionId, x, y);
        }

        public async Task CreateEnemy(string enemyType)
        {
            var creator = new LevelCreator();
            AbstractFactory unitFactory = creator.FactoryMethod(_gameSession.CurrentGameLevel).GetAbstractFactory();

            Unit enemy = unitFactory.CreateEnemy(enemyType);

            var player = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId == Context.ConnectionId).SingleOrDefault();
            var receiver = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId != Context.ConnectionId).SingleOrDefault();

            player.Subject.Attach(enemy);

            receiver.Enemies.Add(enemy);

            await Clients.Caller.SendAsync("EnemyCreated", enemy, player, Context.ConnectionId);
            await Clients.Others.SendAsync("EnemyCreated", enemy, receiver, Context.ConnectionId);

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

            await Clients.All.SendAsync("PoweredUp");
        }

        public async Task GameTimerTick()
        {
            var player = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId == Context.ConnectionId).SingleOrDefault();
            var receiver = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId != Context.ConnectionId).SingleOrDefault();

            await Clients.Caller.SendAsync("Ticked", player.Enemies);
            await Clients.Others.SendAsync("Ticked", receiver.Enemies);
        }

        public void EnemyDied(int index)
        {
            var player = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId != Context.ConnectionId).SingleOrDefault();
            player.Enemies.RemoveAt(index);
        }

        public async Task NearTower(int enemyIndex, int towerIndex, string connectionId)
        {
            var player = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId == connectionId).SingleOrDefault();

            //var player = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId == Context.ConnectionId).SingleOrDefault();
            //var receiver = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId != Context.ConnectionId).SingleOrDefault();
            //Console.WriteLine($"{enemyIndex} {towerIndex} {player.Enemies.Count} {player.Towers.Count}");

            if(player.Enemies.Count > 0 && player.Towers.Count > 0)
            {
                player.Enemies[enemyIndex].Health -= (int)player.Towers[towerIndex].Damage;

                if(player.Enemies[enemyIndex].Health <= 0)
                {
                    await Clients.Caller.SendAsync("EnemyDeath", enemyIndex);
                    await Clients.Others.SendAsync("EnemyDeath", enemyIndex);
                }
            }          
        }
    }
}
