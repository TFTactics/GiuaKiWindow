using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace GameDiCanh
{
    public class Enemy
    {
        // Tạo thuộc tính cơ bản cho bot
        public int health;
        public int damage;
        // Vị trí của bot
        public int enemyTop;
        public int enemyLeft;

        private int timeLate = 100;// tg chờ
        private int enemySpeed = 5;// Tốc độ của bot
        public PictureBox mechaBot = new PictureBox();
        private Timer mechaBotTimer = new Timer();
        private Timer bulletBotTimer = new Timer();
        private Form form;


        public Enemy()
        {

        }
        public Enemy(Form form, int HP=0, int DMG=0)
        {
            this.form = form;
            health = HP;
            damage = DMG;
        }
        public virtual void MakeMechaBot()
        {
            // Khởi tạo bot
            mechaBot.BackColor = System.Drawing.Color.Transparent;
            mechaBot.Image = global::GameDiCanh.Properties.Resources.EnemyMechaRobot;
            mechaBot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            mechaBot.Name = "mechaBot";
            mechaBot.TabStop = false;
            mechaBot.Tag = "Enemy";
            mechaBot.Left = enemyLeft;
            mechaBot.Top = enemyTop;
            mechaBot.Height = 102;
            mechaBot.Width = 61;

            // Add bot vào form
            this.form.Controls.Add(mechaBot);

            

            // Set mechabotTimer
            mechaBotTimer.Interval = timeLate;
            mechaBotTimer.Tick += new EventHandler(MechaBotTimerEvent);
            mechaBotTimer.Start();

            // Set thời gian để dịch bán đạn
            bulletBotTimer.Interval = 1000;
            bulletBotTimer.Tick += new EventHandler(BulletBotTimerEvent);
            bulletBotTimer.Start();
        }
        private void MechaBotTimerEvent(object sender, EventArgs e)
        {
            // Tạo sự kiện mechaBot cho bot tự di chuyển sang trái
            mechaBot.Left -= enemySpeed;

            if (mechaBot.Right<=0)
            {
                mechaBotTimer.Stop();
                mechaBotTimer.Dispose();
                mechaBot.Dispose();
                mechaBotTimer = null;
                mechaBot = null;
            }
        }

        private void BulletBotTimerEvent(object sender, EventArgs e)
        {
            Bullet spawnBullet_enemy = new Bullet();
            // thay đổi tag để tránh địch bắn địch
            spawnBullet_enemy.tag = "bullet_of_enemy";
            spawnBullet_enemy.direction = "Left";
            spawnBullet_enemy.bulletLeft = mechaBot.Left;
            spawnBullet_enemy.bulletTop = mechaBot.Top + mechaBot.Height / 4;
            spawnBullet_enemy.MakeBullet(this.form);
        }
    }

    public class BOSS : Enemy
    {
        public BOSS(Form form, int HP, int DMG) : base(form, HP, DMG) { }
        public override void MakeMechaBot()
        {
            base.MakeMechaBot();
        }
    }

    public class tiny : Enemy
    {
        public tiny(Form form, int HP, int DMG) : base(form, HP, DMG) { }
        public override void MakeMechaBot()
        {
            base.MakeMechaBot();
        }
    }
}
