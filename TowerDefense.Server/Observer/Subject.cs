using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Server.Observers
{
    public class Subject
    {
        public List<Observer> Observers{ get; set; }

        public void Attach(Observer observer)
        {
            Observers.Add(observer);
        }
        
        public void Detach(Observer observer)
        {
            Observers.Remove(observer);
        }

        public void IncreasePower()
        {
            Observers.ForEach(observer => observer.Update());
        }
    }
}
