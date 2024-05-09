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
                LoadPDT_DN();
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
            LoadDS_PDT();
        }

        private void LoadDS_PDT()
        {
            try
            {
                DataSet dataSet = PhieuDangTuyenBUS.LayDSPhieuDangTuyen();
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

        private void LoadPDT_DN()
        {
            try
            {
                string idDoanhNghiep = this.UserId;
                DataSet dataSet = PhieuDangTuyenBUS.LayPDTTheoDoanhNghiep(idDoanhNghiep);
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
            if (e.RowIndex >= 0 && e.RowIndex < this.dgv_DSDangTuyen.Rows.Count)
            {
                DataGridViewRow selectedRow = dgv_DSDangTuyen.Rows[e.RowIndex];
                
                this.IdPDT = selectedRow.Cells["IDPhieuDangTuyen"].Value.ToString();
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
                    MessageBox.Show("Không có dữ liệu yêu cầu công việc cho phiếu đăng tuyển này này");
                    txtMoTaYC.Text = string.Empty;
                }
            }
        }

        private void btnNopHSUT_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UserId) && !string.IsNullOrEmpty(IdPDT))
            {
                frmNopHSUngTuyen NopHSUT = new frmNopHSUngTuyen(UserId, IdPDT);
                NopHSUT.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn vào phiếu đăng tuyển để nộp hồ sơ");
            }
        }

        private void btnXoaPDT_Click(object sender, EventArgs e)
        {
            try
            {
                PhieuDangTuyenBUS.XoaPhieuDangTuyen(IdPDT);
                MessageBox.Show("Đã xóa phiếu đăng tuyển thành công.");
                LoadDS_PDT();
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
                string idDN = UserRole == "DOANHNGHIEP" ? UserId : null;

                DataSet resultDataSet = PhieuDangTuyenBUS.SearchPhieuDangTuyen(tenCty, viTri, idDN);

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
