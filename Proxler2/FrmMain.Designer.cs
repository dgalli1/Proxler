namespace Proxler2
{
    partial class FrmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_AnimeName = new System.Windows.Forms.Label();
            this.lbDown = new System.Windows.Forms.Label();
            this.lbAnime = new System.Windows.Forms.Label();
            this.lbFolgen = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSuchen = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_ID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ComboLanguage = new System.Windows.Forms.ComboBox();
            this.tb_LastEpisode = new System.Windows.Forms.TextBox();
            this.tb_firstEpisode = new System.Windows.Forms.TextBox();
            this.bn_Download = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bn_Jdownloader = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_delay = new System.Windows.Forms.TextBox();
            this.bn_add = new System.Windows.Forms.Button();
            this.bn_remove = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Anime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HeAnistart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HeAniEnd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lb_animeprogress = new System.Windows.Forms.Label();
            this.lb_animestatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_AnimeName
            // 
            this.lb_AnimeName.AutoSize = true;
            this.lb_AnimeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_AnimeName.Location = new System.Drawing.Point(71, 101);
            this.lb_AnimeName.Name = "lb_AnimeName";
            this.lb_AnimeName.Size = new System.Drawing.Size(0, 16);
            this.lb_AnimeName.TabIndex = 51;
            // 
            // lbDown
            // 
            this.lbDown.AutoSize = true;
            this.lbDown.Location = new System.Drawing.Point(313, 426);
            this.lbDown.Name = "lbDown";
            this.lbDown.Size = new System.Drawing.Size(0, 13);
            this.lbDown.TabIndex = 49;
            // 
            // lbAnime
            // 
            this.lbAnime.AutoSize = true;
            this.lbAnime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAnime.Location = new System.Drawing.Point(5, 101);
            this.lbAnime.Name = "lbAnime";
            this.lbAnime.Size = new System.Drawing.Size(49, 16);
            this.lbAnime.TabIndex = 50;
            this.lbAnime.Text = "Anime:";
            // 
            // lbFolgen
            // 
            this.lbFolgen.AutoSize = true;
            this.lbFolgen.Location = new System.Drawing.Point(278, 147);
            this.lbFolgen.Name = "lbFolgen";
            this.lbFolgen.Size = new System.Drawing.Size(118, 13);
            this.lbFolgen.TabIndex = 42;
            this.lbFolgen.Text = "Keine Serie ausgewählt";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 40;
            this.label9.Text = "Folgen: ";
            // 
            // btnSuchen
            // 
            this.btnSuchen.Location = new System.Drawing.Point(473, 96);
            this.btnSuchen.Name = "btnSuchen";
            this.btnSuchen.Size = new System.Drawing.Size(69, 26);
            this.btnSuchen.TabIndex = 39;
            this.btnSuchen.Text = "Suchen";
            this.btnSuchen.UseVisualStyleBackColor = true;
            this.btnSuchen.Click += new System.EventHandler(this.btnSuchen_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 24);
            this.label6.TabIndex = 38;
            this.label6.Text = "Serie ID:";
            // 
            // tb_ID
            // 
            this.tb_ID.Location = new System.Drawing.Point(377, 70);
            this.tb_ID.Name = "tb_ID";
            this.tb_ID.Size = new System.Drawing.Size(165, 20);
            this.tb_ID.TabIndex = 37;
            this.tb_ID.TextChanged += new System.EventHandler(this.tb_ID_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 18);
            this.label8.TabIndex = 36;
            this.label8.Text = "Sprache";
            // 
            // ComboLanguage
            // 
            this.ComboLanguage.Enabled = false;
            this.ComboLanguage.FormattingEnabled = true;
            this.ComboLanguage.Items.AddRange(new object[] {
            "Eng Sub",
            "Eng Dub",
            "Ger Sub",
            "Ger Dub"});
            this.ComboLanguage.Location = new System.Drawing.Point(104, 223);
            this.ComboLanguage.Name = "ComboLanguage";
            this.ComboLanguage.Size = new System.Drawing.Size(131, 21);
            this.ComboLanguage.TabIndex = 35;
            this.ComboLanguage.SelectedIndexChanged += new System.EventHandler(this.ComboLanguage_SelectedIndexChanged);
            // 
            // tb_LastEpisode
            // 
            this.tb_LastEpisode.Enabled = false;
            this.tb_LastEpisode.Location = new System.Drawing.Point(377, 180);
            this.tb_LastEpisode.Name = "tb_LastEpisode";
            this.tb_LastEpisode.Size = new System.Drawing.Size(165, 20);
            this.tb_LastEpisode.TabIndex = 34;
            this.tb_LastEpisode.Validating += new System.ComponentModel.CancelEventHandler(this.tb_LastEpisode_Validating);
            // 
            // tb_firstEpisode
            // 
            this.tb_firstEpisode.Enabled = false;
            this.tb_firstEpisode.Location = new System.Drawing.Point(104, 180);
            this.tb_firstEpisode.Name = "tb_firstEpisode";
            this.tb_firstEpisode.Size = new System.Drawing.Size(131, 20);
            this.tb_firstEpisode.TabIndex = 33;
            this.tb_firstEpisode.Validating += new System.ComponentModel.CancelEventHandler(this.tb_firstEpisode_Validating);
            // 
            // bn_Download
            // 
            this.bn_Download.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bn_Download.Location = new System.Drawing.Point(7, 370);
            this.bn_Download.Name = "bn_Download";
            this.bn_Download.Size = new System.Drawing.Size(227, 32);
            this.bn_Download.TabIndex = 32;
            this.bn_Download.Text = "Zu JDownloader hinzufügen";
            this.bn_Download.UseVisualStyleBackColor = true;
            this.bn_Download.Click += new System.EventHandler(this.bn_Download_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(278, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 18);
            this.label5.TabIndex = 31;
            this.label5.Text = "- Episode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 30;
            this.label4.Text = "Episode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 39);
            this.label1.TabIndex = 29;
            this.label1.Text = "Proxler";
            // 
            // bn_Jdownloader
            // 
            this.bn_Jdownloader.Location = new System.Drawing.Point(7, 416);
            this.bn_Jdownloader.Name = "bn_Jdownloader";
            this.bn_Jdownloader.Size = new System.Drawing.Size(227, 37);
            this.bn_Jdownloader.TabIndex = 52;
            this.bn_Jdownloader.Text = "JD-Account Verwalten";
            this.bn_Jdownloader.UseVisualStyleBackColor = true;
            this.bn_Jdownloader.Click += new System.EventHandler(this.bn_Jdownloader_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(294, 370);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(247, 32);
            this.button1.TabIndex = 53;
            this.button1.Text = "Hoster Priority";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(297, 426);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 55;
            this.label3.Text = "Delay (ms)";
            // 
            // tb_delay
            // 
            this.tb_delay.Location = new System.Drawing.Point(393, 426);
            this.tb_delay.Name = "tb_delay";
            this.tb_delay.Size = new System.Drawing.Size(131, 20);
            this.tb_delay.TabIndex = 56;
            this.tb_delay.Text = "10000";
            this.tb_delay.Validating += new System.ComponentModel.CancelEventHandler(this.tb_delay_Validating);
            // 
            // bn_add
            // 
            this.bn_add.Location = new System.Drawing.Point(460, 267);
            this.bn_add.Name = "bn_add";
            this.bn_add.Size = new System.Drawing.Size(81, 23);
            this.bn_add.TabIndex = 58;
            this.bn_add.Text = "Hinzufügen";
            this.bn_add.UseVisualStyleBackColor = true;
            this.bn_add.Click += new System.EventHandler(this.bn_add_Click);
            // 
            // bn_remove
            // 
            this.bn_remove.Location = new System.Drawing.Point(460, 310);
            this.bn_remove.Name = "bn_remove";
            this.bn_remove.Size = new System.Drawing.Size(81, 23);
            this.bn_remove.TabIndex = 59;
            this.bn_remove.Text = "Entfernen";
            this.bn_remove.UseVisualStyleBackColor = true;
            this.bn_remove.Click += new System.EventHandler(this.bn_remove_Click);
            // 
            // listView1
            // 
            this.listView1.AutoArrange = false;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Anime,
            this.HeAnistart,
            this.HeAniEnd,
            this.columnHeader2});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(7, 267);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(447, 97);
            this.listView1.TabIndex = 60;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Anime
            // 
            this.Anime.Text = "Anime";
            // 
            // HeAnistart
            // 
            this.HeAnistart.Text = "Von Ep.";
            // 
            // HeAniEnd
            // 
            this.HeAniEnd.Text = "Bis Ep.";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Sub";
            this.columnHeader2.Width = 100;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(7, 478);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(535, 23);
            this.progressBar1.TabIndex = 61;
            // 
            // lb_animeprogress
            // 
            this.lb_animeprogress.AutoSize = true;
            this.lb_animeprogress.Location = new System.Drawing.Point(313, 504);
            this.lb_animeprogress.Name = "lb_animeprogress";
            this.lb_animeprogress.Size = new System.Drawing.Size(0, 13);
            this.lb_animeprogress.TabIndex = 62;
            // 
            // lb_animestatus
            // 
            this.lb_animestatus.Location = new System.Drawing.Point(135, 504);
            this.lb_animestatus.Name = "lb_animestatus";
            this.lb_animestatus.Size = new System.Drawing.Size(153, 23);
            this.lb_animestatus.TabIndex = 63;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 526);
            this.Controls.Add(this.lb_animestatus);
            this.Controls.Add(this.lb_animeprogress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.bn_remove);
            this.Controls.Add(this.bn_add);
            this.Controls.Add(this.tb_delay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bn_Jdownloader);
            this.Controls.Add(this.lb_AnimeName);
            this.Controls.Add(this.lbDown);
            this.Controls.Add(this.lbAnime);
            this.Controls.Add(this.lbFolgen);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnSuchen);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_ID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ComboLanguage);
            this.Controls.Add(this.tb_LastEpisode);
            this.Controls.Add(this.tb_firstEpisode);
            this.Controls.Add(this.bn_Download);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_AnimeName;
        private System.Windows.Forms.Label lbDown;
        private System.Windows.Forms.Label lbAnime;
        private System.Windows.Forms.Label lbFolgen;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSuchen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_ID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ComboLanguage;
        private System.Windows.Forms.TextBox tb_LastEpisode;
        private System.Windows.Forms.TextBox tb_firstEpisode;
        private System.Windows.Forms.Button bn_Download;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bn_Jdownloader;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_delay;
        private System.Windows.Forms.Button bn_add;
        private System.Windows.Forms.Button bn_remove;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Anime;
        private System.Windows.Forms.ColumnHeader HeAnistart;
        private System.Windows.Forms.ColumnHeader HeAniEnd;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lb_animeprogress;
        private System.Windows.Forms.Label lb_animestatus;
    }
}

