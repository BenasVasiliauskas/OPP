using TowerDefense.Server.Models.Enemies;

namespace TowerDefense.Server.Models.Builder
{
    public class EnemyBuilder<T> : IBuilder where T : Enemy, new()
    {
        private T _enemy = new T();
        public EnemyBuilder()
        {
            Reset();
        }

        public void SetDamage(int damage)
        {
            _enemy.Damage = damage;
        }

        public void SetHealth(int health)
        {
            _enemy.Health = health;
        }

        public void SetImage(string path)
        {
            _enemy.ImageSource = path;
        }

        public void Reset()
        {
            _enemy = new T();
        }

        public T GetEnemy()
        {
            T enemy = _enemy;
            Reset();
            return enemy;
        }
    }
}
