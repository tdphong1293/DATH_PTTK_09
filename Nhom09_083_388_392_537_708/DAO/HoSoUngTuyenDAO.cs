using System;
using System.Data;
using System.Data.SqlClient;
using Utility;

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
    }
}
