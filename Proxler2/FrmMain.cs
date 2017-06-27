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


namespace Proxler2
{
    public partial class FrmMain : Form
    {
        private LoginData Data = new LoginData();
        private int Folgen;
        private int animeProgress = 0;
        private int accutalAnimeEp = 0;
        Queue<AniQue> Que;
        public FrmMain()
        {
            InitializeComponent();
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
        private void fetchAniInfo()
        {
            string id = tb_ID.Text;
            WebClient wc = new WebClient();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<string> subtyp = new List<String>();
            List<string> messages = new List<string>();


            String Animeinfo = wc.DownloadString("http://proxer.me/info/" + id + "/list/");
            int TitleStart = Animeinfo.IndexOf("name=\"description\"") + 65;
            int TitleEnde = Animeinfo.IndexOf(".", TitleStart);
            lb_AnimeName.Text = Animeinfo.Substring(TitleStart, TitleEnde - TitleStart);
            String json = wc.DownloadString("http://proxer.me/info/" + id + "/list/99" + "?format=json"); //99 Seite für genaue angabe über 50 Episoden
            try
            {


                RootObject ao = js.Deserialize<RootObject>(json);
                Folgen = ao.end;
                List<Datum> data = ao.data;

                lbFolgen.Text = Convert.ToString(Folgen);
                List<string> lang = ao.lang;
                List<String> Language = new List<String>();

                foreach (string value in lang)
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
                ComboLanguage.Enabled = true;
                tb_firstEpisode.Enabled = true;
                tb_LastEpisode.Enabled = true;
                ComboLanguage.DataSource = null;
                ComboLanguage.DataSource = Language;
                Language.Clear();
            }
            catch
            {
                lb_AnimeName.Text = "";
                ComboLanguage.Enabled = false;
                tb_firstEpisode.Enabled = false;
                tb_LastEpisode.Enabled = false;
            }
        }
        private void btnSuchen_Click(object sender, EventArgs e)
        {
            fetchAniInfo();
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
            fetchAniInfo();
            ListViewItem temp = new ListViewItem(new String[4] { lb_AnimeName.Text, tb_firstEpisode.Text, tb_LastEpisode.Text, ComboLanguage.Text });
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
       
                LinkGrabber grabber = new LinkGrabber(Anime.myID,Anime.myFirstEpisode,Anime.myLastEpisode,Anime.mySub,Anime.myDelay,backgroundWorker1);
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
