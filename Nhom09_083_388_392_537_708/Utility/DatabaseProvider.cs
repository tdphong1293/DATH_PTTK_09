using System.Data;
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
                string connStr = @"Data Source=HUYNHPHUC;Initial Catalog=PTTK_ABC;User ID=sa;Password=123";
                conn = new SqlConnection(connStr);
            }
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return conn;
        }
    }
}