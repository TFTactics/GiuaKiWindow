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
        public string direction = "Right";
        public int bulletLeft;
        public int bulletTop;

        public int timeLate = 20;
        public int speed = 20;
        public PictureBox bullet = new PictureBox();
        private Timer bulletTimer = new Timer();


        public void MakeBullet(Form form)
        {
            bullet.BackColor = System.Drawing.Color.Transparent;
            bullet.BackgroundImage = global::GameDiCanh.Properties.Resources.RegAttack;
            bullet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            bullet.Name = "bullet";
            bullet.TabStop = false;
            bullet.Tag = "bullet";
            bullet.Left = bulletLeft;
            bullet.Top = bulletTop;
            
            form.Controls.Add(bullet);
            

            bulletTimer.Interval = timeLate;
            bulletTimer.Tick += new EventHandler(BulletTimerEvent);
            bulletTimer.Start();
        }
        private void BulletTimerEvent(object sender, EventArgs e)
        {
            if (direction == "Right")
            {
                bullet.Left += speed;
                if (bullet.Left > 1280)
                {
                    bulletTimer.Stop();
                    bulletTimer.Dispose();
                    bullet.Dispose();
                    bulletTimer = null;
                    bullet = null;
                }
            }
            if (direction == "Left")
            {
                bullet.Left -= speed;
                if (bullet.Right <= 0)
                {
                    bulletTimer.Stop();
                    bulletTimer.Dispose();
                    bullet.Dispose();
                    bulletTimer = null;
                    bullet = null;
                }
            }    
        }     
    }

    //Enemy Bullet (Override)
}
