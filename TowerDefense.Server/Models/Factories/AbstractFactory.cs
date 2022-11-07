namespace TowerDefense.Server.Models
{
    public abstract class AbstractFactory
    {
        public abstract Unit CreateTower(string type);
        public abstract Unit CreateEnemy(string type);
    }
}
