using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
namespace BUS
{
    public class BangCapBUS
    {
        public static DataTable LayDSBangCapTheoUngVien(int idUngVien)
        {
            return BangCapDAO.DocDSBangCapTheoUngVien(idUngVien);
        }
    }
}
