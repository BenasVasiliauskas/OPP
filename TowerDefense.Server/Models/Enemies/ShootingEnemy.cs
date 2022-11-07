using TowerDefense.Server.Models.Maps;

namespace TowerDefense.Server.Models.Enemies
{
    public class ShootingEnemy : Enemy
    {
        public ShootingEnemy(IMapMoveset mapMoveset) : base(mapMoveset)
        {
            ImageSource = "/Images/Enemies/man-with-gun.png";
            Health = 100;
            Speed = 10;
        }
    }
}
