namespace TowerDefense.Server.Models.Levels
{
    public interface ILevel
    {
        public AbstractFactory GetAbstractFactory();
        public void SetStats(Unit unit);
    }
}
