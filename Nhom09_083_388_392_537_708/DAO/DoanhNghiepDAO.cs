using System;
using System.Data;
using System.Data.SqlClient;
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

        public static DoanhNghiep LayThongTinDN(int iddoanhnghiep)
        {
            try
            {
                string query = "select TV.Ten, TV.Email, DN.MaSoThue, DN.NguoiDaiDien, DN.DiaChi, DN.UuDai" +
                    " from THANHVIEN TV join DOANHNGHIEP DN on TV.IDThanhVien = DN.IDDoanhNghiep" +
                    " where DN.IDDoanhNghiep = @iddoanhnghiep";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@iddoanhnghiep", iddoanhnghiep);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new DoanhNghiep
                            {
                                Ten = reader["Ten"].ToString(),
                                Email = reader["Email"].ToString(),
                                MaSoThue = reader["MaSoThue"].ToString(),
                                NguoiDaiDien = reader["NguoiDaiDien"].ToString(),
                                DiaChi = reader["DiaChi"].ToString(),
                                UuDai = (float.Parse(reader["UuDai"].ToString()) * 100).ToString()
                            };
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
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
