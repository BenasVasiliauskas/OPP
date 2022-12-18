namespace TowerDefense.Server.Models.Strategies
{
    public class ThirdState : State
    {
        public override void Statement()
        {
            Console.WriteLine("I'm going down 0.5");
            if(this._unit.Health / this._unit.MaxHealth < 0.25)
            {
                this._unit.Transition(new FourthState());
            }
        }
    }
}
