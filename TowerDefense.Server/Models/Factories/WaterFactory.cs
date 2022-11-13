using TowerDefense.Server.Models.Bridge;
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
                return new WaterShootingEnemy();
            }
            else if (type == "H")
            {
                return new WaterHealingEnemy();
            }
            else
            {
                return null;
            }
        }

        public override Tower CreateTower(string type)
        {
            if (type == "S")
            {
                return new WaterSingleShotTower(new FirstEnteredRangeShootingStyle(), true);
            }
            else if (type == "A")
            {
                return new WaterAoeTower(new FirstEnteredRangeShootingStyle());
            }
            else
            {
                return null;
            }
        }
    }
}