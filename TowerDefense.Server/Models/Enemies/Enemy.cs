using TowerDefense.Server.Models.Maps;

namespace TowerDefense.Server.Models.Enemies
{
    public class Enemy : Unit
    {
        private readonly IMapMoveset _mapMoveset;

        public Enemy(IMapMoveset mapMoveset)
        {
            _mapMoveset = mapMoveset;
        }

        public List<MovePoint> GetMovePoints()
        {
            return _mapMoveset.GetMovePoints();
        }

        public override void Update()
        {
            Speed = Speed * 2;
        }
    }
}
