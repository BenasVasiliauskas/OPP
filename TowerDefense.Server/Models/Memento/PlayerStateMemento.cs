using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefense.Server.Models.Towers;

namespace TowerDefense.Server.Models.Memento
{
    public class PlayerStateMemento
    {
        public List<Tower> Towers { get; set; }
        public int Money { get; set; }

        public PlayerStateMemento(List<Tower> towers, int money)
        {
            Towers = towers;
            Money = money;
        }
    }
}
