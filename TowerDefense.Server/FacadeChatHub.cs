using Microsoft.AspNetCore.SignalR;
using TowerDefense.Server.Models.Enemies;
using TowerDefense.Server.Services;

namespace TowerDefense.Server
{
    public class FacadeChatHub
    {
        private readonly TowerService towerService;
        private readonly EnemiesService enemiesService;
        public FacadeChatHub(IHubContext<ChatHub> hubContext)
        {
            towerService = new TowerService(hubContext);
            enemiesService = new EnemiesService(hubContext);
        }

        public async Task CreateTower(string towerType, int x, int y, string connectionId)
        {
            await towerService.CreateTower(towerType, x, y, connectionId);
        }

        public async Task NearTower(int enemyIndex, int towerIndex, string connectionId)
        {
            await towerService.NearTower(enemyIndex, towerIndex, connectionId);
        }

        public async Task CreateEnemy(string enemyType, bool aoeResistance, string connectionId)
        {
            await enemiesService.CreateEnemy(enemyType, aoeResistance, connectionId);
        }

        public void EnemyDied(int index, string connectionId)
        {
            enemiesService.EnemyDied(index, connectionId);
        }

        public async Task DrawBulletForEnemy(string actionName, double x1, double x2, double y1, double y2, string connectionId)
        {
            await enemiesService.DrawBulletForEnemy(actionName, x1, x2, y1, y2, connectionId);
        }

        public async Task EnemySurvived(Enemy enemy, int index, string connectionId)
        {
            await enemiesService.EnemySurvived(enemy, index, connectionId);
        }

        public async Task DoubleUpEnemies(string connectionId)
        {
            await enemiesService.DoubleUpEnemies(connectionId);
        }

        public async Task Pause(int index, string connectionId)
        {
            await enemiesService.Pause(index, connectionId);
        }

        public async Task Unpause(int index, string connectionId)
        {
            await enemiesService.Unpause(index, connectionId);
        }
    }
}
