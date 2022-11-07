using TowerDefense.Server.Models.Enemies;
using TowerDefense.Server.Observers;

namespace TowerDefense.Server.Models
{
    public class Player
    {
        public string Username { get; set; }
        public string ConnectionId { get; set; }
        public List<Unit> Enemies { get; set; } = new();
        public List<Unit> Towers { get; set; } = new();
        public Subject Subject { get; set; } = new();

    }
}
