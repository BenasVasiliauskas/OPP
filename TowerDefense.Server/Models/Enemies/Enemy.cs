namespace TowerDefense.Server.Models.Enemies
{
    public class Enemy : Unit, IPrototype, IUnitTemplate
    {
        public int MaxHealth { get; set; }
        public bool HasDead { get; set; }

        public Enemy()
        {
            Speed = 3;
        }

        public Enemy MakeDeepCopy()
        {
            Enemy clone = (Enemy)MemberwiseClone();
            clone.Health = MaxHealth / 2;
            return clone;
        }

        public Enemy MakeShallowCopy()
        {
            return (Enemy)MemberwiseClone();
        }

        public override void Update()
        {
            Speed = Speed * 2;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitEnemy(this);
        }

        public void Orient()
        {
            Console.WriteLine("Enemy: Orienting");
        }

        public void Do()
        {
            Console.WriteLine("Enemy: Doing");
        }
    }
}
