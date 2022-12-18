namespace TowerDefense.Client.Interpreter
{
    public class BuyHealingEnemyExpression : Expression
    {
        public override string Action { get => "buy"; set { } }
        public override string UnitType { get => "healingenemy"; set { } }
    }
}
