using TowerDefense.Server.Models.Towers;

namespace TowerDefense.Server.Models.Bridge
{
    public interface IShootingStyle
    {
        public int GetEnemyToShoot(Player player, int towerIndex);
        public void SetShootingStyle(Tower tower);
    }
}
