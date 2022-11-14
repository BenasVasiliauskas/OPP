namespace TowerDefense.Server.Models
{
    public class FastWalk : UnitStrategy
    {
        public override void Act(Unit unit)
        {
            unit.SpeedRatio = 5;
        }
    }
}
