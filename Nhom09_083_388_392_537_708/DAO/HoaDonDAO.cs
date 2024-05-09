using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class HoaDonDAO
    {
        private static SqlConnection con = DatabaseProvider.GetConnection();

        public static int ThemHD(double Tongtien, string lhtt, int idpdt)
        {
            try
            {
                int idhd = 0;
                using (SqlCommand cmd = new SqlCommand("ThemHD", con))
                {
                    float datra = 0;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tongtien", Tongtien);
                    cmd.Parameters.AddWithValue("@datra", datra);
                    cmd.Parameters.AddWithValue("@lhtt", lhtt);
                    cmd.Parameters.AddWithValue("@ngaylap", DateTime.Today);
                    cmd.Parameters.AddWithValue("@ttht", "Chưa hoàn thành");
                    cmd.Parameters.AddWithValue("@idpdt", idpdt);
                    SqlParameter paramID = new SqlParameter("@idhd", SqlDbType.Int);
                    paramID.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramID);
                    cmd.ExecuteNonQuery();
                    idhd = Convert.ToInt32(paramID.Value);
                }
                return idhd;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
    }
}
