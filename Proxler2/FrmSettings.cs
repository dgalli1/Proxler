using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proxler2
{
    public partial class FrmSettings : Form
    {
        public SettingController Data;
        public FrmSettings(SettingController Data)
        {
            InitializeComponent();
            this.Data = Data;
            tb_DeviceName.Text = Data.DeviceName;
            tb_Email.Text = Data.Email;
            tb_Passwort.Text = Data.Password;
            tb_downloadpath.Text=Data.downloadpath;
            tb_delay.Text = Data.delay + "";
            switch(Data.Downloader)
            {
                case SettingController.DownloaderEnum.Jdownloader:
                    radioButton2.Checked = true;
                    gb_jdownloader.Enabled = true;
                    gb_youtubedl.Enabled = false;
                    break;
                case SettingController.DownloaderEnum.youtubedl:
                    gb_jdownloader.Enabled = false;
                    radioButton1.Checked = true;
                    gb_youtubedl.Enabled = true;
                    break;
            }
            
        }

 

        private void button1_Click(object sender, EventArgs e)
        {
            Data.Email = tb_Email.Text;
            Data.DeviceName = tb_DeviceName.Text;
            Data.Password = tb_Passwort.Text;
            Data.downloadpath = tb_downloadpath.Text;
            Data.delay =Int32.Parse( tb_delay.Text);
            switch (Data.Downloader)
            {
                case SettingController.DownloaderEnum.Jdownloader:

                    break;
                case SettingController.DownloaderEnum.youtubedl:
                    if(Data.downloadpath.Length<1)
                    {
                        MessageBox.Show("Bitte setzte einen Pfad für die Datei Downloads, ansonsten wird  der Aktuelle Ordner von Proxler verwender");
                    }
                    break;
            }
            this.Close();
        }

        private void FrmJD_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            var radiobutton = sender as RadioButton;
            if(radiobutton.Checked)
            {
                Data.Downloader = SettingController.DownloaderEnum.youtubedl;
                gb_jdownloader.Enabled = false;
                gb_youtubedl.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            var radiobutton = sender as RadioButton;
            if (radiobutton.Checked)
            {
                Data.Downloader = SettingController.DownloaderEnum.Jdownloader;
                gb_jdownloader.Enabled = true;
                gb_youtubedl.Enabled = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    tb_downloadpath.Text = fbd.SelectedPath;
                }
            }
        }

        private void tb_downloadpath_TextChanged(object sender, EventArgs e)
        {

        }

        private void bn_updateytdl_Click(object sender, EventArgs e)
        {
            Data.updateYoutubeDlforce();
        }

        private void tb_delay_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Int32.Parse(tb_delay.Text);
            }
            catch
            {
                tb_delay.Text = "0";
            }
        }

        private void tb_delay_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
