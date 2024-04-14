using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Nhom09_083_388_392_537_708
{
    public partial class XULYHOSOUNGTUYEN : Form
    {
        FormDangNhap dangNhap = new FormDangNhap();
        public static SqlConnection curConn = FormDangNhap.conn;
        public static System.Timers.Timer NhaTD1_Timer, NhaTD2_Timer;
        public static string lastSearch_NhaTD1, lastSearch_NhaTD2;

        public XULYHOSOUNGTUYEN()
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
            string query = string.IsNullOrEmpty(searchText) ? $"select tv_uv.Ten as N'Ứng viên', tv_dn.Ten as N'Doanh nghiệp', hsut.NgayUngTuyen, hsut.ViTriUngTuyen, hsut.TinhTrangUngTuyen " +
                $"from HOSOUNGTUYEN hsut, THANHVIEN tv_uv, THANHVIEN tv_dn, UNGVIEN uv, DOANHNGHIEP dn " +
                $"where hsut.IDDoanhNghiep = dn.IDDoanhNghiep " +
                        $"and hsut.IDUngVien = uv.IDUngVien " +
                        $"and dn.IDDoanhNghiep = tv_dn.IDThanhVien " +
                        $"and uv.IDUngVien = tv_uv.IDThanhVien " +
                        $"and (hsut.TinhTrangUngTuyen = N'Chưa đủ điều kiện' or hsut.TinhTrangUngTuyen is Null)" :
                $"select tv_uv.Ten as N'Ứng viên', tv_dn.Ten as N'Doanh nghiệp', hsut.NgayUngTuyen, hsut.ViTriUngTuyen, hsut.TinhTrangUngTuyen " +
                $"from HOSOUNGTUYEN hsut, THANHVIEN tv_uv, THANHVIEN tv_dn, UNGVIEN uv, DOANHNGHIEP dn " +
                $"where hsut.IDDoanhNghiep = dn.IDDoanhNghiep " +
                        $"and hsut.IDUngVien = uv.IDUngVien " +
                        $"and dn.IDDoanhNghiep = tv_dn.IDThanhVien " +
                        $"and uv.IDUngVien = tv_uv.IDThanhVien " +
                        $"and (hsut.TinhTrangUngTuyen = N'Chưa đủ điều kiện' or hsut.TinhTrangUngTuyen is Null) " +
                        $"and UPPER(tv_dn.Ten) LIKE UPPER('%{searchText}%')";
            ReloadDataIntoDTGV(query, dtgv_HSChoDuyet);
        }

        public void SearchAndReloadHSUT_DaDuyet(string searchText)
        {
            string query = string.IsNullOrEmpty(searchText) ? $"select tv_uv.Ten as N'Ứng viên', tv_dn.Ten as N'Doanh nghiệp', hsut.NgayUngTuyen, hsut.ViTriUngTuyen, hsut.TinhTrangUngTuyen " +
                $"from HOSOUNGTUYEN hsut, THANHVIEN tv_uv, THANHVIEN tv_dn, UNGVIEN uv, DOANHNGHIEP dn " +
                $"where hsut.IDDoanhNghiep = dn.IDDoanhNghiep " +
                        $"and hsut.IDUngVien = uv.IDUngVien " +
                        $"and dn.IDDoanhNghiep = tv_dn.IDThanhVien " +
                        $"and uv.IDUngVien = tv_uv.IDThanhVien " +
                        $"and (hsut.TinhTrangUngTuyen = N'Đủ điều kiện' or hsut.TinhTrangUngTuyen = N'Đang xử lý')" :
                $"select tv_uv.Ten as N'Ứng viên', tv_dn.Ten as N'Doanh nghiệp', hsut.NgayUngTuyen, hsut.ViTriUngTuyen, hsut.TinhTrangUngTuyen " +
                $"from HOSOUNGTUYEN hsut, THANHVIEN tv_uv, THANHVIEN tv_dn, UNGVIEN uv, DOANHNGHIEP dn " +
                $"where hsut.IDDoanhNghiep = dn.IDDoanhNghiep " +
                        $"and hsut.IDUngVien = uv.IDUngVien " +
                        $"and dn.IDDoanhNghiep = tv_dn.IDThanhVien " +
                        $"and uv.IDUngVien = tv_uv.IDThanhVien " +
                        $"and (hsut.TinhTrangUngTuyen = N'Đủ điều kiện' or hsut.TinhTrangUngTuyen = N'Đang xử lý') " +
                        $"and UPPER(tv_dn.Ten) LIKE UPPER('%{searchText}%')";
            ReloadDataIntoDTGV(query, dtgv_HSDaDuyet);
        }

        private void ReloadDataIntoDTGV(string query, DataGridView dtgv)
        {
            using (SqlCommand command = new SqlCommand(query, curConn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable resultTable = new DataTable();
                    resultTable.Load(reader);
                    dtgv.DataSource = resultTable;
                }
            }
        }

        private void btn_Duyet_Click(object sender, EventArgs e)
        {
            // Text account
        }

        private void btn_ThemBangCap_Click(object sender, EventArgs e)
        {
            THEMBANGCAP tHEMBANGCAP = new THEMBANGCAP();
            tHEMBANGCAP.Show();
        }

        

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            
        }

        

        private void dtgv_HSChoDuyet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataAfterCellClick(sender, e, dtgv_HSChoDuyet);
        }

        private void dtgv_HSDaDuyet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataAfterCellClick(sender, e, dtgv_HSDaDuyet);
        }

        private void LoadDataAfterCellClick(object sender, DataGridViewCellEventArgs e, DataGridView dtgv) 
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

                string query_email_ngaysinh = $"select tv.Email, uv.NgaySinh " +
                    $"from THANHVIEN tv, UNGVIEN uv " +
                    $"where tv.IDThanhVien = uv.IDUngVien and UPPER(tv.Ten) = UPPER('{tb_HoTen.Text}')";
                
                //dangNhap.conServer();
                using (SqlCommand command = new SqlCommand(query_email_ngaysinh, curConn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tb_Email.Text = reader["Email"].ToString();
                            int space = reader["NgaySinh"].ToString().IndexOf(' ');
                            tb_NgaySinh.Text = reader["NgaySinh"].ToString().Substring(0, space);
                        }
                    }
                }

                string query_TimKiemBangCap = $"select bc.TenBang as N'Tên bằng', bc.CapBac as N'Cấp bậc', bc.NgayCap as N'Ngày cấp', bc.DonViCap as N'Đơn vị cấp' " +
                    $"from THANHVIEN tv, BANGCAP bc " +
                    $"where UPPER(tv.Ten) = UPPER('{tb_HoTen.Text}') and bc.IDUngVien = tv.IDThanhVien ";

                ReloadDataIntoDTGV(query_TimKiemBangCap, dtgv_BangCap);


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
