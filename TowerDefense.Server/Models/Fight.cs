namespace TowerDefense.Server.Models
{
    public class Fight: UnitStrategy
    {
        public override void Act(Unit unit)
        {
            unit.Speed = 0.0;
            //reduce obstacle's in front of you health by your attack
        }
    }
}
