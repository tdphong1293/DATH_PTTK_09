using BUS;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmGiaHanHopDong : Form
    {
        private Timer debounceTimer = new Timer();
        private int iddoanhnghiep = -1;
        private static SqlConnection conn = frmDangNhap.conn;
        public frmGiaHanHopDong()
        {
            InitializeComponent();
            debounceTimer.Interval = 500;
            debounceTimer.Tick += DebounceTimer_Tick;
            dtgv_KetQuaTuyenDung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgv_KetQuaTuyenDung.DataSource = HoSoUngTuyenBUS.LayKetQuaUngTuyen("");
        }

        private void ThongBao(string noidungtb)
        {
            MessageBox.Show(noidungtb);
        }

        private void txt_timkiem_dn_TextChanged(object sender, EventArgs e)
        {
            debounceTimer.Stop();
            debounceTimer.Start();
        }

        private void DebounceTimer_Tick(object sender, EventArgs e)
        {
            debounceTimer.Stop();
            dtgv_KetQuaTuyenDung.DataSource = HoSoUngTuyenBUS.LayKetQuaUngTuyen(txt_timkiem.Text);
        }

        private void dtgv_KetQuaTuyenDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtgv_KetQuaTuyenDung.RowCount)
            {
                DataGridViewRow row = dtgv_KetQuaTuyenDung.Rows[e.RowIndex];
                status_bar.Items["status_itemselect"].Text = "Đã chọn công ty " + row.Cells["Tên công ty"].Value.ToString();
                iddoanhnghiep = int.Parse(row.Cells["IDDoanhNghiep"].Value.ToString());
                string[] DoanhNghiep = DoanhNghiepBUS.LayThongTinDN(iddoanhnghiep);
                txt_name_dn.Text = DoanhNghiep[0];
                txt_email_dn.Text = DoanhNghiep[1];
                txt_tax_dn.Text = DoanhNghiep[2];
                txt_daidien_dn.Text = DoanhNghiep[3];
                txt_diachi_dn.Text = DoanhNghiep[4];
                txt_discount_dn.Text = DoanhNghiep[5];
                btn_luudiscount.Enabled = true;
            }
            else
            {
                status_bar.Items["status_itemselect"].Text = "Chưa chọn công ty nào";
                txt_name_dn.Text = "";
                txt_email_dn.Text = "";
                txt_tax_dn.Text = "";
                txt_daidien_dn.Text = "";
                txt_diachi_dn.Text = "";
                txt_discount_dn.Text = "";
                btn_luudiscount.Enabled = false;
            }
        }

        private bool uudai_inputvalidation (string input)
        {
            int number;
            if (int.TryParse(input, out number))
            {
                if (number >= 0 && number <= 50)
                {
                    return true;
                }
            }
            return false;
        }

        private void btn_luudiscount_Click(object sender, EventArgs e)
        {
            if (uudai_inputvalidation(txt_discount_dn.Text))
            {
                if (iddoanhnghiep >= 0)
                {
                    try
                    {
                        if (DoanhNghiepBUS.CapNhatUuDai(iddoanhnghiep, txt_discount_dn.Text))
                        {
                            ThongBao("Cập nhật ưu đãi thành công");
                        }

                    } 
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi cập nhật ưu đãi: " + ex.Message);
                    }
                }
                else
                {
                    ThongBao("Vui lòng chọn doanh nghiệp để chỉnh sửa mức ưu đãi");
                }
            }
            else
            {
                ThongBao("Ưu đãi không hợp lệ");
            }
        }
    }
}