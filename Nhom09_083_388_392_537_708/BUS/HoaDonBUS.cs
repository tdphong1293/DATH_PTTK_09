using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class HoaDonBUS
    {
        public static int ThemHD (double Tongtien, string lhtt, int idpdt)
        {
            return HoaDonDAO.ThemHD(Tongtien, lhtt, idpdt);
        }

        public static DataTable LayTTHoaDon(int IDPhieuDT)
        {
            return HoaDonDAO.DocTTHoaDon(IDPhieuDT);
        }
    }
}
