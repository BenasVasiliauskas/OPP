namespace TowerDefense.Server.Models
{
    public class SuperFastWalk : UnitStrategy
    {
        public override void Act(Unit unit)
        {
            unit.SpeedRatio = 10;
        }
    }
}
