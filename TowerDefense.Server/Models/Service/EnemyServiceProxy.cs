using TowerDefense.Server.Models.Enemies;

namespace TowerDefense.Server.Models.Service
{
    public class EnemyServiceProxy : IEnemyService
    {
        private readonly IEnemyService _enemyService;
        private readonly string _currentLevel;
        private readonly Dictionary<string, Enemy> _cachedEnemies = new();

        public EnemyServiceProxy(IEnemyService enemyService, string firstLevel)
        {
            _enemyService = enemyService;
            _currentLevel = firstLevel;
        }

        public Enemy CreateEnemy(GameSession session, string enemyType, Player player, Player receiver)
        {
            if (_cachedEnemies.Any() && session.CurrentGameLevel == _currentLevel && _cachedEnemies.ContainsKey(enemyType))
            {
                var cloned = _cachedEnemies[enemyType].MakeDeepCopy();
                receiver.Enemies.AddEnemy(cloned);

                return cloned;
            }

            var enemy = _enemyService.CreateEnemy(session, enemyType, player, receiver);

            if (!_cachedEnemies.ContainsKey(enemyType))
            {
                var cloned = enemy.MakeDeepCopy();
                _cachedEnemies[enemyType] = cloned;
            }

            return enemy;
        }
    }
}
