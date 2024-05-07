using BUS;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmDoanhNghiepTiemNang : Form
    {
        public static SqlConnection con = frmDangNhap.conn;
        public frmDoanhNghiepTiemNang()
        {
            InitializeComponent();
            HienThi();
        }
        public void HienThi()
        {
            dgv_DoanhNghiepTN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_DoanhNghiepTN.DataSource = DoanhNghiepBUS.LayDSTTDoanhNghiepTiemNang();
        }
    }

}
