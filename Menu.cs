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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
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
            this.Hide();
            StageDemo stage0 = new StageDemo();
            stage0.Size = new Size(1280, 720); 
            stage0.ShowDialog();
        }

        public void Setting()
        {
            CheckBox NhacNen = new CheckBox() 
            {
                Height = 50,
                Width = 180,
                BackColor = Color.FromArgb(48, 59, 57),
                ForeColor = Color.FromArgb(239, 141, 84),
                FlatStyle = FlatStyle.Popup
            };
            NhacNen.Text = "SOUND TRACK";
            NhacNen.Location = new Point(206, 60);
            NhacNen.Font = new Font("Manaspace", 14);
            this.Controls.Add(NhacNen);

            CheckBox NhacHieuUng = new CheckBox()
            {
                Height = 50,
                Width = 100,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(48, 59, 57),
                ForeColor = Color.FromArgb(239, 141, 84),
                FlatStyle = FlatStyle.Popup

            };
            NhacHieuUng.Text = "SFX";
            NhacHieuUng.Location = new Point(400, 60);
            NhacHieuUng.Font = new Font("Manaspace", 14);
            this.Controls.Add(NhacHieuUng);

            Button QuayLai = new Button() { 
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

            Button Reset = new Button() {
                AutoSize = true,
                Height = 50,
                Width = 100,
                BackColor = Color.FromArgb(48, 59, 57),
                ForeColor = Color.FromArgb(239, 141, 84),
                FlatStyle = FlatStyle.Popup

            };
            Reset.Text = "RESET";
            Reset.Font = new Font("Manaspace", 14);
            Reset.Location = new Point(206, 210);
            this.Controls.Add(Reset);

            QuayLai.Click += (s, e) =>
            {
                NhacHieuUng.Dispose();
                NhacNen.Dispose();
                QuayLai.Dispose();
                btnCon.Show();
                btnStart.Show();
                btnExit.Show();
                btnSetting.Show();
            };
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
     
        }
    }
}
