namespace TowerDefense.Server.Models
{
    public class SlowWalk
    {
        public void Act(Unit unit)
        {
            unit.SpeedRatio = 0.2;
        }
    }
}
