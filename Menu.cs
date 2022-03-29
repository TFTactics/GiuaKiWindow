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
            CheckBox NhacNen = new CheckBox();
            NhacNen.Text = "Nhac Nen";
            NhacNen.Location = new Point(206, 61);
            NhacNen.Font = new Font("Snap ITC", 14);
            NhacNen.AutoSize = true;
            this.Controls.Add(NhacNen);

            CheckBox NhacHieuUng = new CheckBox();
            NhacHieuUng.Text = "SFX";
            NhacHieuUng.Location = new Point(206, 137);
            NhacHieuUng.Font = new Font("Snap ITC", 14);
            NhacHieuUng.AutoSize = true;
            this.Controls.Add(NhacHieuUng);

            Button QuayLai = new Button();
            QuayLai.Text = "RETURN";
            QuayLai.Location = new Point(206, 268);
            this.Controls.Add(QuayLai);

            Button Reset = new Button();
            Reset.Text = "RESET";
            Reset.Location = new Point(206, 312);
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
    }
}
