using TowerDefense.Server.Models.Maps;

namespace TowerDefense.Server.Models.Enemies
{
    public class HealingEnemy : Enemy
    {
        public HealingEnemy(IMapMoveset mapMoveset) : base(mapMoveset)
        {
            ImageSource = "/Images/Enemies/priest.png";
            Speed = 1;
        }
    }
}
