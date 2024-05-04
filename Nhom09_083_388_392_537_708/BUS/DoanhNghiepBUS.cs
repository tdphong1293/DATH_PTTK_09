using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DoanhNghiepBUS
    {
        public static bool KiemTraDNTonTai(string TenDangNhap)
        {
            return DoanhNghiepDAO.KiemTraDNTonTai(TenDangNhap);
        }

        public static bool ThemDN(string username, string password, string name, string email, string tax, string daidien, string diachi)
        {
            return DoanhNghiepDAO.ThemDN(username, password, name, email, tax, daidien, diachi);
        }

        public static string[] LayThongTinDN(int iddoanhnghiep)
        {
            return DoanhNghiepDAO.LayThongTinDN(iddoanhnghiep);
        }

        public static bool CapNhatUuDai(int iddoanhnghiep, string uudai)
        {
            return DoanhNghiepDAO.CapNhatUuDai(iddoanhnghiep, uudai);
        }
    }
}
