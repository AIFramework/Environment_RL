using System;
using System.Drawing;

namespace EnvLib.GameTurrel
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

        public Bitmap GetSprite() => sprite;


        public void Update()
        {
            if (flagMove) CoordY -= 1;
            else CoordY += 1;

            flagMove = !flagMove;
        }
    }
}
