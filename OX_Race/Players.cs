using System.Windows.Forms;

namespace OX_Race
{
    public class Harman : Punter
    {
        public Harman(Bet MyBet, Label MaximumBet, int Money, Label MyLabel) : base(MyBet, MaximumBet, Money, MyLabel)
        {
        }

        public override void setPunterName()
        {
            Title = "Harman";
        }
    }

    public class Kalu : Punter
    {
        public Kalu(Bet bet, Label MaximumBet, int Money, Label label) : base(bet, MaximumBet, Money, label)
        {
        }

        public override void setPunterName()
        {
            Title = "Kalu";
        }
    }

    public class Raj : Punter
    {
        public Raj(Bet bet, Label MaximumBet, int Money, Label label) : base(bet, MaximumBet, Money, label)
        {
        }

        public override void setPunterName()
        {
            Title = "Raj";
        }
    }
}
