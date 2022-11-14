using TowerDefense.Server.Models.Enemies;
using TowerDefense.Server.Models.Towers;
using TowerDefense.Server.Observers;

namespace TowerDefense.Server.Models
{
    public class Player
    {
        public string Username { get; set; }
        public string ConnectionId { get; set; }
        public List<Enemy> Enemies { get; set; } = new();
        public List<Tower> Towers { get; set; } = new();
        public Subject Subject { get; set; } = new();
        public int Money { get; set; }

        public int GetMoney()
        {
            return this.Money;
        }
    }
}
