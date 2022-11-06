namespace TowerDefense.Server.Models.Levels.Map
{
    public class Interval
    {
        public int FromX { get; set; }
        public int ToX { get; set; }
        public int FromY { get; set; }
        public int ToY { get; set; }
        public string Direction { get; set; }
    }
}