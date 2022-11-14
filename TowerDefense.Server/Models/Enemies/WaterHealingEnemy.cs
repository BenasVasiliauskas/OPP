using TowerDefense.Server.Models.Maps;

namespace TowerDefense.Server.Models.Enemies
{
    public class WaterHealingEnemy : Enemy
    {
        public WaterHealingEnemy()
        {
            Speed = 10;
            SpeedRatio = 0.5;
        }
    }
}
