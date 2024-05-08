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
            openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                if (Path.GetExtension(selectedFilePath).ToLower() == ".pdf")
                {
                    llbFileName.Tag = selectedFilePath;
                    llbFileName.Text = Path.GetFileName(selectedFilePath);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn file định dạng PDF");
                }
            }
        }

        private void btnXNNopHS_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(llbFileName.Text) && cbVTUT.SelectedItem != null && txtTenDN != null && txtTenUV != null)
            {
                string viTriUngTuyen = cbVTUT.SelectedItem.ToString();
                MessageBox.Show(viTriUngTuyen);
                //try
                //{
                //    HoSoUngTuyenBUS.ThemHSUngTuyen(IdDoanhNghiep, IdUngVien, DateTime.Now.Date, viTriUngTuyen);
                //    MessageBox.Show("Nộp hồ sơ thành công");

                //    string userId = IdUngVien;
                //    string baseDirectory = @"DAO\DS_CV";
                //    string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

                //    string targetDirectory = Path.Combine(projectDirectory, baseDirectory, userId);
                //    if (!Directory.Exists(targetDirectory))
                //    {
                //        Directory.CreateDirectory(targetDirectory);
                //    }

                //    int fileCount = Directory.GetFiles(targetDirectory, "*", SearchOption.TopDirectoryOnly).Length;
                //    string newFilePath = Path.Combine(targetDirectory, $"CV{fileCount + 1}.pdf");
                //    File.Copy(llbFileName.Tag.ToString(), newFilePath);
                //    llbFileName.Text = Path.GetFileName(newFilePath);

                //    this.Close();
                //}
                //catch (Exception)
                //{
                //    MessageBox.Show("Bạn đã nộp hồ sơ này. Vui lòng ứng tuyển hồ sơ khác");
                //}
            }
            else
            {
                MessageBox.Show("Thông tin không được để trống!");
            }
        }
    }
}
