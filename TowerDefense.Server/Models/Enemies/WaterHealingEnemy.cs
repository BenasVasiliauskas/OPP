using TowerDefense.Server.Models.Maps;

namespace TowerDefense.Server.Models.Enemies
{
    public class WaterHealingEnemy : Enemy, IPrototype
    {
        public WaterHealingEnemy()
        {
            ImageSource = "/Images/Enemies/priest.png";
            Speed = 1;
            Health = 500;
        }

        public Enemy MakeDeepCopy()
        {
            throw new NotImplementedException();
        }

        public Enemy MakeShallowCopy()
        {
            throw new NotImplementedException();
        }
    }
}
