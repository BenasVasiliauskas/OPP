using TowerDefense.Server.Models.Levels;

namespace TowerDefense.Server.Models.Enemies
{
    public class ShootingEnemy : Enemy
    {
        public ShootingEnemy(ILevel level) : base(level)
        {
            ImageSource = "/Images/Enemies/man-with-gun.png";
            Health = 100;
        }
    }
}
