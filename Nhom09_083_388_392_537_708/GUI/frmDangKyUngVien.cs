using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using BUS;

namespace GUI
{
    public partial class frmDangKyUngVien : Form
    {
        public frmDangKyUngVien()
        {
            InitializeComponent();
            dtp_birth_uv.MaxDate = DateTime.Today;
        }

        private void ThongBao(string noidungtb)
        {
            MessageBox.Show(noidungtb);
        }

        private bool ValidateInputString(string input)
        {
            if (input.Length > 30)
            {
                return false;
            }
            else if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            else if (!input.All(Char.IsLetterOrDigit))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool KiemTraTKMK()
        {
            if (!ValidateInputString(txt_username_uv.Text))
            {
                ThongBao("Tên đăng nhập không hợp lệ");
                return false;
            }
            else if (!ValidateInputString(txt_password_uv.Text))
            {
                ThongBao("Mật khẩu không hợp lệ");
                return false;
            }
            else if (txt_password_uv.Text != txt_repassword_uv.Text)
            {
                ThongBao("Mật khẩu nhập lại không khớp");
                return false;
            }
            else if (string.IsNullOrEmpty(txt_name_uv.Text) || (txt_name_uv.Text).Length > 50)
            {
                ThongBao("Tên ứng viên không hợp lệ");
                return false;
            }
            else if (string.IsNullOrEmpty(txt_email_uv.Text) || (txt_email_uv.Text).Length > 50)
            {
                ThongBao("Email không hợp lệ");
                return false;
            }
            return true;
        }

        private void btn_DangKyUngVien_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraTKMK())
                {
                    return;
                }

                if (!UngVienBUS.KiemTraUVTonTai(txt_username_uv.Text))
                {
                    ThongBao("Ứng viên đã tồn tại trong hệ thống. Vui lòng đổi tên đăng nhập khác!");
                    return;
                }

                if (UngVienBUS.ThemUV(txt_username_uv.Text, txt_password_uv.Text, txt_name_uv.Text, txt_email_uv.Text, dtp_birth_uv.Value.ToString("yyyy-MM-dd")))
                {
                    txt_username_uv.Text = "";
                    txt_password_uv.Text = "";
                    txt_repassword_uv.Text = "";
                    txt_name_uv.Text = "";
                    txt_email_uv.Text = "";
                    ThongBao("Đăng ký Ứng Viên thành công");
                }
            }
            catch (Exception ex)
            {
                ThongBao("Lỗi thêm UV " + ex.Message);
            }
        }
    }
}
