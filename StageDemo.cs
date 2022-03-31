using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameDiCanh
{
    public partial class StageDemo : Form
    {
        bool goLeft, goRight, jumping, isGameOver;

        int jumpSpeed = 10;
        int force;
        int playerSpeed = 7;

        int horizontalSpeed = 5;
        int verticalSpeed = 3;

        int enemySpeed = 5;
        public StageDemo()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void StageDemo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                goLeft = false;
            if (e.KeyCode == Keys.Right)
                goRight = false;
            if (jumping == true)
                jumping = false;
            if (e.KeyCode == Keys.Enter && isGameOver == true)
                RestartGame();
        }

        private void StageDemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                goLeft = true;
            if (e.KeyCode == Keys.Right)
                goRight = true;
            if (e.KeyCode == Keys.Up && jumping == false)
                jumping = true;
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            if (goLeft == true)
                player.Left -= playerSpeed;
            if (goRight == true)
                player.Left += playerSpeed;
            if (jumping == true && force < 0)
                jumping = false;
            if (jumping == true)
            {
                jumpSpeed -= 8;
                force -= 1;
            }
            else
                jumpSpeed = 10;

            foreach (Control x in this.Controls)
                if ((string)x.Tag == "Ground")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        force = 8;
                        player.Top = x.Top - player.Height;
                    }
                    x.BringToFront();
                }
                    
        }

        private void RestartGame()
        {
            jumping = false;
            goLeft = false;
            goRight = false;
            isGameOver = false;
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Visible == false)
                    x.Visible = true;
            }

            player.Left = 184;
            player.Top = 395;


            
            MyTimer.Start();
        }
    }
}
