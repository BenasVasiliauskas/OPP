using System.Collections;

namespace TowerDefense.Server.Models.Iterator
{
    public abstract class IteratorAggregate : IEnumerable
    {
        public abstract IEnumerator GetEnumerator();
    }
}
