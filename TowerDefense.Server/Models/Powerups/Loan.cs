namespace TowerDefense.Server.Models.Powerups
{
    public class Loan : IPowerup
    {
        public int LoanAmount = 1000;
        public Player player { get; set; }

        public Loan(Player player)
        {
            this.player = player;
        }

        public void execute()
        {
            this.player.Money += LoanAmount;
        }

        public void undo()
        {
            this.player.Money -= LoanAmount;
        }
    }
}
