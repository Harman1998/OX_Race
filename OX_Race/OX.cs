using System;
using System.Drawing;
using System.Windows.Forms;

namespace OX_Race
{
    public class OX
    {
        private static int StartingPosition;
        private static int RacetrackLength;
        public PictureBox OXPictureBox = null;
        public int Location = 0;
        public static Random MyRandom = new Random(); //declared random object as static to avoid same random number

        public static int StartingPosition1 { get => StartingPosition; set => StartingPosition = value; }
        public static int RacetrackLength1 { get => RacetrackLength; set => RacetrackLength = value; }

        // generation across all OX objects

        public static bool Run(OX obj)
        {
            int distance = MyRandom.Next(1, 10);
            if (obj.OXPictureBox != null)
                obj.MoveOXPictureBox(distance);

            obj.Location += distance;
            if (obj.Location >= (RacetrackLength1 - StartingPosition1))
            {
                return true;
            }
            return false;
        }

        public void StartPosition()
        {
            MoveOXPictureBox(-Location); //reset location to -ve distance ie. to starting point
            Location = 0;

        }

        public void MoveOXPictureBox(int distance)
        {
            Point p = OXPictureBox.Location;
            p.X += distance;
            OXPictureBox.Location = p; //move OX in x-axis
        }
    }
}
