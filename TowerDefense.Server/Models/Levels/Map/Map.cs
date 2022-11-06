namespace TowerDefense.Server.Models.Levels.Map
{
    public class Map
    {
        public List<Coordinate> Path { get; set; }
        public string PathImageSource { get; set; }
        public List<Interval> Move { get; set; }
    }
}
