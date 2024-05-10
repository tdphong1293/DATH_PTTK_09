using System.Windows.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Timers;
using BUS;
using DTO;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;

namespace GUI
{
    public partial class frmThanhToan : Form
    {
        public static SqlConnection curConn = frmDangNhap.conn;
        private int IDUngVien, IDDoanhNghiep, IDPhieuDT, IDPhieuQC, IDHoaDon, IDThanhToan;
        public static System.Timers.Timer NhaTD_Timer;


        public frmThanhToan()
        {
            InitializeComponent();

            NhaTD_Timer = new System.Timers.Timer();
            NhaTD_Timer.Interval = 500; // Set the delay time (500 milliseconds in this case)
            NhaTD_Timer.Elapsed += searchPDT_Event;

        }

        private void tb_TenNhaTuyenDung_TextChanged(object sender, EventArgs e)
        {
            NhaTD_Timer.Stop();
            NhaTD_Timer.Start();
        }

        private void searchPDT_Event(Object source, ElapsedEventArgs e)
        {
            NhaTD_Timer.Stop();
            this.Invoke(new Action(() => LoadPDTIntoCB(tb_TenNhaTuyenDung.Text)));
        }

        private void LoadPDTIntoCB(string NhaTD)
        {
            tb_ViTriTD.Text = "";
            tb_SoLuongTD.Text = "";
            tb_HinhThucDangTuyen.Text = "";
            tb_NgayBD.Text = "";
            tb_NgayKT.Text = "";
            tb_TongNgayDT.Text = "";
            tb_TrangThaiThanhToan.Text = "";
            tb_TrangThaiThanhToan.BackColor = Color.WhiteSmoke;
            tb_LoaiHinhThanhToan.Text = "";
            tb_HinhThucThanhToan.Text = "";
            tb_TongTienCanThanhToan.Text = "";
            tb_TienDaTra.Text = "";
            tb_TienCanThanhToan.Text = "";
            tb_NgayGiaoDich.Text = "";


            cb_PhieuDangTuyen.Items.Clear();
            cb_Dot.Items.Clear();
            btn_ThanhToan.Enabled = false;

            this.IDDoanhNghiep = DoanhNghiepBUS.TimIDDoanhNghiep(NhaTD);
            List<int> PDT_list = new List<int>();
            PDT_list = PhieuDangTuyenBUS.LayDSIDPDT(this.IDDoanhNghiep);
            foreach (int item in PDT_list)
            {
                cb_PhieuDangTuyen.Items.Add(item.ToString());
            }

            cb_PhieuDangTuyen.SelectedIndexChanged += new EventHandler(cb_PhieuDangTuyen_SelectedIndexChanged);
        }

        private void cb_PhieuDangTuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataPDT = PhieuDangTuyenBUS.LayTTPhieuDangTuyen(Convert.ToInt32(cb_PhieuDangTuyen.SelectedItem.ToString()));
            DataRow row1 = dataPDT.Rows[0];
            tb_ViTriTD.Text = row1["ViTriDangTuyen"].ToString() ?? string.Empty;
            tb_SoLuongTD.Text = row1["SoLuongTuyenDung"].ToString() ?? string.Empty;
            this.IDPhieuDT = Convert.ToInt32(row1["IDPhieuDangTuyen"].ToString());
            this.IDPhieuQC = Convert.ToInt32(row1["IDPhieuQuangCao"].ToString());

            DataTable dataPQC = PhieuQuangCaoBUS.LayTTPhieuQuangCao(this.IDPhieuQC);
            DataRow row2 = dataPQC.Rows[0];
            tb_HinhThucDangTuyen.Text = row2["HinhThucDangTuyen"].ToString(); 
            tb_NgayBD.Text = row2["NgayBatDau"].ToString().Substring(0, row2["NgayBatDau"].ToString().IndexOf(' ')) ?? string.Empty;
            tb_NgayKT.Text = row2["NgayKetThuc"].ToString().Substring(0, row2["NgayKetThuc"].ToString().IndexOf(' ')) ?? string.Empty;

            DateTime ngayBatDau = DateTime.Parse(tb_NgayBD.Text);
            DateTime ngayKetThuc = DateTime.Parse(tb_NgayKT.Text);
            TimeSpan khoangCach = ngayKetThuc - ngayBatDau;
            tb_TongNgayDT.Text = ((int)khoangCach.TotalDays).ToString() ?? string.Empty;

            DataTable dataHD = HoaDonBUS.LayTTHoaDon(this.IDPhieuDT);
            DataRow row3 = dataHD.Rows[0];
            this.IDHoaDon = Convert.ToInt32(row3["IDHoaDon"].ToString());
            tb_TrangThaiThanhToan.Text = row3["TrangThaiHoanThanh"].ToString() ?? string.Empty;
            tb_LoaiHinhThanhToan.Text = row3["LoaiHinhThanhToan"].ToString() ?? string.Empty;
            tb_TongTienCanThanhToan.Text = row3["TongTien"].ToString() ?? string.Empty;
            tb_TienDaTra.Text = row3["DaTra"].ToString();
            if (tb_TrangThaiThanhToan.Text == "Chưa hoàn thành")
                tb_TrangThaiThanhToan.BackColor = Color.LightSalmon;
            else
                tb_TrangThaiThanhToan.BackColor = Color.PaleGreen;

            btn_ThanhToan.Enabled = false;
            tb_NgayGiaoDich.Text = "";
            tb_TienCanThanhToan.Text = "";
            LoadDotIntoCB(this.IDHoaDon);
        }

        private void LoadDotIntoCB(int IDHoaDon)
        {
            cb_Dot.Items.Clear();
            List<int> Dot_list = new List<int>();
            Dot_list = ThanhToanBUS.LayDSDotThanhToan(IDHoaDon);
            foreach (int item in Dot_list)
            {
                cb_Dot.Items.Add(item.ToString());
            }

            cb_Dot.SelectedIndexChanged += new EventHandler(cb_Dot_SelectedIndexChanged);
        }

        private void cb_Dot_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataPDT = ThanhToanBUS.LayTTThanhToan(this.IDHoaDon, Convert.ToInt32(cb_Dot.SelectedItem.ToString()));
            DataRow row1 = dataPDT.Rows[0];
            tb_NgayGiaoDich.Text = row1["NgayGiaoDich"].ToString() ?? string.Empty;
            tb_TienCanThanhToan.Text = row1["SoTienCanThanhToan"].ToString() ?? string.Empty;
            tb_HinhThucThanhToan.Text = row1["H inhThucTT"].ToString() ?? string.Empty;
            this.IDThanhToan = Convert.ToInt32(row1["IDThanhToan"].ToString());

            bool flag = ThanhToanBUS.KiemTraThanhToan(this.IDHoaDon, Convert.ToInt32(cb_Dot.SelectedItem.ToString()));
            btn_ThanhToan.Enabled = flag;

        }

        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            ThanhToanBUS.THANHTOAN(this.IDHoaDon, Convert.ToInt32(cb_Dot.SelectedItem.ToString()));
            MessageBox.Show("Thanh toán thành công");
            
            DataTable dataPDT = ThanhToanBUS.LayTTThanhToan(this.IDHoaDon, Convert.ToInt32(cb_Dot.SelectedItem.ToString()));
            DataRow row1 = dataPDT.Rows[0];
            tb_NgayGiaoDich.Text = row1["NgayGiaoDich"].ToString() ?? string.Empty;

            DataTable dataHD = HoaDonBUS.LayTTHoaDon(this.IDPhieuDT);
            DataRow row3 = dataHD.Rows[0];
            tb_TienDaTra.Text = row3["DaTra"].ToString();
            tb_TrangThaiThanhToan.Text = row3["TrangThaiHoanThanh"].ToString() ?? string.Empty;
            if (tb_TrangThaiThanhToan.Text == "Chưa hoàn thành")
                tb_TrangThaiThanhToan.BackColor = Color.LightSalmon;
            else
                tb_TrangThaiThanhToan.BackColor = Color.PaleGreen;
            bool flag = ThanhToanBUS.KiemTraThanhToan(this.IDHoaDon, Convert.ToInt32(cb_Dot.SelectedItem.ToString()));
            btn_ThanhToan.Enabled = flag;
        }
    }
}
