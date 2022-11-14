using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Server.Models.Decorator
{
    public class SingleShotImmunityDecorator : Decorator
    {
        public SingleShotImmunityDecorator(Immunity immunity) : base(immunity)
        {
        }

        public override void GrantImmunity()
        {
            //grant immunity for enemies to single shot
        }
    }
}
