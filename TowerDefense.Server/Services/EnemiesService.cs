using Microsoft.AspNetCore.SignalR;
using TowerDefense.Server.Models.Enemies;
using TowerDefense.Server.Models.Levels;
using TowerDefense.Server.Models;

namespace TowerDefense.Server.Services
{
    public class EnemiesService : Hub
    {
        private readonly GameSession _gameSession = GameSession.GetIstance();
        private readonly IHubContext<ChatHub> _hubContext;

        public EnemiesService(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task CreateEnemy(string enemyType, bool aoeResistance, string connectionId)
        {
            var creator = new LevelCreator();
            AbstractFactory unitFactory = creator.FactoryMethod(_gameSession.CurrentGameLevel).GetAbstractFactory();

            var enemy = unitFactory.CreateEnemy(enemyType);
            enemy.SetUnitStrategy(new Walk(), enemy);

            var player = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId == connectionId).SingleOrDefault();
            var receiver = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId != connectionId).SingleOrDefault();

            player.Subject.Attach(enemy);

            receiver.Enemies.Add(enemy as Enemy);

            await _hubContext.Clients.Client(connectionId).SendAsync("EnemyCreated", enemy, player, connectionId);
            await _hubContext.Clients.AllExcept(connectionId).SendAsync("EnemyCreated", enemy, receiver, connectionId);

        }

        public void EnemyDied(int index, string connectionId)
        {
            var player = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId != connectionId).SingleOrDefault();
            player.Enemies.RemoveAt(index);
        }

        public async Task DrawBulletForEnemy(string actionName, double x1, double x2, double y1, double y2, string connectionId)
        {
            await _hubContext.Clients.AllExcept(connectionId).SendAsync(actionName, x1, x2, y1, y2);
        }

        public async Task EnemySurvived(Enemy enemy, int index, string connectionId)
        {
            var player = _gameSession.GetSessionPlayers()
                .Where(p => p.ConnectionId == connectionId)
                .SingleOrDefault();

            var receiver = _gameSession.GetSessionPlayers()
                .Where(p => p.ConnectionId != connectionId)
                .SingleOrDefault();

            player.Enemies.Remove(enemy);

            await _hubContext.Clients.All.SendAsync("EnemyDeath", index, player.ConnectionId);
        }

        public async Task DoubleUpEnemies(string connectionId)
        {
            var receiver = _gameSession.GetSessionPlayers()
                .Where(p => p.ConnectionId != connectionId)
                .SingleOrDefault();

            var player = _gameSession.GetSessionPlayers()
                .Where(p => p.ConnectionId != connectionId)
                .SingleOrDefault();

            var newEnemies = new List<Enemy>();

            foreach (var enemy in receiver.Enemies)
            {
                newEnemies.Add(enemy);
                newEnemies.Add(enemy.MakeDeepCopy());
            }

            receiver.Enemies = newEnemies;

            await _hubContext.Clients.All.SendAsync("EnemiesDoubled", player);
        }
        public async Task PowerUp(string connectionId)
        {
            var player = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId == connectionId).SingleOrDefault();

            player.Subject.IncreasePower();

            await _hubContext.Clients.All.SendAsync("PoweredUp");
        }

        public async Task Pause(int index, string connectionId)
        {
            var player = _gameSession.GetSessionPlayers()
                .Where(p => p.ConnectionId == connectionId)
                .SingleOrDefault();

            player.Enemies[index].SetUnitStrategy(new SlowWalk(), player.Enemies[index]);


            await _hubContext.Clients.All.SendAsync("Paused", player);
        }

        public async Task Unpause(int index, string connectionId)
        {
            var player = _gameSession.GetSessionPlayers()
                .Where(p => p.ConnectionId == connectionId)
                .SingleOrDefault();

            player.Enemies[index].SetUnitStrategy(new Walk(), player.Enemies[index]);


            await _hubContext.Clients.All.SendAsync("Unpaused", player);
        }
    }
}
