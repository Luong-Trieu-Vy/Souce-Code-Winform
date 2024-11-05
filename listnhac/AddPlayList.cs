using listnhac.Model;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace listnhac
{
    public partial class frmAddPlayList : Form
    {
        private readonly ModelMediaApp context;
        private readonly int userId; // Biến để lưu trữ UserId

        public frmAddPlayList(int userId)
        {
            InitializeComponent();
            txtNamePlaylist.MaxLength = 100;
            txtDescription.MaxLength = 500; // Thiết lập độ dài tối đa cho mô tả
            this.userId = userId; // Gán UserId
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string playlistName = txtNamePlaylist.Text.Trim();
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(playlistName))
            {
                MessageBox.Show("Tên playlist không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ModelMediaApp"].ConnectionString))
                {
                    string query = @"INSERT INTO Playlists (UserID, Name, Description, CreatedDate) 
                                     VALUES (@UserID, @Name, @Description, @CreatedDate)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId); // Gán UserId cho playlist
                        cmd.Parameters.AddWithValue("@Name", playlistName);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Thêm playlist thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNamePlaylist_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
