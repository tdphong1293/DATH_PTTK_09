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

        private void btn_DangKyUngVien_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputString(txt_name_dn.Text))
                {
                    MessageBox.Show("Tên đăng nhập không hợp lệ");
                }
                else if (!ValidateInputString(txt_password_dn.Text))
                {
                    MessageBox.Show("Mật khẩu không hợp lệ");
                }
                else if (txt_password_dn.Text != txt_repassword_dn.Text)
                {
                    MessageBox.Show("Mật khẩu nhập lại không khớp");
                }
                else if (string.IsNullOrEmpty(txt_name_dn.Text) || (txt_name_dn.Text).Length > 50)
                {
                    MessageBox.Show("Tên không hợp lệ");
                }
                else if (string.IsNullOrEmpty(txt_email_dn.Text) || (txt_email_dn.Text).Length > 50)
                {55
                    MessageBox.Show("Email không hợp lệ");
                }
                else if (string.IsNullOrEmpty(txt_tax_dn.Text) || (txt_tax_dn.Text).Length != 10)
                {
                    MessageBox.Show("Mã số thuế không hợp lệ");
                }
                else if (string.IsNullOrEmpty(txt_daidien_dn.Text) || (txt_daidien_dn.Text).Length > 50)
                {
                    MessageBox.Show("Tên người đại diện không hợp lệ");
                }
                else if (string.IsNullOrEmpty(txt_diachi_dn.Text) || (txt_diachi_dn.Text).Length > 100)
                {
                    MessageBox.Show("Địa chỉ không hợp lệ");
                }
                else
                {
                    //Chỗ này cho string connection vào
                    string connectionString = "Data Source=P1293; Initial Catalog = PTTK_ABC; User Id = sa; Password = ducphong1293;";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("CreateDoanhNghiep", connection))
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
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
