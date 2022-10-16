using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace fastfoodnew
{
    public partial class foodform : Telerik.WinControls.UI.RadForm
    {
        public foodform()
        {
            InitializeComponent();
        }
        byte[] pic = null;
        fastfoodEntities dbb = new fastfoodEntities();
        Image img1 = null;
        public void clear()
        {
            radTextBox1.Text =radTextBox2.Text= "";
           
            pictureBox1.Image = null;
            pic = null;
            img1 = null;
        }




        public int getmax()
        {
            int val;
            try
            {
               val = dbb.foodtables.Max(x => x.fid) + 1;
               
            }
            catch { val = 1; }

            return val;
            
        }

        private void getcombo()
        {
            comboBox1.DisplayMember = "catname";
            comboBox1.ValueMember = "catid";
            comboBox1.DataSource = dbb.categorytables.Where(x=>x.isdeleted=="n").ToList();
        }

        public void getdata()
        {
            int cid =int.Parse( comboBox1.SelectedValue.ToString());
            var data = (from res in dbb.foodtables
                        where (res.isdeleted == "n" && res.catid==cid)
                        select new { fid = res.fid, catid = res.catid, ناو = res.fname, نرخ = res.fprice, وێنە = res.fpic }).ToList();
            radGridView1.DataSource = data;
            radGridView1.Columns[0].IsVisible = false;
            radGridView1.Columns[1].IsVisible = false;
            foreach (GridViewColumn r in radGridView1.Columns)
            {


                r.TextAlignment = ContentAlignment.MiddleCenter;


            }
        }

        private void foodform_Load(object sender, EventArgs e)
        {


            getcombo();
            getdata();

        }

      

        private void radButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "وێنە هەڵبژێرە";
            op.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (op.ShowDialog() == DialogResult.OK)
            {
                pic = File.ReadAllBytes(op.FileName);
                img1 = Image.FromFile(op.FileName);
                img1 = img.ResizeImage(img1, 350, 350);
                pictureBox1.Image = img1;

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getdata();
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void radTextBox1_Enter(object sender, EventArgs e)
        {
            try
            {
                CultureInfo TypeOfLanguage = CultureInfo.CreateSpecificCulture("KU");
                System.Threading.Thread.CurrentThread.CurrentCulture = TypeOfLanguage;
                InputLanguage l = InputLanguage.FromCulture(TypeOfLanguage);
                InputLanguage.CurrentInputLanguage = l;
            }
            catch { }
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (usinfo.getpermission("add", "food") == true)
                {
                    int cid = int.Parse(comboBox1.SelectedValue.ToString());
                    pic = img.ImageToByteArray(img1);
                    foodtable c = new foodtable();
                    c.fid = getmax();
                    c.catid = cid;
                    c.fname = radTextBox1.Text;
                    c.fprice =NumberToText.numtoarab( radTextBox2.Text);
                    c.fpic = pic;
                    c.createdby = usinfo.uid;
                    c.isdeleted = "n";
                    dbb.foodtables.Add(c);
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

        int catid = 0, fid = 0;

        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {

                if (RadMessageBox.Show(this, "گۆڕانکاری", "دڵنیایت؟", MessageBoxButtons.YesNo, RadMessageIcon.Question, MessageBoxDefaultButton.Button1, RightToLeft.Yes) == DialogResult.Yes)
                {
                    if (usinfo.getpermission("update", "food") == true)
                    {
                        pic = img.ImageToByteArray(img1);

                        var c = dbb.foodtables.Where(x => x.fid == fid).FirstOrDefault();
                        if (c != null)
                        {
                            int cid = int.Parse(comboBox1.SelectedValue.ToString());
                            c.catid = cid;
                            c.fname = radTextBox1.Text;

                            c.fprice = NumberToText.numtoarab(radTextBox2.Text);
                            c.fpic = pic;
                            c.modifiedby = usinfo.uid;
                            c.lastmodiefied = DateTime.Now;
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
                    if (usinfo.getpermission("delete", "food") == true)
                    {
                        pic = img.ImageToByteArray(img1);

                        var c = dbb.foodtables.Where(x => x.fid == fid).FirstOrDefault();
                        if (c != null)
                        {
                            c.isdeleted = "y";
                            c.modifiedby = usinfo.uid;
                            c.lastmodiefied = DateTime.Now;
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
                fid = int.Parse(radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                catid = int.Parse(radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                radTextBox1.Text = radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                radTextBox2.Text = radGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBox1.SelectedIndex = comboBox1.FindStringExact(dbb.categorytables.Where(x => x.catid == catid).FirstOrDefault().catname);

                pic = (byte[])radGridView1.Rows[e.RowIndex].Cells[4].Value;
                using (var a = new MemoryStream(pic))
                {
                    img1 = Image.FromStream(a);
                }
                pictureBox1.Image = img1;

            }
            catch
            {
                fid = 0;
                catid = 0;

                clear();
            }
        }
    }
}
