using TowerDefense.Server.Models.Levels;

namespace TowerDefense.Server.Models.Towers
{
    public abstract class Tower : Unit
    {
        public double Damage { get; set; }

        protected Tower(ILevel level) : base(level)
        {
            level.SetStats(this);
        }

        public override void Update()
        {
            Damage *= 2;
        }
    }
}
