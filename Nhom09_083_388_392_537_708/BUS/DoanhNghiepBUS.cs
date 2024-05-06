using DTO;
using DAO;

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

        public static DoanhNghiep LayThongTinDN(int iddoanhnghiep)
        {
            return DoanhNghiepDAO.LayThongTinDN(iddoanhnghiep);
        }

        public static bool CapNhatUuDai(int iddoanhnghiep, string uudai)
        {
            return DoanhNghiepDAO.CapNhatUuDai(iddoanhnghiep, uudai);
        }

        public static double LayUuDai(string username)
        {
            return DoanhNghiepDAO.LayUuDai(username);
        }
    }
}
