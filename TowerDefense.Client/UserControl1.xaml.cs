using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TowerDefense.Server.Models;

namespace TowerDefense.Client
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1(HubConnection connection)
        {
            InitializeComponent();

            connection.On<List<string>>("PlayerJoined", async (message) =>
            {
                await this.Dispatcher.InvokeAsync(() =>
                { 
                    players.Items.Clear();
                    message.ForEach(p => players.Items.Add($"{p} joined!"));
                });
            });

            connection.On("GameStarted", async () =>
            {
                game.Text = "GAME WILL START SOON";
                await Wait();
                this.Content = new UserControl2();
            });
        }

        public async Task Wait()
        {
            await Task.Delay(2000);
        }
    }
}
