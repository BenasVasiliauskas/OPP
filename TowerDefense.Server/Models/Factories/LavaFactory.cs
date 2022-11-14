using TowerDefense.Server.Models.Bridge;
using TowerDefense.Server.Models.Builder;
using TowerDefense.Server.Models.Enemies;
using TowerDefense.Server.Models.Maps;
using TowerDefense.Server.Models.Towers;

namespace TowerDefense.Server.Models
{
    public class LavaFactory : AbstractFactory
    {
        private Director _director = new();
        public override Unit CreateEnemy(string type)
        {
            if (type == "S")
            {
                var enemyBuilder = new EnemyBuilder<LavaShootingEnemy>();
                _director.ConstructLavaShootingEnemy(enemyBuilder);
                return enemyBuilder.GetEnemy();
            }
            else if(type == "H")
            {
                var enemyBuilder = new EnemyBuilder<LavaHealingEnemy>();
                _director.ConstructLavaHealingEnemy(enemyBuilder);
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
