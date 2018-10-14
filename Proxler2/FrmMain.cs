using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CloudFlareUtilities;
using System.Net.Http;
using Octokit;
using System.IO;

namespace Proxler2
{
    public partial class FrmMain : Form
    {
        private SettingController Data = new SettingController();
        private int Folgen;
        private int animeProgress = 0;
        private HttpClient client;//set global client i don't think this is how you do this but it saves me from solving cloudflare multiple times
        private int accutalAnimeEp = 0;
        public double maxDownloadSpeedmbytes = 0;
        Queue<AniQue> Que;
        public FrmMain(string id)
        {
            InitializeComponent();
            if(id!="-1")//id passed by argument
            {
                tb_ID.Text = id;
                fetchAniInfoAsync(id);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Data.LoadFromFile();
            Data.updateYoutubeDl();

            listView1.View = View.Details;

        }


        private void bn_Jdownloader_Click(object sender, EventArgs e)
        {
            FrmSettings myForm2 = new FrmSettings(Data);
            myForm2.ShowDialog();
            Data.SaveToFile();

        }

        private void bn_Download_Click(object sender, EventArgs e)
        {
            bn_Download.Enabled = false;
             Que = new Queue<AniQue>();
            int alleFolgen=0;

            foreach (ListViewItem listviewitem in listView1.Items)
            {
                string Lang = listviewitem.SubItems[3].Text;
                if ("English Sub" == Lang)
                {
                    Lang = "engsub";
                }
                else if ("English Dub" == Lang)
                {
                    Lang = "engdub";
                }
                else if ("German Sub" == Lang)
                {
                    Lang = "gersub";
                }
                else if ("German Dub" == Lang)
                {
                    Lang = "gerdub";
                }
                AniQue temp = new AniQue(listviewitem.SubItems[0].Text, (String)listviewitem.Tag, listviewitem.SubItems[1].Text, listviewitem.SubItems[2].Text, Lang);
                alleFolgen += temp.EpisodeCount();
                Que.Enqueue(temp);
          
            }
            AniQue anime = Que.Dequeue();
            accutalAnimeEp = anime.EpisodeCount();
            lb_animeprogress.Text = 0 + "/" + accutalAnimeEp;
            progressBar1.Maximum = alleFolgen;
            progressBar1.Value = 0;
            lb_animestatus.Text = anime.myName;
            backgroundWorker1.RunWorkerAsync(anime);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmHoster FrmHoster = new FrmHoster(Data.HosterPriority);
            FrmHoster.ShowDialog();
            Data.HosterPriority = FrmHoster.HosterPriority;
            Data.SaveHosterToFile();
        }
        private async Task fetchAniInfoAsync(string id)
        {
            String Animeinfo = "";
            var cookieContainer = new CookieContainer();
            ClearanceHandler handler = new ClearanceHandler();                // Create the clearance handler.
            HttpClientHandler innerHandler = handler.InnerHandler as HttpClientHandler;
            innerHandler.AllowAutoRedirect = true;
            var baseAdress = new Uri("http://proxer.me/");
            innerHandler.CookieContainer.Add(baseAdress, new Cookie("adult", "1"));//wtf
            client = new HttpClient(handler);
            try
            {


                // Create a HttpClient that uses the handler to bypass CloudFlare's JavaScript challange.

                // Use the HttpClient as usual. Any JS challenge will be solved automatically for you.
                
                  Animeinfo = await client.GetStringAsync("http://proxer.me/info/" + id + "/list/");
            }
     
            catch (AggregateException ex) when (ex.InnerException is CloudFlareClearanceException)
            {
                MessageBox.Show("Some cloudflare bs happend 1");
                return;
            }
            catch (AggregateException ex) when (ex.InnerException is TaskCanceledException)
            {
                MessageBox.Show("Some cloudflare bs happend 2");
                return;
                // Looks like we ran into a timeout. Too many clearance attempts?
                // Maybe you should increase client.Timeout as each attempt will take about five seconds.
            }
            //   wc.Headers.Add(HttpRequestHeader.Cookie, "+adult=1"); //if this cookie is set the pages over 18 can get accessed (test anime 44 => Elfen Lied) //needs rework because use of HttpClient
            List<string> subtyp = new List<String>();
            List<string> messages = new List<string>();
           
            int TitleStart = Animeinfo.IndexOf("name=\"description\"") + 65;

            int TitleEnde = Animeinfo.IndexOf(".", TitleStart);
            String AnieName = Animeinfo.Substring(TitleStart, TitleEnde - TitleStart);
            lb_AnimeName.Text = AnieName;
            try
            {
               
                String[] posFolgSites = new String[] { "p\">1 - 50", ">51 - 100", "101 - 150", "151 - 200", //this definitly needs a rework @source to Jérome G
                    "201 - 250", "251 - 300", "301 - 350", "351 - 400", "401 - 450", "451 - 500", "501 - 550", "551 - 600", "601 - 650",
                    "651 - 700", "701 - 750", "751 - 800", "801 - 850", "851 - 900", "901 - 950" };
                int EpStart = Animeinfo.LastIndexOf("0</a>") - 8;
                int EpEnd = Animeinfo.LastIndexOf("0</a>") + 1;
                int page = 0;
                try
                {
                    for (int i = 1; i <= posFolgSites.Length - 1; i++)
                    {                                                                                       //Pages filled with episodes are determined
                        if (posFolgSites[i] == Animeinfo.Substring(EpStart, EpEnd - EpStart))
                        {
                            page = i + 1;                                                                   //Sets page value according to the last page that contains episodes.
                        }
                    }
                }
                catch { page = 1; }                                                                         //catches error if only one page of episodes is available.
                String EpUebersichtQC = await client.GetStringAsync("http://proxer.me/info/" + id + "/list/" + page);//new page for a more accurate determination of the last episode is converted to a string.
                EpStart = EpUebersichtQC.LastIndexOf(AnieName + " Episode") + AnieName.Length + 9;
                EpEnd = EpUebersichtQC.LastIndexOf(AnieName + " Episode") + AnieName.Length + 12;
                String FolgenAnz = EpUebersichtQC.Substring(EpStart, EpEnd - EpStart);                    //Accurate last episode is now in FolgenAnz 

                if (FolgenAnz.EndsWith("<"))                                                               //To prevent episode 1-99 from being set as text to the label with an "<" behind them.
                {
                    lbFolgen.Text = FolgenAnz.Substring(0, 2);
                }
                else { lbFolgen.Text = FolgenAnz; }
                List<String> untranslated_langs = new List<string>();
                String[] posLanguage = new String[] { "GerDub", "GerSub", "EngDub", "EngSub" };                 //Possible languages
                for (int i = 0; i <= posLanguage.Length - 1; i++)                                                  //Searches for available languages.
                {
                    int LangStart = Animeinfo.IndexOf(">" + posLanguage[i] + "<") + 19;
                    int LangEnd = Animeinfo.IndexOf(">" + posLanguage[i] + "<") + 32;
                    String LangAvailable = Animeinfo.Substring(LangStart, LangEnd - LangStart);
                    if (LangAvailable == "Status:Online" || LangAvailable == "Status:Ersche")                             //If available append to list.
                    {
                        untranslated_langs.Add(posLanguage[i].ToLower());
                    }
                }
                //end Source Jérome G
                List<String> Language = new List<String>();
                ComboLanguage.Items.Clear();
                foreach (string value in untranslated_langs)
                {
                   
                    if (value == "gersub")
                    {
                        ComboLanguage.Items.Add("German Sub");
                    }
                    if (value == "gerdub")
                    {
                        ComboLanguage.Items.Add("German Dub");
                    }
                    if (value == "engsub")
                    {
                        ComboLanguage.Items.Add("English Sub");
                    }
                    if (value == "engdub")
                    {
                        ComboLanguage.Items.Add("English Dub");
                    }
                }

                Folgen = 99999;
                //lbFolgen.Text = Convert.ToString(Folgen);
                /*
                Language.Add("German Sub");
                Language.Add("German Dub");
                Language.Add("English Sub");
                Language.Add("English Dub");
                */
                ComboLanguage.Enabled = true;
                tb_firstEpisode.Enabled = true;
                tb_LastEpisode.Enabled = true;

                Language.Clear();

            }
            catch (Exception ex)
            {
                throw ex;
                lb_AnimeName.Text = "";
                ComboLanguage.Enabled = false;
                tb_firstEpisode.Enabled = false;
                tb_LastEpisode.Enabled = false;
            }
        }
        private async void btnSuchen_Click(object sender, EventArgs e)
        {
            string id = tb_ID.Text;
            fetchAniInfoAsync(id);
        }

        private void tb_ID_TextChanged(object sender, EventArgs e)
        {

        }
   
        private void tb_LastEpisode_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int lastepisode = Int32.Parse(tb_LastEpisode.Text);
                if (Folgen < lastepisode)
                {
                    tb_LastEpisode.Text = "" + Folgen;
                }
            }
            catch
            {
                tb_LastEpisode.Text = "";
            }
        }

        private void tb_firstEpisode_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int firstepisode = Int32.Parse(tb_firstEpisode.Text);

                if (firstepisode <= 0)
                {
                    throw new Exception();
                }
            }
            catch
            {
                tb_firstEpisode.Text = "1";
            }

        }



        private void bn_add_Click(object sender, EventArgs e)
        {
            ListViewItem temp = new ListViewItem(new String[4] { lb_AnimeName.Text, tb_firstEpisode.Text, tb_LastEpisode.Text, this.ComboLanguage.GetItemText(this.ComboLanguage.SelectedItem) });
            temp.Tag = tb_ID.Text;
            listView1.Items.Add(temp);

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bn_remove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in listView1.SelectedItems)
            {
                listView1.Items.Remove(eachItem);
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            JDownloader jdownloader= new JDownloader();
            JDownloader.JdDevice yourdevice =new JDownloader.JdDevice();
            YoutubeDl youtubeDl = null;
            //setup downloader
            switch (Data.Downloader)
            {
                case SettingController.DownloaderEnum.Jdownloader:
                    try
                    {
                        jdownloader.Connect(Data.Email, Data.Password);
                        jdownloader.EnumerateDevices();
                         yourdevice = jdownloader.Devices.FirstOrDefault(x => x.Name == Data.DeviceName);
                    }
                    catch
                    {
                        MessageBox.Show("Konnte nicht zu deinem myJDownloader Account verbinden. Überprüfe deine Einstellungen");
                        return;
                    }
                    break;
                case SettingController.DownloaderEnum.youtubedl:
                    youtubeDl  = new YoutubeDl();
                    youtubeDl.pathtoexcecutable = Data.ytDlPath;
                    break;
            }
            int episodeall = 0;
            AniQue Anime = e.Argument as AniQue;
            LinkGrabber grabber = null;
            grabber = new LinkGrabber(Anime.myID, Anime.myFirstEpisode, Anime.myLastEpisode, Anime.mySub, backgroundWorker1, client);
            int episode = int.Parse(Anime.myFirstEpisode);
            string linkfirst = "http://proxer.me/watch/";
            int intlastepisode = int.Parse(Anime.myLastEpisode);
            string error_log = "";
            while (intlastepisode >= episode)
            {
                grabber.FetchEpisodeAsync(linkfirst, Anime.myID, episode, Anime.mySub);
                Boolean episode_found = false;
                foreach (string Hoster in Data.HosterPriority)
                {
                    foreach (Hoster item in grabber.Links)
                    {
                        if(episode_found)
                        {
                            continue;
                        }
                        if (item.Episode == episode && item.isHoster(Hoster))
                        {
                            //add to download Manager
                            Console.WriteLine(item.Link);
                            switch (Data.Downloader)
                            {
                                case SettingController.DownloaderEnum.Jdownloader:
                                    System.Threading.Thread.Sleep(Data.delay); //add delay because Downloads are threaded
                                    jdownloader.AddLink(yourdevice, item.Link, Anime.myName + " Ep. " + item.Episode);
                                    //todo online check eventuel?

                                    //go to next episode if everything worked out
                                    episodeall++;
                                    episode++;
                                    break;
                                case SettingController.DownloaderEnum.youtubedl:
                                    string filetype = "";
                                    string download_url = "";
                                    if (Hoster == "mp4upload") //mp4upload is not supported by youtube-dl anymore own logic
                                    {
                                        string link = item.Link;
                                        if(!item.Link.Contains("embed-"))
                                        { //we need the iframe (only this thing contains the url
                                            int posstart = item.Link.IndexOf('/', 5) + 1;
                                            link = item.Link.Insert(posstart, "embed-");

                                        }
                                        if(!item.Link.Contains(".html"))
                                        {
                                            link = link + ".html";
                                        }

                                        // Add a user agent header in case the 
                                        // requested URI contains a query.

                                        string webpage = client.GetStringAsync(link).Result;
                                        //extract a packed js object
                                        int startindex = webpage.IndexOf("<script type='text/javascript'>eval(function(p,a,c,k,e,d)", 0);
                                        string packed = webpage.Substring(startindex, webpage.IndexOf("</script>", startindex));
                                        String[] data = packed.Split('|');
                                        String subdomain = "";
                                        String videokey = "";
                                        String port = "";
                                        for (int i = 0; i < data.Length; i++)
                                        {
                                            string data_item = data[i];
                                            if (data_item == "IFRAME") //server name will be 5 elements after this
                                            {
                                                subdomain = data[i + 5] + "."; 
                                            }
                                            if (data_item == "video")
                                            {
                                                videokey = data[i + 1];
                                                port =data[i + 2];
                                            }

                                        }
                                        // construct url
                                        download_url = "https://" + subdomain + "mp4upload.com:" + port + "/d/" + videokey + "/video.mp4";
                                        filetype = "mp4";
                                    }
                                    else
                                    {
                                        youtubeDLResponse response = youtubeDl.getLink(item.Link);
                                        if (response.error.Count > 0)
                                        {
                                            Console.WriteLine(item.Link + "failed with" + response.error[0]);
                                            break;

                                        }
                                        else
                                        {
                                            filetype = response.filelink.Substring(response.filelink.LastIndexOf('.')).Replace("\n", "");
                                            download_url = response.filelink;
                                        }

                                    } 

                                       Console.WriteLine("try to download:" + download_url);
                                        episode_found = true;
                                        Downloader downloader = new Downloader(this);
                                        downloader.episodeall = episodeall;
                                        downloader.backgroundworker = backgroundWorker1;
                                        var path = "";
                                        int p = (int)Environment.OSVersion.Platform;
                                        if ((p == 4) || (p == 6) || (p == 128))
                                        {
                                            path = Data.downloadpath + "/" + CleanFileName(Anime.myName) + "/" + Anime.mySub + "/" + item.Episode + filetype;
                                        }
                                        else
                                        {
                                            path = Data.downloadpath + "\\" + CleanFileName(Anime.myName) + "\\" + Anime.mySub + "\\" + item.Episode + filetype;
                                        }
                                        downloader.Get(download_url, path); //wont work on linux
                                        episodeall++;//mark episode as complete
                                        episode++;
                                     

                                    break;

                            }
                        }

                    }

                }

                //check if the episode wa found
                if (!episode_found)
                {
                    //todo add to logs
                    error_log += "Couldn't add Episode" + episode + " because the hoster was unsupported or offline\n";
                    //episode not found add to logs and go to next episode
                    episodeall++;//mark episode as complete
                    episode++;
 
                }
                grabber.Links.Clear();//todo make this less stupid

                backgroundWorker1.ReportProgress(episodeall);

            }
            switch (Data.Downloader)
            {
                case SettingController.DownloaderEnum.Jdownloader:
                    jdownloader.Disconnect();
                    break;
                case SettingController.DownloaderEnum.youtubedl:

                    break;
            }
            MessageBox.Show(error_log);
            e.Result=Anime;
        }


        public static string CleanFileName(string fileName)
        {
            return Path.GetInvalidFileNameChars().Aggregate(fileName, (current, c) => current.Replace(c.ToString(), string.Empty));
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           AniQue old= e.Result as AniQue;
           animeProgress= old.EpisodeCount();
            if(Que.Count > 0)
            {
                AniQue anime = Que.Dequeue();
                accutalAnimeEp = anime.EpisodeCount();
                lb_animestatus.Text = anime.myName;
                lb_animeprogress.Text = 0 + "/" + accutalAnimeEp;
                backgroundWorker1.RunWorkerAsync(anime);
            }
            else
            {
                bn_Download.Enabled = true;
                animeProgress = 0;
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
            {
                var args = (System.Tuple<string, double, double>)e.UserState;
                progress_file.Value = (int)args.Item2;
                lb_fileprogress.Text = args.Item1;
            }
            progressBar1.Value = e.ProgressPercentage+animeProgress;
            lb_animeprogress.Text = e.ProgressPercentage + "/" + accutalAnimeEp;
        }

        private void tb_downloadSpeed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var temp = double.Parse(tb_downloadSpeed.Text);
                maxDownloadSpeedmbytes = temp;
            }
            catch
            {
                maxDownloadSpeedmbytes = 0;
            }
            Console.WriteLine(maxDownloadSpeedmbytes);
        }

        private void lb_fileprogress_Click(object sender, EventArgs e)
        {

        }
    }
}
