namespace TowerDefense.Server.Models.Levels
{
    public class LavaLevel : ILevel
    {
        public AbstractFactory GetAbstractFactory()
        {
            return new LavaFactory();
        }

        public void SetStats(Unit unit)
        {
            unit.Speed = 150;
            unit.Color = "Red";
        }
    }
}