using System.Drawing;

namespace EnvLib.GameTurrel
{
    public class Info : IGameObj
    {
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public int H { get; set; }
        public int W { get; set; }
        public bool IsDestroyed { get; set; }
        bool flagMove = true;
        Bitmap sprite;

        public Info()
        {


            int h = 47, w = 97;

            sprite = new Bitmap(h, w);

            CoordX = 0;
            CoordY = 0;
            H = h;
            W = w;
        }

        public void GetSprite(int score, int time)
        {
            sprite = new Bitmap(W, H);
            using (Graphics graphics = Graphics.FromImage(sprite))
            {
                Font font = new Font("Calibri", 9);
                graphics.DrawString("Score: " + score, font, new SolidBrush(Color.Red), new Point(0, 0));
                graphics.DrawString("Time: " + time, font, new SolidBrush(Color.Red), new Point(0, 20));
            }
        }

        public Bitmap GetSprite() => sprite;

        public void Update()
        {
        }
    }
}
