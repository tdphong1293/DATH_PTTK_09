using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GUI
{
    public partial class frmDoanhNghiepTiemNang : Form
    {
        public static SqlConnection con = frmDangNhap.conn;
        public frmDoanhNghiepTiemNang()
        {
            InitializeComponent();
            dgv_DoanhNghiepTN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_DoanhNghiepTN.DataSource = LoadData_DNTN().Tables[0];
        }
        DataSet LoadData_DNTN()
        {
            string query = $"select tv.ten as TenDoanhNghiep, tv.email as Email, dn.* from DOANHNGHIEP dn, THANHVIEN tv where dn.iddoanhnghiep = tv.idthanhvien and dn.uudai <> 0";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dntn = new DataSet();
            adapter.Fill(dntn);
            return dntn;
        }
    }

}
