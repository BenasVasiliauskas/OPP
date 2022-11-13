namespace TowerDefense.Server.Models.Enemies
{
    public class Enemy : Unit
    {
        public int MaxHealth { get; set; }
        public bool HasDead { get; set; }

        public override void Update()
        {
            Speed = Speed * 2;
        }
    }
}
