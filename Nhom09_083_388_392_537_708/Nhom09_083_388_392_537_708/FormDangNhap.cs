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
using System.Data.SqlClient;

namespace Nhom09_083_388_392_537_708
{
    public partial class FormDangNhap : Form
    {
        public event EventHandler ButtonClicked;
        public string role = "";
        public static SqlConnection conn = new SqlConnection();
        public string username = "";
        public string id = "";

        public FormDangNhap()
        {
            InitializeComponent();
        }

        public void conServer()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    string connStr = "Data Source=ShiphuDOTcpp;Initial Catalog=PTTK_ABC;Integrated Security=true;";
                    conn.ConnectionString = connStr;
                    conn.Open();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi kết nối : " + ex.Message);
            }
        }

        public string checkLogin(string username, string password)
        {
            conServer();
            try
            {
                string que = $"SELECT IDThanhVien FROM THANHVIEN WHERE TenDangNhap = @username";
                SqlCommand cmdGetID = new SqlCommand(que, conn);
                cmdGetID.Parameters.AddWithValue("@username", username);
                object result = cmdGetID.ExecuteScalar();
                if (result != null)
                {
                    this.id = result.ToString();
                    //MessageBox.Show(this.id);
                }
                else
                {
                    return null;
                }

                SqlCommand cmd = new SqlCommand("checkLogin", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) 
                    {
                        role = reader["LoaiThanhVien"].ToString();
                        this.username = username;
                        return role;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ (ví dụ: ghi log, thông báo lỗi, vv.)
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
            finally
            {
            }
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
