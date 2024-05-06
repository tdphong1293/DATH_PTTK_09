using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class YeuCauCVBUS
    {
        public static void ThemYC(string mota, int IDPDT)
        {
            YeuCauCVDAO.ThemYC(mota, IDPDT);
        }
    }
}
