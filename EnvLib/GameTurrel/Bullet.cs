using System.Drawing;

namespace EnvLib.GameTurrel
{
    public class Bullet : IGameObj
    {
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public int H { get; set; }
        public int W { get; set; }
        public bool IsDestroyed { get; set; }

        Bitmap sprite;

        public Bullet()
        {
            sprite = new Bitmap(7, 7);
            using (Graphics bull = Graphics.FromImage(sprite))
            {

                bull.FillEllipse(new SolidBrush(Color.Red), new Rectangle(0, 0, 7, 7));
            }

            CoordX = 0;
            CoordY = 0;
            H = 7;
            W = 7;
        }

        public void Update() => CoordY -= 3;

        public Bitmap GetSprite() => sprite;

    }
}
