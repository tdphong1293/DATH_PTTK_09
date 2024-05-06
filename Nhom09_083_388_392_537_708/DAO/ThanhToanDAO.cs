using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
