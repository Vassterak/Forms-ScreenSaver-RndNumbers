using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RndScreenSaver
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            LoadCurrentSettings();
        }

        private void LoadCurrentSettings()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Rnd_ScreenSaver");

            if (key == null)
                radioButton1.Checked = true;
            else
            {
                if ((int)key.GetValue("GeneratorType") == 0)
                {
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                }

                else if ((int)key.GetValue("GeneratorType") == 1)
                {
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                    radioButton3.Checked = false;
                }

                else
                {
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = true;
                }
            }
        }

        private void SaveNowSettings()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Rnd_ScreenSaver");

            if (radioButton1.Checked)
                key.SetValue("GeneratorType", 0); //0 represents ID

            else if (radioButton2.Checked)
                key.SetValue("GeneratorType", 1); //ID

            else if (radioButton3.Checked)
                key.SetValue("GeneratorType", 2); //ID
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveNowSettings();
            Close();
        }
    }
}
