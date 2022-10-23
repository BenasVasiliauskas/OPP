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

        public async Task BuildTower(double x, double y, string levelName)
        {
            Creator creator = new LevelCreator();
            Level level = creator.FactoryMethod(levelName);

            AbstractFactory unitFactory = level.getAbstractFactory();

            Unit tower = unitFactory.createTower("S");

            await Clients.All.SendAsync("TowerBuilt", x, y, tower);
        }

        public async Task CreateEnemy(string levelName)
        {
            Creator creator = new LevelCreator();
            Level level = creator.FactoryMethod(levelName);

            AbstractFactory unitFactory = level.getAbstractFactory();

            Unit enemy = unitFactory.createEnemy("B");
            enemy.Color = "green";
            enemy.Speed = 100;

            await Clients.All.SendAsync("EnemyCreated", enemy);
        }
    }
}
