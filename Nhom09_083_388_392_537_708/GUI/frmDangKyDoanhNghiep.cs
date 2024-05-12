using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using BUS;

namespace GUI
{
    public partial class frmDangKyDoanhNghiep : Form
    {
        public frmDangKyDoanhNghiep()
        {
            InitializeComponent();
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
            if (!ValidateInputString(txt_username_dn.Text))
            {
                ThongBao("Tên đăng nhập không hợp lệ");
                return false;
            }
            else if (!ValidateInputString(txt_password_dn.Text))
            {
                ThongBao("Mật khẩu không hợp lệ");
                return false;
            }
            else if (txt_password_dn.Text != txt_repassword_dn.Text)
            {
                ThongBao("Mật khẩu nhập lại không khớp");
                return false;
            }
            else if (string.IsNullOrEmpty(txt_name_dn.Text) || (txt_name_dn.Text).Length > 50)
            {
                ThongBao("Tên công ty không hợp lệ");
                return false;
            }
            else if (string.IsNullOrEmpty(txt_email_dn.Text) || (txt_email_dn.Text).Length > 50)
            {
                ThongBao("Email không hợp lệ");
                return false;
            }
            else if (string.IsNullOrEmpty(txt_tax_dn.Text) || (txt_tax_dn.Text).Length != 10)
            {
                ThongBao("Mã số thuế không hợp lệ");
                return false;
            }
            else if (string.IsNullOrEmpty(txt_daidien_dn.Text) || (txt_daidien_dn.Text).Length > 50)
            {
                ThongBao("Tên người đại diện không hợp lệ");
                return false;
            }
            else if (string.IsNullOrEmpty(txt_diachi_dn.Text) || (txt_diachi_dn.Text).Length > 100)
            {
                ThongBao("Địa chỉ không hợp lệ");
                return false;
            }
            return true;
        }

        private void btn_DangKyDoanhNghiep_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraTKMK())
                {
                    return;
                }

                if (!DoanhNghiepBUS.KiemTraDNTonTai(txt_username_dn.Text))
                {
                    ThongBao("Doanh Nghiệp đã tồn tại trong hệ thống. Vui lòng đổi tên đăng nhập khác!");
                    return;
                }

                if (DoanhNghiepBUS.ThemDN(txt_username_dn.Text, txt_password_dn.Text, txt_name_dn.Text, txt_email_dn.Text, txt_tax_dn.Text, txt_daidien_dn.Text, txt_diachi_dn.Text))
                {
                    txt_username_dn.Text = "";
                    txt_password_dn.Text = "";
                    txt_repassword_dn.Text = "";
                    txt_name_dn.Text = "";
                    txt_email_dn.Text = "";
                    txt_tax_dn.Text = "";
                    txt_daidien_dn.Text = "";
                    txt_diachi_dn.Text = "";
                    ThongBao("Đăng ký Doanh Nghiệp thành công");
                }
            }
            catch (Exception ex)
            {
                ThongBao("Lỗi thêm DN " + ex.Message);
            }
        }
    }
}
