namespace listnhac
{
    partial class frmVideo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVideo));
            this.playerVideo = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.playerVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // playerVideo
            // 
            this.playerVideo.Dock = System.Windows.Forms.DockStyle.Top;
            this.playerVideo.Enabled = true;
            this.playerVideo.Location = new System.Drawing.Point(0, 0);
            this.playerVideo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.playerVideo.Name = "playerVideo";
            this.playerVideo.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("playerVideo.OcxState")));
            this.playerVideo.Size = new System.Drawing.Size(848, 463);
            this.playerVideo.TabIndex = 14;
            // 
            // frmVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 466);
            this.Controls.Add(this.playerVideo);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmVideo";
            this.Text = "Video";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmVideo_FormClosed);
            this.Load += new System.EventHandler(this.frmVideo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playerVideo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private AxWMPLib.AxWindowsMediaPlayer playerVideo;
    }
}