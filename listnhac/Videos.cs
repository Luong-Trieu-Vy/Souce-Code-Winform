using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace listnhac
{
    public partial class frmVideo : Form
    {
        private string[] paths;
        private int currentVideoIndex = 0;

        public frmVideo(string[] videoPaths)
        {
            InitializeComponent();
            paths = videoPaths;
        }

        private void frmVideo_Load(object sender, EventArgs e)
        {
            if (paths.Length > 0)
            {
                LoadVideo(paths[currentVideoIndex]);
            }
        }

        private void LoadVideo(string videoPath)
        {
            if (System.IO.File.Exists(videoPath))
            {
                playerVideo.URL = videoPath;
                playerVideo.Ctlcontrols.play();
            }
            else
            {
                MessageBox.Show("The selected video file does not exist.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            playerVideo.Ctlcontrols.stop();
            if (++currentVideoIndex < paths.Length) LoadVideo(paths[currentVideoIndex]);
            else MessageBox.Show("No more videos to play.", "End of List", MessageBoxButtons.OK);
        }

        private void btnPlay_Click(object sender, EventArgs e) => playerVideo.Ctlcontrols.play();

        private void btnPause_Click(object sender, EventArgs e) => playerVideo.Ctlcontrols.pause();

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentVideoIndex > 0) LoadVideo(paths[--currentVideoIndex]);
        }
        private void frmVideo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Show();
            }
        }

        private void dgvSelect_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //form hiện danh sách video
        }
    }
}
