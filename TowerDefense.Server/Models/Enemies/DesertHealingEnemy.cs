using TowerDefense.Server.Models.Maps;

namespace TowerDefense.Server.Models.Enemies
{
    public class DesertHealingEnemy : Enemy, IPrototype
    {
        public DesertHealingEnemy(IMapMoveset mapMoveset) : base(mapMoveset)
        {
        }

        public Enemy MakeDeepCopy()
        {
            Enemy clone = (Enemy) MemberwiseClone();
            clone.Health = MaxHealth / 2;
            return clone;
        }

        public Enemy MakeShallowCopy()
        {
            return (Enemy) MemberwiseClone();
        }
    }
}
