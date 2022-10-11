namespace TowerDefense.Server.Models
{
    public class Unit
    {
        public Unit(string name)
        {
            this.name = name;
        }

        string name = "";

        public void SayHello()
        {
            Console.WriteLine();
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

    }
}
