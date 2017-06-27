namespace Proxler2
{
    partial class FrmJD
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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "E-Mail";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Passwort";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "JDownloaderDeviceName";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(444, 51);
            this.label4.TabIndex = 3;
            this.label4.Text = "Logge dich hier mit deinen MyJDownloader Daten ein!";
            // 
            // tb_Email
            // 
            this.tb_Email.Location = new System.Drawing.Point(255, 78);
            this.tb_Email.Name = "tb_Email";
            this.tb_Email.Size = new System.Drawing.Size(199, 20);
            this.tb_Email.TabIndex = 4;
            // 
            // tb_Passwort
            // 
            this.tb_Passwort.Location = new System.Drawing.Point(255, 111);
            this.tb_Passwort.Name = "tb_Passwort";
            this.tb_Passwort.Size = new System.Drawing.Size(199, 20);
            this.tb_Passwort.TabIndex = 5;
            // 
            // tb_DeviceName
            // 
            this.tb_DeviceName.Location = new System.Drawing.Point(255, 146);
            this.tb_DeviceName.Name = "tb_DeviceName";
            this.tb_DeviceName.Size = new System.Drawing.Size(199, 20);
            this.tb_DeviceName.TabIndex = 6;
            // 
            // bn_Speichern
            // 
            this.bn_Speichern.Location = new System.Drawing.Point(12, 203);
            this.bn_Speichern.Name = "bn_Speichern";
            this.bn_Speichern.Size = new System.Drawing.Size(442, 28);
            this.bn_Speichern.TabIndex = 7;
            this.bn_Speichern.Text = "Speichern";
            this.bn_Speichern.UseVisualStyleBackColor = true;
            this.bn_Speichern.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmJD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 261);
            this.Controls.Add(this.bn_Speichern);
            this.Controls.Add(this.tb_DeviceName);
            this.Controls.Add(this.tb_Passwort);
            this.Controls.Add(this.tb_Email);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmJD";
            this.Text = "MyJDownloader";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}