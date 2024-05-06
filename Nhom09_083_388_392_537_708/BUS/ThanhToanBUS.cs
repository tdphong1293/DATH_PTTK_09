using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class ThanhToanBUS
    {
        public static void ThemTT(string HTTT, double sotien, int dot, int IDHD)
        {
            ThanhToanDAO.ThemTT(HTTT, sotien, dot, IDHD);
        }
    }
}
