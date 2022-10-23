using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Server.Models
{
    public class LevelCreator : Creator
    {
        public override Level FactoryMethod(string level)
        {
            if(level == "lava")
            {
                return new LavaLevel();
            }
            else if(level == "water")
            {
                return new WaterLevel();
            }
            else if(level == "desert")
            {
                return new DesertLevel();
            }
            return null;
        }
    }
}
