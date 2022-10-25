namespace TowerDefense.Server.Models
{
    public class DesertLevel : Level
    {
        public override AbstractFactory getAbstractFactory()
        {
            return new DesertFactory();
        }
    }
}
