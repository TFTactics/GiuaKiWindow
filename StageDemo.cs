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
        bool goLeft, goRight, jumping, shoot;
        int jumpSpeed = 20;
        int force;
        int playerSpeed = 7;
        int score;

        Random rnd = new Random();


        public StageDemo()
        {
            InitializeComponent();
            RestartGame();
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void StageDemo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) { goRight = false; }
            if (e.KeyCode == Keys.Left) { goLeft = false; }
            if (e.KeyCode == Keys.Space && GameManager.isGameOver == false && shoot == true)
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

        private void mechaBot_Click(object sender, EventArgs e)
        {

        }

        private void StageDemo_Load(object sender, EventArgs e)
        {

        }

        private void StageDemo_Load_1(object sender, EventArgs e)
        {

        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score.ToString();

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

            #region bullet || player collison enemy
            foreach (Control y in this.Controls)
                foreach (Control x in this.Controls)
                {
                    if ((string)x.Tag == "Enemy")
                    {
                        if ((string)y.Tag == "bullet_of_enemy" && player.Bounds.IntersectsWith(y.Bounds))
                        {
                            gameOver();
                        }
                        if (y.Bounds.IntersectsWith(x.Bounds) && (string)y.Tag == "bullet")
                        {
                            x.Tag = "deathEnemy";
                            x.Dispose();
                            y.Dispose();
                            score += 1;
                            CreateNewEnemy();
                            
                        }
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameOver();
                        }
                    }
                    // Player collison enemy bullet
                }
            #endregion
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void SpawnBullet()
        {
            Bullet spawnBullet = new Bullet();
            spawnBullet.bulletLeft = player.Left - 2;
            spawnBullet.bulletTop = player.Top + player.Height/4;
            spawnBullet.MakeBullet(this, "playerBullet");
        }

        private void CreateNewEnemy()
        {
            Enemy enemy = new Enemy(this);
            enemy.enemyLeft = rnd.Next(1200, 1280);
            enemy.enemyTop = rnd.Next(460, 470);
            enemy.MakeMechaBot();
            enemy.health = 3;
        }

        private void RestartGame()
        {
            score = 0;
            CreateNewEnemy();
            player.Top = 565;
            player.Left = 200;
            player.Show();
            MyTimer.Start();

            txtScore.Text = "Score: " + score.ToString();   
        }
        private void movShoot()
        {
            // tạo hiệu ảnh chuyển động khi player bắn đạn
            if (shoot)
                player.BackgroundImage = Properties.Resources._1;
            else
                player.BackgroundImage = Properties.Resources._0;
        }

        private void gameOver()
        {
            GameManager.isGameOver = true;
            player.Hide();
            MyTimer.Stop();
            DialogResult result = MessageBox.Show("Game Over","Continue ???", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                GameManager.isGameOver = false;
                RestartGame();
            }
            else
            {
                this.Close();
            }
        }
        
    }
}