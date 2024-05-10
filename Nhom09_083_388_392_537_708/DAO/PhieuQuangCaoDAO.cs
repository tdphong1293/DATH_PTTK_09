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
    public class PhieuQuangCaoDAO
    {
        private static SqlConnection con = DatabaseProvider.GetConnection();
        public static int ThemPQC(PhieuQuangCaoDTO pqc)
        {
            try
            {
                int IDPhieuQuangCao = 0;
                using (SqlCommand cmd = new SqlCommand("ThemPQC", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NBD", pqc.NBD);
                    cmd.Parameters.AddWithValue("@NKT", pqc.NKT);
                    cmd.Parameters.AddWithValue("@htdt", pqc.HTDT.ToString());
                    cmd.Parameters.AddWithValue("@tongtien", pqc.TongTienQC);
                    SqlParameter paramID = new SqlParameter("@IDPhieuQuangCao", SqlDbType.Int);
                    paramID.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramID);
                    cmd.ExecuteNonQuery();
                    IDPhieuQuangCao = Convert.ToInt32(paramID.Value);
                }
                return IDPhieuQuangCao;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }

        }


        public static DataTable DocTTPhieuQuangCao(int IDPhieuQC)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("DocTTPhieuQuangCao", con))
                {
                    DataTable dataTable = new DataTable();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IDPhieuQC", IDPhieuQC));
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
