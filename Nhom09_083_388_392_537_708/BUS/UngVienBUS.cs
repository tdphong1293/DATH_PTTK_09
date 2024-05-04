using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class UngVienBUS
    {
        public static bool KiemTraUVTonTai(string TenDangNhap)
        {
            return UngVienDAO.KiemTraUVTonTai(TenDangNhap);
        }

        public static bool ThemUV(string username, string password, string name, string email, string birth)
        {
            return UngVienDAO.ThemUV(username, password, name, email, birth);
        }
    }
}
