using TowerDefense.Server.Models.Enemies;

namespace TowerDefense.Server.Models.Iterator
{
    public interface IUnitCollection
    {
        IEnumerator<Enemy> GetEnumerator();
    }
}
