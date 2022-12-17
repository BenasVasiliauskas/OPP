using TowerDefense.Server.Models.Enemies;

namespace TowerDefense.Server.Models.Service
{
    public interface IEnemyService
    {
        Enemy CreateEnemy(GameSession session, string enemyType, Player player, Player receiver);
    }
}
