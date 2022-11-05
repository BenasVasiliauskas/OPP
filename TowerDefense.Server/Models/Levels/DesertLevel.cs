using TowerDefense.Server.Models.Levels;

namespace TowerDefense.Server.Models
{
    public class DesertLevel : ILevel
    {
        public AbstractFactory GetAbstractFactory()
        {
            return new DesertFactory();
        }

        public void SetStats(Unit unit)
        {
            unit.Speed = 50;
            unit.Color = "Yellow";
        }
    }
}
