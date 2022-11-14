using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Server.Models.Decorator
{
    public class AoeImmunityDecorator : Decorator
    {
        public AoeImmunityDecorator(Immunity immunity) : base(immunity)
        {
        }

        public override void GrantImmunity()
        {
            //Grant immunity for enemies to aoe
        }
    }
}
