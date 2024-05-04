using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAO;

namespace BUS
{
    public class DangNhapBUS
    {

    }
    public string checkLogin(string username, string password)
    {
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
}
