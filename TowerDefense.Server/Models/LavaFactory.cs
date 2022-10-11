namespace TowerDefense.Server.Models
{
    public class LavaFactory : AbstractFactory
    {
        public override Unit createEnemy(string type)
        {
            if (type == "B")
            {
                return new LavaEnemyWeak("Lava Enemy");
            }
            else
            {
                return new LavaHealingEnemyWeak("Lava healing enemy");
            }
        }



        public override Unit createTower(string type)
        {
            if (type == "S")
            {
                return new LavaTowerSingleShotSmall("Lava level single shot Tower");
            }
            else
            {
                return new LavaHealingEnemyWeak("Lava level aoe Tower");
            }
        }
    }
}
