using TowerDefense.Server.Models.Bridge;
using TowerDefense.Server.Models.Builder;
using TowerDefense.Server.Models.Enemies;
using TowerDefense.Server.Models.Maps;
using TowerDefense.Server.Models.Towers;

namespace TowerDefense.Server.Models
{
    public class DesertFactory : AbstractFactory
    {
        private Director _director = new();
        public override Unit CreateEnemy(string type)
        {
            if (type == "S")
            {
                var enemyBuilder = new EnemyBuilder<DesertShootingEnemy>();
                _director.ConstructDesertShootingEnemy(enemyBuilder);
                return enemyBuilder.GetEnemy();
            }
            else if (type == "H")
            {
                var enemyBuilder = new EnemyBuilder<DesertHealingEnemy>();
                _director.ConstructDesertHealingEnemy(enemyBuilder);
                return enemyBuilder.GetEnemy();
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
                return new DesertSingleShotTower(new FirstEnteredRangeShootingStyle());
            }
            else if (type == "A")
            {
                return new DesertAoeTower(new FirstEnteredRangeShootingStyle());
            }
            else
            {
                return null;
            }
        }
    }
}
