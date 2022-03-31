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
        bool goLeft, goRight, jumping, isGameOver, shooting;

        int jumpSpeed = 20;
        int force;
        int playerSpeed = 7;
        int bulletSpeed = 20;

        List<PictureBox> bulletList=new List<PictureBox>();

        Random rnd = new Random();

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
            if (e.KeyCode == Keys.Right) { goRight = false; }
            if (e.KeyCode == Keys.Left) { goLeft = false; }
            if (e.KeyCode == Keys.Space && isGameOver == false)
            {
                SpawnBullet();
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
   

        }

        private void SpawnBullet()
        {
            Bullet spawnBullet = new Bullet();
            spawnBullet.bulletLeft = player.Left;
            spawnBullet.bulletTop = player.Top + player.Height/3;
            spawnBullet.MakeBullet(this);
        }

        private void RestartGame()
        {
            
        }
    }
}
