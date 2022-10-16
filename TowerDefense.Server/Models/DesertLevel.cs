namespace TowerDefense.Server.Models
{
    public class DesertLevel
    {
        public AbstractFactory getAbstractFactory()
        {
            return new DesertFactory();
        }
    }
}
