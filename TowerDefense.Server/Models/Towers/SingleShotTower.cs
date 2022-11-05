using TowerDefense.Server.Models.Levels;

namespace TowerDefense.Server.Models.Towers
{
    public class SingleShotTower : Tower
    {
        public SingleShotTower(ILevel level) : base(level)
        {
            Damage = 5;
        }
    }
}
