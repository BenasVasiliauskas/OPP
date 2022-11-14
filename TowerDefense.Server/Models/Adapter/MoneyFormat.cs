namespace TowerDefense.Server.Models.Adapter
{
    public class MoneyFormat : INumberFormat
    {
        public Player player;

        public MoneyFormat(Player player)
        {
            this.player = player;
        }

        public string GetHumanReadable()
        {
            if(Math.Abs(this.player.GetMoney()) >= 1000000)
            {
                //milion
                return ((double)this.player.GetMoney() / 1000000).ToString() + "M";
            }
            if(Math.Abs(this.player.GetMoney()) >= 1000)
            {
                //thousand
                return ((double)this.player.GetMoney() / 1000).ToString() + "K";
            }
            return this.player.GetMoney().ToString();
        }
    }
}
