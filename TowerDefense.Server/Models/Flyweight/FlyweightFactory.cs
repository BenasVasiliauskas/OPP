namespace TowerDefense.Server.Models.Flyweight
{
    public class FlyweightFactory
    {
        private readonly IDictionary<UnitFlyweight, UnitFlyweight> _flyweights = new Dictionary<UnitFlyweight, UnitFlyweight>();

        public UnitFlyweight GetFlyweight(UnitFlyweight unitFlyweight)
        {
            if (_flyweights.ContainsKey(unitFlyweight))
            {
                return _flyweights[unitFlyweight];
            }

            _flyweights[unitFlyweight] = unitFlyweight;
            return unitFlyweight;
        }
    }
}
