using System.Collections;
using TowerDefense.Server.Models.Enemies;

namespace TowerDefense.Server.Models.Iterator
{
    public class EnemyCollection : IUnitCollection
    {
        public List<Enemy> Collection { get; set; } = new();

        public List<Enemy> GetEnemies()
        {
            return Collection;
        }

        public Enemy GetEnemy(int index)
        {
            return Collection[index];
        }

        public void AddEnemy(Enemy enemy)
        {
            Collection.Add(enemy);
        }

        public bool RemoveEnemy(Enemy enemy)
        {
            return Collection.Remove(enemy);
        }

        public bool RemoveEnemyAt(int index)
        {
            if (index < 0 || index >= Collection.Count)
            {
                return false;
            }
            Collection.RemoveAt(index);
            return true;
        }

        public int EnemyCount()
        {
            return Collection.Count;
        }

        public IEnumerator<Enemy> GetEnumerator()
        {
            return new EnemyIterator(this);
        }
    }
}
