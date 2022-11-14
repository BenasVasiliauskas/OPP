using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Server.Models.Decorator
{
    public abstract class Decorator : Immunity
    {
        protected Immunity _immunity;

        public Decorator(Immunity immunity)
        {
            _immunity = immunity;
        }

        public void SetImmunity(Immunity immunity)
        {
            _immunity = immunity;
        }

        public override void GrantImmunity()
        {
            _immunity.GrantImmunity();
        }
    }
}
