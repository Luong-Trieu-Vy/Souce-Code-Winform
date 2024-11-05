using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using listnhac.Model;

namespace listnhac
{
    public partial class DisplayPlaylist : Form
    {
        private ModelMediaApp Context;
        private int userId;

        public DisplayPlaylist(int userId)
        {
            InitializeComponent();
            Context = new ModelMediaApp();
            this.userId = userId;

            // Kiểm tra giá trị userId
            MessageBox.Show("User ID: " + userId);

            LoadPlaylists();
        }

        private void LoadPlaylists()
        {
            try
            {
                var playlists = Context.Playlists
                                       .Where(p => p.UserId == userId)
                                       .ToList();

                // Kiểm tra xem có playlist nào không
                if (!playlists.Any())
                {
                    MessageBox.Show("Không có playlist nào được tìm thấy cho user này."); // Thông báo nếu không có playlist
                }
                else
                {
                    MessageBox.Show("Số lượng playlist: " + playlists.Count); // Kiểm tra số lượng playlist
                }

                dgvPlaylist.DataSource = playlists; // Gán danh sách playlist vào DataGridView
                dgvPlaylist.AutoGenerateColumns = true; // Tự động tạo cột nếu cần
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách playlist: " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        var playlistSongs = Context.PlaylistSongs.Where(ps => ps.PlaylistID == playlistId).ToList();
                        Context.PlaylistSongs.RemoveRange(playlistSongs);

                        // Xóa Playlist
                        var playlist = Context.Playlists.Find(playlistId);
                        Context.Playlists.Remove(playlist);

                        Context.SaveChanges();

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
            frmAddPlayList addPlayListForm = new frmAddPlayList(userId); 

            if (addPlayListForm.ShowDialog() == DialogResult.OK)
            {
                LoadPlaylists();
            }
        }
    }
}
