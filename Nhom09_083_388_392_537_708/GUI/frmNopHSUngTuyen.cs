using BUS;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using DTO;

namespace GUI
{
    public partial class frmNopHSUngTuyen : Form
    {
        public static SqlConnection con = frmDangNhap.conn;
        public string IdUngVien = "";
        public string IdDoanhNghiep = "";
        public string IdPDT = "";

        public frmNopHSUngTuyen(string idUser, string idpdt)
        {
            InitializeComponent();
            this.IdUngVien = idUser;
            this.IdPDT = idpdt;
            IdDoanhNghiep = Lay_IdDN_Tu_IDPDT(IdPDT);
        }

        private void NopHoSoUngTuyen_Load(object sender, EventArgs e)
        {
            LayThongTinUngVien(IdUngVien);
            LayThongTinDoanhNghiep(IdDoanhNghiep);
            LoadViTriDangTuyen();
        }
        
        private string Lay_IdDN_Tu_IDPDT(string idPDT)
        {
            return PhieuDangTuyenBUS.Lay_IdDN_Tu_IdPDT(idPDT);
        }

        private void LoadViTriDangTuyen()
        {
            try
            {
                DataTable dt = PhieuDangTuyenBUS.LayViTriDangTuyen(IdPDT);
                cbVTUT.DataSource = dt;
                cbVTUT.DisplayMember = "DanhSachViTriDangTuyen";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách vị trí đăng tuyển: " + ex.Message);
            }
        }

        private void LayThongTinUngVien(string idUngVien)
        {
            txtTenUV.Text = UngVienBUS.LayTTUngVien(idUngVien);
        }

        private void LayThongTinDoanhNghiep(string IdDoanhNghiep)
        {
            int id = int.Parse(IdDoanhNghiep);
            DoanhNghiep dn = DoanhNghiepBUS.LayThongTinDN(id);
            txtTenDN.Text = dn.Ten;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a file to upload";
            openFileDialog.Filter = "All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                llbFileName.Text = Path.GetFileName(selectedFilePath);
            }
        }

        private void btnXNNopHS_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(llbFileName.Text) && cbVTUT.SelectedItem != null)
            {
                string viTriUngTuyen = cbVTUT.SelectedItem.ToString();
                try
                {
                    HoSoUngTuyenBUS.ThemHSUngTuyen(IdDoanhNghiep, IdUngVien, DateTime.Now.Date, viTriUngTuyen);
                    MessageBox.Show("Nộp hồ sơ thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi nộp hồ sơ: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Thông tin không được để trống!");
            }
        }
    }
}
