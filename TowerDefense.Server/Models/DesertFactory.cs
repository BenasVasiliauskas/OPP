namespace TowerDefense.Server.Models
{
    public class DesertFactory : AbstractFactory
    {
        public override Unit createEnemy(string type)
        {
            if (type == "B")
            {
                return new DesertEnemyStrong("Desert Enemy");
            }
            else
            {
                return new DesertHealingEnemyStrong("Desert healing enemy");
            }
        }



        public override Unit createTower(string type)
        {
            if (type == "S")
            {
                return new DesertTowerSingleShotBig("Desert level single shot Tower");
            }
            else
            {
                return new DesertTowerAOEBig("Desert level aoe Tower");
            }
        }

    }
}
