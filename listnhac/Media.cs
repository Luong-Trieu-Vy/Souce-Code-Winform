using listnhac.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using TagLib;
using WMPLib;
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
            player.settings.autoStart = false;
        }

        private void frmMedia_Load(object sender, EventArgs e)
        {
            cmbSort.Items.AddRange(new string[] { "Sort by A-Z", "Sort by Z-A" });
            cmbSort.SelectedItem = "Sort by A-Z";

            LoadMusic(); // Load music files into the player

            // Initialize trackbar volume to the current player's volume level
            trackBar1.Minimum = 0; // Set minimum volume level
            trackBar1.Maximum = 100; // Set maximum volume level
            trackBar1.Value = player.settings.volume;
        }

        // =======================
        // Event Handlers
        // =======================

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMusic_Click(object sender, EventArgs e)
        {
            tab.SelectedTab = tabMusic;
            LoadMusic();
        }

        private void btnVideo_Click(object sender, EventArgs e)
        {
            tab.SelectedTab = tabVideos;
            LoadVideos();
        }      
        private void cmbSort_SelectedIndexChanged_1(object sender, EventArgs e)
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
        private void Player1_MediaError(object sender, AxWMPLib._WMPOCXEvents_MediaErrorEvent e)
        {

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
            dgvVideo.DataSource = null;
            dgvVideo.DataSource = videoList;
            ConfigureDataGridView(dgvVideo, true);
        }

        private void ConfigureDataGridView(DataGridView dgv, bool isVideo = false)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            if (isVideo)
            {
                // Thêm cột cho Video
                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Title",   // Đảm bảo đối tượng dữ liệu có thuộc tính "Title"
                    HeaderText = "Tên video",
                    Width = 200
                });
                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "FilePath", // Đảm bảo đối tượng dữ liệu có thuộc tính "FilePath"
                    HeaderText = "Đường dẫn",
                    Width = 300
                });
            }
            else
            {
                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Title",    // Đảm bảo đối tượng dữ liệu có thuộc tính "Title"
                    HeaderText = "Tên bài hát",
                    Width = 200
                });
                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "FilePath", // Thêm cột đường dẫn cho bài hát nếu cần
                    HeaderText = "Đường dẫn",
                    Width = 300
                });
            }

            // Gọi phương thức cấu hình style chung cho DataGridView
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

            // Thiết lập style cho DataGridView
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
                        // Sử dụng TagLib để lấy thông tin ca sĩ
                        var fileTag = TagLib.File.Create(file);

                        Song newSong = new Song
                        {
                            Title = fileTag.Tag.Title ?? System.IO.Path.GetFileNameWithoutExtension(file), // Lấy tên bài hát từ metadata, nếu không có thì lấy từ tên tệp
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

        // =======================
        // Error Handling
        // =======================

        private void ShowErrorMessage(string message, Exception ex)
        {
            MessageBox.Show($"{message}\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //nhấn nút edit này thì sẽ qua form edit 
            if (dgvMusic.SelectedRows.Count > 0)
            {
                // Lấy bài hát được chọn từ DataGridView
                Song selectedSong = dgvMusic.SelectedRows[0].DataBoundItem as Song; // Giả sử Song là kiểu dữ liệu của bạn

                if (selectedSong != null)
                {
                    // Khởi tạo form chỉnh sửa và truyền bài hát cùng DbContext
                    frmEdit editForm = new frmEdit(selectedSong, Context);

                    // Hiển thị form chỉnh sửa
                    editForm.ShowDialog();

                    // Sau khi form chỉnh sửa được đóng, có thể cần cập nhật lại danh sách bài hát
                    LoadMusic(); // Giả sử LoadSongs là phương thức để tải lại danh sách bài hát
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bài hát để chỉnh sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //tăng giảm âm lượng bài hát
            player.settings.volume = trackBar1.Value;
        }

        private void btnAddVideo_Click(object sender, EventArgs e)
        {
            // thêm video vào datagridview
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Video Files|*.mp4;*.avi;*.mov"; // Thay đổi định dạng nếu cần
                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in ofd.FileNames)
                    {
                        Video newVideo = new Video
                        {
                            Title = System.IO.Path.GetFileNameWithoutExtension(file),
                            FilePath = file
                        };

                        // Kiểm tra xem videoList đã được khởi tạo chưa
                        if (videoList == null)
                        {
                            videoList = new List<Video>();
                        }

                        try
                        {
                            // Thêm video vào danh sách và cơ sở dữ liệu
                            videoList.Add(newVideo);
                            Context.Videos.Add(newVideo); // Sửa tên biến ở đây
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi thêm video: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    try
                    {
                        Context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                        LoadVideos(); // Tải lại danh sách video
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi lưu video vào cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnRemoveVid_Click(object sender, EventArgs e)
        {
            //xóa video
            if (dgvVideo.SelectedRows.Count > 0)
            {
                var selectedVideo = dgvVideo.SelectedRows[0].DataBoundItem as Video;
                if (selectedVideo != null)
                {
                    videoList.Remove(selectedVideo); // Xóa khỏi danh sách
                    Context.Videos.Remove(selectedVideo); // Xóa khỏi cơ sở dữ liệu
                    Context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                    LoadVideos(); // Tải lại danh sách video
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn video để xóa.");
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            LoadVideos();
        }
        private void OpenVideoForm(string videoPath)
        {
            frmVideo videoForm = new frmVideo(new string[] { videoPath });
            videoForm.Owner = this; // Đặt frmMedia là form cha
            videoForm.Show();
        }

        private void cmpSortVideo_SelectedIndexChanged(object sender, EventArgs e)
        {

            string sortOption = cmpSortVideo.SelectedItem.ToString();

            if (sortOption == "Sort by A-Z")
            {
                videoList = videoList.OrderBy(v => v.Title).ToList();
            }
            else if (sortOption == "Sort by Z-A")
            {
                videoList = videoList.OrderByDescending(v => v.Title).ToList();
            }
            BindVideoData();
        }

        private void dgvVideo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var cellValue = dgvVideo.Rows[e.RowIndex].Cells[1].Value;
                if (cellValue != null && !string.IsNullOrEmpty(cellValue.ToString()))
                {
                    string videoPath = cellValue.ToString();
                    frmVideo videoForm = new frmVideo(new string[] { videoPath });
                    videoForm.Show(this);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Đường dẫn video không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPlaylist_Click(object sender, EventArgs e)
        {
            DisplayPlaylist playList = new DisplayPlaylist();
            playList.Show(this);
        }
        

        private void p_bar_Click(object sender, EventArgs e)
        {

        }
    }
}
