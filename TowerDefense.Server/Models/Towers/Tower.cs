namespace TowerDefense.Server.Models.Towers
{
    public abstract class Tower : Unit
    {
        public double Damage { get; set; }

        protected Tower()
        {
        }

        public override void Update()
        {
            Damage *= 2;
        }
    }
}
