using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace DAO
{
    public class DoanhNghiepDAO
    {
        private static SqlConnection conn = DatabaseProvider.GetConnection();
        public static bool KiemTraDNTonTai(string TenDangNhap)
        {
            try
            {
                string query = "select TenDangNhap from THANHVIEN where TenDangNhap = @tendangnhap";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@tendangnhap", TenDangNhap);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool ThemDN(string username, string password, string name, string email, string tax, string daidien, string diachi)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("ThemDN", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@username", username));
                    command.Parameters.Add(new SqlParameter("@password", password));
                    command.Parameters.Add(new SqlParameter("@name", name));
                    command.Parameters.Add(new SqlParameter("@email", email));
                    command.Parameters.Add(new SqlParameter("@masothue", tax));
                    command.Parameters.Add(new SqlParameter("@nguoidaidien", daidien));
                    command.Parameters.Add(new SqlParameter("@diachi", diachi));

                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static string[] LayThongTinDN(int iddoanhnghiep)
        {
            try
            {
                string[] DoanhNghiep = new string [6];
                string query = "select TV.Ten, TV.Email, DN.MaSoThue, DN.NguoiDaiDien, DN.DiaChi, DN.UuDai" +
                    " from THANHVIEN TV join DOANHNGHIEP DN on TV.IDThanhVien = DN.IDDoanhNghiep" +
                    " where DN.IDDoanhNghiep = @iddoanhnghiep";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@iddoanhnghiep", iddoanhnghiep);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DoanhNghiep[0] = reader["Ten"].ToString();
                            DoanhNghiep[1] = reader["Email"].ToString();
                            DoanhNghiep[2] = reader["MaSoThue"].ToString();
                            DoanhNghiep[3] = reader["NguoiDaiDien"].ToString();
                            DoanhNghiep[4] = reader["DiaChi"].ToString();
                            DoanhNghiep[5] = (float.Parse(reader["UuDai"].ToString()) * 100).ToString();
                        }
                    }
                    return DoanhNghiep;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static bool CapNhatUuDai(int iddoanhnghiep, string uudai)
        {
            try
            {
                string query = "update DOANHNGHIEP set UuDai = @uudai where IDDoanhNghiep = @iddoanhnghiep";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@uudai", float.Parse(uudai) / 100);
                    command.Parameters.AddWithValue("@iddoanhnghiep", iddoanhnghiep);
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
