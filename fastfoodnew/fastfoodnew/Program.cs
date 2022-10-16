using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;

namespace fastfoodnew
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SetTelerikControlStyles();
            Application.Run(new splash());
        }

        private static void SetTelerikControlStyles()
        {
            RadMessageBox.SetThemeName("CrystalDark");
           

            RadMessageBox.Instance.FormElement.TitleBar.Font = new Font("Unikurd Jino", 14f);
            // I added this additional check for safety, if Telerik modifies the name of the control.
            if (RadMessageBox.Instance.Controls.ContainsKey("radLabel1"))
            {
                RadMessageBox.Instance.Controls["radLabel1"].Font = new Font("Unikurd Jino", 14f, FontStyle.Regular);
            }
        }
    }
}
