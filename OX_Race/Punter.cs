using System;
using System.Windows.Forms;

namespace OX_Race
{
    public abstract class Punter
    {
        public string Title;
        public Bet gamble;
        public int money;
        public bool busted;
        public Label statusLabel, MaximumBet;

        public abstract void setPunterName();

        public Punter(Bet bet, Label MaximumBet, int Cash, Label statusLabel)
        {
            this.gamble = bet;
            this.money = Cash;
            this.MaximumBet = MaximumBet;
            this.statusLabel = statusLabel;
            if (this.statusLabel != null)
                this.statusLabel.ForeColor = System.Drawing.Color.Black;

        }
        public void Collect(int Winner)
        {
            money += gamble.Pay(Winner);
        }
        public void UpdateLabels()
        {
            if (gamble == null)
            {
                statusLabel.Text = String.Format("{0} hasn't placed any bets", Title);
            }

            else
            {
                statusLabel.Text = gamble.GetDescription();
            }
            if (money == 0)
            {
                busted = true;
                statusLabel.Text = String.Format("BUSTED!");
                statusLabel.ForeColor = System.Drawing.Color.Red;

            }
            MaximumBet.Text = String.Format("Maximum Bet: ${0}", money);
        }


        public void ClearBet()
        {
            gamble.Amount = 0;
        }

        public bool PlaceBet(int Amount, int OX)
        {
            if (Amount <= money)
            {
                gamble = new Bet(Amount, OX, this);
                return true;
            }
            return false;
        }

    }
}
