using TowerDefense.Server.Models.Enemies;

namespace TowerDefense.Server.Models.Strategies
{
    public abstract class State
    {
        protected Enemy _unit;

        public void SetUnit(Enemy unit)
        {
            this._unit = unit;
        }

        public abstract void Statement();
    }
}
