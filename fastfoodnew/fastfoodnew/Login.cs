using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using DemoLicense;
using QLicense;
using System.IO;
using System.Reflection;

namespace fastfoodnew
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        fastfoodEntities dbb = new fastfoodEntities();
        byte[] _certPubicKeyData;

        private void Login_Load(object sender, EventArgs e)
        {
            MyLicense _lic = null;
            string _msg = string.Empty;
            LicenseStatus _status = LicenseStatus.UNDEFINED;

            //Read public key from assembly
            Assembly _assembly = Assembly.GetExecutingAssembly();
            using (MemoryStream _mem = new MemoryStream())
            {


                _assembly.GetManifestResourceStream("fastfoodnew.LicenseVerify.cer").CopyTo(_mem);

                _certPubicKeyData = _mem.ToArray();
            }

            //Check if the XML license file exists
            if (File.Exists("license.lic"))
            {
                _lic = (MyLicense)LicenseHandler.ParseLicenseFromBASE64String(
                    typeof(MyLicense),
                    File.ReadAllText("license.lic"),
                    _certPubicKeyData,
                    out _status,
                    out _msg);
            }
            else
            {
                _status = LicenseStatus.INVALID;
                _msg = "ئەم بەرنامەیە چالاک نەکراوە";
            }

            switch (_status)
            {
                case LicenseStatus.VALID:

                    //TODO: If license is valid, you can do extra checking here
                    //TODO: E.g., check license expiry date if you have added expiry date property to your license entity
                    //TODO: Also, you can set feature switch here based on the different properties you added to your license entity 

                    //Here for demo, just show the license information and RETURN without additional checking       
                    licInfo.ShowLicenseInfo(_lic);

                    return;

                default:
                    //for the other status of license file, show the warning message
                    //and also popup the activation form for user to activate your application
                    MessageBox.Show(_msg, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    using (frmActivation frm = new frmActivation())
                    {
                        frm.CertificatePublicKeyData = _certPubicKeyData;
                        frm.ShowDialog();

                        //Exit the application after activation to reload the license file 
                        //Actually it is not nessessary, you may just call the API to reload the license file
                        //Here just simplied the demo process

                        Application.Exit();
                    }
                    break;
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://azhergroup.net/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int roleid = 0;
                string username = db.Encrypt(radTextBox1.Text);
                string pass = db.Encrypt(radTextBox2.Text);
                var a = dbb.usertables.Where(x => x.username == username && x.password == pass).FirstOrDefault();
                if (a != null)
                {
                    roleid = a.roleid;
                    var rec = dbb.rolestables.Where(x => x.roleid == roleid).FirstOrDefault();
                    if (rec != null)
                    {


                        if (rec.activated == "y")
                        {
                            usinfo.uid = a.userid;
                            usinfo.fullname = a.fullname;
                            usinfo.password = db.Decrypt(pass);
                            usinfo.rolename = dbb.rolestables.Where(x => x.roleid == rec.roleid).FirstOrDefault().rolename;
                            if(usinfo.per!=null)
                           usinfo.per.Clear();
                            foreach (autherizationv per in dbb.autherizationvs.Where(x => x.roleid == roleid).ToList())
                            {
                                
                                usinfo.per.Add(per);

                            }
                            radTextBox1.Text = "";
                            radTextBox2.Text = "";
                            this.Hide();

                            mainform f = new mainform();
                            f.Show();
                        }
                        else
                        {
                            MessageBox.Show("ئەم بەکارهێنەرە ئەکتیڤ نیە");
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("ناوی بەکارهێنەر یان وشەی نهێنی هەڵەیە");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string value = "";
            if (inputbox2.InputBox("Change Application setting", "Autherization", "Password", ref value) == DialogResult.OK)
            {
                if (value == "gnt573")
                {
                    Settingform f = new Settingform();
                    f.ShowDialog();
                }
                else
                {
                    RadMessageBox.Show("Wrong password");
                }
            }
         }



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {



            if (keyData == (Keys.Enter))
            {
                button2_Click(this, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


    }
}
