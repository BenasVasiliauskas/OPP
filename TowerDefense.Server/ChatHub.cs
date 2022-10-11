using Microsoft.AspNetCore.SignalR;
using TowerDefense.Server.Models;

namespace TowerDefense.Server
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            var session = GameSession.GetIstance();

            var gameStarted = session.AddPlayer(new Player { ConnectionId = Context.ConnectionId, Username = message });

            var sessionUsernames = session.GetSessionPlayers().Select(p => p.Username).ToList();


            await Clients.All.SendAsync("PlayerJoined", sessionUsernames);
            if (gameStarted)
            {
                await Clients.Clients(session.GetSessionIds()).SendAsync("GameStarted");
            }
        }
    }
}
