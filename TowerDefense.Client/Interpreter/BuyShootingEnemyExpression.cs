namespace TowerDefense.Client.Interpreter
{
    public class BuyShootingEnemyExpression : Expression
    {
        public override string Action { get => "buy"; set { } }
        public override string UnitType { get => "shootingenemy"; set { } }
    }
}
