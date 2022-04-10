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
        // goLeft: di chuyển sang trái, goRight: di chuyển sang phải
        // jumping: đang nhảy, shoot: đang bắn, hold: đang đứng yên
        // grounding: đang chạm đất, rotate: nhận vật đang xoay sang phải
        bool goLeft, goRight, jumping, shoot = false, hold = true, grounding = true, rotate = false;
        int jumpSpeed = 20;
        int force;
        int playerSpeed = 7;
        int score;
        
        Random rnd = new Random();


        public StageDemo()
        {
            InitializeComponent();
            /* RestartGame();*/
            
        }

        private void StageDemo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right&!hold && goLeft != true) 
            { 
                goRight = false;
                hold = true;
                // Đứng yên hướng về bên phải
                player.Image = Properties.Resources.standing;
            }
            else if (e.KeyCode == Keys.Left&!hold && goRight != true) 
            { 
                goLeft = false;
                hold = true;
                // Đứng yên hướng về bên trái
                player.Image = Properties.Resources.standing_rotate;
            }
            if (e.KeyCode == Keys.Space && GameManager.isGameOver == false && shoot == true)
            {
                SpawnBullet();
                player.Image = Properties.Resources.standing;
                shoot = false;
            }
        }

        private void StageDemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right & hold && goLeft != true)
            {
                goRight = true;
                hold = false;
                // Di chuyển sang phải
                player.Image = Properties.Resources.moving;
                rotate = false;
            }

            else if (e.KeyCode == Keys.Left & hold & goRight != true) 
            { 
                goLeft = true;
                hold = false;
                // Di chuyển sang trái
                player.Image = Properties.Resources.moving_rotate;
                rotate = true;
            }

            if (jumping != true)
            {
                if (e.KeyCode == Keys.Up & !rotate)
                {
                    jumping = true;
                    force = jumpSpeed;
                    hold = false;
                    // Nhảy hướng về bên phải
                    player.Image = Properties.Resources.jump;
                    grounding = false;
                }
                if (e.KeyCode == Keys.Up & rotate)
                {
                    jumping = true;
                    force = jumpSpeed;
                    hold = false;
                    // Nhảy hướng về bên phải
                    player.Image = Properties.Resources.jump_rotate;
                    grounding = false;
                }
            }  
            if(e.KeyCode == Keys.Space) 
            { 
                shoot = true;
                player.Image = Properties.Resources.shoot;
            }
           
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
                // Set animation khi nhân vật tiếp đất
                player.Top = this.Height - pictureBox1.Height - player.Height;
                jumping = false;
                // keep moving to right
                if (!grounding & goRight)
                {
                    player.Image = Properties.Resources.moving;
                    grounding = true;
                }
                // keep moving to left
                if (!grounding & goLeft)
                {
                    player.Image = Properties.Resources.moving_rotate;
                    grounding = true;
                }
                // hold to right
                if (!grounding & !hold & !rotate)
                {
                    player.Image = Properties.Resources.standing;
                    grounding = true;
                    hold = true;
                }
                // hold to left
                if (!grounding & rotate & !hold)
                {
                    player.Image = Properties.Resources.standing_rotate;
                    grounding = true;
                    hold = true;
                }
            }
            #endregion player movement logic ends


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