using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BUS;
using Utility;

namespace GUI
{
    public partial class frmDangNhap : Form
    {
        public event EventHandler ButtonClicked;
        public static SqlConnection conn = DatabaseProvider.GetConnection();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool checkCharUsername = Regex.IsMatch(tbxUsername.Text, @"^[a-zA-z0-9]+$");
            bool checkCharPassword = Regex.IsMatch(tbxPassword.Text, @"^[a-zA-z0-9]+$");
            if (!checkCharUsername || !checkCharPassword)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không hợp lệ!");
            }
            else
            {
                LoggedUser result = UserBUS.CheckLogin(tbxUsername.Text, tbxPassword.Text);
                if (!string.IsNullOrEmpty(result?.Role))
                {
                    ButtonClicked?.Invoke(this, new RoleEventArgs(result.Role, tbxUsername.Text, result.Id));
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!!!");
                }
            }
        }
    }
}