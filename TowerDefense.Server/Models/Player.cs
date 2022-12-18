using TowerDefense.Server.Models.Enemies;
using TowerDefense.Server.Models.Iterator;
using TowerDefense.Server.Models.Memento;
using TowerDefense.Server.Models.Towers;
using TowerDefense.Server.Observers;

namespace TowerDefense.Server.Models
{
    public class Player
    {
        public string Username { get; set; }
        public string ConnectionId { get; set; }
        public EnemyCollection Enemies { get; set; } = new();
        public List<Tower> Towers { get; set; } = new();
        public Subject Subject { get; set; } = new();
        public int Money { get; set; }

        public PlayerStateMemento CreateSnapshot()
        {
            return new PlayerStateMemento(new List<Tower>(Towers), Money);
        }

        public void Restore(PlayerStateMemento state)
        {
            Towers = state.Towers;
            Money = state.Money;
        }
    }
}
