using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Server.Models.Memento
{
    public class PlayerStateCaretaker
    {
        private PlayerStateMemento _playerStateMemento;

        public void MakeBackup(Player player)
        {
            _playerStateMemento = player.CreateSnapshot();
        }

        public PlayerStateMemento Undo()
        {
            return _playerStateMemento;
        }
    }
}
