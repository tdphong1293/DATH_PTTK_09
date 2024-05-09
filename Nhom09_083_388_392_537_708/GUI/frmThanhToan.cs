using System.Windows.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Timers;
using BUS;
using DTO;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class frmThanhToan : Form
    {
        public static SqlConnection curConn = frmDangNhap.conn;
        private int IDUngVien, IDDoanhNghiep, IDPhieuQC;
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


            cb_PhieuDangTuyen.Items.Clear();

            this.IDDoanhNghiep = ThanhToanBUS.TimIDDoanhNghiep(NhaTD);
            List<int> PDT_list = new List<int>();
            PDT_list = ThanhToanBUS.LayDSIDPDT(this.IDDoanhNghiep);
            foreach (int item in PDT_list)
            {
                cb_PhieuDangTuyen.Items.Add(item.ToString());
            }

            cb_PhieuDangTuyen.SelectedIndexChanged += new EventHandler(cb_PhieuDangTuyen_SelectedIndexChanged);
        }

        private void cb_PhieuDangTuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataPDT = ThanhToanBUS.LayTTPhieuDangTuyen(Convert.ToInt32(cb_PhieuDangTuyen.SelectedItem.ToString()));
            DataRow row1 = dataPDT.Rows[0];
            tb_ViTriTD.Text = row1["ViTriDangTuyen"].ToString();
            tb_SoLuongTD.Text = row1["SoLuongTuyenDung"].ToString();
            this.IDPhieuQC = Convert.ToInt32(row1["IDPhieuQuangCao"].ToString());

            DataTable dataPQC = ThanhToanBUS.LayTTPhieuQuangCao(this.IDPhieuQC);
            DataRow row2 = dataPQC.Rows[0];
            tb_HinhThucDangTuyen.Text = row2["HinhThucDangTuyen"].ToString(); 
            tb_NgayBD.Text = row2["NgayBatDau"].ToString().Substring(0, row2["NgayBatDau"].ToString().IndexOf(' '));
            tb_NgayKT.Text = row2["NgayKetThuc"].ToString().Substring(0, row2["NgayKetThuc"].ToString().IndexOf(' '));

            DateTime ngayBatDau = DateTime.Parse(tb_NgayBD.Text);
            DateTime ngayKetThuc = DateTime.Parse(tb_NgayKT.Text);
            TimeSpan khoangCach = ngayKetThuc - ngayBatDau;
            tb_TongNgayDT.Text = ((int)khoangCach.TotalDays).ToString();


        }


    }
}
