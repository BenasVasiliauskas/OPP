using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefense.Server.Models.Enemies;

namespace TowerDefense.Server.Models.Iterator
{
    public class EnemyIterator : Iterator
    {
        private readonly EnemyCollection _collection;
        private int _position = -1;

        public EnemyIterator(EnemyCollection collection)
        {
            _collection = collection;
        }

        public override object Current()
        {
            return _collection.GetEnemies()[_position];
        }

        public override bool MoveNext()
        {
            int updatedPosition = _position + 1;

            if(updatedPosition >= 0 && updatedPosition < _collection.GetEnemies().Count)
            {
                _position = updatedPosition;
                return true;
            }

            return false;
        }

        public override void Reset()
        {
            _position = 0;
        }
    }
}
