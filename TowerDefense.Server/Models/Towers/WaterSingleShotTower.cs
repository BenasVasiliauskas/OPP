using TowerDefense.Server.Models.Bridge;
using TowerDefense.Server.Models.Enemies;
using TowerDefense.Server.Models.Visitor;

namespace TowerDefense.Server.Models.Towers
{
    public class WaterSingleShotTower : Tower, IVisitor
    {
        //public WaterSingleShotTower(IShootingStyle shootingStyle) : base(shootingStyle)
        //{
        //    Damage = 10;
        //    shootingStyle.SetFlag(this);
        //}

        public WaterSingleShotTower(IShootingStyle shootingStyle, bool isFirstShooting) : base(shootingStyle) 
        {
            shootingStyle.SetShootingStyle(this);
            Damage = 10;
        }

        public void VisitEnemy(Enemy enemy)
        {
            enemy.SetUnitStrategy(new SlowWalk(), enemy);
        }
    }
}
