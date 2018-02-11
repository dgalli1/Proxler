using Octokit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proxler2
{
    public class SettingController
    {
        private string myEmail;
        public string Email
        {
            get { return myEmail; }
            set { myEmail = value; }
        }
        public int delay
        {
            get { return myDelay; }
            set { myDelay = value; }
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
        public enum DownloaderEnum
        {
            Jdownloader,
            youtubedl
        }
        private List<String> myHosterPriority;
        public List<String> HosterPriority
        {
            get { return myHosterPriority; }
            set { myHosterPriority = value; } 
        }
        public String ytDlPath
        {
            get { return myytDlPath; }
        }



        public int youtubeDLVersion { get; internal set; }

        private DownloaderEnum myDownloader;
        public DownloaderEnum Downloader
        {
            get { return myDownloader; }
            set { myDownloader = value; }
        }

        public string downloadpath { get; internal set; }

        private string myytDlPath;
        private string FilePath;
        private string HosterPath;
        private int myDelay;

        public SettingController()
        {

        }
        public SettingController(string Email,string Password, string DeviceName)
        {
            myEmail = Email;
            myPassword = Password;
            myDeviceName = DeviceName;
            
        }
        public void updateYoutubeDl()
        {
            Task Updater = AsyncUpdate(this);
        }
        public void updateYoutubeDlforce()
        {
            this.youtubeDLVersion = 0;
            updateYoutubeDl();
        }
        

        private async static Task AsyncUpdate(SettingController Settings)
        {

            var client = new GitHubClient(new ProductHeaderValue("what_the_fuck_do_i_have_to_write_here"));
            var releases = await client.Repository.Release.GetAll("rg3", "youtube-dl");
            var latest = releases[0];
            if (latest.Id != Settings.youtubeDLVersion)
            {//start replace old file
                foreach (var item in latest.Assets)
                {
                    if (item.Name == "youtube-dl.exe")
                    {
                        using (WebClient webClient = new WebClient())
                        {
                            try
                            {
                                Console.WriteLine(Settings.ytDlPath);
                                Console.WriteLine(item.BrowserDownloadUrl);
                                webClient.DownloadFile(item.BrowserDownloadUrl, Settings.ytDlPath);
                                Settings.youtubeDLVersion = latest.Id;
                                Settings.SaveToFile();
                                MessageBox.Show("youtube-dl was updated successfully");
                            }
                            catch
                            {
                                MessageBox.Show("Automatic Update from Yt-dl failed");
                            }
                        }
                    }
                }
            }
            //add check if run on windows

        }

        public void LoadFromFile()
        {
            try { 
            // The folder for the roaming current user 
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // Combine the base folder with your specific folder....
            string specificFolder = Path.Combine(folder, "Proxler");
                myytDlPath = Path.Combine(specificFolder, "youtube-dl.exe");//set a path so it can download

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
                youtubeDLVersion =Int32.Parse(credits[3]);
                myDownloader = (DownloaderEnum)Int32.Parse(credits[4]);
                downloadpath = credits[5];
                    myDelay = Int32.Parse(credits[6]);
            } else
                {
                    youtubeDLVersion = 0;
                    myDownloader = DownloaderEnum.youtubedl;
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
            catch
            {
                System.Windows.Forms.MessageBox.Show("Your Save file is corrupted");
            }
        }

        public void SaveHosterToFile()
        {
            File.WriteAllText(HosterPath, string.Join(";", myHosterPriority.ToArray()));
        }

        public void SaveToFile()
        {
            File.WriteAllText(FilePath, myEmail + ";" + myPassword + ";" + myDeviceName + ";" + this.youtubeDLVersion + ";" +(int)this.myDownloader + ";" + this.downloadpath + ";"+this.myDelay);
        }
    }
}
