namespace TowerDefense.Server.Models
{
    public class Walk : UnitStrategy
    {
        public override void Act(Unit unit)
        {
            unit.Speed = 10.0;
            //should prolly also follow some path, so pathfinding or smth?
        }
    }
}
