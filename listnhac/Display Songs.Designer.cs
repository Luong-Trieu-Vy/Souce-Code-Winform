namespace listnhac
{
    partial class frmDisplaySongs
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddMusic = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPlayAll = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.panelPlay = new System.Windows.Forms.Panel();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.lblTimeStart = new System.Windows.Forms.Label();
            this.lblTimeEnd = new System.Windows.Forms.Label();
            this.p_bar = new System.Windows.Forms.ProgressBar();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lbl_trackend = new System.Windows.Forms.Label();
            this.btnChon = new System.Windows.Forms.Button();
            this.dgvSong = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panelPlay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSong)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnAddMusic);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(315, 501);
            this.panel2.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Location = new System.Drawing.Point(86, 319);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(103, 51);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddMusic
            // 
            this.btnAddMusic.BackColor = System.Drawing.Color.Transparent;
            this.btnAddMusic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMusic.ForeColor = System.Drawing.Color.Black;
            this.btnAddMusic.Location = new System.Drawing.Point(86, 200);
            this.btnAddMusic.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddMusic.Name = "btnAddMusic";
            this.btnAddMusic.Size = new System.Drawing.Size(103, 51);
            this.btnAddMusic.TabIndex = 14;
            this.btnAddMusic.Text = "Add Music";
            this.btnAddMusic.UseVisualStyleBackColor = false;
            this.btnAddMusic.Click += new System.EventHandler(this.btnAddMusic_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::listnhac.Properties.Resources.spotify1;
            this.pictureBox1.Location = new System.Drawing.Point(106, 28);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Purple;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(96, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "Playlist";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.Controls.Add(this.btnExit);
            this.panel3.Controls.Add(this.btnPlayAll);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.txtSearch);
            this.panel3.Controls.Add(this.lblSearch);
            this.panel3.Controls.Add(this.panelPlay);
            this.panel3.Controls.Add(this.dgvSong);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(315, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(561, 501);
            this.panel3.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = global::listnhac.Properties.Resources.letter_x;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(528, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(33, 27);
            this.btnExit.TabIndex = 14;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPlayAll
            // 
            this.btnPlayAll.BackgroundImage = global::listnhac.Properties.Resources.play_button;
            this.btnPlayAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPlayAll.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnPlayAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayAll.Location = new System.Drawing.Point(21, 28);
            this.btnPlayAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlayAll.Name = "btnPlayAll";
            this.btnPlayAll.Size = new System.Drawing.Size(50, 44);
            this.btnPlayAll.TabIndex = 12;
            this.btnPlayAll.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::listnhac.Properties.Resources.search_interface_symbol;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(484, 53);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 19);
            this.button1.TabIndex = 9;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.Menu;
            this.txtSearch.Location = new System.Drawing.Point(329, 53);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(159, 20);
            this.txtSearch.TabIndex = 3;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(274, 54);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(59, 17);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Search";
            // 
            // panelPlay
            // 
            this.panelPlay.BackColor = System.Drawing.Color.Purple;
            this.panelPlay.Controls.Add(this.btnPlay);
            this.panelPlay.Controls.Add(this.btnStop);
            this.panelPlay.Controls.Add(this.btnPrevious);
            this.panelPlay.Controls.Add(this.btnNext);
            this.panelPlay.Controls.Add(this.btnPause);
            this.panelPlay.Controls.Add(this.lblTimeStart);
            this.panelPlay.Controls.Add(this.lblTimeEnd);
            this.panelPlay.Controls.Add(this.p_bar);
            this.panelPlay.Controls.Add(this.trackBar1);
            this.panelPlay.Controls.Add(this.lbl_trackend);
            this.panelPlay.Controls.Add(this.btnChon);
            this.panelPlay.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPlay.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.panelPlay.Location = new System.Drawing.Point(0, 441);
            this.panelPlay.Margin = new System.Windows.Forms.Padding(2);
            this.panelPlay.Name = "panelPlay";
            this.panelPlay.Size = new System.Drawing.Size(561, 60);
            this.panelPlay.TabIndex = 8;
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.Purple;
            this.btnPlay.BackgroundImage = global::listnhac.Properties.Resources.play1;
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.ForeColor = System.Drawing.Color.Purple;
            this.btnPlay.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPlay.Location = new System.Drawing.Point(154, 19);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(25, 30);
            this.btnPlay.TabIndex = 32;
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Purple;
            this.btnStop.BackgroundImage = global::listnhac.Properties.Resources.stop_button;
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.ForeColor = System.Drawing.Color.Purple;
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStop.Location = new System.Drawing.Point(220, 20);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(34, 29);
            this.btnStop.TabIndex = 31;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.Purple;
            this.btnPrevious.BackgroundImage = global::listnhac.Properties.Resources.rewind;
            this.btnPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.ForeColor = System.Drawing.Color.Purple;
            this.btnPrevious.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrevious.Location = new System.Drawing.Point(114, 20);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(36, 29);
            this.btnPrevious.TabIndex = 30;
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Purple;
            this.btnNext.BackgroundImage = global::listnhac.Properties.Resources.forward;
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.ForeColor = System.Drawing.Color.Purple;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNext.Location = new System.Drawing.Point(259, 20);
            this.btnNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(25, 30);
            this.btnNext.TabIndex = 29;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.Purple;
            this.btnPause.BackgroundImage = global::listnhac.Properties.Resources.pause__1____Copy1;
            this.btnPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.ForeColor = System.Drawing.Color.Purple;
            this.btnPause.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPause.Location = new System.Drawing.Point(184, 19);
            this.btnPause.Margin = new System.Windows.Forms.Padding(2);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(32, 30);
            this.btnPause.TabIndex = 28;
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // lblTimeStart
            // 
            this.lblTimeStart.AutoSize = true;
            this.lblTimeStart.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeStart.ForeColor = System.Drawing.Color.White;
            this.lblTimeStart.Location = new System.Drawing.Point(9, 2);
            this.lblTimeStart.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTimeStart.Name = "lblTimeStart";
            this.lblTimeStart.Size = new System.Drawing.Size(34, 13);
            this.lblTimeStart.TabIndex = 26;
            this.lblTimeStart.Text = "00:00";
            // 
            // lblTimeEnd
            // 
            this.lblTimeEnd.AutoSize = true;
            this.lblTimeEnd.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeEnd.ForeColor = System.Drawing.Color.White;
            this.lblTimeEnd.Location = new System.Drawing.Point(398, 2);
            this.lblTimeEnd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTimeEnd.Name = "lblTimeEnd";
            this.lblTimeEnd.Size = new System.Drawing.Size(34, 13);
            this.lblTimeEnd.TabIndex = 25;
            this.lblTimeEnd.Text = "00:00";
            // 
            // p_bar
            // 
            this.p_bar.Location = new System.Drawing.Point(46, 9);
            this.p_bar.Margin = new System.Windows.Forms.Padding(2);
            this.p_bar.Name = "p_bar";
            this.p_bar.Size = new System.Drawing.Size(346, 5);
            this.p_bar.TabIndex = 21;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(435, 6);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(106, 45);
            this.trackBar1.TabIndex = 24;
            // 
            // lbl_trackend
            // 
            this.lbl_trackend.AutoSize = true;
            this.lbl_trackend.Font = new System.Drawing.Font("Engravers MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_trackend.ForeColor = System.Drawing.Color.Black;
            this.lbl_trackend.Location = new System.Drawing.Point(731, -6);
            this.lbl_trackend.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_trackend.Name = "lbl_trackend";
            this.lbl_trackend.Size = new System.Drawing.Size(60, 19);
            this.lbl_trackend.TabIndex = 23;
            this.lbl_trackend.Text = "00:00";
            // 
            // btnChon
            // 
            this.btnChon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnChon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChon.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnChon.Location = new System.Drawing.Point(704, 24);
            this.btnChon.Margin = new System.Windows.Forms.Padding(2);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(8, 8);
            this.btnChon.TabIndex = 20;
            this.btnChon.UseVisualStyleBackColor = true;
            // 
            // dgvSong
            // 
            this.dgvSong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSong.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvSong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSong.Location = new System.Drawing.Point(0, 89);
            this.dgvSong.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSong.Name = "dgvSong";
            this.dgvSong.RowHeadersWidth = 51;
            this.dgvSong.RowTemplate.Height = 24;
            this.dgvSong.Size = new System.Drawing.Size(559, 353);
            this.dgvSong.TabIndex = 0;
            this.dgvSong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSong_CellContentClick);
            // 
            // frmDisplaySongs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 501);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmDisplaySongs";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelPlay.ResumeLayout(false);
            this.panelPlay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvSong;
        private System.Windows.Forms.Panel panelPlay;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label lblTimeStart;
        private System.Windows.Forms.Label lblTimeEnd;
        private System.Windows.Forms.ProgressBar p_bar;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lbl_trackend;
        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPlayAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAddMusic;
        private System.Windows.Forms.Button btnDelete;
    }
}