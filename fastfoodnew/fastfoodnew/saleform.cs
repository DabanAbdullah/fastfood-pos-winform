using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.SqlClient;
using System.Data;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Text.RegularExpressions;

namespace fastfoodnew
{
    public partial class saleform : Telerik.WinControls.UI.RadForm
    {
     public static   DateTime d;
        public saleform()
        {
            InitializeComponent();
            d = DateTime.Now.Date;
        }


        public static decimal waslno { get; set; }
       
        fastfoodEntities dbb = new fastfoodEntities();

        public decimal getsid()
        {
            decimal val;
            try
            {
                val = dbb.saletables.Max(x => x.sid) + 1;

            }
            catch { val = 1; }

            return val;

        }


        public decimal getwasl()
        {
            decimal val;
            try
            {

             
              

                val = decimal.Parse(db.getmax2("saletable","wasl",d.Date,"sdate"));

            }
            catch { val = 1; }

            return val;

        }


        SqlConnection con = db.con;

        SqlDataAdapter da;
        DataTable dt = new DataTable();
        DataTable vsale = new DataTable();
        vorder v = new vorder();
        decimal sum = 0;
        public void getdata()
        {
            up = 0;
            flowLayoutPanel3.Controls.Clear();
            decimal wasl = decimal.Parse(wasltxt.Text);

            dt.Clear();
            da=new SqlDataAdapter("select * from vorder where sdate=@1 and wasl=@2", con);
            da.SelectCommand.Parameters.AddWithValue("@1", d.Date);
            da.SelectCommand.Parameters.AddWithValue("@2", wasl);
            da.Fill(dt);
            sum = 0;
            foreach (DataRow dr in dt.Rows)
            {
                v.sid = decimal.Parse(dr["sid"].ToString());
                v.sprice= decimal.Parse(dr["sprice"].ToString());
                sum=sum+ decimal.Parse(dr["sprice"].ToString());
                v.fname = dr["fname"].ToString();
                v.fpic = (byte[])dr["fpic"];
                v.qty = int.Parse(dr["qty"].ToString());
                v.note = dr["note"].ToString();
                v.sdate = DateTime.Parse(dr["sdate"].ToString());
                ordercontrol or = new ordercontrol();
                or.f = this;
                or.v = v;
                or.wasl = decimal.Parse(wasltxt.Text);
                or.dtt = DateTime.Now.Date;
                or.sid= decimal.Parse(dr["sid"].ToString());
                flowLayoutPanel3.Controls.Add(or);
            }

            vsale.Clear();
            da = new SqlDataAdapter("select * from vsale where sdate=@1 and wasl=@2", con);
            da.SelectCommand.Parameters.AddWithValue("@1", d.Date);
            da.SelectCommand.Parameters.AddWithValue("@2", wasl);
            da.Fill(vsale);

            if (vsale.Rows.Count > 0)
            {
                telltxt.Text = vsale.Rows[0]["tell"].ToString();
                comboBox1.SelectedIndex= comboBox1.FindStringExact( vsale.Rows[0]["dname"].ToString());
            }


            label1.Text = NumberToText.Convert(sum);

        }



        public  void clear()
        {
            flowLayoutPanel3.Controls.Clear();
            label1.Text = "";
            comboBox1.SelectedIndex = 0;
            telltxt.Text = "";
            wasltxt.Text = getwasl() + "";
        }

        private void saleform_Load(object sender, EventArgs e)
        {

            comboBox1.DisplayMember = "dname";
            comboBox1.ValueMember = "did";
            comboBox1.DataSource = dbb.diliverytables.ToList();


            wasltxt.Text = getwasl() + "";
            getdata();
            //  MessageBox.Show(getsid() + "  " + getwasl());

            foreach (categorytable c in dbb.categorytables.Where(x => x.isdeleted == "n").ToList())
            {
               
                Panel p = new Panel();
          
                p.Width = 150;
              
                p.Height = 150;

                Label l = new Label();
                l.Text = c.catname;
                
                l.Dock = DockStyle.Bottom;
                l.TextAlign = ContentAlignment.MiddleCenter;
                p.Controls.Add(l);
                l.Font = new Font("UniKurd Jino", 12, FontStyle.Regular);
                l.ForeColor = Color.White;
                l.BackColor = Color.FromArgb(24, 30, 54);
                PictureBox image = new PictureBox();
                using (var a = new MemoryStream(c.pic))
                {
                    image.Image = Image.FromStream(a);
                }
                image.SizeMode = PictureBoxSizeMode.StretchImage;
                image.Dock = DockStyle.Fill;
                p.Controls.Add(image);
                image.Name = c.catid.ToString();

                image.Click += catclick;
                flowLayoutPanel1.Controls.Add(p);

            }




        }

        private void catclick(object sender, EventArgs e)
        {

            try
            {
                flowLayoutPanel2.Controls.Clear();
                PictureBox ss = (sender) as PictureBox;

                int cid = int.Parse(ss.Name);
                foreach (foodtable f in dbb.foodtables.Where(x => x.isdeleted == "n"&& x.catid==cid).ToList())
                {

                    Panel p = new Panel();

                    p.Width = 150;

                    p.Height = 160;

                    Label l = new Label();
                    l.Text = f.fname;

                    l.Dock = DockStyle.Top;
                    l.TextAlign = ContentAlignment.MiddleCenter;
                    p.Controls.Add(l);
                    l.Font = new Font("UniKurd Jino", 12, FontStyle.Regular);
                    l.ForeColor = Color.White;
                    l.BackColor = Color.FromArgb(24, 30, 54);


                    Label l2 = new Label();
                    if (f.fprice.Contains(','))
                    {
                        l2.Text = new String(NumberToText.arabtoeng(f.fprice).Where(c => c != ',' && (c < '0' || c > '9')).ToArray());

                    }
                    else {
                        l2.Text = f.fprice;
                    }
                  
                    l2.Height = 30;
                    l2.Dock = DockStyle.Bottom;
                    l2.TextAlign = ContentAlignment.MiddleCenter;
                    p.Controls.Add(l2);
                    l2.Font = new Font("UniKurd Jino", 10, FontStyle.Regular);
                    l2.ForeColor = Color.White;
                    l2.BackColor = Color.FromArgb(24, 30, 54);



                    PictureBox image = new PictureBox();
                    using (var a = new MemoryStream(f.fpic))
                    {
                        image.Image = Image.FromStream(a);
                    }
                    image.SizeMode = PictureBoxSizeMode.StretchImage;
                    image.Dock = DockStyle.Fill;
                    p.Controls.Add(image);
                    image.Name = f.fid.ToString();

                    image.Click += productclick;
                    flowLayoutPanel2.Controls.Add(p);

                }


            }
            catch(Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }


        }
        int fid = 0;
        private void productclick(object sender, EventArgs e)
        {



            try
            {


                PictureBox ss = (sender) as PictureBox;
            fid   = int.Parse(ss.Name);

                var price = dbb.foodtables.Where(x => x.fid == fid).FirstOrDefault().fprice;

                if (price.Contains(","))
                {
                    ContextMenuStrip m = new ContextMenuStrip();
                    string[] arr = price.Split(',');


                    ToolStripMenuItem aa = new ToolStripMenuItem();

                    aa.Text =dbb.foodtables.Where(x=>x.fid==fid).FirstOrDefault().fname ;
                    aa.BackColor = Color.FromArgb(24, 30, 54);
                    aa.ForeColor = Color.White;
                    aa.Font = new Font("UniKurd Jino", 22, FontStyle.Bold);
                    m.Items.Add(aa);
                    foreach (string pr in arr)
                    {
                        ToolStripMenuItem mitem = new ToolStripMenuItem();
                        
                        mitem.Text = pr;
                        mitem.BackColor =  Color.FromArgb(24, 30, 54);
                        mitem.ForeColor = Color.White;
                        mitem.Font= new Font("UniKurd Jino", 22, FontStyle.Bold);
                        mitem.Click += selectprice;
                        m.Items.Add(mitem);
                       // ToolStripSeparator mm = new ToolStripSeparator();
                       // mm.BackColor= Color.FromArgb(24, 30, 54);
                       // m.Items.Add(mm);

                    }

                    m.Show(ss, 150, 5);
                }
                else
                {

                    saletable s = new saletable();
                    s.sid = getsid();
                    s.wasl = decimal.Parse(wasltxt.Text);
                    s.fid = fid;
                    s.qty = 1;
                    s.sprice = decimal.Parse(NumberToText.arabtoeng(price));
                    s.sdate = d.Date;
                   
                    s.createdby = usinfo.uid;
                    s.isdeleted = "n";
                    dbb.saletables.Add(s);
                    dbb.SaveChanges();
                    addwasl2();
                    getdata();
                 

                }




            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }

        }

        private void selectprice(object sender, EventArgs e)
        {
            try
            {

                ToolStripMenuItem m = (sender) as ToolStripMenuItem;
              string  resultString = Regex.Match(NumberToText.arabtoeng(m.Text), @"\d+").Value;
                decimal money = decimal.Parse(resultString);

             
                string typee = new String(NumberToText.arabtoeng(m.Text).Where(c => c != '-' && (c < '0' || c > '9')).ToArray());

                saletable s = new saletable();
                s.sid = getsid();
                s.wasl = decimal.Parse(wasltxt.Text);
                s.fid = fid;
                s.qty = 1;
                s.sprice = money;
                s.sdate = d.Date;
                s.typee = typee;
                s.createdby = usinfo.uid;
                s.isdeleted = "n";
                dbb.saletables.Add(s);
                dbb.SaveChanges();
                addwasl2();
                getdata();
            


            }
            catch(Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }
        }

        private void wasltxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (wasltxt.Text.Length == 0)
                {
                    wasltxt.Text = getwasl() + "";

                    flowLayoutPanel3.Controls.Clear();
                }

                else
                {
                    getdata();
                }

            }
        }

        private void wasltxt_TextChanged(object sender, EventArgs e)
        {
           
        }

        DataTable dtt = new DataTable();

        public void addwasl2()
        {
            try
            {
                if (flowLayoutPanel3.Controls.Count > 0)
                {

                    SqlDataAdapter da = new SqlDataAdapter("select * from wasltable where sdate=@1 and wasl=@2", con);
                    da.SelectCommand.Parameters.AddWithValue("@1", d.Date);
                    da.SelectCommand.Parameters.AddWithValue("@2", decimal.Parse(wasltxt.Text));
                    dtt.Clear();
                    da.Fill(dtt);
                    if (dtt.Rows.Count == 0)
                    {


                        wasltable t = new wasltable();
                        t.wid = decimal.Parse(db.getmax("wasltable", "wid"));
                        t.wasl = decimal.Parse(wasltxt.Text);
                        t.sdate = d.Date;
                        t.createdby = usinfo.uid;
                        t.did = int.Parse(comboBox1.SelectedValue.ToString());
                        t.tell = telltxt.Text;
                        t.isdeleted = "n";
                        dbb.wasltables.Add(t);
                        dbb.SaveChanges();






                    }

                    else
                    {

                        decimal wid = decimal.Parse(dtt.Rows[0]["wid"].ToString());

                        var rec = dbb.wasltables.Where(x => x.wid == wid).FirstOrDefault();

                        if (rec != null)
                        {
                            rec.tell = telltxt.Text;
                            rec.did = int.Parse(comboBox1.SelectedValue.ToString());
                            dbb.SaveChanges();
                        }
                    }
                  
                }


        }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }

}






        public void addwasl()
        {
            try
            {
                if (flowLayoutPanel3.Controls.Count > 0)
                {

                    SqlDataAdapter da = new SqlDataAdapter("select * from wasltable where sdate=@1 and wasl=@2", con);
                    da.SelectCommand.Parameters.AddWithValue("@1", d.Date);
                    da.SelectCommand.Parameters.AddWithValue("@2", decimal.Parse(wasltxt.Text));
                    dtt.Clear();
                    da.Fill(dtt);
                    if (dtt.Rows.Count == 0)
                    {

                   
                        wasltable t = new wasltable();
                        t.wid = decimal.Parse(db.getmax("wasltable", "wid"));
                        t.wasl = decimal.Parse(wasltxt.Text);
                        t.sdate = d.Date;
                        t.createdby = usinfo.uid;
                        t.did = int.Parse(comboBox1.SelectedValue.ToString());
                        t.tell = telltxt.Text;
                        t.isdeleted = "n";
                        dbb.wasltables.Add(t);
                        dbb.SaveChanges();






                    }

                    else
                    {
                        decimal w = decimal.Parse(wasltxt.Text);
                        var a = dbb.wasltables.Where(x => x.wasl == w && x.sdate == d).FirstOrDefault();
                        if (a != null)
                        {
                          

                            a.tell = telltxt.Text;
                            a.did = int.Parse(comboBox1.SelectedValue.ToString());
                            dbb.SaveChanges();
                        }


                    }
                    flowLayoutPanel3.Controls.Clear();
                }


            }
            catch (Exception ex)
            {
                RadMessageBox.Show(ex.Message);
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {

          


            try
            {
                addwasl();
                print();
            }
            catch
            {

            }

            finally
            {
                clear();
            }

          



        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void label1_ControlRemoved(object sender, ControlEventArgs e)
        {
          

        }


       public static int up = 0;
        private void flowLayoutPanel3_ControlRemoved(object sender, ControlEventArgs e)
        {

            if (up > 0)
            {
                decimal wasl = decimal.Parse(wasltxt.Text);
                dt.Clear();
                da = new SqlDataAdapter("select * from vorder where sdate=@1 and wasl=@2", con);
                da.SelectCommand.Parameters.AddWithValue("@1", d.Date);
                da.SelectCommand.Parameters.AddWithValue("@2", wasl);
                da.Fill(dt);
                sum = 0;
                foreach (DataRow dr in dt.Rows)
                {

                    sum = sum + decimal.Parse(dr["sprice"].ToString());

                }

                label1.Text = NumberToText.Convert(sum);
                up = 0;
            }
            }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                d = DateTime.Now;
             

                if (flowLayoutPanel1.Controls.Count == 0)
                {
                    saleform_Load(this, null);
                }
                else
                {
                    addwasl();
                }
            }
            catch { }
            finally
            {
                clear();
            }
        }




        waslrep w;
        DataTable dt3 = new DataTable();
       
        public void print()
        {
            try
            {

                dt3.Clear();
              
                SqlDataAdapter da = new SqlDataAdapter("select * from vsale where wasl=@1 and sdate=@2", con);
                da.SelectCommand.Parameters.AddWithValue("@1", NumberToText.arabtoeng(wasltxt.Text));
                da.SelectCommand.Parameters.AddWithValue("@2", d.Date);
                da.Fill(dt3);
                w = new waslrep();

                w.SetDataSource(dt3);
                w.Refresh();


                //w.PrintOptions.PaperSize = PaperSize.DefaultPaperSize;
                // w.PrintOptions.

                PageMargins margins;


                margins = w.PrintOptions.PageMargins;
                margins.bottomMargin = 0;
                margins.leftMargin = 0;
                margins.rightMargin = 0;
                margins.topMargin = 0;
                w.PrintOptions.ApplyPageMargins(margins);
                CrystalDecisions.CrystalReports.Engine.TextObject txtReportHeader;
              

               txtReportHeader = w.ReportDefinition.ReportObjects["Text6"] as TextObject;
               txtReportHeader.Text = label1.Text;


                w.PrintToPrinter(1, false, 0, 0);



            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            if (f.ShowDialog() == DialogResult.OK)
            {

                wasltxt.Text = waslno.ToString();
               
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel2.Controls.Clear();
                flowLayoutPanel3.Controls.Clear();
             

                dt.Clear();
                da = new SqlDataAdapter("select * from vorder where sdate=@1 and wasl=@2", con);
                da.SelectCommand.Parameters.AddWithValue("@1", d.Date);
                da.SelectCommand.Parameters.AddWithValue("@2", waslno);
                da.Fill(dt);
                sum = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    v.sid = decimal.Parse(dr["sid"].ToString());
                    v.sprice = decimal.Parse(dr["sprice"].ToString());
                    sum = sum + decimal.Parse(dr["sprice"].ToString());
                    v.fname = dr["fname"].ToString();
                    v.fpic = (byte[])dr["fpic"];
                    v.qty = int.Parse(dr["qty"].ToString());
                    v.note = dr["note"].ToString();
                    v.sdate = DateTime.Parse(dr["sdate"].ToString());
                    ordercontrol or = new ordercontrol();
                    or.f = this;
                    or.v = v;
                    or.wasl = decimal.Parse(wasltxt.Text);
                    or.dtt = DateTime.Now.Date;
                    or.sid = decimal.Parse(dr["sid"].ToString());
                    flowLayoutPanel3.Controls.Add(or);
                }

                label1.Text = NumberToText.Convert(sum);
                vsale.Clear();
                da = new SqlDataAdapter("select * from vsale where sdate=@1 and wasl=@2", con);
                da.SelectCommand.Parameters.AddWithValue("@1", d.Date);
                da.SelectCommand.Parameters.AddWithValue("@2", waslno);
                da.Fill(vsale);

                if (vsale.Rows.Count > 0)
                {
                    telltxt.Text = vsale.Rows[0]["tell"].ToString();
                    comboBox1.SelectedIndex = comboBox1.FindStringExact(vsale.Rows[0]["dname"].ToString());
                }


            }
            else
            {
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel2.Controls.Clear();
                flowLayoutPanel3.Controls.Clear();
                d = DateTime.Now;
                saleform_Load(this, null);
                clear();
             
            }
        }
    }




}
