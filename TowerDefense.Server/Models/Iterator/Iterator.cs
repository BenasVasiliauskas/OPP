using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Server.Models.Iterator
{
    public abstract class Iterator : IEnumerator
    {
        object IEnumerator.Current => Current();
        public abstract bool MoveNext();
        public abstract void Reset();
        public abstract object Current();
    }
}
