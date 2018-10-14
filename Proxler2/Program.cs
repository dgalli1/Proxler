using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proxler2
{
    static class Program
    {
        [DllImport("Shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FileAssociationHelper.AssociateFileExtension(".anix");
             SHChangeNotify(0x09000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
            
            string[] args = Environment.GetCommandLineArgs();
            string id = "-1";
            if (args.Length > 1) {
             if(File.Exists(args[1]))
                {
                    //dont start whole application just continue watching from the last episode
                    //pare file for that

                    //windows default programm to start it
                    string directory=Path.GetDirectoryName(args[1]);

                    //eventualy implented to go to correct sub
                    System.Diagnostics.Process.Start(@"file path");
                } else
                {
                    id = args[1].Replace("proxler:", "");
                    id = id.Replace("/", "");
                }

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


            key.Close();
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new FrmMain(id));
        }
        static Boolean IsAssociated()
        {
            return (Registry.CurrentUser.OpenSubKey("Software\\Classes\\.animx", false) == null);
        }
        public static void Associate()
        {
            RegistryKey FileReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\.animx");
            RegistryKey AppReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\Applications\\Proxler2.exe");
            RegistryKey AppAssoc = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.animx");

            

            AppAssoc.CreateSubKey("UserChoice").SetValue("Progid", "Applications\\Proxler2.exe");
        }
    }
}
