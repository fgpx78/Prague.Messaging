namespace WinMailSender
{
    partial class MainForm
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
            this.btCancel = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.btSaveConfig = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.fdbLogs = new WinMailSender.Components.FoldersBrowser();
            this.flbRecipients = new WinMailSender.Components.FilesBrowser();
            this.fdbTemplateFolder = new WinMailSender.Components.FoldersBrowser();
            this.flbSmtpServers = new WinMailSender.Components.FilesBrowser();
            this.SuspendLayout();
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCancel.Location = new System.Drawing.Point(254, 209);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(82, 23);
            this.btCancel.TabIndex = 18;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btStart
            // 
            this.btStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btStart.Location = new System.Drawing.Point(163, 208);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(85, 23);
            this.btStart.TabIndex = 19;
            this.btStart.Text = "Start bulk";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btSaveConfig
            // 
            this.btSaveConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSaveConfig.Location = new System.Drawing.Point(12, 208);
            this.btSaveConfig.Name = "btSaveConfig";
            this.btSaveConfig.Size = new System.Drawing.Size(107, 23);
            this.btSaveConfig.TabIndex = 20;
            this.btSaveConfig.Text = "Save config";
            this.btSaveConfig.UseVisualStyleBackColor = true;
            this.btSaveConfig.Click += new System.EventHandler(this.btSaveConfig_Click);
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExit.Location = new System.Drawing.Point(452, 208);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(93, 23);
            this.btExit.TabIndex = 21;
            this.btExit.Text = "Exit";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // fdbLogs
            // 
            this.fdbLogs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fdbLogs.LabelText = "Log folder";
            this.fdbLogs.Location = new System.Drawing.Point(12, 154);
            this.fdbLogs.Name = "fdbLogs";
            this.fdbLogs.Path = "";
            this.fdbLogs.Size = new System.Drawing.Size(533, 52);
            this.fdbLogs.TabIndex = 15;
            this.fdbLogs.PathSelected += new WinMailSender.Base.BrowserBase.PathSelectedEventHandler(this.fdbLogs_PathSelected);
            // 
            // flbRecipients
            // 
            this.flbRecipients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flbRecipients.FileFilter = "Excel Files|*.xls;*.xlsx";
            this.flbRecipients.LabelText = "Recipients file";
            this.flbRecipients.Location = new System.Drawing.Point(12, 106);
            this.flbRecipients.Name = "flbRecipients";
            this.flbRecipients.Path = "";
            this.flbRecipients.Size = new System.Drawing.Size(533, 42);
            this.flbRecipients.TabIndex = 14;
            this.flbRecipients.PathSelected += new WinMailSender.Base.BrowserBase.PathSelectedEventHandler(this.flbRecipients_PathSelected);
            // 
            // fdbTemplateFolder
            // 
            this.fdbTemplateFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fdbTemplateFolder.LabelText = "Templates folder";
            this.fdbTemplateFolder.Location = new System.Drawing.Point(12, 12);
            this.fdbTemplateFolder.Name = "fdbTemplateFolder";
            this.fdbTemplateFolder.Path = "";
            this.fdbTemplateFolder.Size = new System.Drawing.Size(533, 41);
            this.fdbTemplateFolder.TabIndex = 12;
            this.fdbTemplateFolder.PathSelected += new WinMailSender.Base.BrowserBase.PathSelectedEventHandler(this.fdbTemplateFolder_PathSelected);
            // 
            // flbSmtpServers
            // 
            this.flbSmtpServers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flbSmtpServers.FileFilter = "XML File|*.xml";
            this.flbSmtpServers.LabelText = "SMTP Server configuration file";
            this.flbSmtpServers.Location = new System.Drawing.Point(12, 59);
            this.flbSmtpServers.Name = "flbSmtpServers";
            this.flbSmtpServers.Path = "";
            this.flbSmtpServers.Size = new System.Drawing.Size(533, 41);
            this.flbSmtpServers.TabIndex = 13;
            this.flbSmtpServers.PathSelected += new WinMailSender.Base.BrowserBase.PathSelectedEventHandler(this.flbSmtpServers_PathSelected);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 244);
            this.Controls.Add(this.fdbTemplateFolder);
            this.Controls.Add(this.flbRecipients);
            this.Controls.Add(this.flbSmtpServers);
            this.Controls.Add(this.fdbLogs);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btSaveConfig);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.btCancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(573, 282);
            this.Name = "MainForm";
            this.Text = "E-mail sender";
            this.ResumeLayout(false);

        }

        #endregion

        private Components.FoldersBrowser fdbTemplateFolder;
        private Components.FilesBrowser flbSmtpServers;
        private Components.FilesBrowser flbRecipients;
        private Components.FoldersBrowser fdbLogs;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btSaveConfig;
        private System.Windows.Forms.Button btExit;
    }
}

