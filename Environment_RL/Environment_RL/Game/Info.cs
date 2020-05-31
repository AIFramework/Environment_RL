using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Environment_RL.Game
{
    public class Info : IGameObj
    {
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public int H { get; set; }
        public int W { get; set; }
        public bool IsDestroyed { get; set; }
        bool flagMove = true;
        Bitmap bitmap;

        public Info()
        {


            int h = 47, w = 97;

            bitmap = new Bitmap(h,w);

            CoordX = 0;
            CoordY = 0;
            H = h;
            W = w;
        }

        public void GetSprite(int score, int time)
        {
            bitmap = new Bitmap(W, H);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                Font font = new Font("Calibri", 9);
                graphics.DrawString("Score: " + score, font, new SolidBrush(Color.Red), new Point(0, 0));
                graphics.DrawString("Time: " + time, font, new SolidBrush(Color.Red), new Point(0, 20));
            }
        }

        public Bitmap GetSprite()
        {
            return bitmap;
        }
    }
}
