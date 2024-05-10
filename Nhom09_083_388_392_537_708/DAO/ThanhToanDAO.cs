﻿using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

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

        public static int TimIDDoanhNghiep(string TenDN)
        {
            try
            {
                int IDDoanhNghiep = 0;
                using (SqlCommand cmd = new SqlCommand("TimIDDoanhNghiep", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TenDoanhNghiep", TenDN);

                    SqlParameter paramID = new SqlParameter("@IDDoanhNghiep", SqlDbType.Int);
                    paramID.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramID);
                    cmd.ExecuteNonQuery();
                    if (paramID.Value != DBNull.Value)
                        IDDoanhNghiep = Convert.ToInt32(paramID.Value);
                    else
                        IDDoanhNghiep = -1;

                }
                return IDDoanhNghiep;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public static List<int> LayDSIDPDT(int IDDoanhNghiep)
        {
            List<int> idList = new List<int>();
            try
            {
                using (SqlCommand command = new SqlCommand("LayDSIDPDT", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IDDoanhNghiep", IDDoanhNghiep));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            idList.Add(Convert.ToInt32(reader["IDPhieuDangTuyen"]));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return idList;
        }

        public static DataTable DocTTPhieuDangTuyen(int IDPhieuDangTuyen)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("DocTTPhieuDangTuyen", con))
                {
                    DataTable dataTable = new DataTable();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IDPhieuDangTuyen", IDPhieuDangTuyen));
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

        public static DataTable DocTTHoaDon(int IDPhieuDT)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("DocTTHoaDon", con))
                {
                    DataTable dataTable = new DataTable();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IDPhieuDT", IDPhieuDT));
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

        public static List<int> LayDSDotThanhToan(int IDHoaDon)
        {
            List<int> idList = new List<int>();
            try
            {
                using (SqlCommand command = new SqlCommand("LayDSDotThanhToan", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IDHoaDon", IDHoaDon));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            idList.Add(Convert.ToInt32(reader["Dot"]));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return idList;
        }

        public static DataTable DocTTThanhToan(int IDHoaDon, int Dot)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("DocTTThanhToan", con))
                {
                    DataTable dataTable = new DataTable();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IDHoaDon", IDHoaDon));
                    command.Parameters.Add(new SqlParameter("@dot", Dot));
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

        public static bool KiemTraThanhToan(int IDHoaDon, int Dot)
        {
            try
            {
                bool flag = true;
                using (SqlCommand cmd = new SqlCommand("KTThanhToan", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDHoaDon", IDHoaDon);
                    cmd.Parameters.AddWithValue("@dot", Dot);


                    SqlParameter paramID = new SqlParameter("@kq", SqlDbType.Int);
                    paramID.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramID);
                    cmd.ExecuteNonQuery();
                    if (Convert.ToInt32(paramID.Value) == 1)
                        flag = true;
                    else
                        flag = false;

                }
                return flag;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static void THANHTOAN(int IDHoaDon, int Dot)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("ThucHienThanhToan", con))
                {
                    DataTable dataTable = new DataTable();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IDHoaDon", IDHoaDon));
                    command.Parameters.Add(new SqlParameter("@dot", Dot));
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return;
        }

    }
}
