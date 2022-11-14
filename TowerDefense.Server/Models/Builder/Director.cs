namespace TowerDefense.Server.Models.Builder
{
    public class Director
    {
        public void ConstructWaterHealingEnemy(IBuilder builder)
        {
            builder.SetHealth(1000);
            builder.SetDamage(10);
            builder.SetImage("/Images/Enemies/blue_cross.png");
        }
        public void ConstructWaterShootingEnemy(IBuilder builder)
        {
            builder.SetHealth(500);
            builder.SetDamage(20);
            builder.SetImage("/Images/Enemies/blue_gun.png");
        }
        public void ConstructLavaHealingEnemy(IBuilder builder)
        {
            builder.SetHealth(2000);
            builder.SetDamage(20);
            builder.SetImage("/Images/Enemies/red_cross.png");
        }
        public void ConstructLavaShootingEnemy(IBuilder builder)
        {
            builder.SetHealth(1000);
            builder.SetDamage(40);
            builder.SetImage("/Images/Enemies/red_gun.png");
        }
        public void ConstructDesertHealingEnemy(IBuilder builder)
        {
            builder.SetHealth(4000);
            builder.SetDamage(40);
            builder.SetImage("/Images/Enemies/yellow_cross.png");
        }
        public void ConstructDesertShootingEnemy(IBuilder builder)
        {
            builder.SetHealth(2000);
            builder.SetDamage(80);
            builder.SetImage("/Images/Enemies/yellow_gun.png");
        }
    }
}
