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
                return _cachedEnemies[enemyType];
            }

            var enemy = _enemyService.CreateEnemy(session, enemyType, player, receiver);

            if (!_cachedEnemies.ContainsKey(enemyType))
            {
                _cachedEnemies[enemyType] = enemy;
            }

            return enemy;
        }
    }
}
