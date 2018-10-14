using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxler2
{
    class YoutubeDl
    {
        private string mypathtoexcecutable;
        public string pathtoexcecutable
        {
            get { return mypathtoexcecutable; }
            set { mypathtoexcecutable = value; }
        }
        public YoutubeDl ()
        {

        }
        public youtubeDLResponse getLink(string unparsedURL)
        {
            List<String> arguments = new List<string>();
            arguments.Add("-g");
            arguments.Add(unparsedURL);
            return executeCommand(arguments);

        }
        public youtubeDLResponse download(string unparsedURL)
        {
            List<String> arguments = new List<string>();
            arguments.Add(unparsedURL);
            return executeCommand(arguments);
             
        }
        private youtubeDLResponse executeCommand(List<String> Arguments)
        {
            String StrArgument = "";
            foreach (string item in Arguments)
            {
                StrArgument += item + " ";
            }
            Process process = new Process();
            process.StartInfo.FileName = mypathtoexcecutable;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.Arguments = StrArgument;
            process.Start();
            youtubeDLResponse response = new youtubeDLResponse();
            response.arguments = StrArgument;
            string output = process.StandardOutput.ReadToEnd();
            string err = process.StandardError.ReadToEnd();
            string[] arr_output = output.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None
            );
            foreach (var item in arr_output)
            {
                if(item.StartsWith("http"))
                {
                    response.filelink = item;
                } else
                {
                    response.AddOutput(item);
                }
                
            }
            string[] arr_error = output.Split(
            new[] { Environment.NewLine },
            StringSplitOptions.None
            );
            foreach (string item in arr_error)
            {
                if(item.StartsWith("WARNING"))
                {
                    response.AddWarning(item);
                } else
                {
                    response.AddError(item);
                }
            }
            Console.WriteLine("Output: "+output);
            Console.WriteLine("ERR:" +err);
            process.WaitForExit();
            return response;
        }
    }
}
