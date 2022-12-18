namespace TowerDefense.Server.Models.Strategies
{
    public class SecondState : State
    {
        public override void Statement()
        {
            Console.WriteLine("I'm hit 75");
            if(this._unit.Health / this._unit.MaxHealth < 0.5)
            {
                this._unit.Transition(new ThirdState());
            }
        }
    }
}
