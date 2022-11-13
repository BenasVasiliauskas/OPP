namespace TowerDefense.Server.Models
{
    public class SlowWalk : UnitStrategy
    {
        public override void Act(Unit unit)
        {
            unit.SpeedRatio = 0.2;
        }
    }
}
