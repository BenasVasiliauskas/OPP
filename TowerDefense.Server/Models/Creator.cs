using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Server.Models
{
    public abstract class Creator
    {
        public abstract Level FactoryMethod(string level);
    }
}
