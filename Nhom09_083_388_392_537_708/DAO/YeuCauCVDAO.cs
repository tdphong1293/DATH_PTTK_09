﻿using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class YeuCauCVDAO
    {
        private static SqlConnection con = DatabaseProvider.GetConnection();
        public static void ThemYC(string mota, int IDPDT)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("ThemYC", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pdt", IDPDT);
                    cmd.Parameters.AddWithValue("@mota", mota);
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
