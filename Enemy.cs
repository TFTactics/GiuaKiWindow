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
        public int health;
        public int damage;

        public int enemyTop;
        public int enemyLeft;
        private int enemySpeed = 2;
        public PictureBox enemyBot = new PictureBox();
        private Timer mechaBotTimer = new Timer();
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
            enemyBot.BackColor = System.Drawing.Color.Transparent;
            enemyBot.Image = global::GameDiCanh.Properties.Resources.EnemyMechaRobot;
            enemyBot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            enemyBot.Name = "mechaBot";
            enemyBot.TabStop = false;
            enemyBot.Tag = "Enemy";
            enemyBot.Left = enemyLeft;
            enemyBot.Top = enemyTop;
            enemyBot.Height = 102;
            enemyBot.Width = 61;


            this.form.Controls.Add(enemyBot);


            mechaBotTimer.Interval = enemySpeed;
            mechaBotTimer.Tick += new EventHandler(MechaBotTimerEvent);
            mechaBotTimer.Start();
        }
        private void MechaBotTimerEvent(object sender, EventArgs e)
        {
            enemyBot.Left -= enemySpeed;

            if (enemyBot.Right<=0)
            {
                mechaBotTimer.Stop();
                mechaBotTimer.Dispose();
                enemyBot.Dispose();
                mechaBotTimer = null;
                enemyBot = null;
            }    
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
