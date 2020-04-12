using System;
using System.Windows.Forms;

namespace OX_Race
{
    public class PlayerFactory
    {
        public Punter getPunter(String Name, Label MaximumBet, Label bet)
        {
            Punter p;
            switch (Name.ToLower())
            {
                case "harman":
                    p = new Harman(null, MaximumBet, 50, bet);
                    break;

                case "raj":
                    p = new Raj(null, MaximumBet, 50, bet);
                    break;

                case "kalu":
                    p = new Kalu(null, MaximumBet, 50, bet);
                    break;

                default:
                    p = null;
                    break;
            }
            p.setPunterName();
            return p;
        }
    }
}
