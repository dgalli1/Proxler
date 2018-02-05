using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proxler2
{
    public partial class FrmJD : Form
    {
        public SettingController Data;
        public FrmJD(SettingController Data)
        {
            InitializeComponent();
            this.Data = Data;
            tb_DeviceName.Text = Data.DeviceName;
            tb_Email.Text = Data.Email;
            tb_Passwort.Text = Data.Password;
        }

 

        private void button1_Click(object sender, EventArgs e)
        {
            Data.Email = tb_Email.Text;
            Data.DeviceName = tb_DeviceName.Text;
            Data.Password = tb_Passwort.Text;
            this.Close();
        }
    }
}
