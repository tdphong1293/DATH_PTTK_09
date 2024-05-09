using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BangCapDTO
    {
        public BangCapDTO(string TenBang, string CapBac, DateTime NgayCap, string DonViCap, int IDUngVien)
        {
            this.TenBang = TenBang;
            this.CapBac = CapBac;
            this.Ngaycap = NgayCap;
            this.DonViCap = DonViCap;
            this.IDUngVien = IDUngVien;
        }

        public string TenBang { get; set; }
        public string CapBac { get; set;}
        public DateTime Ngaycap { get; set; }
        public string DonViCap { get; set; }
        public int IDUngVien { get; set; }
    }
}
