using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class UserDAO
    {
        public static LoggedUser CheckLogin(string username, string password)
        {
            SqlConnection conn = DatabaseProvider.GetConnection();
            string que = $"SELECT IDThanhVien FROM THANHVIEN WHERE TenDangNhap = @username";
            SqlCommand cmdGetID = new SqlCommand(que, conn);
            cmdGetID.Parameters.AddWithValue("@username", username);
            object result = cmdGetID.ExecuteScalar();
            if (result != null)
            {
                string id = result.ToString();
                SqlCommand cmd = new SqlCommand("checkLogin", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string role = reader["LoaiThanhVien"].ToString();
                        return new LoggedUser { Id = id, Role = role };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }
        }
    }
}