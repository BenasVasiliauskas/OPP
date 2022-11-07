using TowerDefense.Server.Observers;

namespace TowerDefense.Server.Models
{
    public class Unit : Observer
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Speed { get; set; }
        public UnitStrategy UnitStrategy { get; private set; }
        public string ImageSource { get; set; }
        public int Health { get; set; }
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
