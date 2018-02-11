using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        int mydelay;
        private HttpClient globClient;
        public List<Hoster> Links;
        private BackgroundWorker backgroundWorker1;

        public void FetchEpisodeAsync(string linkfirst, string id, int episode, string sub)
        {

            bool streamfound = false;
            //   client.Headers.Add(HttpRequestHeader.Cookie, "adult=1"); //if this cookie is set the pages over 18 can get accessed (test anime 44 => Elfen Lied) todo use in HttpClient //client already created in main thread
            
                string episodelink = linkfirst + id + "/" + episode + "/" + sub;
                string htmlCode =  globClient.GetStringAsync(episodelink).Result;
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

            if(!streamfound)
            {
                MessageBox.Show("Kein Streamgefunden versuche erneut");
                FetchEpisodeAsync(linkfirst, id, episode, sub);
            }
        }
        public LinkGrabber(string id, string firstepisode,string lastepisode, string sub,int delay, BackgroundWorker backgroundWorker1, HttpClient client)
        {
            globClient = client;
            myId = id;
            myFirstEpisode =firstepisode;
            myLastEpisode = lastepisode;
            mySub =sub;
            mydelay = delay;
            Links = new List<Hoster>();
            this.backgroundWorker1 = backgroundWorker1;
            this.StartWork();
        }

        private void StartWork()
        {

        }
    }
}
