using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Environment_RL.Game
{
    public class Box : IGameObj
    {
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public int H { get; set; }
        public int W { get; set; }
        public bool IsDestroyed { get; set; }
        Random random = new Random();
        bool flagMove = true;

        Bitmap sprite;

        public Box()
        {
            int h = 7, w = 17;

            sprite = new Bitmap(w, h);
            using (Graphics box = Graphics.FromImage(sprite))
            {

                box.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, w, h));
            }

            CoordX = 0;
            CoordY = 0;
            H = h;
            W = w;
        }

        public Bitmap GetSprite()
        {
            if (flagMove)
            {
                CoordY -= 1;
            }
            else
            {
                CoordY += 1;
            }

            flagMove = !flagMove;

            return sprite;
        }
    }
}
