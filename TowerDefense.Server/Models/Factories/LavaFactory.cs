using TowerDefense.Server.Models.Bridge;
using TowerDefense.Server.Models.Enemies;
using TowerDefense.Server.Models.Maps;
using TowerDefense.Server.Models.Towers;

namespace TowerDefense.Server.Models
{
    public class LavaFactory : AbstractFactory
    {
        public override Unit CreateEnemy(string type)
        {
            if (type == "S")
            {
                return new LavaShootingEnemy();
            }
            else if(type == "H")
            {
                return new LavaHealingEnemy();
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
                return new LavaSingleShotTower(new FirstEnteredRangeShootingStyle());
            }
            else if(type == "A")
            {
                return new LavaAoeTower(new FirstEnteredRangeShootingStyle());
            }
            else
            {
                return null;
            }
        }
    }
}
