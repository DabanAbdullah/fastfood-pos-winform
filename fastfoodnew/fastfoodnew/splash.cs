using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace fastfoodnew
{
    public partial class splash : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
       (
             int nLeftRect,
             int nTopRect,
             int nRightRect,
             int nBottomRect,
             int nWidthEllipse,
             int nHeightEllipse

       );
        public splash()
        {
            InitializeComponent();

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(00,00, Width, Height, 60,60));
            ProgressBar1.Value = 0;
        }

        private void splash_Load(object sender, EventArgs e)
        {
            label5.Text = Environment.UserName;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ProgressBar1.Value += 1;
            ProgressBar1.Text = ProgressBar1.Value.ToString() + "%";
            label5.Text = Environment.UserName + " " + DateTime.Now;
            if (ProgressBar1.Value == 100)
            {
                timer1.Enabled = false;
                Login l = new Login();
                l.Show();
                this.Hide();
            }

        }
    }
}
