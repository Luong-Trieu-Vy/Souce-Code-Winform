using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using listnhac.Model;
namespace listnhac
{
    public partial class DisplayPlaylist : Form
    {
        private ModelMediaApp _context;

        public DisplayPlaylist()
        {
            InitializeComponent();
            _context = new ModelMediaApp();
            LoadPlaylists();
        }

        private void LoadPlaylists()
        {
            var playlists = _context.Playlists.Select(p => new
            {
                p.PlaylistID,
                p.Name,
                p.Description,
                p.CreatedDate
            }).ToList();

            dgvPlaylist.DataSource = playlists;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEdit_Click(object sender, EventArgs e)
        {

        }

        private void dgvPlaylist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvPlaylist.SelectedRows.Count > 0)
            {
                int playlistId = Convert.ToInt32(dgvPlaylist.SelectedRows[0].Cells["PlaylistID"].Value);

                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa playlist này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        // Xóa mối quan hệ giữa Playlist và Song
                        var playlistSongs = _context.PlaylistSongs.Where(ps => ps.PlaylistID == playlistId).ToList();
                        _context.PlaylistSongs.RemoveRange(playlistSongs);

                        // Xóa Playlist
                        var playlist = _context.Playlists.Find(playlistId);
                        _context.Playlists.Remove(playlist);

                        _context.SaveChanges();

                        MessageBox.Show("Xóa playlist thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPlaylists();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một playlist để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (dgvPlaylist.SelectedRows.Count > 0)
            {
                int playlistId = Convert.ToInt32(dgvPlaylist.SelectedRows[0].Cells["PlaylistID"].Value);

                // Mở frmDisplaySongs và truyền PlaylistID
                frmDisplaySongs displaySongsForm = new frmDisplaySongs(playlistId);
                displaySongsForm.ShowDialog(); // Sử dụng ShowDialog nếu bạn muốn chặn tương tác với form hiện tại
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một playlist để hiển thị bài hát!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddPlayList_Click(object sender, EventArgs e)
        {
            frmAddPlayList addPlayListForm = new frmAddPlayList();

            if (addPlayListForm.ShowDialog() == DialogResult.OK)
            {
                LoadPlaylists();
            }
        }
    }
}
