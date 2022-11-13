using TowerDefense.Server.Models.Towers;

namespace TowerDefense.Server.Models.Bridge
{
    public class HighestEnteredEnemyHealthShootingStyle : IShootingStyle
    {
        public int GetEnemyToShoot(Player player, int towerIndex)
        {
            var maxHealthEnemy = player.Towers[towerIndex].EnemiesInRange.MaxBy(x => x.Health);
            var maxHealthEnemyIndex = player.Towers[towerIndex].EnemiesInRange.IndexOf(maxHealthEnemy);

            return maxHealthEnemyIndex;
        }

        public void SetShootingStyle(Tower tower)
        {
            tower.isHighestHealthStyle = true;
            tower.isFirstStyle = false;
        }
    }
}
