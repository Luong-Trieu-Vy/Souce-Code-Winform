using listnhac.Model;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace listnhac
{
    public partial class frmLogin : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ModelMediaApp"].ConnectionString;

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
                OpenMainForm(userId);
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
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Password FROM Users WHERE Username = @Username";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    conn.Open();
                    var storedPassword = cmd.ExecuteScalar();

                    if (storedPassword != null)
                    {
                        string hashedPassword = HashPassword(password);

                        Console.WriteLine($"Mật khẩu đã mã hóa: {hashedPassword}");
                        Console.WriteLine($"Mật khẩu trong DB: {storedPassword.ToString()}");
                        return hashedPassword == storedPassword.ToString();
                    }
                }
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
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT UserID FROM Users WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        private void btnExit_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
