﻿using System.Data;
using System.Data.SqlClient;

namespace Utility
{
    public class DatabaseProvider
    {
        private static SqlConnection conn = null;

        public static SqlConnection GetConnection()
        {
            if (conn == null)
            {

                //string connStr = @"Data Source=P1293;Initial Catalog=PTTK_ABC;Trusted_Connection=True";
                //string connStr = @"Data Source=HUYNHPHUC;Initial Catalog=PTTK_ABC;Trusted_Connection=True";
                string connStr = "Data Source=DESKTOP-U8VK4R9\\MSSQLSERVER2022;Initial Catalog=PTTK_ABC;Integrated Security=true;";
                conn = new SqlConnection(connStr);
            }
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return conn;
        }
    }
}