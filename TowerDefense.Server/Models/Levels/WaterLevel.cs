using TowerDefense.Server.Models.Maps;
using TowerDefense.Server.Models.Strategies;

namespace TowerDefense.Server.Models.Levels
{
    public class WaterLevel : ILevel
    {
        public WaterMap Map { get; set; } = new WaterMap();
        public AbstractFactory GetAbstractFactory()
        {
            return new WaterFactory();
        }

        public List<MovePoint> GetMapMoveset()
        {
            return Map.GetMovePoints();
        }

        public List<MovePoint> GetPath()
        {
            return Map.GetPath();
        }

        public void SetStats(Unit unit)
        {
            unit.Speed = 100;
        }
    }
}
