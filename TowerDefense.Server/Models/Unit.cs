using TowerDefense.Server.Models.Levels;
using TowerDefense.Server.Observers;

namespace TowerDefense.Server.Models
{
    public class Unit : Observer
    {
        public double Speed { get; set; }
        public UnitStrategy UnitStrategy { get; private set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public ILevel Level { get; set; }
        public string ImageSource { get; set; }
        public int Health { get; set; }

        public Unit(ILevel level)
        {
            Level = level;
        }

        public void SetUnitStrategy(UnitStrategy UnitStrategy, Unit unit)
        {
            this.UnitStrategy = UnitStrategy;
            this.UnitStrategy.Act(unit);
        }

        public override void Update()
        {
            
        }
    }
}
