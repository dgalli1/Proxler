using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proxler2
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            string id = "-1";
            if (args.Length > 1) { 
            id = args[1].Replace("proxler:", "");
            id = id.Replace("/", "");
            }
            RegistryKey key = Registry.ClassesRoot.OpenSubKey("proxler");  //open myApp protocol's subkey
            string myAppPath= System.Windows.Forms.Application.ExecutablePath;
            if (key == null)  //if the protocol is not registered yet...we register it
            {
                try
                {
                    key = Registry.ClassesRoot.CreateSubKey("proxler");
                    key.SetValue(string.Empty, "URL: Proxler Protocol");
                    key.SetValue("URL Protocol", string.Empty);

                    key = key.CreateSubKey(@"shell\open\command");
                    key.SetValue(string.Empty, myAppPath + " " + "%1");
                }
                catch
                {
                    MessageBox.Show("Bitte starte das Programm das erste mal mit Admin rechten");
                }
                //%1 represents the argument - this tells windows to open this program with an argument / parameter
            }
            //check for updates on yt-dl
          //  Console.WriteLine(GetReleases("rg3", "youtube-dl"));
            //var latest = releases.Result[0];

            key.Close();
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new FrmMain(id));
        }

    }
}
