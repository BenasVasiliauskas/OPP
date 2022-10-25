namespace TowerDefense.Server.Models
{
    public class WaterLevel : Level
    {
        public override AbstractFactory getAbstractFactory()
        {
            return new WaterFactory();
        }
    }
}
