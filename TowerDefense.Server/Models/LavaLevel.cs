namespace TowerDefense.Server.Models
{
    public class LavaLevel : Level
    {
        public override AbstractFactory getAbstractFactory()
        {
            return new LavaFactory();
        }
    }
}