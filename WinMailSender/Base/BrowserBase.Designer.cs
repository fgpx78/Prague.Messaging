namespace WinMailSender.Base
{
    partial class BrowserBase
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btBrowse = new System.Windows.Forms.Button();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.lbParameterName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btBrowse
            // 
            this.btBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowse.Location = new System.Drawing.Point(241, 16);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.Size = new System.Drawing.Size(75, 23);
            this.btBrowse.TabIndex = 14;
            this.btBrowse.Text = "Browse...";
            this.btBrowse.UseVisualStyleBackColor = true;
            this.btBrowse.Click += new System.EventHandler(this.btBrowse_Click);
            // 
            // tbPath
            // 
            this.tbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPath.Location = new System.Drawing.Point(0, 18);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(235, 20);
            this.tbPath.TabIndex = 13;
            this.tbPath.TextChanged += new System.EventHandler(this.tbPath_TextChanged);
            // 
            // lbParameterName
            // 
            this.lbParameterName.AutoSize = true;
            this.lbParameterName.Location = new System.Drawing.Point(-3, 0);
            this.lbParameterName.Name = "lbParameterName";
            this.lbParameterName.Size = new System.Drawing.Size(35, 13);
            this.lbParameterName.TabIndex = 12;
            this.lbParameterName.Text = "Name";
            // 
            // BrowserBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btBrowse);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.lbParameterName);
            this.Name = "BrowserBase";
            this.Size = new System.Drawing.Size(316, 38);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btBrowse;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Label lbParameterName;
    }
}
