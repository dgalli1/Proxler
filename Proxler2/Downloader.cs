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
     class Downloader
    {
        int downloadspeed = Int32.MaxValue; //unlimited
        public double downloadspeedmb
        {
            get { return ConvertBytesToMegabytes(downloadspeed); }
        }
        ThrottledStream throttled;
        private FrmMain frmMain;

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
                    while ((len = throttled.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, len);
                        progress += len;
                        double result = ((double)progress/ContentLength)*100;
                        setDownloadSpeed(frmMain.maxDownloadSpeedmbytes);
                     
                        //Console.WriteLine(progress + "/" + ContentLength);
                        Console.WriteLine(result + "%");
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
