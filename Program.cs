using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RndScreenSaver
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //the arguments are necessary for windows, so it will allow proper integration into windows own screen savers
            if (args.Length > 0)
            {
                string firstArgument = args[0].ToLower().Trim();
                string secondArgument = null;

                if (firstArgument.Length > 2)
                {
                    secondArgument = firstArgument.Substring(3).Trim();
                    firstArgument = firstArgument.Substring(0, 2);
                }

                else if (args.Length > 1)
                    secondArgument = args[1];

                // Configuration mode
                if (firstArgument == "/c")
                    Application.Run(new SettingsForm());

                // Preview mode
                else if (firstArgument == "/p")
                {
                    if (secondArgument == null)
                    {
                        MessageBox.Show("Tato funce není podporována","Šetřič obrazovky", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                // Full-screen mode
                else if (firstArgument == "/s") 
                {
                    ShowScreenSaver();
                    Application.Run();
                }

                // Undefined argument
                else
                    MessageBox.Show("Omlouváme se, ale zadaný argument: \"" + firstArgument +"\" není platný.", "Šetřič obrazovky",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            // No arguments -> treat like /c
            else
                Application.Run(new SettingsForm());
        }

        static void ShowScreenSaver()
        {
            //Enable full screen mode on all available screens
            foreach (Screen screen in Screen.AllScreens)
            {
                Form1 screensaver = new Form1(screen.Bounds);
                screensaver.Show();
            }
        }


    }
}
