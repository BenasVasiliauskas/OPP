using Microsoft.AspNetCore.SignalR;
using TowerDefense.Server.Models;
using TowerDefense.Server.Models.Enemies;
using TowerDefense.Server.Models.Levels;
using TowerDefense.Server.Models.Towers;

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
                    var tile = level.GetPath();

                    await Clients.Clients(_gameSession.GetSessionIds()).SendAsync("GameStarted", path, tile);
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

            var test = tower as Tower;
            test._shootingStyle = null;
            
            var player = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId == Context.ConnectionId).SingleOrDefault();
            var receiver = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId != Context.ConnectionId).SingleOrDefault();

            player.Towers.Add(test);

            await Clients.Caller.SendAsync("TowerBuilt", tower, receiver, Context.ConnectionId, x, y);
            await Clients.Others.SendAsync("TowerBuilt", tower, player, Context.ConnectionId, x, y);
        }

        public async Task CreateEnemy(string enemyType, bool aoeResistance)
        {
            var creator = new LevelCreator();
            AbstractFactory unitFactory = creator.FactoryMethod(_gameSession.CurrentGameLevel).GetAbstractFactory();

            var enemy = unitFactory.CreateEnemy(enemyType);
            enemy.SetUnitStrategy(new Walk(), enemy);

            var player = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId == Context.ConnectionId).SingleOrDefault();
            var receiver = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId != Context.ConnectionId).SingleOrDefault();

            player.Subject.Attach(enemy);

            receiver.Enemies.Add(enemy as Enemy);

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

            await Clients.Caller.SendAsync("Ticked", player.Enemies, player.Towers, player, Context.ConnectionId);
            await Clients.Others.SendAsync("Ticked", receiver.Enemies, receiver.Towers, receiver, Context.ConnectionId);
        }

        public void EnemyDied(int index)
        {
            var player = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId != Context.ConnectionId).SingleOrDefault();
            player.Enemies.RemoveAt(index);
        }

        public async Task NearTower(int enemyIndex, int towerIndex, string connectionId)
        {
            var player = _gameSession.GetSessionPlayers()
                .Where(p => p.ConnectionId == connectionId)
                .SingleOrDefault();

            if (player.Enemies.Count > 0 && player.Towers.Count > 0)
            {
                player.Enemies[enemyIndex].Health -= (int)player.Towers[towerIndex].Damage;

                if (player.Enemies[enemyIndex].Health <= 0)
                {
                    player.Enemies.RemoveAt(enemyIndex);
                    await Clients.All.SendAsync("EnemyDeath", enemyIndex, player.ConnectionId);
                }
            }
        }

        public async Task DrawBulletForEnemy(double x1, double x2, double y1, double y2)
        {
            await Clients.Others.SendAsync("DrawBullet", x1, x2, y1, y2);
        }

        public async Task EnemySurvived(Enemy enemy, int index)
        {
            var player = _gameSession.GetSessionPlayers()
                .Where(p => p.ConnectionId == Context.ConnectionId)
                .SingleOrDefault();

            var receiver = _gameSession.GetSessionPlayers()
                .Where(p => p.ConnectionId != Context.ConnectionId)
                .SingleOrDefault();

            player.Enemies.Remove(enemy);

            await Clients.All.SendAsync("EnemyDeath", index, player.ConnectionId);
        }

        public async Task DoubleUpEnemies()
        {
            var receiver = _gameSession.GetSessionPlayers()
                .Where(p => p.ConnectionId != Context.ConnectionId)
                .SingleOrDefault();

            var player = _gameSession.GetSessionPlayers()
                .Where(p => p.ConnectionId != Context.ConnectionId)
                .SingleOrDefault();

            var newEnemies = new List<Enemy>();

            foreach (var enemy in receiver.Enemies)
            {
                newEnemies.Add(enemy);
                newEnemies.Add(enemy.MakeDeepCopy());
            }

            receiver.Enemies = newEnemies;

            await Clients.All.SendAsync("EnemiesDoubled", player);
        }

        public async Task Pause(int index)
        {
            var player = _gameSession.GetSessionPlayers()
                .Where(p => p.ConnectionId == Context.ConnectionId)
                .SingleOrDefault();

            player.Enemies[index].SetUnitStrategy(new SlowWalk(), player.Enemies[index]);


            await Clients.All.SendAsync("Paused", player);
        }

        public async Task Unpause(int index)
        {
            var player = _gameSession.GetSessionPlayers()
                .Where(p => p.ConnectionId == Context.ConnectionId)
                .SingleOrDefault();

            player.Enemies[index].SetUnitStrategy(new Walk(), player.Enemies[index]);


            await Clients.All.SendAsync("Unpaused", player);
        }
    }
}
