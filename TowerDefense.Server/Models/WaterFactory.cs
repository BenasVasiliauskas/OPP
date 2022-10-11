namespace TowerDefense.Server.Models
{
    internal class WaterFactory : AbstractFactory
    {
        public override Unit createEnemy(string type)
        {
            if (type == "B")
            {
                return new WaterEnemyAverage("Water Enemy");
            }
            else
            {
                return new WaterHealingEnemyAverage("Water healing enemy");
            }
        }



        public override Unit createTower(string type)
        {
            if (type == "S")
            {
                return new WaterTowerSingleShotMedium("Water level single shot Tower");
            }
            else
            {
                return new WaterTowerAOEMedium("Water level aoe Tower");
            }
        }

    }

}