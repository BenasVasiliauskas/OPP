namespace TowerDefense.Server.Models.Levels
{
    public class WaterLevel : ILevel
    {
        
        public AbstractFactory GetAbstractFactory()
        {
            return new WaterFactory();
        }

        public void SetStats(Unit unit)
        {
            unit.Speed = 100;
            unit.Color = "Blue";
        }
    }
}
