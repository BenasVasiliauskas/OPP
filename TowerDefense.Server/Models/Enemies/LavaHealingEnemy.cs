using TowerDefense.Server.Models.Maps;

namespace TowerDefense.Server.Models.Enemies
{
    public class LavaHealingEnemy : Enemy, IPrototype
    {
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
