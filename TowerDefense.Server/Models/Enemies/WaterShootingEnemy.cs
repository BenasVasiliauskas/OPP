using TowerDefense.Server.Models.Maps;

namespace TowerDefense.Server.Models.Enemies
{
    public class WaterShootingEnemy : Enemy
    {
        public WaterShootingEnemy()
        {
            ImageSource = "/Images/Enemies/man-with-gun.png";
            Health = 2500;
            Speed = 10;
        }
    }
}
