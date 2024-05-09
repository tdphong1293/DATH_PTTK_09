using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class BangCapBUS
    {
        public static DataTable LayDSBangCapTheoUngVien(int idUngVien)
        {
            return BangCapDAO.DocDSBangCapTheoUngVien(idUngVien);
        }
        public static DataTable LayDSBangCapCuaUngVien(int idUngVien)
        {
            return BangCapDAO.DocDSBangCapCuaUngVien(idUngVien);
        }

        public static int ThemBangCap(BangCapDTO bangcap)
        {
            return BangCapDAO.ThemBangCap(bangcap);
        }    
    }
}
