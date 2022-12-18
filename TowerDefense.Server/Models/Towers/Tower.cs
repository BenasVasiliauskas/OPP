using TowerDefense.Server.Models.Bridge;
using TowerDefense.Server.Models.Strategies;

namespace TowerDefense.Server.Models.Towers
{
    public class Tower : Unit, IUnitTemplate
    {
        public IShootingStyle _shootingStyle;
        public bool isFirstStyle { get; set; }
        public bool isHighestHealthStyle { get; set; }
        public Tower(IShootingStyle shootingStyle)
        {
            _shootingStyle = shootingStyle;
        }
        public Tower() { }

        public override void Update()
        {
            Damage *= 2;
        }

        public void Orient()
        {
            Console.WriteLine("Tower: Orienting");
        }

        public void Do()
        {
            Console.WriteLine("Tower: Doing");
        }
    }
}
