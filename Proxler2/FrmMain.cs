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
using System.Web.Script.Serialization;
using CloudFlareUtilities;
using System.Net.Http;

namespace Proxler2
{
    public partial class FrmMain : Form
    {
        private LoginData Data = new LoginData();
        private int Folgen;
        private int animeProgress = 0;
        private HttpClient client;//set global client i don't think this is how you do this but it saves me from solving cloudflare multiple times
        private int accutalAnimeEp = 0;
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
            listView1.View = View.Details;

        }

        private void bn_Jdownloader_Click(object sender, EventArgs e)
        {
            FrmJD myForm2 = new FrmJD(Data);
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
                AniQue temp = new AniQue(listviewitem.SubItems[0].Text, (String)listviewitem.Tag, listviewitem.SubItems[1].Text, listviewitem.SubItems[2].Text, Lang, Int32.Parse(tb_delay.Text));
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
                foreach (string value in untranslated_langs)
                {
                   
                    if (value == "gersub")
                    {
                        Language.Add("German Sub");
                    }
                    if (value == "gerdub")
                    {
                        Language.Add("German Dub");
                    }
                    if (value == "engsub")
                    {
                        Language.Add("English Sub");
                    }
                    if (value == "engdub")
                    {
                        Language.Add("English Dub");
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
                ComboLanguage.DataSource = null;
                ComboLanguage.DataSource = Language;
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

        private void ComboLanguage_SelectedIndexChanged(object sender, EventArgs e)
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

        private void tb_delay_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Int32.Parse(tb_delay.Text);
            }
            catch
            {
                tb_delay.Text = "0";
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
            int episodeall = 0;
            AniQue Anime = e.Argument as AniQue;
            LinkGrabber grabber = null;
                grabber = new LinkGrabber(Anime.myID, Anime.myFirstEpisode, Anime.myLastEpisode, Anime.mySub, Anime.myDelay, backgroundWorker1, client);
                int episode = Int32.Parse(Anime.myFirstEpisode); //todo;
                var jdownloader = new JDownloader();
                jdownloader.Connect(Data.Email, Data.Password);
                jdownloader.EnumerateDevices();
                var yourdevice = jdownloader.Devices.FirstOrDefault(x => x.Name == Data.DeviceName);
                foreach (string Hoster in Data.HosterPriority)
                {
                    foreach (Hoster item in grabber.Links)
                    {
                        if (item.Episode == episode && item.isHoster(Hoster))
                        {
                            jdownloader.AddLink(yourdevice, item.Link, Anime.myName + " Ep. " + item.Episode);
                            episode++;
                            episodeall++;
                        }

                    }
                }
                jdownloader.Disconnect();
            e.Result=Anime;
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
            progressBar1.Value = e.ProgressPercentage+animeProgress;
            lb_animeprogress.Text = e.ProgressPercentage + "/" + accutalAnimeEp;
            Console.Write("dfs");
        }
    }
}
