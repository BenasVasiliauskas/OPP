using TowerDefense.Server.Models.Maps;

namespace TowerDefense.Server.Models.Enemies
{
    public class WaterHealingEnemy : Enemy
    {
        public WaterHealingEnemy()
        {
            ImageSource = "/Images/Enemies/priest.png";
            Speed = 10;
            Health = 10;
        }
    }
}
