using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace GameDiCanh
{
    class Bullet
    {
        public string direction = "Right";// hướng đạn
        public int bulletLeft;
        public int bulletTop;// vị trí đạn
        public string tag = "bullet";
        public int timeLate = 20;// tg chờ
        public int speed = 18;// tốc độ đạn
        public PictureBox bullet = new PictureBox();
        private Timer bulletTimer = new Timer();

        public void MakeBullet(Form form, string Flag)
        {
            #region setBullet
            bullet.BackColor = System.Drawing.Color.Transparent;
            bullet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            bullet.Tag = tag;
            bullet.Left = bulletLeft;
            bullet.Top = bulletTop;
            if (Flag == "enemyBullet")
                bullet.BackgroundImage = Properties.Resources.MechaRobotAttack;
            else
                bullet.BackgroundImage = Properties.Resources.RegAttack;
            #endregion
            form.Controls.Add(bullet);
            #region setBulletTimer
            bulletTimer.Interval = timeLate;
            bulletTimer.Tick += new EventHandler(BulletTimerEvent);
            bulletTimer.Start();
            #endregion
        }
        private void BulletTimerEvent(object sender, EventArgs e)
        {
            // Tạo sự kiện bulletTimer
            // Nếu hướng đạn bên phải thì ...
            if (direction == "Right")
            {
                bullet.Left += speed;
                if (bullet.Left > 1280)
                {
                    bulletTimer.Dispose();
                    bullet.Dispose();
                }
            }

            // Nếu hướng đạn bên trái thì ...
            if (direction == "Left")
            {
                bullet.Left -= speed;
                if (bullet.Right <= 0)
                {
                    bulletTimer.Dispose();
                    bullet.Dispose();
                }
            }    
        }     
    }
}
