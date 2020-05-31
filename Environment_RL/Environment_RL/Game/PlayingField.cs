using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Environment_RL.Game
{
    public class PlayingField : List<IGameObj>
    {
       
        public int W { get; set; }
        public int H { get; set; }
        public Color BackGround { get; set; }

        /// <summary>
        /// Игровое поле
        /// </summary>
        /// <param name="w">Разрешение по ширине</param>
        /// <param name="h">Разрешение по высоте</param>
        /// <param name="backColor">Фон</param>
        public PlayingField(int w, int h, Color backColor)
        {
            W = w;
            H = h;
            BackGround = backColor;
        }


        /// <summary>
        /// Отрисовка игровых сущностей
        /// </summary>
        public Bitmap Draw()
        {
            Bitmap bitmap = new Bitmap(W,H);
            Destroyer(); 

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(BackGround);

                for (int i = 0; i < Count; i++)
                {
                    int coordX = this[i].CoordX;
                    int coordY = this[i].CoordY;

                    bool xCond = W > coordX && coordX > -this[i].W,
                         yCond = H > coordY && coordY >= 0;

                    if (xCond && yCond)
                    {
                        int coordEndX = this[i].CoordX + this[i].W;
                        int coordEndY = this[i].CoordY + this[i].H;

                        coordEndX = (coordEndX < W) ? coordEndX : W;
                        coordEndY = (coordEndY < H) ? coordEndY : H;

                        int h = coordEndY - coordY;
                        int w = coordEndX - coordX;
                        graphics.DrawImage(this[i].GetSprite(), new Rectangle(coordX, coordY, w, h), new Rectangle(0, 0, w, h), GraphicsUnit.Pixel);
                    }
                }
            }

            return bitmap;
        }

        void Destroyer()
        {
            RemoveAll(x => x.IsDestroyed);
        }
    }
}
