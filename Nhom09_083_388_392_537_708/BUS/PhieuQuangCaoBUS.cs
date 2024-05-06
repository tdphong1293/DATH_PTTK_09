using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class PhieuQuangCaoBUS
    {
        public static double TinhTongTien(PhieuQuangCaoDTO pqc, double UD)
        {
            int soNgay = 0;
            double TienTheoHinhThuc = 1.0;
            int TienTheoNgay = 200000;
            TimeSpan songay = pqc.NKT.Subtract(pqc.NBD);
            soNgay = (int)songay.TotalDays;
            if (pqc.HTDT.ToString() == "Báo giấy")
            {
                TienTheoHinhThuc = 1.3;
            }
            else if (pqc.HTDT.ToString() == "Banner quảng cáo")
            {
                TienTheoHinhThuc = 1.5;
            }
            else
            {
                TienTheoHinhThuc = 1.0;
            }
            double tongtien = TienTheoNgay * soNgay * TienTheoHinhThuc * (1 - UD);
            return Math.Round(tongtien, 2);
        }

        public static int ThemPQC(PhieuQuangCaoDTO pqc)
        {
            return PhieuQuangCaoDAO.ThemPQC(pqc);
        }
    }
}
