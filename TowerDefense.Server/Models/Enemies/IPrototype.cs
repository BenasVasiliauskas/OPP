namespace TowerDefense.Server.Models.Enemies
{
    public interface IPrototype
    {
        public Enemy MakeShallowCopy();
        public Enemy MakeDeepCopy();
    }
}
