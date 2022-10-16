namespace TowerDefense.Server.Models
{
    public class LavaLevel
    {
        public AbstractFactory getAbstractFactory()
        {
            return new LavaFactory();
        }
    }
}