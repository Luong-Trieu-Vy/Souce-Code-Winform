using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NAudio.Wave;

namespace listnhac
{
    public partial class Display_Songs : Form
    {
        private IWavePlayer waveOut;
        private AudioFileReader audioFileReader;
        private List<string> songList = new List<string>();
        private int currentSongIndex = -1;

        public Display_Songs()
        {
            InitializeComponent();

            // Khởi tạo player
            waveOut = new WaveOut();

            // Thêm đường dẫn bài hát vào danh sách
            songList.Add("C:\\path\\to\\your\\first_song.mp3");
            songList.Add("C:\\path\\to\\your\\second_song.mp3");
            songList.Add("C:\\path\\to\\your\\third_song.mp3");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            waveOut.Pause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            waveOut.Stop();
            audioFileReader?.Dispose();
            audioFileReader = null;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentSongIndex++;
            if (currentSongIndex >= songList.Count)
            {
                currentSongIndex = 0; // Quay về đầu danh sách
            }
            PlaySong(currentSongIndex);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            currentSongIndex--;
            if (currentSongIndex < 0)
            {
                currentSongIndex = songList.Count - 1; // Quay lại cuối danh sách
            }
            PlaySong(currentSongIndex);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (currentSongIndex < 0)
            {
                currentSongIndex = 0; // Nếu chưa chọn bài nào, phát bài đầu tiên
            }
            PlaySong(currentSongIndex);
        }

        private void PlaySong(int index)
        {
            if (songList.Count == 0 || index < 0 || index >= songList.Count)
                return; // Không làm gì nếu danh sách trống hoặc chỉ số không hợp lệ

            if (audioFileReader != null)
            {
                waveOut.Stop();
                audioFileReader.Dispose(); // Giải phóng tài nguyên
            }

            audioFileReader = new AudioFileReader(songList[index]);
            waveOut.Init(audioFileReader);
            waveOut.Play();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.ToLower();
            var filteredSongs = songList.Where(song => song.ToLower().Contains(searchTerm)).ToList();

            // Cập nhật danh sách bài hát hiển thị
            if (filteredSongs.Count > 0)
            {
                dgvSong.DataSource = filteredSongs.Select(s => new { Title = s }).ToList(); // Giả sử bạn có DataGridView để hiển thị bài hát
            }
            else
            {
                dgvSong.DataSource = null; // Nếu không tìm thấy bài hát
                MessageBox.Show("Không tìm thấy bài hát nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvSong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                currentSongIndex = e.RowIndex; // Lưu chỉ số bài hát đã chọn
                PlaySong(currentSongIndex);
            }
        }
    }
}
