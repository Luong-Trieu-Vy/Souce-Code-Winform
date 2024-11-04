using listnhac.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace listnhac
{

    public partial class frmAddPlayList : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ModelMediaApp"].ConnectionString;
        private readonly ModelMediaApp context;
        public frmAddPlayList()
        {
            InitializeComponent();
            txtNamePlaylist.MaxLength = 100;
            txtDescription.MaxLength = 500; // Thiết lập độ dài tối đa cho mô tả
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
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Playlists (Name, Description, CreatedDate) 
                             VALUES (@Name, @Description, @CreatedDate)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
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