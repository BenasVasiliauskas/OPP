using Microsoft.AspNetCore.SignalR;

namespace AAAA.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string direction)
        {
            await Clients.All.SendAsync("ReceiveMessage", direction);
        }
    }
}
