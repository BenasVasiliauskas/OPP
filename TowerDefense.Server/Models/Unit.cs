using TowerDefense.Server.Observers;

namespace TowerDefense.Server.Models
{
    public class Unit : Observer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public double X { get; set; }
        public double Y { get; set; }
        public int Damage { get; set; }
        public double Speed { get; set; }
        public UnitStrategy UnitStrategy { get; private set; }
        public string ImageSource { get; set; }
        public int Health { get; set; }
        public List<Unit> EnemiesInRange { get; set; } = new();
        public void SetUnitStrategy(UnitStrategy UnitStrategy, Unit unit)
        {
            this.UnitStrategy = UnitStrategy;
            this.UnitStrategy.Act(unit);
        }

        public override void Update()
        {
            
        }

        public override bool Equals(object obj)
        {
            var unit = obj as Unit;

            return unit.Id == Id;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
