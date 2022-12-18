using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Client.Interpreter
{
    public abstract class Expression
    {
        public abstract string Action { get; set; }
        public abstract string UnitType { get; set; }
        public async Task Interpret(GameContext context)
        {
            if(context.Input.Length == 0)
            {
                return;
            }

            var commandList = context.Input.Split(' ');

            if(commandList[0] == Action && commandList[1] == UnitType)
            {
                await context.CreateEnemy(commandList[1]);
            }
        }
    }
}
