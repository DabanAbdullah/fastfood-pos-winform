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
    public partial class expenseform : Telerik.WinControls.UI.RadForm
    {
        public expenseform()
        {
            InitializeComponent();
        }
        fastfoodEntities dbb = new fastfoodEntities();
        public void clear()
        {
            radTextBox1.Text =radTextBox2.Text= "";radDateTimePicker1.Value = DateTime.Now;
          
        }


        public void getdata()
        {
            try
            {
                var data = (from res in dbb.vexpenses
                            where (res.isdeleted == "n")
                            select new { eid = res.eid, ناو = res.ename, بڕ = res.eprice, بەروار = res.edate }).ToList();
                radGridView1.DataSource = data;
                radGridView1.Columns[0].IsVisible = false;
                foreach (GridViewColumn r in radGridView1.Columns)
                {


                    r.TextAlignment = ContentAlignment.MiddleCenter;


                }
            }
            catch { }
        }

        private void expenseform_Load(object sender, EventArgs e)
        {
            getdata();
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (usinfo.getpermission("add", "expense") == true)
                {
                    
                    expensetable c = new expensetable();
                    c.eid = decimal.Parse(db.getmax("expensetable", "eid"));
                    c.ename = radTextBox1.Text;
                    c.eprice =decimal.Parse(NumberToText.arabtoeng(radTextBox2.Text));
                    c.edate = radDateTimePicker1.Value;
                    c.createdby = usinfo.uid;
                    c.isdeleted = "n";
                    dbb.expensetables.Add(c);
                    dbb.SaveChanges();
                    getdata();
                    clear();
                }



            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }
        }


        decimal eid = 0;
        private void radGridView1_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                eid = decimal.Parse(radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                radTextBox1.Text = radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                radTextBox2.Text = radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                radDateTimePicker1.Value = DateTime.Parse(radGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
            catch { eid = 0;
                clear();
            }

        }

        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {

                if (RadMessageBox.Show(this, "گۆڕانکاری", "دڵنیایت؟", MessageBoxButtons.YesNo, RadMessageIcon.Question, MessageBoxDefaultButton.Button1, RightToLeft.Yes) == DialogResult.Yes)
                {
                    if (usinfo.getpermission("update", "expense") == true)
                    {
                     

                        var a = dbb.expensetables.Where(x => x.eid == eid).FirstOrDefault();
                        if (a != null)
                        {
                            a.ename = radTextBox1.Text;
                            a.eprice = decimal.Parse(NumberToText.arabtoeng( radTextBox2.Text));
                            a.edate = radDateTimePicker1.Value;
                           
                            a.modiefiedby = usinfo.uid;
                            a.lastmodiefied = DateTime.Now;
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

        private void radMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {

                if (RadMessageBox.Show(this, "سڕینەوە", "دڵنیایت؟", MessageBoxButtons.YesNo, RadMessageIcon.Question, MessageBoxDefaultButton.Button1, RightToLeft.Yes) == DialogResult.Yes)
                {
                    if (usinfo.getpermission("delete", "expense") == true)
                    {


                        var a = dbb.expensetables.Where(x => x.eid == eid).FirstOrDefault();
                        if (a != null)
                        {
                            a.isdeleted = "y";

                            a.modiefiedby = usinfo.uid;
                            a.lastmodiefied = DateTime.Now;
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
