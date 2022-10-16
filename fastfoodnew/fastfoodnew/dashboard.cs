using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.IO;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Telerik.WinControls;

namespace fastfoodnew
{
     
    public partial class dashboard : Form
    {

      


        DateTime date = DateTime.Now;
        public dashboard()
        {
            InitializeComponent();
        }



     


        SqlConnection con = db.con;
        SqlDataAdapter da;
        DataTable dt = new DataTable();

        string cond = "where sdate=@1";

        public void getdata()
        {
          
            dt.Clear();
            da = new SqlDataAdapter("select isnull(sum(ko),0) as ko from sumsalebydate " + cond, con);
            if(cond.Length==14)
            da.SelectCommand.Parameters.AddWithValue("@1", date.Date);

            else
            {
                da.SelectCommand.Parameters.AddWithValue("@1", dateTimePicker1.Value);
                da.SelectCommand.Parameters.AddWithValue("@2", dateTimePicker2.Value);
            }
            da.Fill(dt);
            label3.Text =decimal.Parse( dt.Rows[0]["ko"].ToString()).ToString("G29");
            label4.Text = NumberToText.Convert(decimal.Parse(dt.Rows[0]["ko"].ToString()));
            dt.Clear();


            da = new SqlDataAdapter("select isnull(sum(ko),0) as ko from sumsaledwkan " + cond, con);
            if (cond.Length == 14)
                da.SelectCommand.Parameters.AddWithValue("@1", date.Date);

            else
            {
                da.SelectCommand.Parameters.AddWithValue("@1", dateTimePicker1.Value);
                da.SelectCommand.Parameters.AddWithValue("@2", dateTimePicker2.Value);
            }
            da.Fill(dt);
            label8.Text = decimal.Parse(dt.Rows[0]["ko"].ToString()).ToString("G29");
            label9.Text = NumberToText.Convert(decimal.Parse(dt.Rows[0]["ko"].ToString()));
            dt.Clear();




            da = new SqlDataAdapter("select isnull(sum(ko),0) as ko from sumsalediv " + cond, con);
            if (cond.Length == 14)
                da.SelectCommand.Parameters.AddWithValue("@1", date.Date);

            else
            {
                da.SelectCommand.Parameters.AddWithValue("@1", dateTimePicker1.Value);
                da.SelectCommand.Parameters.AddWithValue("@2", dateTimePicker2.Value);
            }
            da.Fill(dt);
            label5.Text = decimal.Parse(dt.Rows[0]["ko"].ToString()).ToString("G29");
            label6.Text = NumberToText.Convert(decimal.Parse(dt.Rows[0]["ko"].ToString()));
            dt.Clear();




            da = new SqlDataAdapter("select isnull(sum(ko),0) as ko from sumexpense " + cond, con);
            if (cond.Length == 14)
                da.SelectCommand.Parameters.AddWithValue("@1", date.Date);

            else
            {
                da.SelectCommand.Parameters.AddWithValue("@1", dateTimePicker1.Value);
                da.SelectCommand.Parameters.AddWithValue("@2", dateTimePicker2.Value);
            }
            da.Fill(dt);
            label11.Text = decimal.Parse(dt.Rows[0]["ko"].ToString()).ToString("G29");
            label12.Text = NumberToText.Convert(decimal.Parse(dt.Rows[0]["ko"].ToString()));
            dt.Clear();


        }








        private void textBox1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text== "    بەدوای وێنە بگەڕێ")
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "    بەدوای وێنە بگەڕێ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Diagnostics.Process.Start("https://www.google.com/search?q="+textBox1.Text);
            }
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            circularProgressBar1.Value = 0;
            textBox1_Leave(textBox1, null);
            getdata();
            getsalerep();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             cond = "where sdate between @1 and @2";
            getdata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            date = DateTime.Now;
            cond = "where sdate=@1";
            getdata();
        }

        public int GetCpuUsage()
        {
            var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", "MyComputer");
            cpuCounter.NextValue();
            System.Threading.Thread.Sleep(1000);
            return (int)cpuCounter.NextValue();
        }






        string fileName = Properties.Settings.Default.database;

      

        public void getfilename()
        {
            FileInfo fi = new FileInfo(fileName);
            long size = fi.Length;
           
            if (size / (1024 * 1024) > 100)
            {
                try
                {

                    if(size / (1024 * 1024*1024) > 100)
                    {
                        decimal s = size / (1024 * 1024 * 1024);
                        ProgressBar1.Text = s / (1024) + " TB";
                        ProgressBar1.Value = (int)(s / (1024 * 1024));
                    }
                    else
                    {
                        ProgressBar1.Text = size / (1024 * 1024 * 1024) + " GB";
                        ProgressBar1.Value = (int)(size / (1024 * 1024 * 1024));
                    }

                   
                }
                catch(Exception ex)
                {
                   //// MessageBox.Show(ex.Message);
                   // ProgressBar1.Maximum = 100;
                   // ProgressBar1.Value = (int)(size / (1024 * 1024))/10;
               
                }

            }
            else
            {
                ProgressBar1.Text = size / (1024 * 1024) + " MB";
                ProgressBar1.Value = (int)(size / (1024 * 1024));
            }
            
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

           
          

            try
            {


                getfilename();



            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.Message.ToString());
            }

          

           
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cond = "where sdate between @1 and @2";
            getdata();
            getsalerep();
        }



        sumsalerep r;
        public void getsalerep()
        {
            r=new sumsalerep();
            DataTable dt2 = new DataTable();
            da = new SqlDataAdapter("select *  from sumsalebydate " + cond +" order by sdate,fname", con);
            if (cond.Length == 14)
            {
                da.SelectCommand.Parameters.AddWithValue("@1", date.Date);
            }
            else
            {
                da.SelectCommand.Parameters.AddWithValue("@1", dateTimePicker1.Value);
                da.SelectCommand.Parameters.AddWithValue("@2", dateTimePicker2.Value);
            }

            da.Fill(dt2);
            r.SetDataSource(dt2);
            crystalReportViewer1.ReportSource = r;
            crystalReportViewer1.Refresh();
            r.Refresh(); ;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            cond = "where sdate between @1 and @2";
            getdata();
            getsalediv();
        }




        sumdiv r2;
        public void getsalediv()
        {
            r2 = new sumdiv();
            DataTable dt2 = new DataTable();
            da = new SqlDataAdapter("select *  from sumsalediv " + cond + " order by sdate,fname", con);
            if (cond.Length == 14)
            {
                da.SelectCommand.Parameters.AddWithValue("@1", date.Date);
            }
            else
            {
                da.SelectCommand.Parameters.AddWithValue("@1", dateTimePicker1.Value);
                da.SelectCommand.Parameters.AddWithValue("@2", dateTimePicker2.Value);
            }

            da.Fill(dt2);
            r2.SetDataSource(dt2);
            crystalReportViewer1.ReportSource = r2;
            crystalReportViewer1.Refresh();
            r2.Refresh(); ;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            cond = "where sdate between @1 and @2";
            getdata();
            getexp();
        }


        expreport r3;
        public void getexp()
        {
            r3 = new expreport();
            DataTable dt2 = new DataTable();
            da = new SqlDataAdapter("select *  from vexp " + cond + " order by sdate,ename", con);
            if (cond.Length == 14)
            {
                da.SelectCommand.Parameters.AddWithValue("@1", date.Date);
            }
            else
            {
                da.SelectCommand.Parameters.AddWithValue("@1", dateTimePicker1.Value);
                da.SelectCommand.Parameters.AddWithValue("@2", dateTimePicker2.Value);
            }

            da.Fill(dt2);
            r3.SetDataSource(dt2);
            crystalReportViewer1.ReportSource = r3;
            crystalReportViewer1.Refresh();
            r3.Refresh(); ;

        }

        private void label1_Click(object sender, EventArgs e)
        {
             backgroundWorker1.RunWorkerAsync();

        //    using (SqlConnection con = new SqlConnection(db.con.ConnectionString))
        //    {
        //        ServerConnection svrConnection = new ServerConnection(con);
        //        Server server = new Server(svrConnection);
        //        Backup bk = new Backup();
        //        bk.PercentComplete += pctComplete;
        //        bk.Action = BackupActionType.Database;
        //        bk.Database = con.Database;
               
        //bk.Devices.Add(new BackupDeviceItem(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"/fastfood.bak", DeviceType.File));
        //        bk.SqlBackup(server);
        //    }

        }

        private void pctComplete(object sender, PercentCompleteEventArgs e)
        {
            update(e.Percent);

           
        }

        public void update(int x)
        {
            circularProgressBar1.Value = x;
            circularProgressBar1.Text = x.ToString() + " %";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {





            for (int i = 0; i <= 100; i++)
            {
                db.localbackup();
                backgroundWorker1.ReportProgress(i);
            }
        }



        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            circularProgressBar1.Value = e.ProgressPercentage;
            circularProgressBar1.Text = e.ProgressPercentage.ToString() + " %";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RadMessageBox.Show("backup successfuly");
            circularProgressBar1.Value =0;
            circularProgressBar1.Text = 0 + " %";
        }
    }
}
