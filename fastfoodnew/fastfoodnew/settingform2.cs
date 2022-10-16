using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using updater2;
using System.Data.SqlClient;

namespace fastfoodnew
{
    public partial class settingform2 : Telerik.WinControls.UI.RadForm
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.conn);
        public settingform2()
        {
            InitializeComponent();
        }
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        public void getdata()
        { dt.Clear();
            da = new SqlDataAdapter("select * from notetable", con);
            da.Fill(dt);
            radListView1.DisplayMember = "note";
            radListView1.DataSource = dt;
        }

        private void settingform2_Load(object sender, EventArgs e)
        {
            getdata();
        }
        Updater ur = new Updater();
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string value = "";
                if (inputbox4.InputBox("Update The Application Supported by AzherGroup", "UpdateLink", "http://azhergroup.net/fastfood/updateinfo.dat", ref value) == DialogResult.OK)
                {




                    ur.url = value;
                    string a = ur.checkforupdate();


                    if (a != "you already have the latest version")
                    {


                        ur.UpdateApp();


                    }
                    else if (a == "you already have the latest version")
                    {

                        MessageBox.Show("تازەترین ڤێرژنت هەیە");
                    }



                }
            }catch(Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }





        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] p = new SqlParameter[0];
                MessageBox.Show(db.docmd("ALTER DATABASE fastfood     SET RECOVERY SIMPLE  DBCC SHRINKFILE (fastfood_log, 1)  ALTER DATABASE fastfood SET RECOVERY FULL", p));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        string name = "";
        private void radListView1_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                radTextBox1.Text = radListView1.SelectedItem.Text.ToString();
                name= radListView1.SelectedItem.Text.ToString(); 
            }
            catch
            {
                radTextBox1.Text = "";
                name = "";
            }
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] p = new SqlParameter[1];
                p[0] = new SqlParameter("@1", radTextBox1.Text);
                string sql = "insert into notetable values(@1)";

                db.docmd(sql, p);
                getdata();
                name = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            if (RadMessageBox.Show(this, "گۆڕانکاری", "دڵنیایت؟", MessageBoxButtons.YesNo, RadMessageIcon.Question, MessageBoxDefaultButton.Button1, RightToLeft.Yes) == DialogResult.Yes)
            {

                try
                {
                    SqlParameter[] p = new SqlParameter[2];
                    p[0] = new SqlParameter("@1", radTextBox1.Text);
                    p[1] = new SqlParameter("@2", name);
                    string sql = "update notetable set note=@1 where note=@2";

                    db.docmd(sql, p);
                    getdata();
                    name = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void radMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                if (RadMessageBox.Show(this, "سڕینەوە", "دڵنیایت؟", MessageBoxButtons.YesNo, RadMessageIcon.Question, MessageBoxDefaultButton.Button1, RightToLeft.Yes) == DialogResult.Yes)
                {
                    SqlParameter[] p = new SqlParameter[1];

                    p[0] = new SqlParameter("@1", name);
                    string sql = "delete from notetable where note=@1";

                    db.docmd(sql, p);
                    getdata();
                    name = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
