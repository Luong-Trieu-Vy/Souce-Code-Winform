using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using listnhac.Model;

namespace listnhac
{
    public partial class frmMedia : Form
    {
        private ModelMediaApp Context;
        private WMPLib.WindowsMediaPlayer player;
        private System.Windows.Forms.Timer timer;
        private int userId;

        private bool isShuffle = false;
        private List<Song> songList;
        private List<Video> videoList;
        private int currentSongIndex = -1;

        public frmMedia(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            InitializePlayerComponents();
        }

        private void InitializePlayerComponents()
        {
            Context = new ModelMediaApp();
            player = new WMPLib.WindowsMediaPlayer();
            player.PlayStateChange += Player_PlayStateChange;
            player.MediaError += Player_MediaError;
            player.settings.autoStart = false;
            player.settings.volume = 50;

            timer = new System.Windows.Forms.Timer { Interval = 1000 };
            timer.Tick += Timer_Tick;

            songList = new List<Song>();
            videoList = new List<Video>();
        }

        private void frmMedia_Load(object sender, EventArgs e)
        {
            cmbSort.Items.AddRange(new string[] { "Sort by A-Z", "Sort by Z-A" });
            cmbSort.SelectedItem = "Sort by A-Z";
            LoadMusic();
        }

        // =======================
        // Event Handlers
        // =======================

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void btnVideo_Click(object sender, EventArgs e)
        {
            tab.SelectedTab = tabVideos;
            LoadVideos();
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            SortMedia(cmbSort.SelectedItem.ToString());
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            isShuffle = !isShuffle;
            btnShuffle.Text = "Shuffle: " + (isShuffle ? "On" : "Off");

            if (isShuffle && songList.Count > 0)
            {
                Random rand = new Random();
                currentSongIndex = rand.Next(songList.Count);
                PlayCurrentSong();
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (player == null)
            {
                InitializePlayerComponents();
            }

            if (currentSongIndex == -1 && songList.Count > 0)
            {
                currentSongIndex = 0;
            }

            if (player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                player.controls.pause();
                btnPlay.Text = "Play";
            }
            else
            {
                PlayCurrentSong();
                btnPlay.Text = "Pause";
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (player != null && player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                player.controls.pause();
                btnPlay.Text = "Play";
                timer.Stop();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddSongs();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMusic.SelectedRows.Count > 0)
            {
                var selectedSong = dgvMusic.SelectedRows[0].DataBoundItem as Song;
                if (selectedSong != null)
                {
                    var result = MessageBox.Show("Bạn có chắc chắn muốn xóa bài hát này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        songList.Remove(selectedSong);
                        Context.Songs.Remove(selectedSong);

                        try
                        {
                            Context.SaveChanges();
                            LoadMusic();
                            MessageBox.Show("Xóa bài hát thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            ShowErrorMessage("Lỗi khi xóa bài hát", ex);
                        }
                    }
                }
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (songList == null || songList.Count == 0) return;
            currentSongIndex = isShuffle
                ? new Random().Next(0, songList.Count)
                : (currentSongIndex - 1 + songList.Count) % songList.Count;
            PlayCurrentSong();
        }
        private void dgvMusic_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo rằng một hàng hợp lệ đã được nhấn
            {
                currentSongIndex = e.RowIndex; // Lưu chỉ số bài hát được chọn
                PlayCurrentSong(); // Phát bài hát hiện tại
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            PlayNextSong();

        }

        // =======================
        // Timer and Player Events
        // =======================

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (player.playState == WMPLib.WMPPlayState.wmppsPlaying && player.currentMedia != null)
            {
                UpdatePlaybackProgress();
            }
        }

        private void Player_PlayStateChange(int NewState)
        {
            if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                PlayNextSong();
            }
        }


        private void Player_MediaError(object pMediaObject)
        {
            MessageBox.Show("Có lỗi khi phát file nhạc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (player != null && player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                player.controls.stop();
                timer.Stop();
                p_bar.Value = 0;
                lblTimeStart.Text = "00:00";
                lblTimeEnd.Text = "00:00";
                btnPlay.Text = "Play";
            }
        }




        // =======================
        // Music and Video Management
        // =======================

        private void LoadMusic()
        {
            try
            {
                songList = Context.Songs.ToList();
                BindMusicData();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Lỗi khi tải danh sách nhạc", ex);
            }
        }

        private void LoadVideos()
        {
            try
            {
                videoList = Context.Videos.ToList();
                BindVideoData();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Lỗi khi tải danh sách video", ex);
            }
        }

        private void BindMusicData()
        {
            dgvMusic.DataSource = null;
            dgvMusic.DataSource = songList;
            ConfigureDataGridView(dgvMusic);
        }

        private void BindVideoData()
        {
            dgvVideos.DataSource = null;
            dgvVideos.DataSource = videoList;
            ConfigureDataGridView(dgvVideos, true);
        }

        private void ConfigureDataGridView(DataGridView dgv, bool isVideo = false)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            if (isVideo)
            {
                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Title",
                    HeaderText = "Tên video",
                    Width = 200
                });
                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "FilePath",
                    HeaderText = "Đường dẫn",
                    Width = 300
                });
            }
            else
            {
                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Title",
                    HeaderText = "Tên bài hát",
                    Width = 200
                });
                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Artist",
                    HeaderText = "Ca sĩ",
                    Width = 150
                });
            }

            ConfigureDataGridViewStyle(dgv);
        }

        private void ConfigureDataGridViewStyle(DataGridView dgv)
        {
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.RowHeadersVisible = false;

            dgv.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
        }

        // =======================
        // Playback Management
        // =======================

        private void UpdatePlaybackProgress()
        {
            p_bar.Maximum = (int)player.currentMedia.duration;
            p_bar.Value = (int)player.controls.currentPosition;
            lblTimeStart.Text = player.controls.currentPositionString;
            lblTimeEnd.Text = player.currentMedia.durationString;
        }

        private void PlayNextSong()
        {
            if (songList == null || songList.Count == 0) return;

            if (isShuffle)
            {
                Random rand = new Random();
                currentSongIndex = rand.Next(songList.Count);
            }
            else
            {
                currentSongIndex = (currentSongIndex + 1) % songList.Count;
            }

            PlayCurrentSong();
        }

        private void PlayCurrentSong()
        {
            if (currentSongIndex >= 0 && currentSongIndex < songList.Count)
            {
                player.URL = songList[currentSongIndex].FilePath;
                player.controls.play();
                timer.Start();
            }
        }

        // =======================
        // Song and Video Handling
        // =======================

        private void AddSongs()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Audio Files|*.mp3;*.wav";
                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in ofd.FileNames)
                    {
                        Song newSong = new Song
                        {
                            Title = System.IO.Path.GetFileNameWithoutExtension(file),
                            FilePath = file
                        };

                        songList.Add(newSong);
                        Context.Songs.Add(newSong);
                    }

                    SaveChangesAndReloadMusic();
                }
            }
        }

        private void SaveChangesAndReloadMusic()
        {
            try
            {
                Context.SaveChanges();
                LoadMusic();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Lỗi khi lưu bài hát vào cơ sở dữ liệu", ex);
            }
        }

        private void DeleteSelectedSong()
        {
            if (dgvMusic.SelectedRows.Count > 0)
            {
                var selectedSong = dgvMusic.SelectedRows[0].DataBoundItem as Song;
                if (selectedSong != null)
                {
                    songList.Remove(selectedSong);
                    Context.Songs.Remove(selectedSong);
                    SaveChangesAndReloadMusic();
                }
            }
        }

        private void SortMedia(string sortOrder)
        {
            if (sortOrder == "Sort by A-Z")
            {
                songList = songList.OrderBy(s => s.Title).ToList();
            }
            else if (sortOrder == "Sort by Z-A")
            {
                songList = songList.OrderByDescending(s => s.Title).ToList();
            }
            BindMusicData();
        }


        private void ShowErrorMessage(string message, Exception ex)
        {
            MessageBox.Show($"{message}\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectSong_Click(object sender, EventArgs e)
        {
            tab.SelectedTab = tabMusic;
            LoadMusic();
        }

        //edit
        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvMusic.SelectedRows.Count > 0)
            {
                var songIdCell = dgvMusic.SelectedRows[0].Cells.Cast<DataGridViewCell>()
                                    .FirstOrDefault(cell => cell.OwningColumn.Name == "SongID");

                if (songIdCell != null && songIdCell.Value != null)
                {
                    int songId = (int)songIdCell.Value;

                    frmEdit editForm = new frmEdit(songId);
                    editForm.ShowDialog();

                    LoadMusic();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy cột 'SongID'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bài hát để chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddVideo_Click(object sender, EventArgs e)
        {
            AddVideos();
        }
        private void AddVideos()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Video Files|*.mp4;*.avi;*.mov;*.mkv";
                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in ofd.FileNames)
                    {
                        var newVideo = new Video
                        {
                            Title = System.IO.Path.GetFileNameWithoutExtension(file),
                            FilePath = file
                        };

                        videoList.Add(newVideo);
                        Context.Videos.Add(newVideo);
                    }

                    Context.SaveChanges();
                    LoadVideos();
                }
            }
        }


    }
}
