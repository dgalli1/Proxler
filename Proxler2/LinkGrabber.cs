using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Proxler2
{
    class LinkGrabber
    {
        private string myId;
        private string myFirstEpisode;
        private string myLastEpisode;
        private string mySub;
        public List<Hoster> Links;
        private BackgroundWorker backgroundWorker1;

        private void FetchEpisode(string linkfirst, string id, int episode, string sub)
        {
            bool streamfound = false;
            using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
            {
                string episodelink = linkfirst + id + "/" + episode + "/" + sub;
                string htmlCode = client.DownloadString(episodelink);
                char[] delimiters = new char[] { '\r', '\n' };
                string[] htmlcodeLines = htmlCode.Split(delimiters);
                foreach (string line in htmlcodeLines)
                {
                    if (line.StartsWith("\tvar streams = "))
                    {

                        string templine = line.Remove(line.Length - 1);
                        templine = templine.Replace("\tvar streams = ", "");
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        mirror[] mirror = js.Deserialize<mirror[]>(templine);
                        foreach (mirror mirrorelement in mirror)
                        {
                            streamfound = true;
                            string link = mirrorelement.replace.Replace("#", mirrorelement.code);
                            if (link == "")
                            {
                                link = mirrorelement.code;
                            }
                            string Hoster = mirrorelement.type;
                            Console.WriteLine(Hoster);
                            if (!link.Contains("http:"))
                            {
                                link = "http:" + link;
                            }
                            Links.Add(new Hoster(Hoster, link, episode));
                        }

                    }
                   
                   
                       
                    
                }

            }
            if(!streamfound)
            {
                MessageBox.Show("Achtung Spamschutz Aktiv Rufe Proxer auf und klicke Auf denn Recapchan klicke danach auf okey");
                FetchEpisode(linkfirst, id, episode, sub);
            }
        }
        public LinkGrabber(string id, string firstepisode,string lastepisode, string sub,int delay, BackgroundWorker backgroundWorker1)
        {
            string myId = id;
            string myFirstEpisode =firstepisode;
            string myLastEpisode = lastepisode;
            string mySub =sub;
            int episodeall = 0;
            int intlastepisode = int.Parse(lastepisode);
            Links = new List<Hoster>();
            this.backgroundWorker1 = backgroundWorker1;

            int episode = int.Parse(firstepisode);
            string linkfirst = "http://proxer.me/watch/";
            while (intlastepisode >= episode)
            {
                FetchEpisode(linkfirst, id, episode, sub);
                 Thread.Sleep(delay);
                Console.WriteLine(episode + " fetched");
                episodeall++;
                episode++;
                backgroundWorker1.ReportProgress(episodeall);
         
            }



        }


    }
}
