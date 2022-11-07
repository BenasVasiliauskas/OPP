using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefense.Server.Models;

namespace TowerDefense.Server.Observers
{
    public class Subject
    {
        public List<Unit> Observers { get; set; } = new();

        public void Attach(Unit observer)
        {
            Observers.Add(observer);
        }
        
        public void Detach(Unit observer)
        {
            Observers.Remove(observer);
        }

        public void IncreasePower()
        {
            Observers.ForEach(observer => observer.Update());
        }
    }
}
