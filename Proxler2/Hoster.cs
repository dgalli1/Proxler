using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxler2
{
    class Hoster
    {
        private string myLink;
        public string Link
        {
            get { return myLink; }
        }
        private string myHoster;
        private int myEpisode;
        public int Episode
        {
            get { return myEpisode; }
        }
        public Hoster(string Hoster, string Link, int episode)
        {
            myHoster = Hoster;
            myLink = Link;
            myEpisode = episode;
        }//todo online handling

        public Boolean isHoster(String hoster)
        {
            return myHoster == hoster;
        }
    }
}
