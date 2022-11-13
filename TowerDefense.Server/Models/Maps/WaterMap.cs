namespace TowerDefense.Server.Models.Maps
{
    public class WaterMap : IMapMoveset, IMap
    {
        public List<MovePoint> GetMovePoints()
        {
            return new()
            {
                new MovePoint { X = 0, Y = 160 },
                new MovePoint { X = 224, Y = 160 },
                new MovePoint { X = 224, Y = 256 },
                new MovePoint { X = 64, Y = 256 },
                new MovePoint { X = 64, Y = 320 },
                new MovePoint { X = 320, Y = 320 }
            };
        }

        public List<MovePoint> GetPath()
        {
            return new()
            {
                new MovePoint { X = 0, Y = 160 },
                new MovePoint { X = 32, Y = 160 },
                new MovePoint { X = 64, Y = 160 },
                new MovePoint { X = 96, Y = 160 },
                new MovePoint { X = 128, Y = 160 },
                new MovePoint { X = 160, Y = 160 },
                new MovePoint { X = 192, Y = 160 },
                new MovePoint { X = 224, Y = 160 },
                new MovePoint { X = 224, Y = 192 },
                new MovePoint { X = 224, Y = 224 },
                new MovePoint { X = 224, Y = 256 },
                new MovePoint { X = 192, Y = 256 },
                new MovePoint { X = 160, Y = 256 },
                new MovePoint { X = 128, Y = 256 },
                new MovePoint { X = 96, Y = 256 },
                new MovePoint { X = 64, Y = 256 },
                new MovePoint { X = 64, Y = 288 },
                new MovePoint { X = 64, Y = 320 },
                new MovePoint { X = 96, Y = 320 },
                new MovePoint { X = 128, Y = 320 },
                new MovePoint { X = 160, Y = 320 },
                new MovePoint { X = 192, Y = 320 },
                new MovePoint { X = 224, Y = 320 },
                new MovePoint { X = 256, Y = 320 },
                new MovePoint { X = 288, Y = 320 },
                new MovePoint { X = 320, Y = 320 }
            };
        }
    }
}
