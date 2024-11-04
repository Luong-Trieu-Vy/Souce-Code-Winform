using listnhac.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace listnhac
{
    public partial class frmEdit : Form
    {
        private Song currentSong;
        private readonly ModelMediaApp context; // DbContext để làm việc với cơ sở dữ liệu

        public frmEdit(Song song, ModelMediaApp dbContext)
        {
            InitializeComponent();
            currentSong = song;
            context = dbContext; // Gán DbContext
        }

        private void frmEdit_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin của bài hát trong các textbox
            txtTitle.Text = currentSong.Title;
            txtFile.Text = currentSong.FilePath;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Cập nhật thông tin bài hát
            currentSong.Title = txtTitle.Text;
            currentSong.FilePath = txtFile.Text;

            // Lưu thay đổi vào cơ sở dữ liệu
            context.Entry(currentSong).State = System.Data.Entity.EntityState.Modified;

            try
            {
                context.SaveChanges();
                MessageBox.Show("Cập nhật thành công!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form mà không lưu thay đổi
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            // Mở hộp thoại để chọn file bài hát
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Audio Files|*.mp3;*.wav;*.aac|All Files|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFile.Text = openFileDialog.FileName; // Hiển thị đường dẫn file
                }
            }
        }
    }
}