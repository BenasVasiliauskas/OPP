namespace TowerDefense.Server.Models
{
    public class WaterLevel
    {
        public AbstractFactory getAbstractFactory()
        {
            return new WaterFactory();
        }
    }
}
