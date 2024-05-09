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
    public class BangCapDAO
    {
        private static SqlConnection conn = DatabaseProvider.GetConnection();
        public static DataTable DocDSBangCapTheoUngVien(int idUngVien)
        {
            string query = $"SELECT TenBang, CapBac, NgayCap, DonViCap from BANGCAP where idungvien = {idUngVien}";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable data_bangcapuv = new DataTable();
            adapter.Fill(data_bangcapuv);
            return data_bangcapuv;
        }

        public static DataTable DocDSBangCapCuaUngVien(int IDUngVien)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("LayTTBangCap_UV", conn))
                {
                    DataTable dataTable = new DataTable();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@id_uv", IDUngVien));
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

        public static int ThemBangCap(BangCapDTO bc)
        {
            try
            {
                int IDBangCap = 0;
                using (SqlCommand cmd = new SqlCommand("ThemBangCap", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tenbang", bc.TenBang);
                    cmd.Parameters.AddWithValue("@capbac", bc.CapBac);
                    cmd.Parameters.AddWithValue("@ngaycap", bc.Ngaycap);
                    cmd.Parameters.AddWithValue("@dvcap", bc.DonViCap);
                    cmd.Parameters.AddWithValue("@idungvien", bc.IDUngVien);

                    SqlParameter paramID = new SqlParameter("@idbangcap", SqlDbType.Int);
                    paramID.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramID);
                    cmd.ExecuteNonQuery();
                    IDBangCap = Convert.ToInt32(paramID.Value);
                }
                return IDBangCap;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
    }
}
