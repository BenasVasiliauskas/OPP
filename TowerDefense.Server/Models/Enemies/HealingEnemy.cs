using TowerDefense.Server.Models.Levels;

namespace TowerDefense.Server.Models.Enemies
{
    public class HealingEnemy : Enemy
    {
        public HealingEnemy(ILevel level) : base(level)
        {
            ImageSource = "/Images/Enemies/priest.png";
            Speed = 1;
        }
    }
}
