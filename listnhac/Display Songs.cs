using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using listnhac.Model;
using NAudio.Wave;

namespace listnhac
{
    public partial class frmDisplaySongs : Form
    {
        private IWavePlayer waveOut;
        private AudioFileReader audioFileReader;
        private List<string> songList = new List<string>();
        private int currentSongIndex = -1;
        private int _playlistId; // ID của Playlist
        private ModelMediaApp _context;
        private Timer timer;

        public frmDisplaySongs(int playlistId) // Constructor nhận playlistId
        {
            InitializeComponent();
            _playlistId = playlistId;
            _context = new ModelMediaApp();

            // Thêm các cột cho DataGridView
            dgvSong.Columns.Clear();
            dgvSong.Columns.Add("SongID", "ID"); // Cột ID ẩn để lưu SongID
            dgvSong.Columns["SongID"].Visible = false; // Ẩn cột ID
            dgvSong.Columns.Add("SongName", "Tên Bài Hát");
            dgvSong.Columns.Add("Source", "Nguồn");

            LoadSongs();

            // Khởi tạo Timer để cập nhật thời gian chơi nhạc
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void LoadSongs()
        {
            // Lấy danh sách bài hát trong playlist từ cơ sở dữ liệu
            var songs = _context.PlaylistSongs
                .Where(ps => ps.PlaylistID == _playlistId)
                .Select(ps => ps.Song)
                .ToList();

            // Cập nhật danh sách đường dẫn bài hát
            songList = songs.Select(s => s.FilePath).ToList();

            dgvSong.Rows.Clear();
            foreach (var song in songs)
            {
                dgvSong.Rows.Add(song.SongID, song.Title, song.FilePath);
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (currentSongIndex < 0)
            {
                currentSongIndex = 0;
            }
            PlaySong(currentSongIndex);
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            waveOut.Pause();
            timer.Stop();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            waveOut.Stop();
            audioFileReader?.Dispose();
            audioFileReader = null;
            timer.Stop();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentSongIndex++;
            if (currentSongIndex >= songList.Count)
            {
                currentSongIndex = 0;
            }
            PlaySong(currentSongIndex);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            currentSongIndex--;
            if (currentSongIndex < 0)
            {
                currentSongIndex = songList.Count - 1;
            }
            PlaySong(currentSongIndex);
        }

        private void PlaySong(int index)
        {
            if (songList.Count == 0 || index < 0 || index >= songList.Count)
                return;

            if (audioFileReader != null)
            {
                waveOut.Stop();
                audioFileReader.Dispose();
            }

            audioFileReader = new AudioFileReader(songList[index]);
            waveOut = new WaveOut();
            waveOut.Init(audioFileReader);
            waveOut.Play();
        }

        private void btnAddMusic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Music Files|*.mp3;*.wav;*.flac";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string musicFilePath = openFileDialog.FileName;

                try
                {
                    var song = new Song
                    {
                        Title = System.IO.Path.GetFileNameWithoutExtension(musicFilePath),
                        FilePath = musicFilePath
                    };

                    _context.Songs.Add(song);
                    _context.SaveChanges();

                    var playlistSong = new PlaylistSong
                    {
                        PlaylistID = _playlistId,
                        SongID = song.SongID,
                        OrderNumber = 1,
                        DateAdded = DateTime.Now
                    };
                    _context.PlaylistSongs.Add(playlistSong);
                    _context.SaveChanges();

                    MessageBox.Show("Thêm bài hát thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadSongs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSong.SelectedRows.Count > 0)
            {
                int selectedSongId = (int)dgvSong.SelectedRows[0].Cells["SongID"].Value;

                var songToDelete = _context.Songs.Find(selectedSongId);
                if (songToDelete != null)
                {
                    try
                    {
                        var playlistSongToDelete = _context.PlaylistSongs
                            .FirstOrDefault(ps => ps.SongID == selectedSongId && ps.PlaylistID == _playlistId);
                        if (playlistSongToDelete != null)
                        {
                            _context.PlaylistSongs.Remove(playlistSongToDelete);
                        }

                        _context.Songs.Remove(songToDelete);
                        _context.SaveChanges();

                        MessageBox.Show("Đã xóa bài hát thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadSongs();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra khi xóa bài hát: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bài hát để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvSong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                currentSongIndex = e.RowIndex;
                PlaySong(currentSongIndex);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (audioFileReader != null)
            {
                lblTimeStart.Text = audioFileReader.CurrentTime.ToString(@"mm\:ss");
                lblTimeEnd.Text = audioFileReader.TotalTime.ToString(@"mm\:ss");

                if (audioFileReader.TotalTime.TotalSeconds > 0)
                {
                    p_bar.Value = (int)(audioFileReader.CurrentTime.TotalSeconds / audioFileReader.TotalTime.TotalSeconds * 100);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
