using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxler2
{
    class AniQue
    {
        public string myID { get; private set; }
        public string myLastEpisode { get; private set; }
        public string myFirstEpisode { get; private set; }
        public string myName { get; private set; }
        public string mySub { get; private set; }

        public AniQue(String Name, String ID, string firstepisode, string lastepisode, string sub)
        {
            this.myName = Name;
            this.myID = ID;
            this.myFirstEpisode = firstepisode;
            this.myLastEpisode = lastepisode;
            this.mySub = sub;
        }
        public int EpisodeCount()
        {
            return Int32.Parse(myLastEpisode) - Int32.Parse(myFirstEpisode)+1;
        }

    }
}
