namespace Proxler2
{
    partial class FrmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_Email = new System.Windows.Forms.TextBox();
            this.tb_Passwort = new System.Windows.Forms.TextBox();
            this.tb_DeviceName = new System.Windows.Forms.TextBox();
            this.bn_Speichern = new System.Windows.Forms.Button();
            this.gb_jdownloader = new System.Windows.Forms.GroupBox();
            this.tb_delay = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gb_youtubedl = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tb_downloadpath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bn_updateytdl = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gb_jdownloader.SuspendLayout();
            this.gb_youtubedl.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 124);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "E-Mail";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 184);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Passwort";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 258);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(343, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "JDownloaderDeviceName";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(11, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1079, 59);
            this.label4.TabIndex = 3;
            this.label4.Text = "Logge dich hier mit deinen MyJDownloader Daten ein!";
            // 
            // tb_Email
            // 
            this.tb_Email.Location = new System.Drawing.Point(661, 105);
            this.tb_Email.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tb_Email.Name = "tb_Email";
            this.tb_Email.Size = new System.Drawing.Size(524, 38);
            this.tb_Email.TabIndex = 4;
            // 
            // tb_Passwort
            // 
            this.tb_Passwort.Location = new System.Drawing.Point(661, 184);
            this.tb_Passwort.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tb_Passwort.Name = "tb_Passwort";
            this.tb_Passwort.Size = new System.Drawing.Size(524, 38);
            this.tb_Passwort.TabIndex = 5;
            // 
            // tb_DeviceName
            // 
            this.tb_DeviceName.Location = new System.Drawing.Point(661, 267);
            this.tb_DeviceName.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tb_DeviceName.Name = "tb_DeviceName";
            this.tb_DeviceName.Size = new System.Drawing.Size(524, 38);
            this.tb_DeviceName.TabIndex = 6;
            // 
            // bn_Speichern
            // 
            this.bn_Speichern.Location = new System.Drawing.Point(60, 1361);
            this.bn_Speichern.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.bn_Speichern.Name = "bn_Speichern";
            this.bn_Speichern.Size = new System.Drawing.Size(1190, 67);
            this.bn_Speichern.TabIndex = 7;
            this.bn_Speichern.Text = "Speichern";
            this.bn_Speichern.UseVisualStyleBackColor = true;
            this.bn_Speichern.Click += new System.EventHandler(this.button1_Click);
            // 
            // gb_jdownloader
            // 
            this.gb_jdownloader.Controls.Add(this.tb_delay);
            this.gb_jdownloader.Controls.Add(this.label6);
            this.gb_jdownloader.Controls.Add(this.label1);
            this.gb_jdownloader.Controls.Add(this.label2);
            this.gb_jdownloader.Controls.Add(this.label3);
            this.gb_jdownloader.Controls.Add(this.label4);
            this.gb_jdownloader.Controls.Add(this.tb_DeviceName);
            this.gb_jdownloader.Controls.Add(this.tb_Email);
            this.gb_jdownloader.Controls.Add(this.tb_Passwort);
            this.gb_jdownloader.Location = new System.Drawing.Point(38, 306);
            this.gb_jdownloader.Name = "gb_jdownloader";
            this.gb_jdownloader.Size = new System.Drawing.Size(1321, 402);
            this.gb_jdownloader.TabIndex = 9;
            this.gb_jdownloader.TabStop = false;
            this.gb_jdownloader.Text = "myJDownloader";
            // 
            // tb_delay
            // 
            this.tb_delay.Location = new System.Drawing.Point(661, 320);
            this.tb_delay.Margin = new System.Windows.Forms.Padding(8);
            this.tb_delay.Name = "tb_delay";
            this.tb_delay.Size = new System.Drawing.Size(524, 38);
            this.tb_delay.TabIndex = 58;
            this.tb_delay.Text = "10000";
            this.tb_delay.TextChanged += new System.EventHandler(this.tb_delay_TextChanged);
            this.tb_delay.Validating += new System.ComponentModel.CancelEventHandler(this.tb_delay_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 337);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(205, 44);
            this.label6.TabIndex = 57;
            this.label6.Text = "Delay (ms)";
            // 
            // gb_youtubedl
            // 
            this.gb_youtubedl.Controls.Add(this.button1);
            this.gb_youtubedl.Controls.Add(this.tb_downloadpath);
            this.gb_youtubedl.Controls.Add(this.label5);
            this.gb_youtubedl.Controls.Add(this.bn_updateytdl);
            this.gb_youtubedl.Location = new System.Drawing.Point(38, 921);
            this.gb_youtubedl.Name = "gb_youtubedl";
            this.gb_youtubedl.Size = new System.Drawing.Size(1300, 417);
            this.gb_youtubedl.TabIndex = 13;
            this.gb_youtubedl.TabStop = false;
            this.gb_youtubedl.Text = "youtube-dl";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(320, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(277, 68);
            this.button1.TabIndex = 9;
            this.button1.Text = "Auwählen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tb_downloadpath
            // 
            this.tb_downloadpath.Location = new System.Drawing.Point(656, 84);
            this.tb_downloadpath.Name = "tb_downloadpath";
            this.tb_downloadpath.Size = new System.Drawing.Size(524, 38);
            this.tb_downloadpath.TabIndex = 8;
            this.tb_downloadpath.TextChanged += new System.EventHandler(this.tb_downloadpath_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 84);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(208, 32);
            this.label5.TabIndex = 7;
            this.label5.Text = "Download Pfad";
            // 
            // bn_updateytdl
            // 
            this.bn_updateytdl.Location = new System.Drawing.Point(14, 323);
            this.bn_updateytdl.Name = "bn_updateytdl";
            this.bn_updateytdl.Size = new System.Drawing.Size(1171, 73);
            this.bn_updateytdl.TabIndex = 0;
            this.bn_updateytdl.Text = "Erzwinge Update von youtube-dl";
            this.bn_updateytdl.UseVisualStyleBackColor = true;
            this.bn_updateytdl.Click += new System.EventHandler(this.bn_updateytdl_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(48, 74);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(616, 36);
            this.radioButton1.TabIndex = 14;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Interner Downloader verwenden (Empfholen)";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(48, 128);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(364, 36);
            this.radioButton2.TabIndex = 15;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "JDownloader verwenden";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Location = new System.Drawing.Point(38, 48);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1321, 230);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Downloader";
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 1630);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gb_youtubedl);
            this.Controls.Add(this.gb_jdownloader);
            this.Controls.Add(this.bn_Speichern);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "FrmSettings";
            this.Text = "Einstellungen";
            this.Load += new System.EventHandler(this.FrmJD_Load);
            this.gb_jdownloader.ResumeLayout(false);
            this.gb_jdownloader.PerformLayout();
            this.gb_youtubedl.ResumeLayout(false);
            this.gb_youtubedl.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_Email;
        private System.Windows.Forms.TextBox tb_Passwort;
        private System.Windows.Forms.TextBox tb_DeviceName;
        private System.Windows.Forms.Button bn_Speichern;
        private System.Windows.Forms.GroupBox gb_jdownloader;
        private System.Windows.Forms.GroupBox gb_youtubedl;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb_downloadpath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bn_updateytdl;
        private System.Windows.Forms.TextBox tb_delay;
        private System.Windows.Forms.Label label6;
    }
}