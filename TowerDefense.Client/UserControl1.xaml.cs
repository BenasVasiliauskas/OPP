using Microsoft.AspNetCore.SignalR.Client;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using TowerDefense.Server.Models.Maps;

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

            connection.On<List<MovePoint>>("GameStarted", async (path) =>
            {
                game.Text = "GAME WILL START SOON";
                await Wait();
                this.Content = new UserControl2(connection, path);
            });
        }

        public async Task Wait()
        {
            await Task.Delay(2000);
        }
    }
}
