using DAO;
using System;
using System.Collections.Generic;
using System.Data;
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

        public static string LayTTUngVien(string idUngVien)
        {
            return UngVienDAO.LayTTUngVien(idUngVien);
        }

        public static DataTable LayTTUngVienHSUT(int idUngVien)
        {
            return UngVienDAO.DocTTUngVien(idUngVien);
        }
        //DataTable dataTable = UngVienBUS.LayTTUngVienDHSUT(row.Cells["IDUngVien"].Value.ToString);
        public static DataTable LayTTUV_TheoHSUT(int idDoanhNghiep, string tenUV)
        {
            return UngVienDAO.DocTTUV_TheoHSUT(idDoanhNghiep,tenUV);
        }

        public static DataTable LayEmailNgSinh_UV(int IDUngVien)
        {
            return UngVienDAO.DocEmailNgSinh_UV(IDUngVien);
        }
    }
}
