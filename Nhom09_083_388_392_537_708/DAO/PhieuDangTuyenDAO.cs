﻿using System.Data.SqlClient;
using System.Data;
using DTO;
using System;
using System.Collections.Generic;

namespace DAO
{
    public class PhieuDangTuyenDAO
    {
        private static SqlConnection conn = DatabaseProvider.GetConnection();
        public static DataSet GetDataSetFromStoredProcedure(string storedProcedureName, params SqlParameter[] parameters)
        {
            DataSet dataSet = new DataSet();
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
        
        public static DataSet LayDSPhieuDangTuyen()
        {
            return GetDataSetFromStoredProcedure("LayDanhSachPhieuDangTuyen");
        }

        public static DataSet LayPDTTheoDoanhNghiep(string idDoanhNghiep)
        {
            return GetDataSetFromStoredProcedure("LayDanhSachPhieuDangTuyenTheoDoanhNghiep", new SqlParameter("@ID", idDoanhNghiep));
        }

        public static DataSet LayYeuCauCongViec(string idPhieuDangTuyen)
        {
            return GetDataSetFromStoredProcedure("LayYeuCauCongViec", 
                new SqlParameter("@ID", idPhieuDangTuyen));
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

        public static string Lay_IdDN_Tu_IdPDT(string idPDT)
        {
            string idDoanhNghiep = "";
            using (SqlCommand command = new SqlCommand("TimIDDoanhNghiepTuIDPDT", conn))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDPDT", idPDT);
                SqlParameter outputParam = new SqlParameter("@IDDoanhNghiep", SqlDbType.Int);
                outputParam.Direction = ParameterDirection.Output;
                command.Parameters.Add(outputParam);
                command.ExecuteNonQuery();
                idDoanhNghiep = command.Parameters["@IDDoanhNghiep"].Value.ToString();
            }
            return idDoanhNghiep;
        }

        public static DataTable LayViTriDangTuyen(string IdPDT)
        {
            DataTable dt = new DataTable();
            using (SqlCommand command = new SqlCommand("LayViTriDangTuyen", conn))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", IdPDT);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            return dt;
        }

        public static int ThemPDT(PhieuDangTuyenDTO pdt, int IDPQC)
        {
            try
            {
                int IDPDT = 0;
                using (SqlCommand cmd = new SqlCommand("ThemPDT", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vtdt", pdt.VTDT);
                    cmd.Parameters.AddWithValue("@sltd", pdt.SLTD);
                    cmd.Parameters.AddWithValue("@iddn", pdt.IDDN);
                    cmd.Parameters.AddWithValue("@pqc", IDPQC);
                    // Thêm tham số đầu ra để lưu trữ IDPDT
                    SqlParameter paramID = new SqlParameter("@idpdt", SqlDbType.Int);
                    paramID.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramID);
                    cmd.ExecuteNonQuery();
                    IDPDT = Convert.ToInt32(paramID.Value);
                }
                return IDPDT;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public static DataSet SearchPhieuDangTuyen(string tenCty, string viTri, string idDN = null)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Ten", tenCty),
                new SqlParameter("@ViTri", viTri)
            };

            if (!string.IsNullOrEmpty(idDN))
            {
                parameters.Add(new SqlParameter("@ID", idDN));
            }

            return GetDataSetFromStoredProcedure("TimKiemPhieuDangTuyen", parameters.ToArray());
        }
    }
}