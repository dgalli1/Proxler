using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxler2
{
    public class Datum
    {
        public string no { get; set; }
        public string typ { get; set; }
        public string types { get; set; }
        public string typeimg { get; set; }
    }

    public class RootObject
    {
        public int start { get; set; }
        public int end { get; set; }
        public string kat { get; set; }
        public List<string> lang { get; set; }
        public List<Datum> data { get; set; }
        public int state { get; set; }
    }

    public class mirror
    {
        public string id { get; set; }
        public string code { get; set; }
        public string type { get; set; }
        public string htype { get; set; }
        public string name { get; set; }
        public string replace { get; set; }
        public string img { get; set; }
        public string parts { get; set; }
        public string ssl { get; set; }
        public string text { get; set; }
        public string legal { get; set; }
        public string uploader { get; set; }
        public string username { get; set; }
        public string tid { get; set; }
        public string tname { get; set; }
    }

}
