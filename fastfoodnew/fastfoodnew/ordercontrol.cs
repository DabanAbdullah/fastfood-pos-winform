using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Telerik.WinControls;
using System.Data.SqlClient;

namespace fastfoodnew
{
    public partial class ordercontrol : UserControl
    {
        
        public ordercontrol()
        {
            InitializeComponent();
          
        }


        public  saleform f { get; set; }
       
        public  vorder v=new vorder();
        fastfoodEntities dbb = new fastfoodEntities();
        public decimal sid { get; set; }
        public decimal wasl { get; set; }

        public DateTime dtt { get; set; }

        SqlConnection con = db.con;
        DataTable dat = new DataTable();
        SqlDataAdapter da;
        private void ordercontrol_Load(object sender, EventArgs e)
        {


            radCheckedDropDownList1.DisplayMember = "note";

          //  radCheckedDropDownList1.CheckedMember = "note";

            radCheckedDropDownList1.DataSource = dbb.notetables.ToList(); ;

            using (var a=new MemoryStream(v.fpic))
            {
                pictureBox1.Image = Image.FromStream(a);
            }
            label1.Text = v.fname;
            label2.Text =NumberToText.numtoarab( v.sprice.ToString("G29"));
            radCheckedDropDownList1.Text = v.note;
            textBox1.Text = v.qty.ToString();
          
           

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (usinfo.getpermission("update", "sale") == true) {
                

                    textBox1.Text = (int.Parse(textBox1.Text) + 1).ToString();
                  


                    SqlParameter[] p = new SqlParameter[4];

                    string sql = "update saletable set qty=@1,lastmodified=@2,modifiedby=@3 where sid=@4";

                    p[0] = new SqlParameter("@1", int.Parse(textBox1.Text));
                    p[1] = new SqlParameter("@2", DateTime.Now);
                    p[2] = new SqlParameter("@3", usinfo.uid);
                    p[3] = new SqlParameter("@4", sid);
                    db.docmd(sql, p);

                f.getdata();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (usinfo.getpermission("update", "sale") == true)
            {

                if (int.Parse(textBox1.Text) > 1)
                {
                    textBox1.Text = (int.Parse(textBox1.Text) - 1).ToString();
                  
                        SqlParameter[] p = new SqlParameter[4];

                        string sql = "update saletable set qty=@1,lastmodified=@2,modifiedby=@3 where sid=@4";

                        p[0] = new SqlParameter("@1", int.Parse(textBox1.Text));
                        p[1] = new SqlParameter("@2", DateTime.Now);
                        p[2] = new SqlParameter("@3", usinfo.uid);
                        p[3] = new SqlParameter("@4", sid);
                        db.docmd(sql, p);
                    f.getdata();

                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            if (RadMessageBox.Show(this, "سڕینەوە", "دڵنیایت؟", MessageBoxButtons.YesNo, RadMessageIcon.Question, MessageBoxDefaultButton.Button1, RightToLeft.Yes) == DialogResult.Yes)
            {


                if (usinfo.getpermission("delete", "sale") == true)
                {

                    var rec = dbb.saletables.Where(x => x.sid == v.sid).FirstOrDefault();
                    if (rec != null)
                    {
                        saleform.up = 1;

                        SqlParameter[] p = new SqlParameter[4];

                        string sql = "update saletable set isdeleted=@1,lastmodified=@2,modifiedby=@3 where sid=@4";

                        p[0] = new SqlParameter("@1", 'y');
                        p[1] = new SqlParameter("@2", DateTime.Now);
                        p[2] = new SqlParameter("@3", usinfo.uid);
                        p[3] = new SqlParameter("@4", sid);
                        db.docmd(sql, p);

                       // (this.Parent as FlowLayoutPanel).Controls.Remove(this);

                        f.getdata();

                    }

                    



                


                    // SqlDataAdapter da = new SqlDataAdapter("select * from saletable where isdeleted='n' and wasl=@1 and sdate=@2",);


                    dat.Clear();
                

                    da = new SqlDataAdapter("select * from saletable where wasl=@1 and sdate=@2 and isdeleted='n'", con);
                    da.SelectCommand.Parameters.AddWithValue("@1", wasl);
                    da.SelectCommand.Parameters.AddWithValue("@2", dtt.Date);
                    da.Fill(dat);

                    if (dat.Rows.Count == 0)
                    {

                         SqlParameter[] p = new SqlParameter[5];

                        string sql = "update wasltable set isdeleted=@1,lastmodified=@2,modifiedby=@3 where wasl=@4 and sdate=@5";

                        p[0] = new SqlParameter("@1", 'y');
                        p[1] = new SqlParameter("@2", DateTime.Now);
                        p[2] = new SqlParameter("@3", usinfo.uid);
                        p[3] = new SqlParameter("@4", wasl);
                        p[4] = new SqlParameter("@5", dtt.Date);
                        db.docmd(sql, p);

                    }



                    if (dbb.saletables.Where(x => x.wasl ==wasl && x.sdate == dtt && x.isdeleted == "n").ToList().Count == 0)
                    {

                       
                        var a = dbb.saletables.Where(x => x.wasl == v.wasl && x.sdate == v.sdate).FirstOrDefault();
                        if (a != null)
                        {
                            a.isdeleted = "y";
                            a.modifiedby = usinfo.uid;
                            a.lastmodified = DateTime.Now.Date;
                            dbb.SaveChanges();
                        }
                    }



                }
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (usinfo.getpermission("update", "sale") == true)
            {



                SqlParameter[] p = new SqlParameter[4];

                string sql = "update saletable set qty=@1,lastmodified=@2,modifiedby=@3 where sid=@4";

                p[0] = new SqlParameter("@1", int.Parse(textBox1.Text));
                p[1] = new SqlParameter("@2", DateTime.Now);
                p[2] = new SqlParameter("@3", usinfo.uid);
                p[3] = new SqlParameter("@4", sid);
                db.docmd(sql, p);



              p = new SqlParameter[2];

            sql = "update saletable set note=@1 where sid=@2";

                p[0] = new SqlParameter("@1", radCheckedDropDownList1.Text.Replace(';',' '));
                p[1] = new SqlParameter("@2", sid);

                db.docmd(sql, p);
                f.getdata();
                
            }
                
            }
        

        private void radCheckedDropDownList1_ItemCheckedChanged(object sender, Telerik.WinControls.UI.RadCheckedListDataItemEventArgs e)
        {



            //if (radCheckedDropDownList1.Items.Count > 0)
            //{
            //    MessageBox.Show("sdsd");

            //    SqlParameter[] p = new SqlParameter[2];

            //    string sql = "update saletable set note=@1 where sid=@2";

            //    p[0] = new SqlParameter("@1", radCheckedDropDownList1.Text);
            //    p[1] = new SqlParameter("@2", sid);

            //    db.docmd(sql, p);
            //}


        }
    }
}
