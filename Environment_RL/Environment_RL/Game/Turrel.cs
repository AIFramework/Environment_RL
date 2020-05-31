
using System.Drawing;

namespace Environment_RL.Game
{
    class Turrel : IGameObj
    {
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public int H { get; set; }
        public int W { get; set; }
        public bool IsDestroyed { get; set; }

        Bitmap sprite;

        public Turrel()
        {
            int h = 7, w = 22, h2 = 15, w2= 7;

            sprite = new Bitmap(w, h2);
            using (Graphics box = Graphics.FromImage(sprite))
            {

                box.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, h2-h, w, h));
                box.FillRectangle(new SolidBrush(Color.Black), new Rectangle(w/2-w2/2, 0, w2, h2));

            }

            CoordX = 0;
            CoordY = 0;
            H = h2;
            W = w;
        }

        public Bitmap GetSprite()
        {
            return sprite;
        }
    }
}
