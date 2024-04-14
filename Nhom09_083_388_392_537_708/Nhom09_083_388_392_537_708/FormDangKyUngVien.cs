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
    public partial class FormDangKyUngVien : Form
    {
        public FormDangKyUngVien()
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
        
        private bool KiemTraUVTonTai(string TenDangNhap)
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

        private void btn_DangKyUngVien_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTraUVTonTai(txt_username_uv.Text) && KiemTraTKMK())
                {
                    //Chỗ này cho string connection vào
                    string connectionString = "Data Source=P1293; Initial Catalog = PTTK_ABC; User Id = sa; Password = ducphong1293;";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("ThemUV", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.Add(new SqlParameter("@username", txt_username_uv.Text));
                            command.Parameters.Add(new SqlParameter("@password", txt_password_uv.Text));
                            command.Parameters.Add(new SqlParameter("@name", txt_name_uv.Text));
                            command.Parameters.Add(new SqlParameter("@email", txt_email_uv.Text));
                            command.Parameters.Add(new SqlParameter("@birth", dtp_birth_uv.Value.ToString("yyyy-MM-dd")));

                            command.ExecuteNonQuery();
                        }
                        txt_username_uv.Text = "";
                        txt_password_uv.Text = "";
                        txt_repassword_uv.Text = "";
                        txt_name_uv.Text = "";
                        txt_email_uv.Text = "";
                        ThongBao("Đăng ký Ứng Viên thành công");
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                ThongBao("Lỗi thêm UV " + ex.Message);
            }
        }
    }
}
