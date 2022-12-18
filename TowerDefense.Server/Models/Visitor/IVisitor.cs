using TowerDefense.Server.Models.Enemies;

namespace TowerDefense.Server.Models.Visitor
{
    public interface IVisitor
    {
        void VisitEnemy(Enemy enemy);
    }
}
