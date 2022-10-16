using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fastfoodnew
{
    public partial class Settingform : Telerik.WinControls.UI.RadForm
    {
        public Settingform()
        {
            InitializeComponent();
        }

        private void Settingform_Load(object sender, EventArgs e)
        {
            foreach (SettingsProperty currentProperty in Properties.Settings.Default.Properties)
            {
                Label l = new Label();
                l.Name = "a" + currentProperty.Name;
                l.Text = currentProperty.Name;
                flowLayoutPanel1.Controls.Add(l);

                TextBox t = new TextBox();
                t.Width = 980;
                t.Name = currentProperty.Name;
                t.Text = Properties.Settings.Default[currentProperty.Name].ToString();

                flowLayoutPanel1.Controls.Add(t);

            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");



            foreach (Control txt in flowLayoutPanel1.Controls.Cast<Control>().OrderBy(c => c.TabIndex))
            {
                if (txt is TextBox)
                {
                    //  MessageBox.Show(txt.Name + " = " + txt.Text);
                    if (txt.Name == "backup")
                    {
                        Properties.Settings.Default[txt.Name] = DateTime.Parse(txt.Text);
                    }
                    else if (txt.Name == "report")
                    {
                        Properties.Settings.Default[txt.Name] = DateTime.Parse(txt.Text);
                    }
                
                    else if (txt.Name == "modell")
                    {
                        connectionStringsSection.ConnectionStrings["fastfoodEntities"].ConnectionString = txt.Text;
                        Properties.Settings.Default[txt.Name] = txt.Text;
                        config.Save();
                        ConfigurationManager.RefreshSection("fastfoodEntities");
                        //    Clipboard.SetText(connectionStringsSection.ConnectionStrings["taqigaEntities1"].ConnectionString);
                    }
                    else
                    {
                        Properties.Settings.Default[txt.Name] = txt.Text;
                    }
                }

            }

            Properties.Settings.Default.Save();


            flowLayoutPanel1.Controls.Clear();

            Settingform_Load(this, null);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
