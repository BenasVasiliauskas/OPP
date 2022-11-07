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
                return new DesertShootingEnemy(new DesertMap());
            }
            else if (type == "H")
            {
                return new DesertHealingEnemy(new DesertMap());
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
                return new DesertSingleShotTower();
            }
            else if (type == "A")
            {
                return new DesertAoeTower();
            }
            else
            {
                return null;
            }
        }
    }
}
