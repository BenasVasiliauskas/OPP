namespace TowerDefense.Server.Observer
{
    public class UnitManager : Subject
    {
        public UnitManager() : base() { }
        public override void ChangeState()
        {
            foreach (var obs in observers)
            {
                obs.UpdateUnits(); 
            }
        }

        public override void Subscribe(Observer observer)
        {
            this.observers.Add(observer);
        }

        public override void Unsubscribe(Observer observer)
        {
            this.observers.Remove(observer);
        }
    }
}
