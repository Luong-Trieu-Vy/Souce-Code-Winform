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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVol = new System.Windows.Forms.Label();
            this.track_list = new System.Windows.Forms.ListBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.player = new AxWMPLib.AxWindowsMediaPlayer();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(727, 272);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "00:00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(24, 272);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "00:00";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(61, 275);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(645, 8);
            this.progressBar1.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btnNext);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblVol);
            this.groupBox1.Controls.Add(this.track_list);
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnPlay);
            this.groupBox1.Controls.Add(this.btnPause);
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Controls.Add(this.btnPrevious);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(2, 297);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(835, 162);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // btnNext
            // 
            this.btnNext.BackgroundImage = global::listnhac.Properties.Resources.forward;
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.ForeColor = System.Drawing.Color.Lime;
            this.btnNext.Location = new System.Drawing.Point(364, 17);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(79, 31);
            this.btnNext.TabIndex = 8;
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(619, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "0%";
            // 
            // lblVol
            // 
            this.lblVol.AutoSize = true;
            this.lblVol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblVol.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVol.ForeColor = System.Drawing.Color.Lime;
            this.lblVol.Location = new System.Drawing.Point(590, 142);
            this.lblVol.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVol.Name = "lblVol";
            this.lblVol.Size = new System.Drawing.Size(48, 13);
            this.lblVol.TabIndex = 2;
            this.lblVol.Text = "Volume";
            // 
            // track_list
            // 
            this.track_list.BackColor = System.Drawing.Color.LightGray;
            this.track_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.track_list.FormattingEnabled = true;
            this.track_list.Location = new System.Drawing.Point(20, 61);
            this.track_list.Margin = new System.Windows.Forms.Padding(2);
            this.track_list.Name = "track_list";
            this.track_list.Size = new System.Drawing.Size(554, 95);
            this.track_list.TabIndex = 6;
            this.track_list.SelectedIndexChanged += new System.EventHandler(this.track_list_SelectedIndexChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(588, 17);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 128);
            this.trackBar1.TabIndex = 5;
            // 
            // btnStop
            // 
            this.btnStop.BackgroundImage = global::listnhac.Properties.Resources.play_pause;
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.ForeColor = System.Drawing.Color.Lime;
            this.btnStop.Location = new System.Drawing.Point(269, 17);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(79, 31);
            this.btnStop.TabIndex = 4;
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // btnPlay
            // 
            this.btnPlay.BackgroundImage = global::listnhac.Properties.Resources.play1;
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPlay.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.ForeColor = System.Drawing.Color.Lime;
            this.btnPlay.Location = new System.Drawing.Point(103, 17);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(79, 31);
            this.btnPlay.TabIndex = 3;
            this.btnPlay.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            this.btnPause.BackgroundImage = global::listnhac.Properties.Resources.pause__1____Copy;
            this.btnPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPause.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnPause.FlatAppearance.BorderSize = 0;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.ForeColor = System.Drawing.Color.Lime;
            this.btnPause.Location = new System.Drawing.Point(186, 17);
            this.btnPause.Margin = new System.Windows.Forms.Padding(2);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(79, 31);
            this.btnPause.TabIndex = 2;
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // btnOpen
            // 
            this.btnOpen.BackgroundImage = global::listnhac.Properties.Resources.list_check___Copy;
            this.btnOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOpen.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnOpen.FlatAppearance.BorderSize = 0;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.ForeColor = System.Drawing.Color.Lime;
            this.btnOpen.Location = new System.Drawing.Point(494, 17);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(79, 31);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackgroundImage = global::listnhac.Properties.Resources.rewind;
            this.btnPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrevious.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnPrevious.FlatAppearance.BorderSize = 0;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.ForeColor = System.Drawing.Color.Lime;
            this.btnPrevious.Location = new System.Drawing.Point(20, 17);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(79, 31);
            this.btnPrevious.TabIndex = 0;
            this.btnPrevious.UseVisualStyleBackColor = true;
            // 
            // player
            // 
            this.player.Enabled = true;
            this.player.Location = new System.Drawing.Point(2, -2);
            this.player.Margin = new System.Windows.Forms.Padding(2);
            this.player.Name = "player";
            this.player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("player.OcxState")));
            this.player.Size = new System.Drawing.Size(835, 295);
            this.player.TabIndex = 14;
            // 
            // frmVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 466);
            this.Controls.Add(this.player);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmVideo";
            this.Text = "Video";
            this.Load += new System.EventHandler(this.frmVideo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVol;
        private System.Windows.Forms.ListBox track_list;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnPrevious;
        private AxWMPLib.AxWindowsMediaPlayer player;
    }
}