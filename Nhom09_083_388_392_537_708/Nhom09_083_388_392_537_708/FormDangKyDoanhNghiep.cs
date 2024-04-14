using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom09_083_388_392_537_708
{
    public partial class FormDangKyDoanhNghiep : Form
    {
        public FormDangKyDoanhNghiep()
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
            }
            else if (!ValidateInputString(txt_password_dn.Text))
            {
                ThongBao("Mật khẩu không hợp lệ");
            }
            else if (txt_password_dn.Text != txt_repassword_dn.Text)
            {
                ThongBao("Mật khẩu nhập lại không khớp");
            }
            else if (string.IsNullOrEmpty(txt_name_dn.Text) || (txt_name_dn.Text).Length > 50)
            {
                ThongBao("Tên công ty không hợp lệ");
            }
            else if (string.IsNullOrEmpty(txt_email_dn.Text) || (txt_email_dn.Text).Length > 50)
            {
                ThongBao("Email không hợp lệ");
            }
            else if (string.IsNullOrEmpty(txt_tax_dn.Text) || (txt_tax_dn.Text).Length != 10)
            {
                ThongBao("Mã số thuế không hợp lệ");
            }
            else if (string.IsNullOrEmpty(txt_daidien_dn.Text) || (txt_daidien_dn.Text).Length > 50)
            {
                ThongBao("Tên người đại diện không hợp lệ");
            }
            else if (string.IsNullOrEmpty(txt_diachi_dn.Text) || (txt_diachi_dn.Text).Length > 100)
            {
                ThongBao("Địa chỉ không hợp lệ");
            }
            return true;
        }

        private bool KiemTraDNTonTai(string TenDangNhap)
        {
            try
            {
                string connectionString = "Data Source=P1293; Initial Catalog = PTTK_ABC; User Id = sa; Password = ducphong1293;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "select TenDangNhap from THANHVIEN where TenDangNhap = @tendangnhap";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@tendangnhap", TenDangNhap);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                ThongBao("Tên đăng nhập đã tồn tại");
                                connection.Close();
                                return false;
                            }
                            else
                            {
                                connection.Close();
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ThongBao("Lỗi kiểm tra tên đăng nhập " + ex.Message);
                return false;
            }
        }

        private void btn_DangKyDoanhNghiep_Click(object sender, EventArgs e)
        {
            try
            {
               if (KiemTraTKMK() && KiemTraDNTonTai(txt_username_dn.Text))
               {
                    //Chỗ này cho string connection vào
                    string connectionString = "Data Source=P1293; Initial Catalog = PTTK_ABC; User Id = sa; Password = ducphong1293;";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("ThemDN", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.Add(new SqlParameter("@username", txt_username_dn.Text));
                            command.Parameters.Add(new SqlParameter("@password", txt_password_dn.Text));
                            command.Parameters.Add(new SqlParameter("@name", txt_name_dn.Text));
                            command.Parameters.Add(new SqlParameter("@email", txt_email_dn.Text));
                            command.Parameters.Add(new SqlParameter("@masothue", txt_tax_dn.Text));
                            command.Parameters.Add(new SqlParameter("@nguoidaidien", txt_daidien_dn.Text));
                            command.Parameters.Add(new SqlParameter("@diachi", txt_diachi_dn.Text));

                            command.ExecuteNonQuery();
                        }
                        txt_username_dn.Text = "";
                        txt_password_dn.Text = "";
                        txt_repassword_dn.Text = "";
                        txt_name_dn.Text = "";
                        txt_email_dn.Text = "";
                        txt_tax_dn.Text = "";
                        txt_daidien_dn.Text = "";
                        txt_diachi_dn.Text = "";
                        ThongBao("Đăng ký Doanh Nghiệp thành công");
                        connection.Close();
                    }
               }
            }
            catch (Exception ex)
            {
                ThongBao("Lỗi thêm DN " + ex.Message);
            }
        }
    }
}
