using BUS;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmXemPhieuDangTuyen : Form
    {
        public string UserRole = "";
        public string UserId = "";
        public string IdPDT = "";

        public frmXemPhieuDangTuyen(string id, string role)
        {
            InitializeComponent();
            this.UserId = id;
            this.UserRole = role;
        }

        private void XemPhieuDangTuyen_Load(object sender, EventArgs e)
        {
            if (UserRole == "DOANHNGHIEP")
            {
                btnNopHSUT.Visible = false;
                btnXoaPDT.Visible = false;
                LoadDataTheoDoanhNghiep();
                return;
            }
            if (UserRole == "UNGVIEN")
            {
                btnXoaPDT.Visible = false;
            }
            else
            {
                btnNopHSUT.Visible = false;
            }
            LoadDataToDGV();
        }

        private void LoadDataToDGV()
        {
            try
            {
                DataSet dataSet = PhieuDangTuyenBUS.GetDataSetFromStoredProcedure("LayDanhSachPhieuDangTuyen");
                dgv_DSDangTuyen.Columns.Clear();
                dgv_DSDangTuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_DSDangTuyen.DataSource = dataSet.Tables[0];
                dgv_DSDangTuyen.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading DataGridView: " + ex.Message);
            }
        }

        private void LoadDataTheoDoanhNghiep()
        {
            try
            {
                DataSet dataSet = PhieuDangTuyenBUS.GetDataSetFromStoredProcedure("LayDanhSachPhieuDangTuyenTheoDoanhNghiep",
                                                                new SqlParameter("@ID", UserId));
                dgv_DSDangTuyen.Columns.Clear();
                dgv_DSDangTuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_DSDangTuyen.DataSource = dataSet.Tables[0];
                dgv_DSDangTuyen.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading DataGridView: " + ex.Message);
            }
        }

        private void dgv_DSDangTuyen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow selectedRow = dgv_DSDangTuyen.Rows[e.RowIndex];

            object idPhieuDangTuyenObj = selectedRow.Cells["IDPhieuDangTuyen"].Value;
            if (idPhieuDangTuyenObj != DBNull.Value && idPhieuDangTuyenObj != null)
            {
                IdPDT = idPhieuDangTuyenObj.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng không chọn dòng trống");
                return;
            }

            string viTriDangTuyen = selectedRow.Cells["ViTriDangTuyen"].Value.ToString();
            string soLuongTuyenDung = selectedRow.Cells["SoLuongTuyenDung"].Value.ToString();

            txtVTDT.Text = viTriDangTuyen;
            txtSLTD.Text = soLuongTuyenDung;

            DataSet dataSet = PhieuDangTuyenBUS.LayYeuCauCongViec(IdPDT);
            DataTable dataTable = dataSet.Tables[0];

            if (dataTable.Rows.Count > 0)
            {
                txtMoTaYC.Text = dataTable.Rows[0]["MoTaYeuCau"].ToString();
            }
            else
            {
                MessageBox.Show("không có dữ liệu yêu cầu công việc cho phiếu đăng tuyển này này.");
                txtMoTaYC.Text = string.Empty;
            }
        }

        private void btnNopHSUT_Click(object sender, EventArgs e)
        {
            frmNopHSUngTuyen NopHSUT = new frmNopHSUngTuyen(UserId, IdPDT);
            NopHSUT.ShowDialog();
        }

        private void btnXoaPDT_Click(object sender, EventArgs e)
        {
            try
            {
                PhieuDangTuyenBUS.XoaPhieuDangTuyen(IdPDT);
                MessageBox.Show("Đã xóa phiếu đăng tuyển thành công.");
                LoadDataToDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string tenCty = txtTimTenCty.Text;
                string viTri = txtTimVTDT.Text;

                DataSet resultDataSet;
                if (UserRole == "DOANHNGHIEP")
                {
                    resultDataSet = PhieuDangTuyenBUS.GetDataSetFromStoredProcedure("TimKiemPhieuDangTuyen",
                        new SqlParameter("@Ten", tenCty),
                        new SqlParameter("@ViTri", viTri),
                        new SqlParameter("@ID", UserId));
                }
                else
                {
                    resultDataSet = PhieuDangTuyenBUS.GetDataSetFromStoredProcedure("TimKiemPhieuDangTuyen",
                        new SqlParameter("@Ten", tenCty),
                        new SqlParameter("@ViTri", viTri));
                }
                dgv_DSDangTuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_DSDangTuyen.DataSource = resultDataSet.Tables[0];
                dgv_DSDangTuyen.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm: " + ex.Message);
            }
        }
    }
}
