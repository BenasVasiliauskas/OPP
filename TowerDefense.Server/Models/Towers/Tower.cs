namespace TowerDefense.Server.Models.Towers
{
    public abstract class Tower : Unit
    {
        protected Tower()
        {
        }

        public override void Update()
        {
            Damage *= 2;
        }
    }
}
