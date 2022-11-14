using TowerDefense.Server.Models.Levels;
using TowerDefense.Server.Models.Towers;
using TowerDefense.Server.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authentication;

namespace TowerDefense.Server.Services
{
    public class TowerService : Hub
    {
        private readonly GameSession _gameSession = GameSession.GetIstance();
        private readonly IHubContext<ChatHub> _hubContext;

        public TowerService(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task CreateTower(string towerType, int x, int y, string connectionId)
        {
            var creator = new LevelCreator();
            AbstractFactory unitFactory = creator.FactoryMethod(_gameSession.CurrentGameLevel).GetAbstractFactory();

            Unit tower = unitFactory.CreateTower(towerType);

            var test = tower as Tower;
            test._shootingStyle = null;

            var player = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId == connectionId).SingleOrDefault();
            var receiver = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId != connectionId).SingleOrDefault();

            player.Towers.Add(test);
            
            await _hubContext.Clients.Client(connectionId).SendAsync("TowerBuilt", tower, receiver, connectionId, x, y);

            await _hubContext.Clients.AllExcept(connectionId).SendAsync("TowerBuilt", tower, player, connectionId, x, y);
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
                    await _hubContext.Clients.All.SendAsync("EnemyDeath", enemyIndex, player.ConnectionId);
                }
            }
        }

    }
}
