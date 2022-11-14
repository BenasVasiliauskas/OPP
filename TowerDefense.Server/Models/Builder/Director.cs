namespace TowerDefense.Server.Models.Builder
{
    public class Director
    {
        public void ConstructHealingEnemy(IBuilder builder)
        {
            builder.SetHealth(1000);
            builder.SetDamage(10);
            builder.SetImage("/Images/Enemies/priest.png");
        }
        public void ConstructShootingEnemy(IBuilder builder)
        {
            builder.SetHealth(500);
            builder.SetDamage(20);
            builder.SetImage("/Images/Enemies/man-with-gun.png");
        }
    }
}
