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
    public partial class Menu : Form
    {
        CheckBox NhacNen;
        CheckBox NhacHieuUng;
        Button Reset;
        Button QuayLai;
        public Menu()
        {
            InitializeComponent();
            createSetting();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            btnCon.Hide();
            btnExit.Hide();
            btnStart.Hide();
            btnSetting.Hide();
            Setting();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StageDemo stage0 = new StageDemo();
            stage0.Size = new Size(1280, 720); 
            stage0.ShowDialog();
            this.Close();
        }

        public void Setting()
        {
            NhacNen.Show();
            NhacHieuUng.Show();
            QuayLai.Show();
            Reset.Show(); 
            

            QuayLai.Click += (s, e) =>
            {
                NhacHieuUng.Hide();
                NhacNen.Hide();
                QuayLai.Hide();
                btnCon.Show();
                btnStart.Show();
                btnExit.Show();
                btnSetting.Show();
            };


            
        }

        public void createSetting()
        {
            NhacNen = new CheckBox()
            {
                Height = 50,
                Width = 250,
                BackColor = Color.FromArgb(48, 59, 57),
                ForeColor = Color.FromArgb(239, 141, 84),
                FlatStyle = FlatStyle.Popup
            };
            NhacNen.Text = "SOUND TRACK";
            NhacNen.Name = "cbMusic";
            NhacNen.Location = new Point(206, 60);
            NhacNen.Font = new Font("Manaspace", 14);
            NhacNen.CheckedChanged += new System.EventHandler(this.cbMusic_CheckedChanged);
            this.Controls.Add(NhacNen);
            NhacNen.Hide();
            NhacHieuUng = new CheckBox()
            {
                Height = 50,
                Width = 100,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(48, 59, 57),
                ForeColor = Color.FromArgb(239, 141, 84),
                FlatStyle = FlatStyle.Popup

            };
            NhacHieuUng.Text = "SFX";
            NhacHieuUng.Name = "cbEffectMusic";
            NhacHieuUng.Location = new Point(500, 60);
            NhacHieuUng.Font = new Font("Manaspace", 14);
            NhacHieuUng.CheckedChanged += new System.EventHandler(this.cbEffectMusic_CheckedChanged);
            this.Controls.Add(NhacHieuUng);
            NhacHieuUng.Hide();
            
            QuayLai = new Button()
            {
                AutoSize = true,
                Height = 50,
                Width = 100,
                BackColor = Color.FromArgb(48, 59, 57),
                ForeColor = Color.FromArgb(239, 141, 84),
                FlatStyle = FlatStyle.Popup
            };
            QuayLai.Text = "RETURN";
            QuayLai.Font = new Font("Manaspace", 14);
            QuayLai.Location = new Point(206, 150);
            this.Controls.Add(QuayLai);
            QuayLai.Hide();

            Reset = new Button()
            {
                AutoSize = true,
                Height = 50,
                Width = 100,
                BackColor = Color.FromArgb(48, 59, 57),
                ForeColor = Color.FromArgb(239, 141, 84),
                FlatStyle = FlatStyle.Popup

            };
            Reset.Text = "RESET";
            Reset.Font = new Font("Manaspace", 14);
            Reset.Name = "btnReset";
            Reset.Location = new Point(206, 210);
            Reset.Click += new System.EventHandler(this.btnReset_Click);
            this.Controls.Add(Reset);
            Reset.Hide();
        }

        public void cbMusic_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Music");
        }

        public void cbEffectMusic_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Effect Music");
        }

        public void btnReset_Click(object sender, EventArgs e)
        {
            NhacNen.Checked = false;
            NhacHieuUng.Checked = false;
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
     
        }

    }
}
