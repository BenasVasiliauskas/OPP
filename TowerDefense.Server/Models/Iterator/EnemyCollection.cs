using System.Collections;
using TowerDefense.Server.Models.Enemies;

namespace TowerDefense.Server.Models.Iterator
{
    public class EnemyCollection : IteratorAggregate
    {
        private readonly List<Enemy> _collection = new();

        public List<Enemy> GetEnemies()
        {
            return _collection;
        }

        public Enemy GetEnemy(int index)
        {
            return _collection[index];
        }

        public void AddEnemy(Enemy enemy)
        {
            _collection.Add(enemy);
        }

        public bool RemoveEnemy(Enemy enemy)
        {
            return _collection.Remove(enemy);
        }

        public bool RemoveEnemyAt(int index)
        {
            if (index < 0 || index >= _collection.Count)
            {
                return false;
            }
            _collection.RemoveAt(index);
            return true;
        }

        public int EnemyCount()
        {
            return _collection.Count;
        }

        public override IEnumerator GetEnumerator()
        {
            return new EnemyIterator(this);
        }
    }
}
