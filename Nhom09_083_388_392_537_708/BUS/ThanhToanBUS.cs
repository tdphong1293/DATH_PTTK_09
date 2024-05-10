using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class ThanhToanBUS
    {
        public static void ThemTT(string HTTT, double sotien, int dot, int IDHD)
        {
            ThanhToanDAO.ThemTT(HTTT, sotien, dot, IDHD);
        }

        public static int TimIDDoanhNghiep(string TenDN)
        {
            return ThanhToanDAO.TimIDDoanhNghiep(TenDN);
        }

        public static List<int> LayDSIDPDT(int IDDoanhNghiep)
        {
            return ThanhToanDAO.LayDSIDPDT(IDDoanhNghiep);
        }

        public static DataTable LayTTPhieuDangTuyen(int IDPhieuDangTuyen) 
        {
            return ThanhToanDAO.DocTTPhieuDangTuyen(IDPhieuDangTuyen);
        }

        public static DataTable LayTTPhieuQuangCao(int IDPhieuQC)
        {
            return ThanhToanDAO.DocTTPhieuQuangCao(IDPhieuQC);
        }
        
        public static DataTable LayTTHoaDon(int IDPhieuDT)
        {
            return ThanhToanDAO.DocTTHoaDon(IDPhieuDT);
        }

        public static List<int> LayDSDotThanhToan(int IDHoaDon)
        {
            return ThanhToanDAO.LayDSDotThanhToan(IDHoaDon);
        }

        public static DataTable LayTTThanhToan(int IDHoaDon, int Dot)
        {
            return ThanhToanDAO.DocTTThanhToan(IDHoaDon, Dot);
        }

        public static bool KiemTraThanhToan(int IDHoaDon, int Dot)
        {
            return ThanhToanDAO.KiemTraThanhToan(IDHoaDon, Dot);
        }

        public static void THANHTOAN(int IDHoaDon, int Dot)
        {
            ThanhToanDAO.THANHTOAN(IDHoaDon, Dot);
        }
    }
}
