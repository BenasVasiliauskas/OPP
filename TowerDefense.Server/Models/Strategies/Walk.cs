namespace TowerDefense.Server.Models
{
    public class Walk : UnitStrategy
    {
        public override void Act(Unit unit)
        {
            unit.Speed = 100;
        }
    }
}
