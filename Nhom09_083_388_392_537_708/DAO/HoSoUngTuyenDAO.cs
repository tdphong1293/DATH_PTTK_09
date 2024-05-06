using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using DTO;

namespace DAO
{
    public class HoSoUngTuyenDAO
    {
        private static SqlConnection conn = DatabaseProvider.GetConnection();
        public static DataTable LayKetQuaUngTuyen(string timkiem)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("LayKetQuaUngTuyen", conn))
                {
                    DataTable dataTable = new DataTable();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@timkiem", timkiem));
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
        public static void ThemHoSoUngTuyen(string IdDoanhNghiep, string IdUngVien, DateTime NgayUngTuyen, string viTriUngTuyen)
        {
            using (SqlCommand command = new SqlCommand("ThemHoSoUngTuyen", conn))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDDoanhNghiep", IdDoanhNghiep);
                command.Parameters.AddWithValue("@IDUngVien", IdUngVien);
                command.Parameters.AddWithValue("@NgayUngTuyen", NgayUngTuyen);
                command.Parameters.AddWithValue("@ViTriUngTuyen", viTriUngTuyen);
                command.ExecuteNonQuery();
            }
        }
        public static DataTable DocDSHSSUngTuyenTheoDoanhNghiep(int idDoanhNghiep)
        {
            string query = $"SELECT hsut.idungvien as IDUngVien, tv.ten as HoTen, hsut.ngayungtuyen as NgayUngTuyen, hsut.vitriungtuyen as ViTriUngTuyen, hsut.diemdanhgia as DiemDanhGia , hsut.tinhtrangungtuyen as TinhTrangUngTuyen FROM HOSOUNGTUYEN hsut, THANHVIEN tv " +
                $"where hsut.idungvien = tv.idthanhvien and hsut.iddoanhnghiep = {idDoanhNghiep}";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable data_hsut = new DataTable();
            adapter.Fill(data_hsut);
            return data_hsut;
        }

        public static DataTable DocDSHoSoUT_SapXep_DiemDanhGia(int idDoanhNghiep)
        {
            string query = $"SELECT hsut.idungvien as IDUngVien, tv.ten as HoTen, hsut.ngayungtuyen as NgayUngTuyen, hsut.vitriungtuyen as ViTriUngTuyen, hsut.diemdanhgia as DiemDanhGia , hsut.tinhtrangungtuyen as TinhTrangUngTuyen FROM HOSOUNGTUYEN hsut, THANHVIEN tv" +
                $" where hsut.idungvien = tv.idthanhvien and hsut.iddoanhnghiep = {idDoanhNghiep} ORDER BY hsut.diemdanhgia DESC";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable data_hsut = new DataTable(); // Tạo một DataTable thay vì DataSet
            adapter.Fill(data_hsut);
            return data_hsut;
        }

        public static DataTable DocHoSoUT_TheoTenUV(int idDoanhNghiep, string tenUV)
        {
            string query = $"SELECT hsut.idungvien as IDUngVien, tv.ten as HoTen, hsut.ngayungtuyen as NgayUngTuyen, hsut.vitriungtuyen as ViTriUngTuyen, hsut.diemdanhgia as DiemDanhGia , hsut.tinhtrangungtuyen as TinhTrangUngTuyen FROM HOSOUNGTUYEN hsut, THANHVIEN tv " +
                $"where hsut.idungvien = tv.idthanhvien and tv.ten like '%{tenUV}%' and hsut.iddoanhnghiep = {idDoanhNghiep}";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable data_hsut_theoten = new DataTable();
            adapter.Fill(data_hsut_theoten);
            return data_hsut_theoten;
        }

        public static int CapNhat_TinhTrangUngTuyenDB(string dieukien, int idDoanhNghiep, int idUngVien)
        {
            string query = $"UPDATE HOSOUNGTUYEN SET TinhTrangUngTuyen = N'{dieukien}' WHERE idungvien = {idUngVien} and iddoanhnghiep = {idDoanhNghiep}";

            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 0;
            }
            return 1; 
        }

    }
}
