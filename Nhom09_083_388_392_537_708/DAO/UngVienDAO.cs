using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class UngVienDAO
    {
        private static SqlConnection conn = DatabaseProvider.GetConnection();
        public static bool KiemTraUVTonTai(string TenDangNhap)
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

        public static bool ThemUV(string username, string password, string name, string email, string birth)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("ThemUV", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@username", username));
                    command.Parameters.Add(new SqlParameter("@password", password));
                    command.Parameters.Add(new SqlParameter("@name", name));
                    command.Parameters.Add(new SqlParameter("@email", email));
                    command.Parameters.Add(new SqlParameter("@birth", birth));

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

        public static string LayTTUngVien(string idUngVien)
        {
            using (SqlCommand command = new SqlCommand("LayTTUngVien", conn))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", idUngVien);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader["Ten"].ToString();
                    }
                }
            }
            return null;
        }

        public static DataTable DocTTUngVien(int idUngVien)
        {
            string query = $"select tv.ten, tv.email, uv.ngaysinh from THANHVIEN tv, UNGVIEN uv where uv.idungvien = tv.idthanhvien and idthanhvien = {idUngVien};";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable data_uv = new DataTable(); // Tạo một DataTable thay vì DataSet
            adapter.Fill(data_uv);
            return data_uv;
        }

        public static DataTable DocTTUV_TheoHSUT(int idDoanhNghiep, string tenUV)
        {
            string query = $"SELECT hsut.idungvien as IDUngVien, tv.ten as HoTen, hsut.ngayungtuyen as NgayUngTuyen, hsut.vitriungtuyen as ViTriUngTuyen, hsut.diemdanhgia as DiemDanhGia , hsut.tinhtrangungtuyen as TinhTrangUngTuyen FROM HOSOUNGTUYEN hsut, THANHVIEN tv " +
                $"where hsut.idungvien = tv.idthanhvien and tv.ten like '%{tenUV}%' and hsut.iddoanhnghiep = {idDoanhNghiep}";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable data_hsut_theoten = new DataTable();
            adapter.Fill(data_hsut_theoten);
            return data_hsut_theoten;
        }

        public static DataTable DocEmailNgSinh_UV(int IDUngVien)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("LayEmailNgSinh_UV", conn))
                {
                    DataTable dataTable = new DataTable();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IDUngVien", IDUngVien));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                    return dataTable;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
