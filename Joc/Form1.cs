using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Joc
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 10;
        int score = 0;



        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreg.Text = "Score: " + score;

            if (pipeBottom.Left < -50)
            {
                pipeBottom.Left = 600;
                score++;
            }
            if (pipeTop.Left < -80)
            {
                pipeTop.Left = 650;
                score++;
            }
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -25
                )
            {
                endGame();
            }

                if (score > 5)
            { 
                    pipeSpeed = 25;
            }
            


        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }

        }
        private void endGame()
        {
            gameTimer.Stop();
            scoreg.Text += "  Jocul a luat sfarsit!";
            MessageBox.Show("Jocul a luat sfarsit! " + Environment.NewLine + " Apasa OK pentru a iesi din joc");
            this.Close();
        }
        private void scoreg_Click(object sender, EventArgs e)
        {

        }
    }
}
