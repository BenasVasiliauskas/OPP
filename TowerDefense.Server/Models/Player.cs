using TowerDefense.Server.Models.Enemies;

namespace TowerDefense.Server.Models
{
    public class Player
    {
        public string Username { get; set; }
        public string ConnectionId { get; set; }
        public List<Enemy> Enemies { get; set; }
    }
}
