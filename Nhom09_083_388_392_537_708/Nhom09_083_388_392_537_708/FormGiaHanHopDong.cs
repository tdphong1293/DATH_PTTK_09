using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom09_083_388_392_537_708
{
    public partial class FormGiaHanHopDong : Form
    {
        private Timer debounceTimer = new Timer();
        private int iddoanhnghiep = -1;
        private static SqlConnection conn = FormDangNhap.conn;
        public FormGiaHanHopDong()
        {
            InitializeComponent();
            debounceTimer.Interval = 500;
            debounceTimer.Tick += DebounceTimer_Tick;
            dtgv_KetQuaTuyenDung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            SearchAndFillData_KetQuaUngTuyen("");
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

        private void SearchAndFillData_KetQuaUngTuyen(string searchtext)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("LayKetQuaUngTuyen", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@timkiem", searchtext));
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dtgv_KetQuaTuyenDung.DataSource = dataTable;
                }
            } 
            catch (Exception ex)
            {
                ThongBao("Lỗi datagridview: " + ex.Message);
            }
        }

        private void DebounceTimer_Tick(object sender, EventArgs e)
        {
            debounceTimer.Stop();
            SearchAndFillData_KetQuaUngTuyen(txt_timkiem.Text);
        }

        private void DoanhNghiep_TextBox_Changed(int id)
        {
            try
            {
                string query = "select TV.Ten, TV.Email, DN.MaSoThue, DN.NguoiDaiDien, DN.DiaChi, DN.UuDai" +
                    " from THANHVIEN TV join DOANHNGHIEP DN on TV.IDThanhVien = DN.IDDoanhNghiep" +
                    " where DN.IDDoanhNghiep = @iddoanhnghiep";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@iddoanhnghiep", id);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        txt_name_dn.Text = reader["Ten"].ToString();
                        txt_email_dn.Text = reader["Email"].ToString();
                        txt_tax_dn.Text = reader["MaSoThue"].ToString();
                        txt_daidien_dn.Text = reader["NguoiDaiDien"].ToString();
                        txt_diachi_dn.Text = reader["DiaChi"].ToString();
                        txt_discount_dn.Text = (float.Parse(reader["UuDai"].ToString()) * 100).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ThongBao("Lỗi datagridview: " + ex.Message);
            }
        }

        private void dtgv_KetQuaTuyenDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtgv_KetQuaTuyenDung.RowCount)
            {
                DataGridViewRow row = dtgv_KetQuaTuyenDung.Rows[e.RowIndex];
                status_bar.Items["status_itemselect"].Text = "Đang chọn công ty " + row.Cells["Tên công ty"].Value.ToString();
                iddoanhnghiep = int.Parse(row.Cells["IDDoanhNghiep"].Value.ToString());
                DoanhNghiep_TextBox_Changed(iddoanhnghiep);
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
                    string connectionString = "Data Source=P1293; Initial Catalog = PTTK_ABC; User Id = sa; Password = ducphong1293;";

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string query = "update DOANHNGHIEP set UuDai = @uudai where IDDoanhNghiep = @iddoanhnghiep";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@uudai", float.Parse(txt_discount_dn.Text) / 100);
                                command.Parameters.AddWithValue("@iddoanhnghiep", iddoanhnghiep);
                                command.ExecuteNonQuery();
                            }
                            ThongBao("Cập nhật ưu đãi thành công");
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        ThongBao("Lỗi datagridview: " + ex.Message);
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