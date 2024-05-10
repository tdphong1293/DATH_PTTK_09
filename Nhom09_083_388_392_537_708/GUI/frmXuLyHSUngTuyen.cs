using BUS;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Timers;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmXuLyHSUngTuyen : Form
    {
        public static SqlConnection curConn = frmDangNhap.conn;
        private int IDUngVien, IDDoanhNghiep;
        public static System.Timers.Timer NhaTD1_Timer, NhaTD2_Timer;
        public static string lastSearch_NhaTD1, lastSearch_NhaTD2;

        public frmXuLyHSUngTuyen()
        {
            InitializeComponent();
            NhaTD1_Timer = new System.Timers.Timer();
            NhaTD1_Timer.Interval = 500; // Set the delay time (500 milliseconds in this case)
            NhaTD1_Timer.Elapsed += OnTimedEvent1;

            NhaTD2_Timer = new System.Timers.Timer();
            NhaTD2_Timer.Interval = 500; // Set the delay time (500 milliseconds in this case)
            NhaTD2_Timer.Elapsed += OnTimedEvent2;

            SearchAndReloadHSUT_ChoDuyet("");
            SearchAndReloadHSUT_DaDuyet("");

            dtgv_HSChoDuyet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgv_HSDaDuyet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgv_BangCap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void tb_SearchDN1_TextChanged(object sender, EventArgs e)
        {
            NhaTD1_Timer.Stop();
            NhaTD1_Timer.Start();
        }

        private void tb_SearchDN2_TextChanged(object sender, EventArgs e)
        {
            NhaTD2_Timer.Stop();
            NhaTD2_Timer.Start();
        }

        private void OnTimedEvent1(Object source, ElapsedEventArgs e)
        {
            NhaTD1_Timer.Stop();
            if (lastSearch_NhaTD1 != tb_SearchDN1.Text)
            {
                lastSearch_NhaTD1 = tb_SearchDN1.Text;
                this.Invoke(new Action(() => SearchAndReloadHSUT_ChoDuyet(lastSearch_NhaTD1)));
            }
        }

        private void OnTimedEvent2(Object source, ElapsedEventArgs e)
        {
            NhaTD2_Timer.Stop();
            if (lastSearch_NhaTD2 != tb_SearchDN2.Text)
            {
                lastSearch_NhaTD2 = tb_SearchDN2.Text;
                this.Invoke(new Action(() => SearchAndReloadHSUT_DaDuyet(lastSearch_NhaTD2)));
            }
        }

        public void SearchAndReloadHSUT_ChoDuyet(string searchText)
        {
            dtgv_HSChoDuyet.DataSource = HoSoUngTuyenBUS.LayDSHSUTChoDuyet(searchText);
        }

        public void SearchAndReloadHSUT_DaDuyet(string searchText)
        {
            dtgv_HSDaDuyet.DataSource = HoSoUngTuyenBUS.LayDSHSUTDaDuyet(searchText);
        }

        private void btn_Duyet_Click(object sender, EventArgs e)
        {
            HoSoUngTuyenBUS.DuyetHSUTChoDuyet(IDDoanhNghiep, IDUngVien, Convert.ToInt32(tb_DiemDanhGia.Text), "succeed");
            SearchAndReloadHSUT_ChoDuyet("");
            SearchAndReloadHSUT_DaDuyet("");
            enabledButton(false);
        }

        private void btn_Loai_Click(object sender, EventArgs e)
        {
            HoSoUngTuyenBUS.DuyetHSUTChoDuyet(IDDoanhNghiep, IDUngVien, Convert.ToInt32(tb_DiemDanhGia.Text), "fail");
            SearchAndReloadHSUT_ChoDuyet("");
            SearchAndReloadHSUT_DaDuyet("");
            enabledButton(false);
        }

        private void btn_ThemBangCap_Click(object sender, EventArgs e)
        {
            frmThemBangCap tHEMBANGCAP = new frmThemBangCap(IDUngVien, this);
            tHEMBANGCAP.Show();
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            
        }

        public void SearchAndReloadBangCap(int IDUngVien)
        {
            dtgv_BangCap.DataSource = BangCapBUS.LayDSBangCapCuaUngVien(this.IDUngVien);
        }


        private void dtgv_HSChoDuyet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadHSUTAfterCellClick(sender, e, dtgv_HSChoDuyet);
        }

        private void btn_OpenFileCV_Click(object sender, EventArgs e)
        {
            string baseDirectory = @"DAO\DS_CV";
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string subDirectory = IDUngVien.ToString();
            string targetDirectory = Path.Combine(projectDirectory, baseDirectory, subDirectory);

            if (Directory.Exists(targetDirectory))
            {
                System.Diagnostics.Process.Start(targetDirectory);
            }
            else
            {
                MessageBox.Show("Directory does not exist!");
            }
        }

        private void dtgv_HSDaDuyet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadHSUTAfterCellClick(sender, e, dtgv_HSDaDuyet);
        }

        private void LoadHSUTAfterCellClick(object sender, DataGridViewCellEventArgs e, DataGridView dtgv) 
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtgv.Rows.Count)
            {

                DataGridViewRow row = dtgv.Rows[e.RowIndex];
                int viTriKhoangTrang = row.Cells["NgayUngTuyen"].Value.ToString().IndexOf(' ');
                tb_HoTen.Text = row.Cells["Ứng viên"].Value.ToString() ?? string.Empty;
                tb_DoanhNghiepUngTuyen.Text = row.Cells["Doanh nghiệp"].Value.ToString() ?? string.Empty;
                tb_TinhTrangUngTuyen.Text = row.Cells["TinhTrangUngTuyen"].Value.ToString() ?? string.Empty;
                tb_NgayUngTuyen.Text = row.Cells["NgayUngTuyen"].Value.ToString().Substring(0, viTriKhoangTrang) ?? string.Empty;
                tb_ViTriUngTuyen.Text = row.Cells["ViTriUngTuyen"].Value.ToString() ?? string.Empty;
                tb_DiemDanhGia.Text = row.Cells["DiemDanhGia"].Value.ToString() ?? string.Empty;

                this.IDUngVien = Convert.ToInt32(row.Cells["IDUngVien"].Value);
                this.IDDoanhNghiep = Convert.ToInt32(row.Cells["IDDoanhNghiep"].Value);
                DataTable dataUngVien = UngVienBUS.LayEmailNgSinh_UV(this.IDUngVien);
                DataRow rows = dataUngVien.Rows[0];
                tb_Email.Text = rows["Email"].ToString();
                int space = rows["NgaySinh"].ToString().IndexOf(' ');
                tb_NgaySinh.Text = rows["NgaySinh"].ToString().Substring(0, space);
                dtgv_BangCap.DataSource = BangCapBUS.LayDSBangCapCuaUngVien(this.IDUngVien);


                if (tb_TinhTrangUngTuyen.Text == "Đủ điều kiện")
                {
                    tb_TinhTrangUngTuyen.BackColor = Color.PaleGreen;
                    enabledButton(false);
                }
                else if (tb_TinhTrangUngTuyen.Text == "Chưa đủ điều kiện")
                {
                    tb_TinhTrangUngTuyen.BackColor = Color.LightSalmon;
                    enabledButton(false);
                }
                else if (tb_TinhTrangUngTuyen.Text == "")
                {
                    tb_TinhTrangUngTuyen.BackColor = Color.LightGray;
                    enabledButton(true);
                }
                else if (tb_TinhTrangUngTuyen.Text == "Đang xử lý")
                {
                    tb_TinhTrangUngTuyen.BackColor = Color.Yellow;
                    enabledButton(false);
                }
            }
        }

        private void enabledButton(bool flag)
        {
            btn_OpenFileCV.Enabled = flag;
            btn_ThemBangCap.Enabled = flag;
            btn_Duyet.Enabled = flag;
            btn_Loai.Enabled = flag;
            tb_DiemDanhGia.Enabled = flag;
        }
    }
}
