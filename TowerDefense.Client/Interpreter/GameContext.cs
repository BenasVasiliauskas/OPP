using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;

namespace TowerDefense.Client.Interpreter
{
    public class GameContext
    {
        private readonly HubConnection _connection;
        public string Input { get; set; }

        public GameContext(HubConnection connection)
        {
            _connection = connection;
        }

        public async Task CreateEnemy(string enemyType)
        {
            if(enemyType == "healingenemy")
            {
                await _connection.InvokeAsync("CreateEnemy", "H");
            }
            else if(enemyType == "shootingenemy")
            {
                await _connection.InvokeAsync("CreateEnemy", "S");
            }
        }
    }
}
