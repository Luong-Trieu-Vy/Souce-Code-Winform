using listnhac.Model;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace listnhac
{
    public partial class frmLogin : Form
    {
        private ModelMediaApp context = new ModelMediaApp();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void OpenMainForm(int userId)
        {
            frmMedia mainForm = new frmMedia(userId);
            this.Hide();
            mainForm.Show();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (ValidateLogin(username, password))
            {
                int userId = GetUserID(username);
                if (userId != -1)
                {
                    OpenMainForm(userId);
                }
                else
                {
                    MessageBox.Show("Không thể lấy ID người dùng.");
                }
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
            }
        }

        private void lblSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenSignUpForm();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            OpenSignUpForm();
        }

        private void OpenSignUpForm()
        {
            frmLogUp frmLogUp = new frmLogUp();
            frmLogUp.Show();
            this.Hide();
        }

        private bool ValidateLogin(string username, string password)
        {
            var user = context.Users.SingleOrDefault(u => u.Username == username);
            if (user != null)
            {
                string hashedPassword = HashPassword(password);
                return hashedPassword == user.Password;
            }
            return false;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private int GetUserID(string username)
        {
            var user = context.Users.SingleOrDefault(u => u.Username == username);
            return user != null ? user.UserID : -1;
        }


        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
