namespace TowerDefense.Server.Models.Levels.Map
{
    public class WaterMap : Map
    {
        public WaterMap()
        {
            Path = new()
            {
                new Coordinate(96, 0),
                new Coordinate(96, 32),
                new Coordinate(96, 64),
                new Coordinate(96, 96),
                new Coordinate(96, 128),
                new Coordinate(96, 160),
                new Coordinate(96, 192),
                new Coordinate(96, 224),
                new Coordinate(96, 256),
                new Coordinate(96, 288),
                new Coordinate(128, 288),
                new Coordinate(160, 288),
                new Coordinate(192, 288),
                new Coordinate(224, 288),
                new Coordinate(224, 320),
                new Coordinate(224, 352),
                new Coordinate(224, 384),
                new Coordinate(224, 416),
                new Coordinate(224, 448),
                new Coordinate(224, 480),
                new Coordinate(224, 512),
                new Coordinate(224, 544),
                new Coordinate(224, 576),
                new Coordinate(256, 576),
                new Coordinate(288, 576),
                new Coordinate(320, 576),
                new Coordinate(352, 576),
                new Coordinate(352, 544),
                new Coordinate(352, 512),
                new Coordinate(352, 480),
                new Coordinate(352, 448),
                new Coordinate(352, 416),
                new Coordinate(352, 384),
                new Coordinate(352, 352),
                new Coordinate(352, 320),
                new Coordinate(352, 288),
                new Coordinate(384, 288),
            };

            PathImageSource = "/Images/Paths/grass.jpg";

            Move = new()
            {
                new() {FromX = 0, FromY = 96, ToX = 288, ToY = 96, Direction = "right" },
                new() {FromX = 288, FromY = 96, ToX = 288, ToY = 288, Direction = "down" },
            };
        }
    }
}
