using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DatabaseProvider
    {
        public static SqlConnection? GetConnection()
        {
            string connStr = @"Data Source=HUYNHPHUC;Initial Catalog=PTTK_ABC;User ID=sa;Password=123";
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                return conn;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Connection error: " + ex.Message);
                return null;
            }
        }
    }
}
