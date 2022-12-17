using System.Collections;
using TowerDefense.Server.Models.Enemies;

namespace TowerDefense.Server.Models.Iterator
{
    public class EnemyIterator : IEnumerator<Enemy>
    {
        private readonly EnemyCollection _collection;
        private int _position = -1;

        public EnemyIterator(EnemyCollection collection)
        {
            _collection = collection;
        }

        public Enemy Current => _collection.GetEnemies()[_position];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            int updatedPosition = _position + 1;

            if (updatedPosition >= 0 && updatedPosition < _collection.GetEnemies().Count)
            {
                _position = updatedPosition;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _position = 0;
        }
    }
}
