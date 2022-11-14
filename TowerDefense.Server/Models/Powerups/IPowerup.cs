namespace TowerDefense.Server.Models.Powerups
{
    public interface IPowerup
    {
        public void execute();

        public void undo();
    }
}
