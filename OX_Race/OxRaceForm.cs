using System;
using System.Windows.Forms;

namespace OX_Race
{
    public partial class OxRaceForm : Form
    {
        OX[] OXs = new OX[4];

        PlayerFactory pFactory = new PlayerFactory();
        Punter[] punters = new Punter[3];

        public OxRaceForm()
        {
            InitializeComponent();
            SetupRaceTrack();
        }

        private void SetupRaceTrack()
        {

            OX.StartingPosition1 = OX1.Right - racetrack.Left;
            OX.RacetrackLength1 = racetrack.Size.Width - 70; //fixing length of race - till finish line

            OXs[0] = new OX() { OXPictureBox = OX1 };
            OXs[1] = new OX() { OXPictureBox = OX2 };
            OXs[2] = new OX() { OXPictureBox = OX3 };
            OXs[3] = new OX() { OXPictureBox = OX4 };

            punters[0] = pFactory.getPunter("Harman", MaximumBet, HarmanBet); //getting Harman object from factory class
            punters[1] = pFactory.getPunter("Raj", MaximumBet, RajBet); //getting Raj object from factory class
            punters[2] = pFactory.getPunter("Kalu", MaximumBet, KaluBet); //getting Kalu object from factory class


            foreach (Punter punter in punters)
            {
                punter.UpdateLabels();
            }
        }

        private void HarmanButton_CheckedChanged(object sender, EventArgs e)
        {
            setMaximumBetTextLabel(punters[0].money);
        }

        private void RajButton_CheckedChanged(object sender, EventArgs e)
        {
            setMaximumBetTextLabel(punters[1].money);
        }

        private void KalueButton_CheckedChanged(object sender, EventArgs e)
        {
            setMaximumBetTextLabel(punters[2].money);
        }

        private void setMaximumBetTextLabel(int Cash)
        {
            MaximumBet.Text = string.Format("Maximum Bet: ${0}", Cash);
        }

        // setting the bet for each Punter and updating labels respectively
        private void Bets_Click(object sender, EventArgs e)
        {
            int PunterNum = 0;

            if (HarmanButton.Checked)
            {
                PunterNum = 0;
            }
            if (RajButton.Checked)
            {
                PunterNum = 1;
            }
            if (KaluButton.Checked)
            {
                PunterNum = 2;
            }

            punters[PunterNum].PlaceBet((int)BettingAmount.Value, (int)OXNumber.Value);
            punters[PunterNum].UpdateLabels();
        }

        private void race_Click(object sender, EventArgs e)
        {
            bool NoWinner = true;
            int winningOX;
            race.Enabled = false; //disable start race button

            while (NoWinner)
            { // loop until we have a winner
                Application.DoEvents();
                for (int i = 0; i < OXs.Length; i++)
                {
                    if (OX.Run(OXs[i]))
                    {
                        winningOX = i + 1;
                        NoWinner = false;
                        MessageBox.Show("We have a winner - OX #" + winningOX);
                        foreach (Punter punter in punters)
                        {
                            if (punter.gamble != null)
                            {
                                punter.Collect(winningOX); //give double amount to all who've won or deduce betted amount
                                punter.gamble = null;
                                punter.UpdateLabels();
                            }
                        }
                        foreach (OX OX in OXs)
                        {
                            OX.StartPosition();
                        }
                        break;
                    }
                }
            }
            if (punters[0].busted && punters[1].busted && punters[2].busted)
            {  //stop punters from betting if they run out of cash
                string message = "Do you want to Play Again?";
                string title = "GAME OVER!";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    SetupRaceTrack(); //restart game
                }
                else
                {
                    Close();
                }

            }
            race.Enabled = true; //enable race button 
        }

    }
}
