using TowerDefense.Server.Models.Bridge;

namespace TowerDefense.Server.Models.Towers
{
    public class Tower : Unit
    {
        public IShootingStyle _shootingStyle;
        public bool isFirstStyle { get; set; }
        public bool isHighestHealthStyle { get; set; }
        public Tower(IShootingStyle shootingStyle)
        {
            _shootingStyle = shootingStyle;
        }
        public Tower()
        {

        }

        public override void Update()
        {
            Damage *= 2;
        }

        public void UpgradeTower(Tower tower)
        {
            
        }
    }
}
