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

namespace GUI
{
    public partial class frmDangTuyenDung : Form
    {
        public static SqlConnection con = frmDangNhap.conn;
        string username;
        string id;
        public frmDangTuyenDung()
        {
            InitializeComponent();
        }

        public frmDangTuyenDung(string username, string id)
        {
            InitializeComponent();
            this.username = username;
            this.id = id;
        }

        public double LayUuDai(string username)
        {
            //Sửa lại nếu chạy lại script
            string query = $"select UuDai from THANHVIEN tv, DOANHNGHIEP dn where tv.IDThanhVien = dn.IdDoanhNghiep and TenDangNhap = '{username}';";
            SqlCommand cmd = new SqlCommand(query, con);
            double UD = (double)cmd.ExecuteScalar();
            return UD;
        }

        int soNgay = 0;

        public double TinhTongTien()
        {
            double TienTheoHinhThuc = 1.0;
            int TienTheoNgay = 200000;
            TimeSpan songay = dtpNKT.Value.Subtract(dtpNBD.Value);
            soNgay = (int)songay.TotalDays;
            if (cbxHTDT.SelectedItem.ToString() == "Báo giấy")
            {
                TienTheoHinhThuc = 1.3;
            }
            else if (cbxHTDT.SelectedItem.ToString() == "Banner quảng cáo")
            {
                TienTheoHinhThuc = 1.5;
            }
            else
            {
                TienTheoHinhThuc = 1.0;
            }
            double tongtien = TienTheoNgay * soNgay * TienTheoHinhThuc * (1- LayUuDai(username));
            return Math.Round(tongtien, 2);
        }

        private void FormDangTuyenDung_Load(object sender, EventArgs e)
        {
            tbxVTTD.Text = string.Empty;
            tbxSLTD.Text = string.Empty;
            tbxMoTa.Text = string.Empty;
            dtpNBD.Value = DateTime.Today;
            dtpNKT.Value = DateTime.Today;
            cbxHTTT.SelectedIndex = -1;
            cbxHTDT.SelectedIndex = -1;
            tbxTongTien.Text = "";
        }

        private void cbxHTTT_SelectedValueChanged(object sender, EventArgs e)
        {
            tbxTongTien.Text = TinhTongTien().ToString();
        }

        private void cbxHTDT_SelectedValueChanged(object sender, EventArgs e)
        {
            tbxTongTien.Text = TinhTongTien().ToString();
        }

        private void dtpNKT_ValueChanged(object sender, EventArgs e)
        {
            if (dtpNKT.Value != null && cbxHTDT.SelectedItem != null && cbxHTTT.SelectedItem != null)
            {
                tbxTongTien.Text = TinhTongTien().ToString();
            }
            else
            {
                return;
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            int IDPhieuQuangCao = 0;
            int IDPDT = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand("ThemPQC", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NBD", dtpNBD.Value);
                    cmd.Parameters.AddWithValue("@NKT", dtpNKT.Value);
                    cmd.Parameters.AddWithValue("@htdt", cbxHTDT.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("tongtien", float.Parse(tbxTongTien.Text));
                    // Thêm tham số đầu ra để lưu trữ IDPhieuQuangCao
                    SqlParameter paramID = new SqlParameter("@IDPhieuQuangCao", SqlDbType.Int);
                    paramID.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramID);
                    cmd.ExecuteNonQuery();
                    IDPhieuQuangCao = Convert.ToInt32(paramID.Value);
                }
                using (SqlCommand cmd = new SqlCommand("ThemPDT", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@vtdt", tbxVTTD.Text);
                    cmd.Parameters.AddWithValue("@sltd", int.Parse(tbxSLTD.Text));
                    cmd.Parameters.AddWithValue("@iddn", int.Parse(this.id));
                    cmd.Parameters.AddWithValue("@pqc", IDPhieuQuangCao);
                    // Thêm tham số đầu ra để lưu trữ IDPDT
                    SqlParameter paramID = new SqlParameter("@idpdt", SqlDbType.Int);
                    paramID.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(paramID);
                    cmd.ExecuteNonQuery();
                    IDPDT = Convert.ToInt32(paramID.Value);
                }
                using (SqlCommand cmd = new SqlCommand("ThemYC", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pdt", IDPDT);
                    cmd.Parameters.AddWithValue("@mota", tbxMoTa.Text);
                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd = new SqlCommand("ThemHD", con))
                {
                    float datra = 0;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tongtien", float.Parse(tbxTongTien.Text));
                    cmd.Parameters.AddWithValue("@datra", datra);
                    if (soNgay >= 30)
                    {
                        cmd.Parameters.AddWithValue("@lhtt", "Theo đợt");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@lhtt", "Toàn bộ");
                    }
                    cmd.Parameters.AddWithValue("@ngaylap", DateTime.Today);
                    cmd.Parameters.AddWithValue("@ttht", "Chưa hoàn thành");
                    cmd.Parameters.AddWithValue("@iddn", int.Parse(this.id));
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Đăng tuyển thành công!!!");
                FormDangTuyenDung_Load(sender, e);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
