using TowerDefense.Server.Models.Levels;

namespace TowerDefense.Server.Models.Enemies
{
    public class Enemy : Unit
    {
        
        public Enemy(ILevel level) : base(level)
        {
            level.SetStats(this);
            Y = 96;
        }

        public override void Update()
        {
            Speed = Speed * 2;
        }
    }
}
