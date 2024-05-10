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
