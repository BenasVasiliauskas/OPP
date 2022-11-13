using TowerDefense.Server.Models.Maps;

namespace TowerDefense.Server.Models.Enemies
{
    public class WaterHealingEnemy : Enemy
    {
        public WaterHealingEnemy()
        {
            ImageSource = "/Images/Enemies/priest.png";
            Speed = 1;
            Health = 10;
        }
    }
}
