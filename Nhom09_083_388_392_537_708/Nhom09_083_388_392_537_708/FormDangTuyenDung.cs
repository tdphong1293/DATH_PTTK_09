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
    public partial class FormDangTuyenDung : Form
    {
        public static SqlConnection con = FormDangNhap.conn;
        string username;
        public FormDangTuyenDung()
        {
            InitializeComponent();
        }

        public FormDangTuyenDung(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        public double LayUuDai(string username)
        {
            //Sửa lại nếu chạy lại script
            string query = $"select UuDai from THANHVIEN tv, DOANHNGHIEP dn where tv.IDThanhVien = dn.IdDoanhNghiep and TenDangNhap = '{username}';";
            SqlCommand cmd = new SqlCommand(query, con);
            double UD = (double)cmd.ExecuteScalar();
            return UD;
        }

        public double TinhTongTien()
        {
            double TienTheoHinhThuc = 1.0;
            int TienTheoNgay = 200000;
            TimeSpan songay = dtpNKT.Value.Subtract(dtpNBD.Value);
            int soNgay = (int)songay.TotalDays;
            if (cbxHTDT.SelectedItem.ToString() == "Đăng tuyển trên báo giấy")
            {
                TienTheoHinhThuc = 1.3;
            }
            else if (cbxHTDT.SelectedItem.ToString() == "Đăng banner quảng cáo")
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

        }
    }
}
