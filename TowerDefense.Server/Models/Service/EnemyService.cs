using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerDefense.Server.Models.Enemies;
using TowerDefense.Server.Models.Levels;
using Microsoft.AspNetCore.SignalR;


namespace TowerDefense.Server.Models.Service
{
    public class EnemyService : IEnemyService
    {
        public Enemy CreateEnemy(GameSession session, string enemyType, Player player, Player receiver)
        {
            var creator = new LevelCreator();
            AbstractFactory unitFactory = creator.FactoryMethod(session.CurrentGameLevel).GetAbstractFactory();

            var enemy = unitFactory.CreateEnemy(enemyType);
            enemy.SetUnitStrategy(new Walk(), enemy);      

            player.Subject.Attach(enemy);
            receiver.Enemies.AddEnemy(enemy as Enemy);

            return enemy as Enemy;
        }
    }
}
