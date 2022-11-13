using TowerDefense.Server.Models.Bridge;

namespace TowerDefense.Server.Models.Towers
{
    public class WaterSingleShotTower : Tower
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
    }
}
