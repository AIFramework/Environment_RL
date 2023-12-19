using EnvLib.GameTurrel;
using System;
using System.Windows.Forms;

namespace EnvLib
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
            mainGame = new MainGameTurrel(300, 240);
            mainGame.Complite += MainGame_Complite;
        }

        MainGameTurrel mainGame = new MainGameTurrel(300, 240);
        int cf = 0;

        private void Fps_Tick(object sender, EventArgs e)
        {
            mainGame.Tick();
            if (cf % 15 == 0)
                pictureBox1.Image = mainGame.GetBitmap();
            chartVisual1.BarBlack(mainGame.State);
            cf++;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            KD(e);
        }

        private void chartVisual1_KeyDown(object sender, KeyEventArgs e)
        {
            KD(e);
        }

        private void KD(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
                mainGame.Action(1);

            if (e.KeyCode == Keys.A)
                mainGame.Action(2);

            if (e.KeyCode == Keys.W)
                mainGame.Action(3);
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            KD(e);
        }
    }
}
