using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

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
    }
}
