namespace TowerDefense.Server.Models.Maps
{
    public class WaterMap : IMapMoveset, IMap
    {
        public List<MovePoint> GetMovePoints()
        {
            return new()
            {
                new MovePoint { X = 0, Y = 150 },
                new MovePoint { X = 200, Y = 150 },
                new MovePoint { X = 200, Y = 250 },
                new MovePoint { X = 50, Y = 250 },
                new MovePoint { X = 50, Y = 300 },
                new MovePoint { X = 400, Y = 300 }
            };
        }
    }
}
