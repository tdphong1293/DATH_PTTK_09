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
            string query = $"select UuDai from THANHVIEN tv, DOANHNGHIEP dn where tv.IDThanhVien = dn.IdThanhVien and TenDangNhap = '{username}';";
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
            if (cbxHTDT.SelectedValue == "Đăng tuyển trên báo giấy")
            {
                TienTheoHinhThuc = 1.3;
            }
            else if (cbxHTDT.SelectedValue == "Đăng banner quảng cáo")
            {
                TienTheoHinhThuc = 1.5;
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
    }
}
