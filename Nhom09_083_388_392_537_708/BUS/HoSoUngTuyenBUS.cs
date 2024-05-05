using DAO;
using System;
using System.Data;

namespace BUS
{
    public class HoSoUngTuyenBUS
    {
        public static DataTable LayKetQuaUngTuyen(string timkiem)
        {
            return HoSoUngTuyenDAO.LayKetQuaUngTuyen(timkiem);
        }

        public static void ThemHSUngTuyen(string IdDoanhNghiep, string IdUngVien, DateTime NgayUngTuyen, string viTriUngTuyen)
        {
            HoSoUngTuyenDAO.ThemHoSoUngTuyen(IdDoanhNghiep, IdUngVien, NgayUngTuyen, viTriUngTuyen);
        }

    }
}
