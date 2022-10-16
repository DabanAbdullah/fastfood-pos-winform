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

namespace fastfoodnew
{
    public partial class frmActivation : Telerik.WinControls.UI.RadForm
    {
        public frmActivation()
        {
            InitializeComponent();
        }
        public byte[] CertificatePublicKeyData { private get; set; }
        private void frmActivation_Load(object sender, EventArgs e)
        {
            //Assign the application information values to the license control
            licActCtrl.AppName = "aras";
            licActCtrl.LicenseObjectType = typeof(DemoLicense.MyLicense);
            licActCtrl.CertificatePublicKeyData = this.CertificatePublicKeyData;
            //Display the device unique ID
            licActCtrl.ShowUID();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Call license control to validate the license string
            if (licActCtrl.ValidateLicense())
            {
                //If license if valid, save the license string into a local file
                File.WriteAllText(Path.Combine(Application.StartupPath, "license.lic"), licActCtrl.LicenseBASE64String);

                MessageBox.Show("کۆدی چالاک کردن سەرکەوتوو بوو", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }

        private void frmActivation_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Are you sure to cancel?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
