using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace fastfoodnew
{
    public partial class usersform : Telerik.WinControls.UI.RadForm
    {
        public usersform()
        {
            InitializeComponent();
        }

        fastfoodEntities dbb = new fastfoodEntities();

        public void getrole()
        {
            comboBox1.ValueMember = "roleid";
            comboBox1.DisplayMember = "rolename";
            comboBox1.DataSource = dbb.rolestables.ToList();
        }
        public void getdata()
        {
            try
            {
                radGridView1.DataSource = dbb.vusers.ToList();
                radGridView1.Columns[0].IsVisible = false;
                

                foreach (GridViewColumn r in radGridView1.Columns)
                {


                    r.TextAlignment = ContentAlignment.MiddleCenter;


                }
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message);
            }
        }

        public void clear()
        {
            nametxt.Text = usernametxt.Text = passtxt.Text = "";comboBox1.SelectedIndex = 0;
        }

        private void usersform_Load(object sender, EventArgs e)
        {
            getrole();
            getdata();

        }




        private void radMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {

                if (usinfo.getpermission("add", "users") == true)
                {
                    usertable u = new usertable();
                    u.fullname = nametxt.Text;
                    u.username = db.Encrypt(usernametxt.Text);
                    u.password = db.Encrypt(passtxt.Text);
                    u.roleid = int.Parse(comboBox1.SelectedValue.ToString());
                    dbb.usertables.Add(u);
                    dbb.SaveChanges();
                    getdata();
                    clear();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        int uid = 0;
        private void radGridView1_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                uid = int.Parse(radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                nametxt.Text = radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                usernametxt.Text = db.Decrypt(radGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                passtxt.Text = db.Decrypt(radGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                comboBox1.SelectedIndex = comboBox1.FindStringExact(radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());

        }
            catch
            {
                uid = 0;
                clear();
    }
}

        private void radMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {

                if (RadMessageBox.Show(this, "گۆڕانکاری", "دڵنیایت؟", MessageBoxButtons.YesNo, RadMessageIcon.Question, MessageBoxDefaultButton.Button1, RightToLeft.Yes) == DialogResult.Yes)
                {
                    if (usinfo.getpermission("update", "users") == true)
                    {
                        

                        var a = dbb.usertables.Where(x => x.userid == uid).FirstOrDefault();
                        if (a != null)
                        {
                            a.fullname = nametxt.Text;
                            a.username = db.Encrypt(usernametxt.Text);
                            a.password = db.Encrypt(passtxt.Text);
                           
                            dbb.SaveChanges();
                            getdata();
                            clear();
                        }



                    }

                }

            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }

        }

        private void radMenuItem6_Click(object sender, EventArgs e)
        {
            try
            {

                if (RadMessageBox.Show(this, "سڕینەوە", "دڵنیایت؟", MessageBoxButtons.YesNo, RadMessageIcon.Question, MessageBoxDefaultButton.Button1, RightToLeft.Yes) == DialogResult.Yes)
                {
                    if (usinfo.getpermission("delete", "users") == true)
                    {


                        var a = dbb.usertables.Where(x => x.userid == uid).FirstOrDefault();
                        if (a != null)
                        {
                            a.isdeleted = "y";
                          
                            dbb.SaveChanges();
                            getdata();
                            clear();
                        }



                    }

                }

            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }

        }
    }
}
