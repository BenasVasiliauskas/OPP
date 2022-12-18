namespace TowerDefense.Server.Models
{
    public class Walk
    {
        public void Act(Unit unit)
        {
            unit.SpeedRatio = 1;
        }
    }
}
