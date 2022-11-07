using TowerDefense.Server.Models.Maps;

namespace TowerDefense.Server.Models.Levels
{
    public class LavaLevel : ILevel
    {
        public LavaMap Map { get; set; } = new LavaMap();
        public AbstractFactory GetAbstractFactory()
        {
            return new LavaFactory();
        }

        public List<MovePoint> GetMapMoveset()
        {
            return Map.GetMovePoints();
        }
    }
}