using DAO;
using System;
using System.Data;

namespace BUS
{
    public class HoSoUngTuyenBUS
    {
        public int IDDoanhNghiep { get; set; }
        public int IDUngVien { get; set; }
        public string NgayUngTuyen { get; set; }
        public string ViTriUngTuyen { get; set; }
        public int DiemDanhGia { get; set; }

        public static DataTable LayKetQuaUngTuyen(string timkiem)
        {
            return HoSoUngTuyenDAO.LayKetQuaUngTuyen(timkiem);
        }

        public static void ThemHSUngTuyen(string IdDoanhNghiep, string IdUngVien, DateTime NgayUngTuyen, string viTriUngTuyen)
        {
            HoSoUngTuyenDAO.ThemHoSoUngTuyen(IdDoanhNghiep, IdUngVien, NgayUngTuyen, viTriUngTuyen);
        }
        public static DataTable LayDSHSSUngTuyenTheoDoanhNghiep(int idDoanhNghiep)
        {
            return HoSoUngTuyenDAO.DocDSHSSUngTuyenTheoDoanhNghiep(idDoanhNghiep);
        }
        public static DataTable LayDSHoSoUT_SapXep_DiemDanhGia(int idDoanhNghiep)
        {
            return HoSoUngTuyenDAO.DocDSHoSoUT_SapXep_DiemDanhGia(idDoanhNghiep);
        }
        public static int CapNhat_TinhTrangUngTuyen(string dieuKien, int idDoanhNghiep, int idUngVien)
        {
            return HoSoUngTuyenDAO.CapNhat_TinhTrangUngTuyenDB(dieuKien, idDoanhNghiep, idUngVien);
        }
    }
}
