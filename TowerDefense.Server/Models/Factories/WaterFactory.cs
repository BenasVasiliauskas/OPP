using TowerDefense.Server.Models.Enemies;
using TowerDefense.Server.Models.Maps;
using TowerDefense.Server.Models.Towers;

namespace TowerDefense.Server.Models
{
    public class WaterFactory : AbstractFactory
    {
        public override Unit CreateEnemy(string type)
        {
            if (type == "S")
            {
                return new WaterShootingEnemy(new WaterMap());
            }
            else if (type == "H")
            {
                return new WaterHealingEnemy(new WaterMap());
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
                return new WaterSingleShotTower();
            }
            else if (type == "A")
            {
                return new WaterAoeTower();
            }
            else
            {
                return null;
            }
        }
    }
}