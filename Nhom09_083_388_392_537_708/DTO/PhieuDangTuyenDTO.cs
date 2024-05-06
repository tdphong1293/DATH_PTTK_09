using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuDangTuyenDTO
    {
        public PhieuDangTuyenDTO(string vtdt, int sltd, int iddn) { 
            this.VTDT = vtdt;
            this.SLTD = sltd;
            this.IDDN = iddn;
        }
        public string VTDT { get; set; }
        public int SLTD { get; set; }
        public int IDDN { get; set; }
    }
}
