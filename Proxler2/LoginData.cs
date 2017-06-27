﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxler2
{
    public class LoginData
    {
        private string myEmail;
        public string Email
        {
            get { return myEmail; }
            set { myEmail = value; }
        }
        private string myPassword;
        public string Password
        {
            get { return myPassword; }
            set { myPassword = value; }
        }
        private string myDeviceName;
        public string DeviceName
        {
            get { return myDeviceName; }
            set { myDeviceName = value; }
        }
        private List<String> myHosterPriority;
        public List<String> HosterPriority
        {
            get { return myHosterPriority; }
            set { myHosterPriority = value; } 
        }
        private string FilePath;
        private string HosterPath;
        public LoginData()
        {

        }
        public LoginData(string Email,string Password, string DeviceName)
        {
            myEmail = Email;
            myPassword = Password;
            myDeviceName = DeviceName;
        }
        
        public void LoadFromFile()
        {
            // The folder for the roaming current user 
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // Combine the base folder with your specific folder....
            string specificFolder = Path.Combine(folder, "Proxler");

            // Check if folder exists and if not, create it
            if (!Directory.Exists(specificFolder))
                Directory.CreateDirectory(specificFolder);
            HosterPath = Path.Combine(specificFolder, "ProxlerHoster.txt");
             FilePath = Path.Combine(specificFolder, "ProxlerSettings.txt");
            
            if(File.Exists(FilePath))
            {
                string[] credits=File.ReadAllText(FilePath).Split(';');
                myEmail = credits[0];
                myPassword = credits[1];
                myDeviceName = credits[2];
            }
            string[] hosters;
            if (File.Exists(HosterPath))
            {
              hosters = File.ReadAllText(HosterPath).Split(';');
            }
            else
            {
              hosters = "hellsmedia;mp4upload;myvi;novamov;openload;proxer-stream;rutube;streamcloud;videoweed;yourupload".Split(';');
            }
            myHosterPriority = new List<string>(hosters);

        }

        public void SaveHosterToFile()
        {
            File.WriteAllText(HosterPath, string.Join(";", myHosterPriority.ToArray()));
        }

        public void SaveToFile()
        {
           File.WriteAllText(FilePath, myEmail+";"+myPassword+";"+myDeviceName);
        }
    }
}
