using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace fastfoodnew
{
    public partial class Form1 : Telerik.WinControls.UI.RadForm
    {
        public Form1()
        {
            InitializeComponent();
        }


        fastfoodEntities dbb = new fastfoodEntities();



        public void gettables()
        {
            try { 

            comboBox1.ValueMember = "tid";
            comboBox1.DisplayMember = "tnamediplay";
            comboBox1.DataSource = dbb.tablenames.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public void getdata1()
        {
            try { 
            radGridView1.DataSource = dbb.rolestables.Where(x=>x.isdeleted=="n").ToList();
            radGridView1.Columns[0].IsVisible = false;

            radGridView1.Columns[2].IsVisible = false;
            radGridView1.Columns[3].IsVisible = false;
            foreach (GridViewColumn r in radGridView1.Columns)
            {


                r.TextAlignment = ContentAlignment.MiddleCenter;
                

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void getdata2()
        {
            try { 
            radGridView2.DataSource = dbb.permessions.Where(x => x.roleid == roleid).ToList();
            radGridView2.Columns[0].IsVisible = false;
            radGridView2.Columns[1].IsVisible = false;

            foreach (GridViewColumn r in radGridView2.Columns)
            {


                r.TextAlignment = ContentAlignment.MiddleCenter;


            }
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);
            }
        }
        public void clear1() {

            roletxt.Text = "";
            isactivech.Checked = false;
        }


        public void clear2()
        {

            comboBox1.SelectedIndex = 0;
            opench.Checked = addch.Checked = delch.Checked = updatech.Checked = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try { 
            getdata1();
            gettables();
            getdata2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



      

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            try { 

            rolestable r = new rolestable();
            r.roleid = int.Parse(db.getmax("rolestable", "roleid"));
            r.rolename = roletxt.Text;
            r.activated = db.checkbox(isactivech);
            dbb.rolestables.Add(r);
            dbb.SaveChanges();
            getdata1();
            clear1();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        int roleid = 0;
        private void radGridView1_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                roleid = int.Parse(radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                roletxt.Text = radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                if (radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() == "y")
                {
                    isactivech.Checked = true;
                }
                else
                {
                    isactivech.Checked = false;

                }

                getdata2();
           }
            catch { roleid = 0;
                clear1();
                getdata2();
            }
        }

        private void radMenuItem2_Click(object sender, EventArgs e)
        {

            try { 
          
         if(   RadMessageBox.Show(this,"گۆڕانکاری", "دڵنیایت؟", MessageBoxButtons.YesNo,RadMessageIcon.Question,MessageBoxDefaultButton.Button1,RightToLeft.Yes) == DialogResult.Yes)
            {
                var a = dbb.rolestables.Where(x => x.roleid == roleid).FirstOrDefault();
                if (a != null)
                {
                    a.rolename = roletxt.Text;
                    a.activated = db.checkbox(isactivech);
                    dbb.SaveChanges();
                    getdata1();
                    clear1();
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radMenuItem3_Click(object sender, EventArgs e)
        {
            try { 
            if (RadMessageBox.Show(this, "سڕینەوە", "دڵنیایت؟", MessageBoxButtons.YesNo, RadMessageIcon.Question, MessageBoxDefaultButton.Button1, RightToLeft.Yes) == DialogResult.Yes)
            {
                var a = dbb.rolestables.Where(x => x.roleid == roleid).FirstOrDefault();
                if (a != null)
                {
                    a.isdeleted = "y";
                    dbb.SaveChanges();
                    getdata1();
                    clear1();
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {

                permesiontable p = new permesiontable();
                p.roleid = roleid;
                p.cancreate = db.checkbox(addch);
                p.candelete = db.checkbox(delch);
                p.canopen = db.checkbox(opench);
                p.canupdate = db.checkbox(updatech);
                p.tid = int.Parse(comboBox1.SelectedValue.ToString());
                dbb.permesiontables.Add(p);
                dbb.SaveChanges();
                clear2();
                getdata2();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
               
         }


        int perid = 0;
        private void radGridView2_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                perid = int.Parse(radGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());

                comboBox1.SelectedIndex = comboBox1.FindStringExact(radGridView2.Rows[e.RowIndex].Cells[3].Value.ToString());

                opench.Checked = db.checkbox2(radGridView2.Rows[e.RowIndex].Cells[4].Value.ToString());
                addch.Checked = db.checkbox2(radGridView2.Rows[e.RowIndex].Cells[5].Value.ToString());
                updatech.Checked = db.checkbox2(radGridView2.Rows[e.RowIndex].Cells[6].Value.ToString());
                delch.Checked = db.checkbox2(radGridView2.Rows[e.RowIndex].Cells[7].Value.ToString());

            }
            catch {

                perid = 0;
                clear2();
            }
        }

        private void radMenuItem5_Click(object sender, EventArgs e)
        {

            try
            {

                if (RadMessageBox.Show(this, "گۆڕانکاری", "دڵنیایت؟", MessageBoxButtons.YesNo, RadMessageIcon.Question, MessageBoxDefaultButton.Button1, RightToLeft.Yes) == DialogResult.Yes)
                {
                    var a = dbb.permesiontables.Where(x => x.permesionId == perid).FirstOrDefault();
                    if (a != null)
                    {
                        a.cancreate = db.checkbox(addch);
                        a.candelete = db.checkbox(delch);
                        a.canopen = db.checkbox(opench);
                       a.canupdate = db.checkbox(updatech);
                        dbb.SaveChanges();
                        getdata2();
                        clear2();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radMenuItem6_Click(object sender, EventArgs e)
        {
            try
            {

                if (RadMessageBox.Show(this, "سڕینەوە", "دڵنیایت؟", MessageBoxButtons.YesNo, RadMessageIcon.Question, MessageBoxDefaultButton.Button1, RightToLeft.Yes) == DialogResult.Yes)
                {
                    var a = dbb.permesiontables.Where(x => x.permesionId == perid).FirstOrDefault();
                    if (a != null)
                    {
                        dbb.permesiontables.Remove(a);
                        dbb.SaveChanges();
                        getdata2();
                        clear2();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    }

