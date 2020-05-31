using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Environment_RL.Game;

namespace Environment_RL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            mainGame.Complite += MainGame_Complite;
        }

        private void MainGame_Complite(int obj)
        {
            mainGame = new MainGame(300, 240);
            mainGame.Complite += MainGame_Complite;
        }

        MainGame mainGame = new MainGame(300, 240);

        private void Fps_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = mainGame.GetBitmap();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                mainGame.Action(1);
            }
            if (e.KeyCode == Keys.A)
            {
                mainGame.Action(2);
            }

            if (e.KeyCode == Keys.W)
            {
                mainGame.Action(3);
            }
        }
    }
}
