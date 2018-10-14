using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxler2
{
    class youtubeDLResponse
    {
        public string arguments { get; internal set; }
        public string filelink { get; internal set; }
        private List<String> myoutput = new List<string>();
        private List<String> mywarning = new List<string>();
        private List<String> myerror = new List<string>();
        public List<String> output {
            get { return myoutput; }
        }
        public List<String> warning
        {
            get { return myoutput; }
        }
        public List<String> error
        {
            get { return myoutput; }
        }

        public void AddOutput(String output)
        {
            myoutput.Add(output);
        }
        public void AddWarning(String warning)
        {
            mywarning.Add(warning);
        }
        public void AddError(String error)
        {
            myerror.Add(error);
        }
    }
}
