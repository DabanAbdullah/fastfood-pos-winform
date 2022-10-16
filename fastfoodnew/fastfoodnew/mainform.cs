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
using System.Threading;

namespace fastfoodnew
{
    public partial class mainform : Form
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
        public mainform()
        {
            InitializeComponent();
          //  Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            //panelnav.Height = btndashboard.Height;
            ////panelnav.Top = btndashboard.Top;
            //  panelnav.Left = btndashboard.Right;
           // panelnav.BackColor = Color.Red;//Color.FromArgb(46, 51, 73);
        }
       
        private void mainform_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.icons8_hamburger;
            foreach (Control b in panel1.Controls)
            {
                if (b is Button)
                {
                    b.Tag = b.Text;
                    b.Text = "";
                    b.ForeColor = Color.Transparent;
                }
            }
            this.IsMdiContainer = true;
            this.radDock1.AutoDetectMdiChildren = true;

            panel1.Width = 40;
                panel3.Height = 40;

            foreach (Control b in panel1.Controls)
            {
                if (b is Button)
                {
                    b.ForeColor = Color.Transparent;
                }
            }
            label1.Text = usinfo.fullname;
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            Button b = (sender) as Button;

            panelnav.Height = b.Height;
            panelnav.Top = b.Top;
          //  panelnav.Left = b.Right;
            panelnav.BackColor = Color.FromArgb(0, 126, 249);
            //   b.BackColor = Color.FromArgb(46, 51, 73);

            b.BackColor = Color.FromArgb(222, 222, 222);

            if (usinfo.getpermission("open", b.Name) == true) {
                openform(b.Name);

            }


        }
        string aa = "";
        private void openform(string formname)
        {
            try
            {



                Form form = null;
                if (formname == "users") { form = new usersform(); aa = "بەکارهێنەران"; }
                else if (formname == "role") { form = new Form1(); aa = "ڕۆڵەکان"; }
                else if (formname == "category") { form = new categoryform(); aa = "جۆرەکان"; }

                else if (formname == "food") { form = new foodform(); aa = "خواردنەکان"; }
            
                else if (formname == "div"){ form = new diliveryform(); aa = "دیلیڤەریەکان"; }
                else if (formname == "sale"){ form = new saleform(); aa = "کاشێر"; }
                else if (formname == "expense"){form = new expenseform(); aa = "خەرجی"; }
                else if (formname == "dashboard") {form = new dashboard(); aa = "داشبۆرد"; }
                else if (formname == "setting") {form = new settingform2(); aa = "رێکخستن"; }
                bool f = false;
                Form[] openforms = radDock1.MdiChildren;
                foreach (Form aa in openforms)
                {

                    if (aa.Name.ToString() == formname)
                    {
                        f = true;
                        radDock1.ActivateMdiChild(aa);
                    }
                }

                if (f == false)
                {


                    form.Text = aa;
                    form.Name = formname;
                    form.MdiParent = this;
                    form.Show();
                    radDock1.ActivateMdiChild(form);
                }
                else
                {



                    // MessageBox.Show("ئەم فۆڕمە کراوەتەوە");
                }
            }
            catch { }
        }

        private void btndashboard_Leave(object sender, EventArgs e)
        {

            Button b = (sender) as Button;
          

            b.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            if (panel1.Width > 40) {
                panel1.Width = 40;
                panel3.Height = 40;
                foreach (Control b in panel1.Controls)
                {
                    if (b is Button)
                    {
                        b.Tag = b.Text;
                        b.Text = "";
                        b.ForeColor = Color.Transparent;
                    }
                }
            }
            else
            {
                foreach (Control b in panel1.Controls)
                {
                    if (b is Button)
                    {
                        try
                        {
                            b.Text = b.Tag.ToString();
                        }
                        catch { }
                        b.Tag = "";
                        b.ForeColor = Color.FromArgb(0, 126, 249);
                    }
                }
                //
                panel3.Height = 181;
                panel1.Width = 186;
            }

           

        }

        private void label2_Click(object sender, EventArgs e)
        {
            var formToShow = Application.OpenForms.Cast<Form>()
            .FirstOrDefault(c => c is Login);
            if (formToShow != null)
            {
                formToShow.Show();
            }
            this.Close();
        }

        private void dashboard_MouseHover(object sender, EventArgs e)
        {
            if (panel1.Width < 50)
            {
                Button b = (sender) as Button;
              
                menu1.Text = b.Tag.ToString();
                menu1.Width = 120;
                b.ContextMenuStrip = contextMenuStrip1;
                contextMenuStrip1.Top = b.Top;
                contextMenuStrip1.Left = b.Left;
                menu1.Height = b.Height;
                
                contextMenuStrip1.Show(this.PointToScreen(new Point((b.Location.X + radDock1.Width) - menu1.Width, b.Location.Y)));
                this.Focus();
            }
        }

        private void menu1_MouseLeave(object sender, EventArgs e)
        {
          
            contextMenuStrip1.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if ((DateTime.Now - Properties.Settings.Default.report).Days > 0)
            {
               

                  //  Task task = Task.Run((Action)db.sendrep);

            

            }



            if ((DateTime.Now - Properties.Settings.Default.backup).Days > 0)
            {
              
                    Action onCompleted = () =>
                    {

                        // MessageBox.Show("ok");


                    };

                    var thread = new Thread(
                      () =>
                      {
                          try
                          {

                            //  db.senddb();
                          }

                          finally
                          {
                              onCompleted();


                          }
                      });
                    thread.Start();
                }
            }
    }
}
