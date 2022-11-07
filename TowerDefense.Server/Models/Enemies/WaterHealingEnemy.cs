using TowerDefense.Server.Models.Maps;

namespace TowerDefense.Server.Models.Enemies
{
    public class WaterHealingEnemy : Enemy, IPrototype
    {
        public WaterHealingEnemy(IMapMoveset mapMoveset) : base(mapMoveset)
        {
            ImageSource = "/Images/Enemies/priest.png";
            Speed = 1;
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
