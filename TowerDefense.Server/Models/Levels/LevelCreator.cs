namespace TowerDefense.Server.Models.Levels
{
    public class LevelCreator
    {
        public ILevel FactoryMethod(string level)
        {
            if (level == "lava")
            {
                return new LavaLevel();
            }
            else if (level == "water")
            {
                return new WaterLevel();
            }
            else if (level == "desert")
            {
                return new DesertLevel();
            }
            return null;
        }
    }
}
