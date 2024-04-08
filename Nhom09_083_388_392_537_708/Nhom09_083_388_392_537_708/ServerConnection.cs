using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom09_083_388_392_537_708
{
    public class ServerConnection
    {
        public static SqlConnection conn = new SqlConnection();
        public void conServer()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    string connStr = "Data Source=DESKTOP-OST9FTB; Initial Catalog = PTTK_ABC; User Id = sa; Password = 123;";
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
            string role = "";
            conServer();
            try
            {
                SqlCommand cmd = new SqlCommand("checkLogin", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        role = reader["LoaiThanhVien"].ToString();
                        return role;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
