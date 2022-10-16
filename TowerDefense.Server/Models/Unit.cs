namespace TowerDefense.Server.Models
{
    public class Unit
    {
        public Unit(string name, IMovementStrategy movement, IAttackStrategy attack)
        {
            this.name = name;
            this.movementStrategy = movement;
            this.attackStrategy = attack;
        }

        string name = "";

        public void SayHello()
        {
            Console.WriteLine();
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }


        // Strategy related methods
        private IMovementStrategy movementStrategy;
        private IAttackStrategy attackStrategy;

        public void Move()
        {
            //
        }

        public void Attack()
        {
            //
        }

        public void SetMovementStrategy(IMovementStrategy movementStrategy)
        {
            this.movementStrategy = movementStrategy;
        }

        public void SetAttackStrategy(IAttackStrategy attackStrategy)
        {
            this.attackStrategy = attackStrategy;
        }
    }
}
