using TowerDefense.Server.Models.Maps;

namespace TowerDefense.Server.Models.Levels
{
    public interface ILevel
    {
        public AbstractFactory GetAbstractFactory();
        public List<MovePoint> GetMapMoveset();
    }
}
