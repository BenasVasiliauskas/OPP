namespace TowerDefense.Server.Models.Strategies
{
    public class FirstState : State
    {
        public override void Statement()
        {
            Console.WriteLine("I'm alive 100");
            if(this._unit.Health / this._unit.MaxHealth < 0.75)
            {
                this._unit.Transition(new SecondState());
            }
        }
    }
}
