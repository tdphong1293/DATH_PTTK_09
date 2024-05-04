using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class HoSoUngTuyenBUS
    {
        public static DataTable LayKetQuaUngTuyen(string timkiem)
        {
            return HoSoUngTuyenDAO.LayKetQuaUngTuyen(timkiem);
        }
    }
}
