using TowerDefense.Server.Models.Strategies;
using TowerDefense.Server.Observers;

namespace TowerDefense.Server.Models.Strategies
{
    public interface IUnitTemplate
    {
        public abstract void Orient();
        public abstract void Do();
        public virtual void Hook1() { }

        public void Act()
        {
            Orient();
            Hook1();
            Do();
        }
    }
}