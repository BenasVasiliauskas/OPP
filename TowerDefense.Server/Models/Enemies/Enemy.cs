using TowerDefense.Server.Models.Composite;
using TowerDefense.Server.Models.Strategies;
using TowerDefense.Server.Models.Visitor;

namespace TowerDefense.Server.Models.Enemies
{
    public class Enemy : Unit, IPrototype, IUnitTemplate, IComponent
    {
        public int MaxHealth { get; set; }
        public bool HasDead { get; set; }
        private State _state = null;

        public Enemy()
        {
            Speed = 3;
            Transition(new FirstState());
        }

        public void Transition(State state)
        {
            this._state = state;
            this._state.SetUnit(this);
        }

        public void GiveStatement()
        {
            this._state.Statement();
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
