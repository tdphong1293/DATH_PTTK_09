using BUS;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmDuyetHSUngTuyen : Form
    {
        public static SqlConnection con = frmDangNhap.conn;
        private string id;
        private int idUngVien;
        private int idDoanhNghiep;
        public frmDuyetHSUngTuyen(int idDoanhNghiep)
        {
            InitializeComponent();
            this.idDoanhNghiep = idDoanhNghiep;
            HienThi(idDoanhNghiep);
        }
        public void HienThi(int idDoanhNghiep)
        {
            // Gọi phương thức DocDSHSSUngTuyenTheoDoanhNghiep để lấy DataTable chứa dữ liệu
            DataTable dataTable = HoSoUngTuyenBUS.LayDSHSSUngTuyenTheoDoanhNghiep(idDoanhNghiep); // Giả sử idDoanhNghiep đã được xác định trước

            // Gán DataTable vào DataGridView
            dgv_hosoungtuyen.DataSource = dataTable;
        }
        private void btn_OpenFileCV_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a file to upload";
            openFileDialog.Filter = "All files (.)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                //llbFileName.Text = Path.GetFileName(selectedFilePath);
                string uploadFolderPath = Path.Combine(Application.StartupPath, "Upload");
                if (!Directory.Exists(uploadFolderPath))
                {
                    Directory.CreateDirectory(uploadFolderPath);
                }
                //string destinationFilePath = Path.Combine(uploadFolderPath, llbFileName.Text);
                //File.Copy(selectedFilePath, destinationFilePath, true);
            }
        }
        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string name = tb_tenuv.Text.ToString();
            dgv_hosoungtuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_hosoungtuyen.DataSource = HoSoUngTuyenBUS.LayHoSoUT_TheoTenUV(this.idDoanhNghiep, name);
        }
        private void dgv_hosoungtuyen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < this.dgv_hosoungtuyen.Rows.Count) // Make sure user select at least 1 row 
            {
                DataGridViewRow row = this.dgv_hosoungtuyen.Rows[e.RowIndex];
                this.idUngVien = Convert.ToInt32(row.Cells["IDUngVien"].Value);
                DataTable dataTable = UngVienBUS.LayTTUngVienDHSUT(this.idUngVien);
                if (dataTable.Rows.Count > 0)
                {
                    DataRow rows = dataTable.Rows[0];

                    tb_HoTen.Text = rows["ten"].ToString();
                    tb_Email.Text = rows["email"].ToString();

                    DateTime ngaySinh;
                    if (DateTime.TryParse(rows["ngaysinh"].ToString(), out ngaySinh))
                    {
                        tb_NgaySinh.Text = ngaySinh.ToString("dd/MM/yyyy");
                    }
                    else
                        tb_NgaySinh.Text = "Không có thông tin";
                }
                tb_TinhTrangHoSo.Text = row.Cells["TinhTrangUngTuyen"].Value.ToString();
                if (tb_TinhTrangHoSo.Text == "Đủ điều kiện")
                {
                    tb_TinhTrangHoSo.BackColor = Color.YellowGreen;
                }
                else if (tb_TinhTrangHoSo.Text == "Chưa đủ điều kiện")
                {
                    tb_TinhTrangHoSo.BackColor = Color.LightCoral;
                }
                else
                {
                    tb_TinhTrangHoSo.BackColor = Color.White;
                }
                DateTime date_ut = DateTime.Parse(row.Cells["NgayUngTuyen"].Value.ToString());
                ////MessageBox.Show(date_ut.ToString("dd/MM/yyyy"));
                tb_NgayUngTuyen.Text = date_ut.ToString("dd/MM/yyyy");
                tb_ViTriUngTuyen.Text = row.Cells["ViTriUngTuyen"].Value.ToString();
                tb_DiemDanhGia.Text = row.Cells["DiemDanhGia"].Value.ToString();

                dgv_BangCap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_BangCap.DataSource = BangCapBUS.LayDSBangCapTheoUngVien(this.idUngVien);
            }
        }

        private void btn_Duyet_Click(object sender, EventArgs e)
        {
            string dieuKien = "Đủ điều kiện";
            int result = HoSoUngTuyenBUS.CapNhat_TinhTrangUngTuyen(dieuKien, this.idDoanhNghiep, this.idUngVien);
            if (result == 1)
            {
                // Hiển thị thông báo và cập nhật trạng thái
                ThongBao("Đã duyệt thành công!");
                tb_TinhTrangHoSo.Text = "Đủ điều kiện";
                tb_TinhTrangHoSo.BackColor = Color.YellowGreen;

                // Cập nhật DataGridView
                dgv_hosoungtuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgv_hosoungtuyen.DataSource = HoSoUngTuyenBUS.LayDSHSSUngTuyenTheoDoanhNghiep(idDoanhNghiep);

                dgv_BangCap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_BangCap.DataSource = BangCapBUS.LayDSBangCapTheoUngVien(this.idUngVien);
            }
            else
            {
                // Hiển thị thông báo lỗi nếu cập nhật không thành công
                ThongBao("Có lỗi xảy ra khi cập nhật tình trạng ứng tuyển!");
            }
        }

        public void ThongBao(string tb)
        {
            MessageBox.Show(tb);
        }

        private void btn_Loai_Click(object sender, EventArgs e)
        {
            // Cập nhật tình trạng ứng tuyển trong cơ sở dữ liệu
            string dieuKien = "Chưa đủ điều kiện";
            int result = HoSoUngTuyenBUS.CapNhat_TinhTrangUngTuyen(dieuKien, this.idDoanhNghiep, this.idUngVien);

            if (result == 1)
            {
                // Hiển thị thông báo và cập nhật trạng thái
                ThongBao("Đã loại thành công!");
                tb_TinhTrangHoSo.Text = "Chưa đủ điều kiện";
                tb_TinhTrangHoSo.BackColor = Color.LightCoral;

                // Cập nhật DataGridView
                dgv_hosoungtuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgv_hosoungtuyen.DataSource = HoSoUngTuyenBUS.LayDSHSSUngTuyenTheoDoanhNghiep(idDoanhNghiep);

                dgv_BangCap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_BangCap.DataSource = BangCapBUS.LayDSBangCapTheoUngVien(this.idUngVien);
            }
            else
            {
                // Hiển thị thông báo lỗi nếu cập nhật không thành công
                ThongBao("Có lỗi xảy ra khi cập nhật tình trạng ứng tuyển!");
            }
        }

        private void btn_sapxep_Click(object sender, EventArgs e)
        {
            dgv_hosoungtuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_hosoungtuyen.DataSource = HoSoUngTuyenBUS.LayDSHoSoUT_SapXep_DiemDanhGia(this.idDoanhNghiep);
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            dgv_hosoungtuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_hosoungtuyen.DataSource = HoSoUngTuyenBUS.LayDSHSSUngTuyenTheoDoanhNghiep(idDoanhNghiep);
        }
    }
}
