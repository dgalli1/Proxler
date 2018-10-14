using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Proxler2
{
     class Downloader
    {
        int downloadspeed = Int32.MaxValue; //unlimited
        public double downloadspeedmb
        {
            get { return ConvertBytesToMegabytes(downloadspeed); }
        }
        ThrottledStream throttled;
        private FrmMain frmMain;
        internal BackgroundWorker backgroundworker;
        internal int episodeall;

        public Downloader(FrmMain frmMain)
        {
            this.frmMain = frmMain;
        }

        public void Get(string uri,string savepath)
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
                throttled = new ThrottledStream(resp.GetResponseStream(), downloadspeed);
                FileInfo fileInfo = new FileInfo(savepath);

                if (!fileInfo.Exists)
                {
                    Directory.CreateDirectory(fileInfo.Directory.FullName);
                }
                int _bufferSize = 4096;
                using (var fileStream = File.Create(savepath))
                {
                    var buffer = new byte[_bufferSize];
                    int len;
                    long progress = 0;
                    Queue<int> lastseconds = new Queue<int>();
                    int lastbytes = 0;
                    while ((len = throttled.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, len);
                        progress += len;
                        double percentage = ((double)progress/ContentLength)*100;
                        setDownloadSpeed(frmMain.maxDownloadSpeedmbytes);
                        int kbytes = throttled.BytesPerSecond / 1024;
                        int mbytes = throttled.BytesPerSecond / 1024;
                        //Console.WriteLine(kbytes + "kybtes/s");
                        if(lastbytes!=throttled.BytesPerSecond)
                        {
                            lastseconds.Enqueue(kbytes);
                            lastbytes = throttled.BytesPerSecond;
                            Console.WriteLine("Enqued");
                        }
                        int lastsecs = 0;
                        foreach (int item in lastseconds)
                        {
                            lastsecs += item;
                        }
                        if(lastsecs!=0)
                        {
                            lastsecs = lastsecs / lastseconds.Count;
                        }
                        if(lastseconds.Count>10)
                        {
                            Console.WriteLine(lastsecs + "kybtes last 10s");

                            lastseconds.Dequeue();
                        }
                        //Console.WriteLine(ConvertBytesToMegabytes(throttled.BytesPerSecond));
                        backgroundworker.ReportProgress(episodeall, new System.Tuple<string, double, double>(Math.Round(ConvertBytesToMegabytes(progress)) + " von " + Math.Round(ConvertBytesToMegabytes(ContentLength))+"mb", percentage, ConvertBytesToMegabytes(0)));
         
                    }

                }
                throttled.Close();
                throttled.Dispose();
            } catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);             
            }

        }

        public  void setDownloadSpeed(double mbytes)
        {
            this.downloadspeed = (int)ConvertMegabytsToBytes(mbytes);
            if(downloadspeed==0)
            {
                downloadspeed = Int32.MaxValue;
            }
            throttled.MaxBytesPerSecond = downloadspeed;
        }
        private double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
        private double ConvertMegabytsToBytes(double bytes)
        {
            return (bytes * 1024f) * 1024f;
        }

    }
}
