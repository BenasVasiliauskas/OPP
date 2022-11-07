namespace TowerDefense.Server.Models
{
    public class SlowWalk : UnitStrategy
    {
        public override void Act(Unit unit)
        {
            unit.Speed = 10;
            //reduce obstacle's in front of you health by your attack
        }
    }
}
