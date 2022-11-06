using TowerDefense.Server.Models.Enemies;
using TowerDefense.Server.Models.Maps;
using TowerDefense.Server.Models.Towers;

namespace TowerDefense.Server.Models
{
    public class DesertFactory : AbstractFactory
    {
        public override Unit CreateEnemy(string type)
        {
            if (type == "S")
            {
                return new ShootingEnemy(new DesertMap());
            }
            else if (type == "H")
            {
                return new HealingEnemy(new DesertMap());
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
                return new SingleShotTower();
            }
            else if (type == "A")
            {
                return new AoeTower();
            }
            else
            {
                return null;
            }
        }
    }
}
