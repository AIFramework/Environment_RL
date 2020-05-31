﻿using System;
using System.Drawing;

namespace Environment_RL.Game
{
    public class MainGame
    {
        PlayingField gameObjs;
        Turrel turrel;
        Info info = new Info();
        int _w, _h;
        public int Score { get; set; }
        double time = 30;
        Random random = new Random();

        /// <summary>
        ///  Игровая логика
        /// </summary>
        /// <param name="W"></param>
        /// <param name="H"></param>
        public MainGame(int W, int H)
        {
            Complite += MainGame_Complite;
            Score = 0;
            _w = W;
            _h = H;
            gameObjs = new PlayingField(W, H, Color.White); // Игровое поле
            
            turrel = new Turrel(); // Турель
            turrel.CoordX = W / 2 - turrel.W / 2;
            turrel.CoordY =  H - turrel.H+1;
            gameObjs.Add(turrel);


            info.CoordY  = H / 2 - info.H / 2;
            gameObjs.Add(info); // Информация

            // Добавление блоков
            for (int i = 0; i < 7; i++)
            {
                Box box = new Box();
                box.CoordX = i * 30 + 5;
                box.CoordY = random.Next(1, H / 7);
                gameObjs.Add(box);
            }


            
        }
        

        public Bitmap GetBitmap()
        {
            BulletCollision();
            time -= 0.03;

            info.GetSprite(Score, (int)time);

            if ((int)time == 0)
                Complite(Score);

            return gameObjs.Draw();
        }

        // Попадание пулей
        void BulletCollision()
        {

            for (int i = 0; i < gameObjs.Count; i++)
            {
                if (gameObjs[i] is Bullet)
                {
                    for (int j = 0; j < gameObjs.Count; j++)
                    {
                        if (gameObjs[j] is Box)
                        {
                            if (
                                Physics.IsColision(gameObjs[i], gameObjs[j])
                                )
                            {
                                gameObjs[i].IsDestroyed = true;
                                gameObjs[j].IsDestroyed = true;
                                Score++;
                                Box box = new Box();
                                box.CoordX = random.Next(1, _w );
                                box.CoordY = random.Next(1, _h / 7);
                                gameObjs.Add(box);
                            }
                        }
                    }
                }
            }
        }

        // Действия
        public void Action(int act)
        {
            switch (act)
            {
                case 0:
                    break;
                case 1:
                    turrel.CoordX += 3;
                    break;
                case 2:
                    turrel.CoordX -= 3;
                    break;
                case 3:
                    Bullet bullet = new Bullet();
                    bullet.CoordX = turrel.CoordX + turrel.W / 2-bullet.W/2;
                    bullet.CoordY = _h - turrel.H;
                    gameObjs.Add(bullet);
                    break;

            }
        }

        // Заглушка
        private void MainGame_Complite(int obj)
        {

        }
        public event Action<int> Complite;
    }
}
