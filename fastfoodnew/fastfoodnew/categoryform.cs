using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace fastfoodnew
{
    public partial class categoryform : Telerik.WinControls.UI.RadForm
    {
        public categoryform()
        {
            InitializeComponent();
        }

        byte[] pic = null;
        fastfoodEntities dbb = new fastfoodEntities();

        public void clear()
        {
            radTextBox1.Text = "";
            pictureBox1.Image  = null;
            pic = null;
            img1 = null;
        }

        public void getdata()
        {
            var data = (from res in dbb.categorytables
                            where (res.isdeleted == "n" )
                            select new { catid = res.catid, ناو = res.catname,وێنە=res.pic }).ToList();
            radGridView1.DataSource = data;
            radGridView1.Columns[0].IsVisible = false;
            foreach (GridViewColumn r in radGridView1.Columns)
            {


                r.TextAlignment = ContentAlignment.MiddleCenter;


            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            getdata();
        }


        Image img1 = null;
        private void radButton1_Click(object sender, EventArgs e)
        {

            OpenFileDialog op = new OpenFileDialog();
            op.Title = "وێنە هەڵبژێرە";
            op.Filter= "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"; 
            if (op.ShowDialog() == DialogResult.OK) {
                pic = File.ReadAllBytes(op.FileName);
                img1 = Image.FromFile(op.FileName);
                img1 = img.ResizeImage(img1, 350, 350);
                pictureBox1.Image = img1;
               
           }
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (usinfo.getpermission("add", "category") == true)
                {
                    pic = img.ImageToByteArray(img1);
                    categorytable c = new categorytable();
                    c.catname = radTextBox1.Text;
                    c.pic = pic;
                    c.createdby = usinfo.uid;
                    c.isdeleted = "n";
                    dbb.categorytables.Add(c);
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

        int catid = 0;
        private void radGridView1_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                catid = int.Parse(radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                radTextBox1.Text = radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            pic = (byte[])radGridView1.Rows[e.RowIndex].Cells[2].Value;
            using(var a=new MemoryStream(pic))
            {
                img1 = Image.FromStream(a);
            }
                pictureBox1.Image = img1;

            }
            catch
            {

                clear();
            }
        }

        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {

                if (RadMessageBox.Show(this, "گۆڕانکاری", "دڵنیایت؟", MessageBoxButtons.YesNo, RadMessageIcon.Question, MessageBoxDefaultButton.Button1, RightToLeft.Yes) == DialogResult.Yes)
                {
                    if (usinfo.getpermission("update", "category") == true)
                    {
                        pic = img.ImageToByteArray(img1);

                        var a = dbb.categorytables.Where(x => x.catid == catid).FirstOrDefault();
                        if (a != null)
                        {
                            a.catname = radTextBox1.Text;
                            a.pic = pic;
                            a.modifiedby = usinfo.uid;
                            a.lastmodified = DateTime.Now;
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
                    if (usinfo.getpermission("delete", "category") == true)
                    {
                     

                        var a = dbb.categorytables.Where(x => x.catid == catid).FirstOrDefault();
                        if (a != null)
                        {
                            a.isdeleted = "y";
                            a.lastmodified = DateTime.Now;
                            a.modifiedby = usinfo.uid;
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
