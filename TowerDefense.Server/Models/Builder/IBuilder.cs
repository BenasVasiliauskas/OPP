namespace TowerDefense.Server.Models.Builder
{
    public interface IBuilder
    {
        void SetHealth(int health);
        void SetDamage(int damage);
        void SetImage(string path);
    }
}
