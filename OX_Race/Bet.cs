namespace OX_Race
{
    public class Bet
    {
        public int Amount;
        public int OXNum;
        public Punter Bettor;

        public Bet(int Amount, int OXNum, Punter Bettor)
        {
            this.Amount = Amount;
            this.OXNum = OXNum;
            this.Bettor = Bettor;
        }

        public string GetDescription()
        {
            string description = "";

            if (Amount > 0)
            {
                description = string.Format("{0} bets {1} on OX #{2}",
                    Bettor.Title, Amount, OXNum);
            }
            else
            {
                description = string.Format("{0} hasn't placed any bets",
                    Bettor.Title);
            }
            return description;
        }

        public int Pay(int Winner)
        {
            if (OXNum == Winner)
            {
                return Amount;
            }
            return -Amount;
        }
    }
}
