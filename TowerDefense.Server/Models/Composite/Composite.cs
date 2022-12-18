using TowerDefense.Server.Models.Enemies;

namespace TowerDefense.Server.Models.Composite
{
    public class Composite : IComponent
    {
        protected List<IComponent> _children = new List<IComponent>();

        public void Add(IComponent component)
        {
            this._children.Add(component);
        }

        public void Remove(IComponent component)
        {
            this._children.Remove(component);
        }

        public Enemy MakeDeepCopy() { return null; }
    }
}
