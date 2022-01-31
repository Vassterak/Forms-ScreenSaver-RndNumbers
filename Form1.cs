using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RndScreenSaver
{
    public partial class Form1 : Form
    {
        private Point mouseLocation;
        MyRandom random = new MyRandom();

        public Form1 (Rectangle Bounds)
        {
            InitializeComponent();
            this.Bounds = Bounds;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
            TopMost = true;
            LoadSettings();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseLocation.IsEmpty)
            {
                if (Math.Abs(mouseLocation.X - e.X) > 5 || Math.Abs(mouseLocation.Y - e.Y) > 5)
                    Application.Exit();
            }

            // Update current mouse location
            mouseLocation = e.Location;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "LCG:" + random.LCG_CLike().ToString();
            try
            {
                label1.Left = (int)(random.LCG_CLike() % this.Width);
                label1.Top = (int)(random.LCG_CLike() % this.Height);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error: " + ex);
                throw;
            }
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            label1.Text = "MAP:"+ random.LogisticMapAlgorithm().ToString();
            try
            {
                label1.Left = (int)(random.LCG_CLike() % this.Width);
                label1.Top = (int)(random.LCG_CLike() % this.Height);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error: " + ex);
                throw;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            label1.Text = "My:" + random.MyOwnRandom().ToString();
            try
            {
                label1.Left = (int)(random.LCG_CLike() % this.Width);
                label1.Top = (int)(random.LCG_CLike() % this.Height);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error: " + ex);
                throw;
            }
        }

        private void LoadSettings()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Rnd_ScreenSaver");

            if (key == null)
                timer1.Enabled = true;

            else
            {
                if ((int)key.GetValue("GeneratorType") == 0)
                    timer1.Enabled = true;

                else if ((int)key.GetValue("GeneratorType") == 1)
                    timer2.Enabled = true;

                else
                    timer3.Enabled = true;
            }
        }
    }
}
