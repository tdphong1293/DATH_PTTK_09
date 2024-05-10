using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace DAO
{
    public class ThanhToanDAO
    {
        private static SqlConnection con = DatabaseProvider.GetConnection();
        public static void ThemTT(string HTTT, double sotien, int dot, int IDHD)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("ThemTT", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@httt", HTTT);
                    cmd.Parameters.AddWithValue("@sotien", sotien);
                    cmd.Parameters.AddWithValue("@dot", dot);
                    cmd.Parameters.AddWithValue("@idhd", IDHD);
                    cmd.ExecuteNonQuery();
                }
                return;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }


        public static List<int> LayDSDotThanhToan(int IDHoaDon)
        {
            List<int> idList = new List<int>();
            try
            {
                using (SqlCommand command = new SqlCommand("LayDSDotThanhToan", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IDHoaDon", IDHoaDon));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            idList.Add(Convert.ToInt32(reader["Dot"]));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return idList;
        }

        public static DataTable DocTTThanhToan(int IDHoaDon, int Dot)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("DocTTThanhToan", con))
                {
                    DataTable dataTable = new DataTable();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IDHoaDon", IDHoaDon));
                    command.Parameters.Add(new SqlParameter("@dot", Dot));
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

        public static bool KiemTraThanhToan(int IDHoaDon, int Dot)
        {
            try
            {
                bool flag = true;
                using (SqlCommand cmd = new SqlCommand("KTThanhToan", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDHoaDon", IDHoaDon);
                    cmd.Parameters.AddWithValue("@dot", Dot);


                    SqlParameter paramID = new SqlParameter("@kq", SqlDbType.Int);
                    paramID.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramID);
                    cmd.ExecuteNonQuery();
                    if (Convert.ToInt32(paramID.Value) == 1)
                        flag = true;
                    else
                        flag = false;

                }
                return flag;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static void THANHTOAN(int IDHoaDon, int Dot)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("ThucHienThanhToan", con))
                {
                    DataTable dataTable = new DataTable();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IDHoaDon", IDHoaDon));
                    command.Parameters.Add(new SqlParameter("@dot", Dot));
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return;
        }

    }
}
