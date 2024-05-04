using System.Data.SqlClient;
using System.Data;
using DAO;

namespace BUS
{
    public class PhieuDangTuyenBUS
    {
        public static DataSet GetDataSetFromStoredProcedure(string storedProcedureName, params SqlParameter[] parameters)
        {
            return PhieuDangTuyenDAO.GetDataSetFromStoredProcedure(storedProcedureName, parameters);
        }
        public static void XoaPhieuDangTuyen(string idPhieuDangTuyen)
        {
            PhieuDangTuyenDAO.XoaPhieuDangTuyen(idPhieuDangTuyen);
        }
        public static DataSet LayYeuCauCongViec(string idPhieuDangTuyen)
        {
            return PhieuDangTuyenDAO.LayYeuCauCongViec(idPhieuDangTuyen);
        }
    }
}