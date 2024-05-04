using System.Data.SqlClient;
using System.Data;
using Utility;

namespace DAO
{
    public class PhieuDangTuyenDAO
    {
        public static DataSet GetDataSetFromStoredProcedure(string storedProcedureName, params SqlParameter[] parameters)
        {
            DataSet dataSet = new DataSet();
            SqlConnection conn = DatabaseProvider.GetConnection();
            using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
            }
            
            return dataSet;
        }
        public static void XoaPhieuDangTuyen(string idPhieuDangTuyen)
        {
            SqlConnection conn = DatabaseProvider.GetConnection();
            using (SqlCommand cmd = new SqlCommand("XoaPhieuDangTuyen", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDPhieuDangTuyen", idPhieuDangTuyen);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static DataSet LayYeuCauCongViec(string idPhieuDangTuyen)
        {
            return GetDataSetFromStoredProcedure("LayYeuCauCongViec", new SqlParameter("@ID", idPhieuDangTuyen));
        }
    }
}