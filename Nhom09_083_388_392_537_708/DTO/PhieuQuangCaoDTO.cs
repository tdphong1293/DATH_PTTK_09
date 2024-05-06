using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuQuangCaoDTO
    {
        public PhieuQuangCaoDTO(DateTime nbd, DateTime nkt, string htdt, double ttqc) { 
            this.NBD = nbd;
            this.NKT = nkt;
            this.HTDT = htdt;
            this.TongTienQC = ttqc;
        }
        public DateTime NBD { get; set; }
        public DateTime NKT { get; set; }
        public string HTDT { get; set; }
        public double TongTienQC { get; set; }
    }
}
