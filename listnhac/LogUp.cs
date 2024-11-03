using listnhac.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace listnhac
{
    public partial class frmLogUp : Form
    {
        public frmLogUp()
        {
            InitializeComponent();
        }

        private void LogUp_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }

            try
            {
                using (var context = new ModelMediaApp())
                {
                    // Kiểm tra xem tên đăng nhập hoặc email đã tồn tại chưa
                    if (context.Users.Any(u => u.Username == txtName.Text || u.Email == txtEmail.Text))
                    {
                        MessageBox.Show("Tên đăng nhập hoặc email đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Tạo đối tượng User mới
                    var user = new User
                    {
                        Username = txtName.Text,
                        Password = HashPassword(txtPassword.Text),  // Bạn nên mã hóa mật khẩu trước khi lưu ? 
                        // thang nay no coi cua ai z
                        // nguoi ta bao no ma hoa ma no kh ma hoa =)) +)) em thua a
                        Email = txtEmail.Text,
                        CreatedDate = DateTime.Now
                    };

                    // Thêm user vào cơ sở dữ liệu
                    context.Users.Add(user);
                    context.SaveChanges();

                    MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                    this.Close(); 
                    var loginForm = new frmLogin();
                    loginForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
        private void linkLblAlreadyHaveAnAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close(); 
            var loginForm = new frmLogin();
            loginForm.Show();
        }

    
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên đăng nhập không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Email không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất 6 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtPassword.Text != txtConfirm.Text)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }
    }
}
