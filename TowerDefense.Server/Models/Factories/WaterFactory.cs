using TowerDefense.Server.Models.Bridge;
using TowerDefense.Server.Models.Builder;
using TowerDefense.Server.Models.Enemies;
using TowerDefense.Server.Models.Maps;
using TowerDefense.Server.Models.Towers;

namespace TowerDefense.Server.Models
{
    public class WaterFactory : AbstractFactory
    {
        private Director _director = new();
        public override Unit CreateEnemy(string type)
        {
            if (type == "S")
            {
                var enemyBuilder = new EnemyBuilder<WaterShootingEnemy>();
                _director.ConstructWaterShootingEnemy(enemyBuilder);
                return enemyBuilder.GetEnemy();
            }
            else if (type == "H")
            {
                var enemyBuilder = new EnemyBuilder<WaterHealingEnemy>();
                _director.ConstructWaterHealingEnemy(enemyBuilder);
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