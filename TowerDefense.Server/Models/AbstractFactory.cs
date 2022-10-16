namespace TowerDefense.Server.Models
{
    public abstract class AbstractFactory
    {
        public abstract Unit createTower(string type);

        public abstract  Unit createEnemy(string type);
    }
}
