using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Proxler2
{
    static class Downloader
    {
        public static void Get(string uri)
        {

            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                int ContentLength=0;
                if (int.TryParse(resp.Headers.Get("Content-Length"), out ContentLength))
                {
                    Console.WriteLine("yey" + ContentLength);
                }
                //  StreamReader sr = new StreamReader(resp.GetResponseStream());
                ThrottledStream throttled = new ThrottledStream(resp.GetResponseStream(), 524288);

                int _bufferSize = 524288;
                using (var fileStream = File.Create(@"D:\Users\admin\Documents\Sourcetree\Proxler_TEST\Proxler2\bin\Release\video.mp4"))
                {
                    var buffer = new byte[_bufferSize];
                    int len;
                    long progress = 0;
                    while ((len = throttled.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, len);
                        progress += len;
                        double result = ((double)progress/ContentLength)*100;
                        Console.WriteLine(progress + "/" + ContentLength);
                        Console.WriteLine(result + "%");
                    }
                }
            } catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);             
            }

        }

    }           
}
