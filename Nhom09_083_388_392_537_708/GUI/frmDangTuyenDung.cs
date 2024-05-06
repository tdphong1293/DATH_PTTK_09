using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmDangTuyenDung : Form
    {
        string username;
        string id;

        PhieuQuangCaoBUS PQCBUS { get; set; }
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
            PhieuQuangCaoDTO pqc = new PhieuQuangCaoDTO(dtpNBD.Value, dtpNKT.Value, cbxHTDT.Text, 0);
            tbxTongTien.Text = PhieuQuangCaoBUS.TinhTongTien(pqc, DoanhNghiepBUS.LayUuDai(username)).ToString();
        }

        private void cbxHTDT_SelectedValueChanged(object sender, EventArgs e)
        {
            PhieuQuangCaoDTO pqc = new PhieuQuangCaoDTO(dtpNBD.Value, dtpNKT.Value, cbxHTDT.Text, 0);
            tbxTongTien.Text = PhieuQuangCaoBUS.TinhTongTien(pqc, DoanhNghiepBUS.LayUuDai(username)).ToString();
        }

        private void dtpNKT_ValueChanged(object sender, EventArgs e)
        {
            int soNgay = 0;
            TimeSpan songay = dtpNKT.Value.Subtract(dtpNBD.Value);
            soNgay = (int)songay.TotalDays;
            if (soNgay < 30)
            {
                cbxLHTT.SelectedIndex = 1;
                cbxLHTT.Enabled = false;
            }
            else
            {
                cbxLHTT.Enabled = true;
            }
            if (dtpNKT.Value != null && cbxHTDT.SelectedItem != null && cbxHTTT.SelectedItem != null)
            {
                PhieuQuangCaoDTO pqc = new PhieuQuangCaoDTO(dtpNBD.Value, dtpNKT.Value, cbxHTDT.Text, 0);
                tbxTongTien.Text = PhieuQuangCaoBUS.TinhTongTien(pqc, DoanhNghiepBUS.LayUuDai(username)).ToString();
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
            int IDHD = 0;
            try
            {
                PhieuQuangCaoDTO pqc = new PhieuQuangCaoDTO(dtpNBD.Value, dtpNKT.Value, cbxHTDT.Text, double.Parse(tbxTongTien.Text));
                IDPhieuQuangCao = PhieuQuangCaoBUS.ThemPQC(pqc);
                PhieuDangTuyenDTO pdt = new PhieuDangTuyenDTO(tbxVTTD.Text, int.Parse(tbxSLTD.Text), int.Parse(this.id));
                IDPDT = PhieuDangTuyenBUS.ThemPDT(pdt, IDPhieuQuangCao);
                YeuCauCVBUS.ThemYC(tbxMoTa.Text, IDPDT);
                IDHD = HoaDonBUS.ThemHD(double.Parse(tbxTongTien.Text), cbxLHTT.SelectedItem.ToString(), int.Parse(this.id));
                if (cbxLHTT.SelectedItem.ToString() == "Theo đợt")
                {
                    ThanhToanBUS.ThemTT(cbxHTTT.SelectedItem.ToString(), pqc.TongTienQC * 0.3, 1, IDHD);
                    ThanhToanBUS.ThemTT(cbxHTTT.SelectedItem.ToString(), pqc.TongTienQC * 0.3, 2, IDHD);
                    ThanhToanBUS.ThemTT(cbxHTTT.SelectedItem.ToString(), pqc.TongTienQC * 0.4, 3, IDHD);
                }
                else if (cbxLHTT.SelectedItem.ToString() == "Toàn bộ")
                {
                    ThanhToanBUS.ThemTT(cbxHTTT.SelectedItem.ToString(), pqc.TongTienQC, 1, IDHD);
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
