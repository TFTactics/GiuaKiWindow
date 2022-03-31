﻿using System;
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
        bool goLeft, goRight, jumping, isGameOver, shoot;

        int jumpSpeed = 20;
        int force;
        int playerSpeed = 7;

        List<PictureBox> bulletList=new List<PictureBox>();

        Random rnd = new Random();

        public StageDemo()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void StageDemo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) { goRight = false; }
            if (e.KeyCode == Keys.Left) { goLeft = false; }
            if (e.KeyCode == Keys.Space && isGameOver == false && shoot == true)
            {
                SpawnBullet();
                shoot = false;
            }
        }


        private void bullet1_Click(object sender, EventArgs e)
        {

        }

        private void StageDemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) { goRight = true; }
            if (e.KeyCode == Keys.Left) { goLeft = true; }

            if (jumping != true)
            {
                if (e.KeyCode == Keys.Up)
                {
                    jumping = true;
                    force = jumpSpeed;
                }
            }  
            if(e.KeyCode == Keys.Space) { shoot = true; }
           
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {

            #region player movement logic starts
            if (goRight == true && player.Right < 1280)
            {
                player.Left += playerSpeed;
            }
            if (goLeft == true && player.Left > 0)
            {
                player.Left -= playerSpeed;
            }

            if (jumping == true)
            {
                player.Top -= force;
                force -= 1;
            }

            if (player.Top + player.Height >= this.Height - pictureBox1.Height)
            {
                player.Top = this.Height - pictureBox1.Height - player.Height;
                jumping = false;
            }
            #endregion player movement logic ends


            movShoot();


            #region enemy movement
            if (mechaBot.Top + mechaBot.Height >= this.Height - pictureBox1.Height)
            {
                mechaBot.Top = this.Height - pictureBox1.Height - mechaBot.Height;
            }
            // BOT collison Ground
            // BOT JUMP
            #endregion


            #region bullet || player collison enemy
            foreach(Control y in this.Controls)
            foreach(Control x in this.Controls)
                {
                    if ((string)x.Tag == "Enemy")
                        {
                            if (y.Bounds.IntersectsWith(x.Bounds) && (string)y.Tag == "bullet")
                            {
                                x.Visible = false;
                                y.Visible = false;
                            }
                            if (player.Bounds.IntersectsWith(x.Bounds))
                            {
                                player.Visible = false;
                                MyTimer.Stop();
                                MessageBox.Show("Game Over");
                            }
                        }
                    // Player collison enemy bullet
                    }
            #endregion
        }

        public void SpawnBullet()
        {
            Bullet spawnBullet = new Bullet();
            spawnBullet.bulletLeft = player.Left;
            spawnBullet.bulletTop = player.Top + player.Height/4;
            spawnBullet.MakeBullet(this);
        }

        private void RestartGame()
        {
            
        }

        private void movShoot()
        {
            if (shoot)
                player.BackgroundImage = Properties.Resources._1;
            else
                player.BackgroundImage = Properties.Resources._0;
        }
    }
}
