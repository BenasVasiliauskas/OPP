using TowerDefense.Server.Models.Enemies;
using TowerDefense.Server.Models.Levels.Map;
using TowerDefense.Server.Models.Towers;

namespace TowerDefense.Server.Models
{
    public class DesertFactory : AbstractFactory
    {
        public override Unit CreateEnemy(string type)
        {
            if (type == "S")
            {
                return new ShootingEnemy(new DesertLevel());
            }
            else if (type == "H")
            {
                return new HealingEnemy(new DesertLevel());
            }
            else
            {
                return null;
            }
        }

        public override Unit CreateTower(string type)
        {
            if (type == "S")
            {
                return new SingleShotTower(new DesertLevel());
            }
            else if (type == "A")
            {
                return new AoeTower(new DesertLevel());
            }
            else
            {
                return null;
            }
        }

        public override Map CreateMap()
        {
            throw new NotImplementedException();
        }
    }
}
