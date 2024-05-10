using System.Data.SqlClient;
using System.Data;
using DAO;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class PhieuDangTuyenBUS
    {
        public static DataSet GetDataSetFromStoredProcedure(string storedProcedureName, params SqlParameter[] parameters)
        {
            return PhieuDangTuyenDAO.GetDataSetFromStoredProcedure(storedProcedureName, parameters);
        }

        public static DataSet LayDSPhieuDangTuyen()
        {
            return PhieuDangTuyenDAO.LayDSPhieuDangTuyen();
        }

        public static DataSet LayPDTTheoDoanhNghiep(string idDoanhNghiep)
        {
            return PhieuDangTuyenDAO.LayPDTTheoDoanhNghiep(idDoanhNghiep);
        }

        public static DataSet LayYeuCauCongViec(string idPhieuDangTuyen)
        {
            return PhieuDangTuyenDAO.LayYeuCauCongViec(idPhieuDangTuyen);
        }

        public static void XoaPhieuDangTuyen(string idPhieuDangTuyen)
        {
            PhieuDangTuyenDAO.XoaPhieuDangTuyen(idPhieuDangTuyen);
        }
        public static string Lay_IdDN_Tu_IdPDT(string idPDT)
        {
            return PhieuDangTuyenDAO.Lay_IdDN_Tu_IdPDT(idPDT);
        }
        public static string LayViTriDangTuyen(string IdPDT)
        {
            return PhieuDangTuyenDAO.LayViTriDangTuyen(IdPDT);
        }
        public static int ThemPDT(PhieuDangTuyenDTO pdt, int IDPQC)
        {
            return PhieuDangTuyenDAO.ThemPDT(pdt, IDPQC);
        }
        public static DataSet SearchPhieuDangTuyen(string tenCty, string viTri, string idDN = null)
        {
            return PhieuDangTuyenDAO.SearchPhieuDangTuyen(tenCty, viTri, idDN);
        }

        public static List<int> LayDSIDPDT(int IDDoanhNghiep)
        {
            return PhieuDangTuyenDAO.LayDSIDPDT(IDDoanhNghiep);
        }

        public static DataTable LayTTPhieuDangTuyen(int IDPhieuDangTuyen)
        {
            return PhieuDangTuyenDAO.DocTTPhieuDangTuyen(IDPhieuDangTuyen);
        }

    }
}