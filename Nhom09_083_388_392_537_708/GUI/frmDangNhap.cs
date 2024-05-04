using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Nhom09_083_388_392_537_708
{
    public partial class frmDangNhap : Form
    {
        public event EventHandler ButtonClicked;
        public string role = "";

        public string username = "";
        public string id = "";

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
                role = checkLogin(tbxUsername.Text, tbxPassword.Text);
                if (string.IsNullOrEmpty(role))
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!!!");
                }
                else
                {
                    ButtonClicked?.Invoke(this, new RoleEventArgs(role, username, id));
                }
            }   
            
        }
    }
}
