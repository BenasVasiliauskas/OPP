using TowerDefense.Server.Models.Levels;

namespace TowerDefense.Server.Models.Towers
{
    public class AoeTower : Tower
    {
        public AoeTower(ILevel level) : base(level)
        {
            Damage = 1;
        }
    }
}
