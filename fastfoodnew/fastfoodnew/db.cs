using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Diagnostics;

using Telerik.WinControls;
using System.ComponentModel;

using System.Threading;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace fastfoodnew
{
    public class format
    {
        public static void setformat(RadForm f)
        {
            f.ThemeName = "Fluent";
            f.RightToLeft = RightToLeft.Yes;
            // f.RightToLeftLayout = true;
            f.Font = new Font("UniKurd Jino", 12.0f);
            f.StartPosition = FormStartPosition.CenterScreen;
            f.WindowState = FormWindowState.Normal;
            f.MaximizeBox = false;
            f.MinimizeBox = false;
        }
    }

  public static  class img
    {

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public static byte[] ImageToByteArray(System.Drawing.Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }
    }

    public  class usinfo
    {
        public static  string  fullname{ get; set; }
        public static string rolename { get; set; }
        public static string password { get; set; }
        public static int uid { get; set; }
        public static List<autherizationv> per = new List<autherizationv>();



        public static bool getpermission(string op,string location)
        {

            if (usinfo.rolename == "ئەدمین" || usinfo.rolename.ToLower() == "admin")
            {
                return true;
            }
            else
            {
                var a = per.Where(x => x.tname == location).FirstOrDefault();
                if (a != null)
                {
                    if (op == "open")
                    {
                        return Convert(a.cancreate);
                    }
                    else if (op == "add")
                    {
                        return Convert(a.cancreate);

                    }
                    else if (op == "update")
                    {
                        return Convert(a.canupdate);

                    }
                    else if (op == "delete")
                    {
                        return Convert(a.candelete);

                    }


                    else { MessageBox.Show("ڕێگە پێدراو نیت بۆ ئەم کارە"); return false; }
                }
                else
                {
                    MessageBox.Show("ڕێگە پێدراو نیت بۆ ئەم کارە");
                    return false;
                }
            }

            
            
        }

        private static bool Convert(string a)
        {
            if (a == "y") return true;

            else { MessageBox.Show("ڕێگە پێدراو نیت بۆ ئەم کارە");   return false; }
        }

        
    }
   


    public static class db
    {


      

        public static string checkbox(RadCheckBox c)
        {
            if (c.Checked == true) return "y";
            else return "n";
        }


        public static bool checkbox2(string c)
        {
            if (c == "بەڵێ") return true;
            else return false;
        }


        public static decimal TruncateDecimal(decimal value, int decimalPlaces)
        {
            decimal integralValue = Math.Truncate(value);

            decimal fraction = value - integralValue;

            decimal factor = (decimal)Math.Pow(10, decimalPlaces);

            decimal truncatedFraction = Math.Truncate(fraction * factor) / factor;

            decimal result = integralValue + truncatedFraction;

            return result;
        }

        public static void senddb()
        {

            try
            {
                string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"/fastfood.bak";

                DateTime dt = DateTime.Now;


                if (File.Exists(path))
                {
                    File.Delete(path);
                }


                SqlConnection con = new SqlConnection(Properties.Settings.Default.conn);
                string connectionString = con.ConnectionString;





                var sqlConStrBuilder = new SqlConnectionStringBuilder(connectionString);

                // set backupfilename (you will get something like: "C:/temp/MyDatabase-2013-12-07.bak")


                string query = @"BACKUP DATABASE fastfood TO DISK='" + path + "'";


                using (var command = new SqlCommand(query, con))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    command.ExecuteNonQuery();


                    if (con.State == ConnectionState.Open) con.Close();
                }






                using (MailMessage mm = new MailMessage("bahzadmarket1@gmail.com", "bahzadmarket1@gmail.com"))
                {
                    mm.Subject = "fastfood" + " database backup at " + DateTime.Now.ToShortDateString();
                    mm.Body = "";

                    string FileName = Path.GetFileName(path);
                    Attachment attach = new Attachment(path);
                    mm.Attachments.Add(attach);

                    mm.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(db.Decrypt("kwZg7pJHYpxrd6jBCX3Wqw+nYKbuRZQazgMgSssUfJ3GOxc7MlRk5GwUpLi4rZzC"), db.Decrypt("qu7chwDG+bByUESJOpMLHG4N7SMYD8x8RO6SHtufZHE="));
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);


                }

                Properties.Settings.Default.backup = DateTime.Now.Date;

                Properties.Settings.Default.Save();


            }
            catch { }

        }

        public static void localbackup()
        {

            try
            {
                Thread.Sleep(100);
                string path =  System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"/fastfood.bak";
             

                DateTime dt = DateTime.Now;
                if ((Properties.Settings.Default.backup.Date - dt.Date).TotalDays <= -1)
                {


                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }


                    SqlConnection con = new SqlConnection(Properties.Settings.Default.conn);
                   
                    string connectionString = con.ConnectionString;





                    var sqlConStrBuilder = new SqlConnectionStringBuilder(connectionString);

                    // set backupfilename (you will get something like: "C:/temp/MyDatabase-2013-12-07.bak")


                    string query = @"BACKUP DATABASE fastfood TO DISK='" + path + "'";


                    using (var command = new SqlCommand(query, con))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        command.ExecuteNonQuery();


                        if (con.State == ConnectionState.Open) con.Close();
                    }





                }
                else
                {
                    //  MessageBox.Show("no need");
                }
            }
            catch { }

        }


        public static void senddb2()
        {

            try
            {

                FolderBrowserDialog f = new FolderBrowserDialog();

                if (DialogResult.OK == f.ShowDialog())
                {
                    string path =  f.SelectedPath + @"\fastfood.bak";
                   


                    DateTime dt = DateTime.Now;


                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }


                    SqlConnection con = new SqlConnection(Properties.Settings.Default.conn);
                    string connectionString = con.ConnectionString;





                    var sqlConStrBuilder = new SqlConnectionStringBuilder(connectionString);

                    // set backupfilename (you will get something like: "C:/temp/MyDatabase-2013-12-07.bak")


                    string query = @"BACKUP DATABASE fastfood TO DISK='" + path + "'";


                    using (var command = new SqlCommand(query, con))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        command.ExecuteNonQuery();


                        if (con.State == ConnectionState.Open) con.Close();
                    }






                    using (MailMessage mm = new MailMessage("bahzadmarket1@gmail.com", "bahzadmarket1@gmail.com"))
                    {
                        mm.Subject = "fastfood" + " database backup at " + DateTime.Now.ToShortDateString();
                        mm.Body = "";

                        string FileName = Path.GetFileName(path);
                        Attachment attach = new Attachment(path);
                        mm.Attachments.Add(attach);

                        mm.IsBodyHtml = false;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential(db.Decrypt("kwZg7pJHYpxrd6jBCX3Wqw+nYKbuRZQazgMgSssUfJ3GOxc7MlRk5GwUpLi4rZzC"), db.Decrypt("qu7chwDG+bByUESJOpMLHG4N7SMYD8x8RO6SHtufZHE="));
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mm);


                    }

                    Properties.Settings.Default.backup = DateTime.Now.Date;

                    Properties.Settings.Default.Save();
                    RadMessageBox.Show("Database Backup was succsessful");


                }
                else
                {
                    MessageBox.Show("canceled");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        public static void sendrep()
        {

            try
            {


                SqlDataAdapter da = new SqlDataAdapter("select * from sumsale", con);

                DataTable dt = new DataTable();
                da.Fill(dt);
                string text = "";

                foreach (DataRow dr in dt.Rows)
                {
                    text = text + dr["fullname"] + "       داشکاندن     " + dr["discount"] + "       نرخ     " + dr["price"] + "       بەروار     " + dr["sdate"] + Environment.NewLine;

                }


                using (MailMessage mm = new MailMessage("bahzadmarket1@gmail.com", "bahzadhawrami35@gmail.com"))
                {
                    mm.Subject = "ڕاپۆرتی " + DateTime.Now.AddDays(-1);
                    mm.Body = text;




                    mm.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(db.Decrypt("kwZg7pJHYpxrd6jBCX3Wqw+nYKbuRZQazgMgSssUfJ3GOxc7MlRk5GwUpLi4rZzC"), db.Decrypt("qu7chwDG+bByUESJOpMLHG4N7SMYD8x8RO6SHtufZHE="));
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);


                }

                Properties.Settings.Default.report = DateTime.Now.Date;

                Properties.Settings.Default.Save();




            }
            catch (Exception ex)
            {

            }

        }




        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }





        public static void createdb()
        {

            //List<string> list = new List<string>();

            //list.Add("sold");
            //list.Add("sumowe");
            //list.Add("RepStock");


            //MainForm f = new MainForm();
            //f.dbname = "mobilestore";
            //f.path = "MyDatabase.sqlite";
            //f.sqlservername = ".";
            //f.tablenames = list;
            //f.ShowDialog();


            //Thread thread = new Thread(() =>
            //{
            //    try
            //    {

            //        foreach (var entity in db1.ChangeTracker.Entries())
            //        {
            //            entity.Reload();
            //        }

            //        SQLiteConnection.CreateFile("MyDatabase.sqlite");

            //        SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            //        m_dbConnection.Open();


            //        string sql = "CREATE TABLE sell (name VARCHAR(20), company VARCHAR(50),model VARCHAR(50),model2 VARCHAR(50),color VARCHAR(50),serial VARCHAR(50),sprice VARCHAR(50),invoice VARCHAR(50),cash VARCHAR(50),sdate VARCHAR(50),cuname VARCHAR(50))";
            //        SQLiteCommand cmd = new SQLiteCommand(sql, m_dbConnection);
            //        cmd.ExecuteNonQuery();


            //        foreach (sold s in db1.solds.ToList().OrderBy(x => x.کۆمپانیا).OrderBy(x => x.مۆدێل).OrderBy(x => x.تایبەتمەندی))
            //        {
            //            sql = "insert into sell values(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11)";
            //            cmd = new SQLiteCommand(sql, m_dbConnection);
            //            cmd.Parameters.AddWithValue("@1", s.sid.ToString());
            //            cmd.Parameters.AddWithValue("@2", s.کۆمپانیا);
            //            cmd.Parameters.AddWithValue("@3", s.مۆدێل);
            //            cmd.Parameters.AddWithValue("@4", s.تایبەتمەندی);
            //            cmd.Parameters.AddWithValue("@5", s.ڕەنگ);
            //            cmd.Parameters.AddWithValue("@6", s.سریاڵ);
            //            cmd.Parameters.AddWithValue("@7", string.Format("{0}", s.نرخی_فرۆشتن));
            //            cmd.Parameters.AddWithValue("@8", string.Format("{0}", s.وەصل));
            //            cmd.Parameters.AddWithValue("@9", string.Format("{0}", s.کاش));
            //            cmd.Parameters.AddWithValue("@10", string.Format("{0}", s.بەروار));
            //            cmd.Parameters.AddWithValue("@11", s.کڕیار);
            //            cmd.ExecuteNonQuery();
            //        }



            //        sql = "CREATE TABLE sumowe (cuname VARCHAR(20), owe VARCHAR(50),paid paid(50),left VARCHAR(50))";
            //        cmd = new SQLiteCommand(sql, m_dbConnection);
            //        cmd.ExecuteNonQuery();

            //        foreach (sumowe s in db1.sumowes.ToList().OrderBy(x => x.cuname))
            //        {
            //            sql = "insert into sumowe values(@1,@2,@3,@4)";
            //            cmd = new SQLiteCommand(sql, m_dbConnection);
            //            cmd.Parameters.AddWithValue("@1", s.cuname);
            //            cmd.Parameters.AddWithValue("@2", s.owe);
            //            cmd.Parameters.AddWithValue("@3", s.paid);
            //            cmd.Parameters.AddWithValue("@4", s.left);

            //            cmd.ExecuteNonQuery();
            //        }

            //        sql = "CREATE table stock (model VARCHAR(200), descr VARCHAR(200),mawa VARCHAR(20),total VARCHAR(200) )";
            //        cmd = new SQLiteCommand(sql, m_dbConnection);
            //        cmd.ExecuteNonQuery();

            //        foreach (RepStock s in db1.RepStocks.Where(x => x.mawa > 0).ToList().OrderBy(x => x.cname).OrderBy(x => x.model).OrderBy(x => x.descr))
            //        {
            //            sql = "insert into stock values(@1,@2,@3,@4)";
            //            cmd = new SQLiteCommand(sql, m_dbConnection);
            //            cmd.Parameters.AddWithValue("@1", s.model);
            //            cmd.Parameters.AddWithValue("@2", s.descr);
            //            cmd.Parameters.AddWithValue("@3", s.mawa);
            //            cmd.Parameters.AddWithValue("@4", s.Total);

            //            cmd.ExecuteNonQuery();
            //        }



            //        //SQLiteDataAdapter da = new SQLiteDataAdapter("select * from sell", m_dbConnection);
            //        //DataTable dt = new DataTable();
            //        //da.Fill(dt);
            //        //RadMessageBox.Show(dt.Rows.Count.ToString());

            //        m_dbConnection.Close();
            //        m_dbConnection.Dispose();
            //    }
            //    catch (Exception ex) { RadMessageBox.Show(ex.Message); }
            //    finally {
            //        RadMessageBox.Show("done"); 
            //    }
            //});
            //    thread.Start();

            //  thread.Join();



        }

        public static void senddb(string fromname, string emailto, string constr, string dbname, string path)
        {

            try
            {
                SqlConnection con = new SqlConnection(constr);
                string connectionString = con.ConnectionString;


                //if (!Directory.Exists(path))
                //   Directory.CreateDirectory(path);



                var sqlConStrBuilder = new SqlConnectionStringBuilder(constr);

                // set backupfilename (you will get something like: "C:/temp/MyDatabase-2013-12-07.bak")



                string query = @"BACKUP DATABASE " + dbname + " TO DISK='" + path + "'";


                using (var command = new SqlCommand(query, con))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    command.ExecuteNonQuery();


                    if (con.State == ConnectionState.Open) con.Close();
                }






                using (MailMessage mm = new MailMessage("bahzadmarket1@gmail.com", emailto))
                {
                    mm.Subject = fromname;
                    mm.Body = "";

                    string FileName = Path.GetFileName(path);
                    Attachment attach = new Attachment(path);
                    mm.Attachments.Add(attach);

                    mm.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(db.Decrypt("kwZg7pJHYpxrd6jBCX3Wqw+nYKbuRZQazgMgSssUfJ3GOxc7MlRk5GwUpLi4rZzC"), db.Decrypt("qu7chwDG+bByUESJOpMLHG4N7SMYD8x8RO6SHtufZHE="));
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);


                }
            }
            catch { }

        }


        public static byte[] ff;
        public static void getimage()
        {
            OpenFileDialog f = new OpenFileDialog();
            f.ShowDialog();
            ff = File.ReadAllBytes(f.FileName);

        }

        public static string username, role = "admin";
        public static int uid = 3;
        public static string docmd(string sql, SqlParameter[] param)
        {
            string result = "";
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();
                result = "سەرکەوتوو بوو";
                if (con.State == ConnectionState.Closed) con.Close();
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }
            return result;
        }



        public static SqlConnection con = new SqlConnection(Properties.Settings.Default.conn);




        static DataTable dt = new DataTable();
        public static string getmax(string tablename, string field)
        {
            dt.Clear();
            string max = "";
            SqlDataAdapter da = new SqlDataAdapter("select isnull(max(CAST(  " + field + " AS NUMERIC)),0)+1 as max from " + tablename + "", con);
            da.Fill(dt);
            max = dt.Rows[0]["max"].ToString();

            return max;
        }

        public static string getmax2(string tablename, string field,DateTime date,string datename)
        {
            dt.Clear();
            string max = "";
            SqlDataAdapter da = new SqlDataAdapter("select isnull(max(CAST(  " + field + " AS NUMERIC)),0)+1 as max from " + tablename + " where "+datename+"=@1", con);
            da.SelectCommand.Parameters.AddWithValue("@1", date.Date);
            da.Fill(dt);
            max = dt.Rows[0]["max"].ToString();

            return max;
        }

        public static string getwasl(string tablename, string field, string date)
        {
            dt.Clear();
            string max = "";
            SqlDataAdapter da = new SqlDataAdapter("select isnull(max(" + field + "),0)+1 as max from " + tablename + " where " + date + "='" + DateTime.Now.ToShortDateString() + "' ", con);
            da.Fill(dt);
            max = dt.Rows[0]["max"].ToString();

            return max;
        }

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "RESV2PRZHA99795";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }




        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "RESV2PRZHA99795";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }



    }

    static class NumberToText

    {



        public static string numtoarab(string num)
        {
            return num.Replace('0', '٠').Replace('1', '١').Replace('2', '٢').Replace('3', '٣').Replace('4', '٤').Replace('5', '٥').Replace('6', '٦').Replace('7', '٧').Replace('8', '٨').Replace('9', '٩').Replace('،', ',');
        }

        public static string arabtoeng(string num)
        {
            return num.Replace('٠', '0').Replace('١', '1').Replace('٢', '2').Replace('٣', '3').Replace('٤', '4').Replace('٥', '5').Replace('٦', '6').Replace('٧', '7').Replace('٨', '8').Replace('٩', '9').Replace('،',',');
        }

        private static string[] _ones =
        {
            "سفر",
            "یەک",
            "دوو",
            "سێ",
            "چوار",
            "پێنج",
            "شەش",
            "حەوت",
            "هەشت",
            "نۆ"
        };

        private static string[] _teens =
        {
            "دە",
            "یانزە",
            "دوانزە",
            "سیانزە",
            "جواردە",
            "پانزە",
            "شانزە",
            "حەڤدە",
            "هەژدە",
            "نۆزدە"
        };

        private static string[] _tens =
        {
            "",
            "دە",
            "بیست",
            "سی",
            "چل",
            "پەنجا",
            "شەست",
            "حەفتا",
            "هەشتا",
            "نەوە"
        };

        // US Nnumbering:
        private static string[] _thousands =
        {
            "",
            "هەزار",
            "ملێۆن",
            "بلێۆن",
            "تریلوێن",
            "کوادریلیۆن"
        };

        /// <summary>
        /// Converts a numeric value to words suitable for the portion of
        /// a check that writes out the amount.
        /// </summary>
        /// <param name="value">Value to be converted</param>
        /// <returns></returns>
        public static string Convert(decimal value)
        {
            string digits, temp;
            bool showThousands = false;
            bool allZeros = true;

            // Use StringBuilder to build result
            StringBuilder builder = new StringBuilder();
            // Convert integer portion of value to string
            digits = ((long)value).ToString();
            // Traverse characters in reverse order
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int ndigit = (int)(digits[i] - '0');
                int column = (digits.Length - (i + 1));

                // Determine if ones, tens, or hundreds column
                switch (column % 3)
                {
                    case 0:        // Ones position
                        showThousands = true;
                        if (i == 0)
                        {
                            // First digit in number (last in loop)
                            temp = String.Format("{0} ", _ones[ndigit]);
                        }
                        else if (digits[i - 1] == '1')
                        {
                            // This digit is part of "teen" value
                            temp = String.Format("{0} ", _teens[ndigit]);
                            // Skip tens position
                            i--;
                        }
                        else if (ndigit != 0)
                        {
                            // Any non-zero digit
                            temp = String.Format("{0} ", _ones[ndigit]);
                        }
                        else
                        {
                            // This digit is zero. If digit in tens and hundreds
                            // column are also zero, don't show "thousands"
                            temp = String.Empty;
                            // Test for non-zero digit in this grouping
                            if (digits[i - 1] != '0' || (i > 1 && digits[i - 2] != '0'))
                                showThousands = true;
                            else
                                showThousands = false;
                        }

                        // Show "thousands" if non-zero in grouping
                        if (showThousands)
                        {
                            if (column > 0)
                            {
                                temp = String.Format("{0}{1}{2}",
                                    temp,
                                    _thousands[column / 3],
                                    allZeros ? " " : " و ");
                            }
                            // Indicate non-zero digit encountered
                            allZeros = false;
                        }
                        builder.Insert(0, temp);
                        break;

                    case 1:        // Tens column
                        if (ndigit > 0)
                        {
                            temp = String.Format("{0}{1}",
                                _tens[ndigit],
                                (digits[i + 1] != '0') ? "و" : " ");
                            builder.Insert(0, temp);
                        }
                        break;

                    case 2:        // Hundreds column
                        if (ndigit > 0)
                        {

                            if (_ones[ndigit].ToString() != "یەک")
                            {
                                temp = String.Format("{0} سەد و", _ones[ndigit]);
                                builder.Insert(0, temp);
                            }
                            else
                            {
                                temp = String.Format("{0} سەد و   ", "");
                                builder.Insert(0, temp);
                            }
                        }
                        break;
                }
            }

            // Append fractional portion/cents
            builder.AppendFormat("", (value - (long)value) * 100);

            // Capitalize first letter
            return String.Format("{0}{1}",
                Char.ToUpper(builder[0]),
                builder.ToString(1, builder.Length - 1)).TrimEnd('و');
        }
    }


    public static class UpdateExtensions
    {
        public delegate void Func<TArg0>(TArg0 element);

        public static int Update<TSource>(this IEnumerable<TSource> source, Func<TSource> update)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (update == null) throw new ArgumentNullException("update");
            if (typeof(TSource).IsValueType)
                throw new NotSupportedException("value type elements are not supported by update.");

            int count = 0;
            foreach (TSource element in source)
            {
                update(element);
                count++;
            }
            return count;
        }
    }


    public class inputbox
    {
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            RadForm form = new RadForm();
            form.ThemeName = "Office2013Dark";
            form.RightToLeft = RightToLeft.Yes;
            RadLabel label = new RadLabel();
            label.ThemeName = "Office2013Dark";
            RadDateTimePicker textBox = new RadDateTimePicker();
            textBox.CustomFormat = "yyyy-MM-dd";
            textBox.ThemeName = "Office2013Dark";
            RadButton buttonOk = new RadButton();
            buttonOk.ThemeName = "Office2013Dark";
            RadButton buttonCancel = new RadButton();
            buttonCancel.ThemeName = "Office2013Dark";

            form.Text = title;
            label.Text = promptText;


            buttonOk.Text = "Ok";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(329, 10, 100, 20);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(310, 85, 75, 23);
            buttonCancel.SetBounds(180, 85, 120, 23);

            label.AutoSize = true;

            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 150);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 0), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Value.ToShortDateString();
            return dialogResult;
        }

    }


    public class inputbox3
    {
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            RadForm form = new RadForm();
            form.ThemeName = "Office2013Dark";
            form.RightToLeft = RightToLeft.Yes;
            RadLabel label = new RadLabel();
            label.ThemeName = "Office2013Dark";
            RadTextBox textBox = new RadTextBox();
            textBox.ThemeName = "Office2013Dark";
            RadButton buttonOk = new RadButton();
            buttonOk.ThemeName = "Office2013Dark";
            RadButton buttonCancel = new RadButton();
            buttonCancel.ThemeName = "Office2013Dark";

            form.Text = title;
            label.Text = promptText;


            buttonOk.Text = "Ok";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(129, 10, 250, 20);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(310, 85, 75, 23);
            buttonCancel.SetBounds(180, 85, 120, 23);

            label.AutoSize = true;

            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 150);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 0), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

    }

    public class inputbox2
    {
        public static DialogResult InputBox(string title, string promptText, string link, ref string value)
        {
            RadForm form = new RadForm();
            form.ThemeName = "CrystalDark";
            form.RightToLeft = RightToLeft.Yes;
            RadLabel label = new RadLabel();
            label.ThemeName = "CrystalDark";
            RadTextBox textBox = new RadTextBox();
            textBox.ThemeName = "CrystalDark";
            RadButton buttonOk = new RadButton();
            buttonOk.ThemeName = "CrystalDark";
            RadButton buttonCancel = new RadButton();
            buttonCancel.ThemeName = "CrystalDark";

            form.Text = title;
            label.Text = promptText;
            textBox.Text = link;

            buttonOk.Text = "Ok";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(329, 10, 100, 20);
            textBox.SetBounds(12, 36, 372, 20);
            textBox.UseSystemPasswordChar = true;
            buttonOk.SetBounds(310, 85, 75, 23);
            buttonCancel.SetBounds(180, 85, 120, 23);

            label.AutoSize = true;

            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 150);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 0), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

    }


    public class inputbox4
    {
        public static DialogResult InputBox(string title, string promptText, string link, ref string value)
        {
            RadForm form = new RadForm();
            form.ThemeName = "CrystalDark";
            form.RightToLeft = RightToLeft.Yes;
            RadLabel label = new RadLabel();
            label.ThemeName = "CrystalDark";
            RadTextBox textBox = new RadTextBox();
            textBox.ThemeName = "CrystalDark";
            RadButton buttonOk = new RadButton();
            buttonOk.ThemeName = "CrystalDark";
            RadButton buttonCancel = new RadButton();
            buttonCancel.ThemeName = "CrystalDark";

            form.Text = title;
            label.Text = promptText;
            textBox.Text = link;

            buttonOk.Text = "Ok";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(329, 10, 100, 20);
            textBox.SetBounds(12, 36, 372, 20);
           
            buttonOk.SetBounds(310, 85, 75, 23);
            buttonCancel.SetBounds(180, 85, 120, 23);

            label.AutoSize = true;

            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 150);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 0), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

    }



}
