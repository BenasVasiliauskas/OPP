using TowerDefense.Server.Models.Towers;

namespace TowerDefense.Server.Models.Bridge
{
    public class FirstEnteredRangeShootingStyle : IShootingStyle
    {
        public int GetEnemyToShoot(Player player, int towerIndex)
        {
            return 0;
        }

        public void SetShootingStyle(Tower tower)
        {
            tower.isFirstStyle = true;
            tower.isHighestHealthStyle = false;
        }
    }
}
