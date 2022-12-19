using TowerDefense.Server.Models.Enemies;

namespace TowerDefense.Server.Models.Composite
{
    public interface IComponent
    {
        public abstract Enemy MakeDeepCopy();

        public virtual void Add(IComponent component)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(IComponent component)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsComposite()
        {
            return true;
        }

    }
}
