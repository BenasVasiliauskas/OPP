using Microsoft.AspNetCore.SignalR;
using TowerDefense.Server.Models;
using TowerDefense.Server.Models.Enemies;
using TowerDefense.Server.Models.Levels;
using TowerDefense.Server.Models.Powerups;

namespace TowerDefense.Server
{
    public class ChatHub : Hub
    {
        private readonly GameSession _gameSession = GameSession.GetIstance();
        FacadeChatHub _chatHub;

        public ChatHub(IHubContext<ChatHub> hubContext)
        {
            _chatHub = new FacadeChatHub(hubContext);
        }

        public async Task SendMessage(string message)
        {
            if (!_gameSession.IsGameStarted)
            {
                _gameSession.AddPlayer(new Player
                {
                    ConnectionId = Context.ConnectionId,
                    Username = message
                });

                var sessionUsernames = _gameSession.GetSessionPlayers()
                    .Select(p => p.Username)
                    .ToList();

                await Clients.All.SendAsync("PlayerJoined", sessionUsernames);

                if (_gameSession.IsGameStarted)
                {
                    var creator = new LevelCreator();
                    ILevel level = creator.FactoryMethod(_gameSession.CurrentGameLevel);
                    var path = level.GetMapMoveset();
                    var tile = level.GetPath();

                    await Clients.Clients(_gameSession.GetSessionIds()).SendAsync("GameStarted", path, tile);
                }
            }
            else
            {
                await Clients.Caller.SendAsync("FullLobby");
            }
        }

        public async Task ChangeLevel()
        {
            _gameSession.ChangeLevel();

            await Clients.All.SendAsync("LevelChanged", _gameSession.CurrentGameLevel);
        }

        public async Task PowerUp()
        {
            var player = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId == Context.ConnectionId).SingleOrDefault();

            player.Subject.IncreasePower();

            await Clients.All.SendAsync("PoweredUp");
        }

        public async Task GameTimerTick()
        {
            var player = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId == Context.ConnectionId).SingleOrDefault();
            var receiver = _gameSession.GetSessionPlayers().Where(p => p.ConnectionId != Context.ConnectionId).SingleOrDefault();

            await Clients.Caller.SendAsync("Ticked", player.Enemies, player.Towers, player, Context.ConnectionId);
            await Clients.Others.SendAsync("Ticked", receiver.Enemies, receiver.Towers, receiver, Context.ConnectionId);
        }

        public async Task CreateTower(string towerType, int x, int y)
        {
            await _chatHub.CreateTower(towerType, x, y, Context.ConnectionId);
        }
        public async Task NearTower(int enemyIndex, int towerIndex)
        {
            await _chatHub.NearTower(enemyIndex, towerIndex, Context.ConnectionId);
        }

        public async Task CreateEnemy(string enemyType, bool aoeResistance)
        {
            await _chatHub.CreateEnemy(enemyType, aoeResistance, Context.ConnectionId);
        }

        public void EnemyDied(int index)
        {
            _chatHub.EnemyDied(index, Context.ConnectionId);
        }

        public async Task DrawBulletForEnemy(double x1, double x2, double y1, double y2, string actionName = "DrawBullet")
        {
            await _chatHub.DrawBulletForEnemy(actionName, x1, x2, y1, y2, Context.ConnectionId);
        }

        public async Task EnemySurvived(Enemy enemy, int index)
        {
            await _chatHub.EnemySurvived(enemy, index, Context.ConnectionId);
        }

        public async Task DoubleUpEnemies()
        {
            await _chatHub.DoubleUpEnemies(Context.ConnectionId);
        }

        public async Task GetLoan()
        {
            var player = _gameSession.GetSessionPlayers()
                .Where(p => p.ConnectionId != Context.ConnectionId)
                .SingleOrDefault();

            Loan bank = new Loan(player);
            bank.execute();

            await Clients.Caller.SendAsync("UpdateMoney", player);
        }

        public async Task PayLoan()
        {
            var player = _gameSession.GetSessionPlayers()
                .Where(p => p.ConnectionId != Context.ConnectionId)
                .SingleOrDefault();

            Loan bank = new Loan(player);
            bank.undo();

            await Clients.Caller.SendAsync("UpdateMoney", player);
        }

        public async Task Pause(int index)
        {
            await _chatHub.Pause(index, Context.ConnectionId);
        }

        public async Task Unpause(int index)
        {
            await _chatHub.Unpause(index, Context.ConnectionId);
        }
    }
}
