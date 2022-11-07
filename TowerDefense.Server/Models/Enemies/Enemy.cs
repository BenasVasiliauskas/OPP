using TowerDefense.Server.Models.Maps;

namespace TowerDefense.Server.Models.Enemies
{
    public class Enemy : Unit
    {
        public int MaxHealth { get; set; }
        public bool HasDead { get; set; }
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
