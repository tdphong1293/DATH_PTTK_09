using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Nhom09_083_388_392_537_708
{
    public partial class FormDangNhap : Form
    {
        public event EventHandler ButtonClicked;
        public string role;
        public FormDangNhap()
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
                if (string.IsNullOrEmpty(role))
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!!!");
                }
                else
                {
                    ButtonClicked?.Invoke(this, new RoleEventArgs(role));
                }
            }   
            
        }
    }
}
