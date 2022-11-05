using TowerDefense.Server.Models.Enemies;
using TowerDefense.Server.Models.Levels;
using TowerDefense.Server.Models.Levels.Map;
using TowerDefense.Server.Models.Towers;

namespace TowerDefense.Server.Models
{
    public class WaterFactory : AbstractFactory
    {
        public override Unit CreateEnemy(string type)
        {
            if (type == "S")
            {
                return new ShootingEnemy(new WaterLevel());
            }
            else if (type == "H")
            {
                return new HealingEnemy(new WaterLevel());
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
                return new SingleShotTower(new WaterLevel());
            }
            else if (type == "A")
            {
                return new AoeTower(new WaterLevel());
            }
            else
            {
                return null;
            }
        }

        public override Map CreateMap()
        {
            return new WaterMap();
        }
    }
}