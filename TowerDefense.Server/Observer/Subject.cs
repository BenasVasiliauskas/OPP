namespace TowerDefense.Server.Observer
{
    public abstract class Subject
    {
        protected List<Observer> observers;
        public Subject()
        {
            observers = new List<Observer>();
        }
        protected Subject(List<Observer> observers)
        {
            this.observers = observers;
        }

        //public List<Observer> Observers { get { return observers; } }

        public abstract void ChangeState();
        public abstract void Subscribe(Observer observer);
        public abstract void Unsubscribe(Observer observer);
    }
}
