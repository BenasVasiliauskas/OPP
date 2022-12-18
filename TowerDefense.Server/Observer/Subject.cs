using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefense.Server.Models;
using TowerDefense.Server.Models.Enemies;
using TowerDefense.Server.Models.Strategies;

namespace TowerDefense.Server.Observers
{
    public class Subject
    {
        public List<Enemy> Observers { get; set; } = new();

        public void Attach(Enemy observer)
        {
            Observers.Add(observer);
        }
        
        public void Detach(Enemy observer)
        {
            Observers.Remove(observer);
        }

        public void IncreasePower()
        {
            Observers.ForEach(observer => observer.Update());
        }
    }
}
