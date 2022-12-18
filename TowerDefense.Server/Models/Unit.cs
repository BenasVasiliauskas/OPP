using TowerDefense.Server.Models.Strategies;
using TowerDefense.Server.Observers;

namespace TowerDefense.Server.Models
{
    public class Unit : Observer, IUnitTemplate
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public double X { get; set; }
        public double Y { get; set; }
        public int Damage { get; set; }
        public double Speed { get; set; }
        public double SpeedRatio { get; set; }
        public string ImageSource { get; set; }
        public int Health { get; set; }
        public List<Unit> EnemiesInRange { get; set; } = new();

        public void Do() { }

        public void Orient() { }

        public void Act()
        {
            Orient();
            Do();
        }

        public override void Update()
        {
            
        }



        //public override bool Equals(object obj)
        //{
        //    var unit = obj as Unit;
        //    return unit.Id == Id;
        //}
        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}
    }
}
