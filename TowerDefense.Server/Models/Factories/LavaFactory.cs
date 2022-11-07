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
                return new LavaShootingEnemy(new LavaMap());
            }
            else if(type == "H")
            {
                return new LavaHealingEnemy(new LavaMap());
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
                return new LavaSingleShotTower();
            }
            else if(type == "A")
            {
                return new LavaAoeTower();
            }
            else
            {
                return null;
            }
        }
    }
}
