using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TowerDefense.Client.Mediators
{
    internal class Mediator
    {
        private UserControl2 _userControl;

        public Mediator(UserControl2 userControl)
        {
            _userControl = userControl;
        }

        public void HandleButtonClick(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("Button was clicked");
        }

        public void UpdatePlayerMoney(int amount)
        {
            // update the player's money
        }
    }
}
