using TowerDefense.Server.Models.Levels;
using TowerDefense.Server.Models.Maps;

namespace TowerDefense.Server.Models
{
    public class DesertLevel : ILevel
    {
        public DesertMap Map { get; set; } = new DesertMap();
        public AbstractFactory GetAbstractFactory()
        {
            return new DesertFactory();
        }

        public List<MovePoint> GetMapMoveset()
        {
            return Map.GetMovePoints();
        }

        public List<MovePoint> GetPath()
        {
            throw new NotImplementedException();
        }

        public void SetStats(Unit unit)
        {
            unit.Speed = 50;
        }
    }
}
