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
    public partial class diliveryform : Telerik.WinControls.UI.RadForm
    {
        public diliveryform()
        {
            InitializeComponent();
        }



        fastfoodEntities dbb = new fastfoodEntities();







        private void diliveryform_Load(object sender, EventArgs e)
        {
            getdata();
        }

        private void radMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {

                if (usinfo.getpermission("add", "dilivery") == true) { 

                    diliverytable d = new diliverytable();
                d.dname = radTextBox1.Text;
                d.tell = radTextBox2.Text;
                d.createdby = usinfo.uid;
                d.isdeleted = "n";
                dbb.diliverytables.Add(d);
                dbb.SaveChanges();
                getdata();
                clear();
            }
            }
            catch(Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }

        }

        private void clear()
        {
            radTextBox1.Text = radTextBox2.Text = "";
        }

        private void getdata()
        {

            try
            {

                radGridView1.DataSource = (from res in dbb.diliverytables
                                           where (res.isdeleted == "n" && res.did!=1)
                                           select new { did = res.did, ناو = res.dname, مۆبایل = res.tell }).ToList();

                radGridView1.Columns[0].IsVisible = false;

                foreach (GridViewColumn r in radGridView1.Columns)
                {


                    r.TextAlignment = ContentAlignment.MiddleCenter;


                }
            }
            catch { }
        }


        int did = 0;

        private void radMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {

                if (RadMessageBox.Show(this, "گۆڕانکاری", "دڵنیایت؟", MessageBoxButtons.YesNo, RadMessageIcon.Question, MessageBoxDefaultButton.Button1, RightToLeft.Yes) == DialogResult.Yes)
                {
                    if (usinfo.getpermission("update", "dilivery") == true)
                    {
                       

                        var c = dbb.diliverytables.Where(x => x.did == did).FirstOrDefault();
                        if (c != null)
                        {
                           
                         
                            c.dname = radTextBox1.Text;
                            c.tell = radTextBox2.Text;

                          
                            c.modiefiedby = usinfo.uid;
                            c.lastmodified = DateTime.Now;
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
                    if (usinfo.getpermission("delete", "dilivery") == true)
                    {


                        var c = dbb.diliverytables.Where(x => x.did == did).FirstOrDefault();
                        if (c != null)
                        {


                            c.isdeleted = "y";
                            c.modiefiedby = usinfo.uid;
                            c.lastmodified = DateTime.Now;
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

        private void radGridView1_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {

                did = int.Parse(radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                radTextBox1.Text = radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                radTextBox2.Text = radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            }
            catch
            {
                did = 0;
                clear();
            }
        }
    }
}
