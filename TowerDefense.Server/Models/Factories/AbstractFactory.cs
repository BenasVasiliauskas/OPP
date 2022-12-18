using TowerDefense.Server.Models.Strategies;
using TowerDefense.Server.Models.Towers;

namespace TowerDefense.Server.Models
{
    public abstract class AbstractFactory
    {
        public abstract Tower CreateTower(string type);
        public abstract Unit CreateEnemy(string type);
    }
}
