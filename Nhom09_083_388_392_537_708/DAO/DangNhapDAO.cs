using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class DangNhapDAO
    {
        public string role = "";
        public static SqlConnection? conn = DatabaseProvider.GetConnection();
        public string username = "";
        public string id = "";

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
                }
                else
                {
                    return null;
                }

                SqlCommand cmd = new SqlCommand("checkLogin", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@passwoerd", password);
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
}
