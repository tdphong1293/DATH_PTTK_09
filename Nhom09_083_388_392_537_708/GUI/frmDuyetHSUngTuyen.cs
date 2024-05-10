using BUS;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GUI
{
    public partial class frmDuyetHSUngTuyen : Form
    {
        public static SqlConnection con = frmDangNhap.conn;
        private string id;
        private int idUngVien = 0;
        private int idDoanhNghiep = 0;
        public frmDuyetHSUngTuyen(int idDoanhNghiep)
        {
            InitializeComponent();
            this.idDoanhNghiep = idDoanhNghiep;
            HienThi(idDoanhNghiep);
        }
        public void HienThi(int idDoanhNghiep)
        {
            DataTable dataTable = HoSoUngTuyenBUS.LayDSHSSUngTuyenTheoDoanhNghiep(idDoanhNghiep);
            dgv_HoSo_UngTuyen.DataSource = dataTable;
        }
        private void btn_OpenFileCV_Click(object sender, EventArgs e)
        {
            string baseDirectory = @"DAO\DS_CV";
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            string subDirectory = idUngVien.ToString();
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

        private void btn_TimKiemTenUV_Click(object sender, EventArgs e)
        {
            string name = txt_TenUngVien.Text.ToString();
            dgv_HoSo_UngTuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_HoSo_UngTuyen.DataSource = UngVienBUS.LayTTUV_TheoHSUT(this.idDoanhNghiep, name);
        }
        private void dgv_HoSo_UngTuyen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < this.dgv_HoSo_UngTuyen.Rows.Count) // Make sure user select at least 1 row 
                {
                    btn_Duyet.Enabled = true;
                    btn_Loai.Enabled = true;
                    btn_OpenFileCV.Enabled = true;

                    DataGridViewRow row = this.dgv_HoSo_UngTuyen.Rows[e.RowIndex];
                    this.idUngVien = Convert.ToInt32(row.Cells["IDUngVien"].Value);

                    DataTable dataTable = UngVienBUS.LayTTUngVienHSUT(this.idUngVien);
                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow rows = dataTable.Rows[0];

                        txt_HoTenUV.Text = rows["ten"].ToString() ?? string.Empty; ;
                        txt_EmailUV.Text = rows["email"].ToString() ?? string.Empty; ;

                        DateTime ngaySinh;
                        if (DateTime.TryParse(rows["ngaysinh"].ToString(), out ngaySinh))
                        {
                            txt_NgaySinhUV.Text = ngaySinh.ToString("dd/MM/yyyy") ?? string.Empty;
                        }
                        else
                            txt_NgaySinhUV.Text = "";
                    }

                    txt_TinhTrangHS.Text = row.Cells["TinhTrangUngTuyen"].Value.ToString() ?? string.Empty;
                    if (txt_TinhTrangHS.Text == "Đang xử lý")
                    {
                        txt_TinhTrangHS.BackColor = Color.Yellow;
                    }
                    else
                    {
                        txt_TinhTrangHS.BackColor = Color.LightGray;
                    }

                    DateTime date_ut = DateTime.Parse(row.Cells["NgayUngTuyen"].Value.ToString());
                    txt_NgayUngTuyen.Text = date_ut.ToString("dd/MM/yyyy")?? string.Empty;
                    txt_ViTriUngTuyen.Text = row.Cells["ViTriUngTuyen"].Value.ToString() ?? string.Empty; ;
                    txt_DiemDanhGia.Text = row.Cells["DiemDanhGia"].Value.ToString() ?? string.Empty; ;

                    dgv_BangCapUV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv_BangCapUV.DataSource = BangCapBUS.LayDSBangCapTheoUngVien(this.idUngVien);
                }
            }
            catch
            {
                if (txt_HoTenUV.Text == "")
                {
                    btn_Duyet.Enabled = false;
                    btn_Loai.Enabled = false;
                    btn_OpenFileCV.Enabled = false;
                }
                MessageBox.Show("Không thể chọn!");
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
                txt_TinhTrangHS.BackColor = Color.LightGray;

                // clear mọi thứ
                this.idUngVien = 0;
                txt_DiemDanhGia.Text = "";
                txt_EmailUV.Text = "";
                txt_HoTenUV.Text = "";
                txt_NgaySinhUV.Text = "";
                txt_NgayUngTuyen.Text = "";
                txt_TenUngVien.Text = "";
                txt_TinhTrangHS.Text = "";
                txt_ViTriUngTuyen.Text = "";

                dgv_BangCapUV.DataSource = null;
                this.dgv_BangCapUV.Rows.Clear();
                // Cập nhật DataGridView
                dgv_HoSo_UngTuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgv_HoSo_UngTuyen.DataSource = HoSoUngTuyenBUS.LayDSHSSUngTuyenTheoDoanhNghiep(idDoanhNghiep);
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
                txt_TinhTrangHS.BackColor = Color.LightGray;

                // clear mọi thứ
                this.idUngVien = 0;
                txt_DiemDanhGia.Text = "";
                txt_EmailUV.Text = "";
                txt_HoTenUV.Text = "";
                txt_NgaySinhUV.Text = "";
                txt_NgayUngTuyen.Text = "";
                txt_TenUngVien.Text = "";
                txt_TinhTrangHS.Text = "";
                txt_ViTriUngTuyen.Text = "";

                dgv_BangCapUV.DataSource = null;
                this.dgv_BangCapUV.Rows.Clear();

                // Cập nhật DataGridView
                dgv_HoSo_UngTuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgv_HoSo_UngTuyen.DataSource = HoSoUngTuyenBUS.LayDSHSSUngTuyenTheoDoanhNghiep(idDoanhNghiep);
            }
            else
            {
                // Hiển thị thông báo lỗi nếu cập nhật không thành công
                ThongBao("Có lỗi xảy ra khi cập nhật tình trạng ứng tuyển!");
            }
        }

        private void btn_SapXep_Click(object sender, EventArgs e)
        {
            dgv_HoSo_UngTuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_HoSo_UngTuyen.DataSource = HoSoUngTuyenBUS.LayDSHoSoUT_SapXep_DiemDanhGia(this.idDoanhNghiep);
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            dgv_HoSo_UngTuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_HoSo_UngTuyen.DataSource = HoSoUngTuyenBUS.LayDSHSSUngTuyenTheoDoanhNghiep(idDoanhNghiep);
        }
    }
}
