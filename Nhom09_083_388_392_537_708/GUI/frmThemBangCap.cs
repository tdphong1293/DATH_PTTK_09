using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmThemBangCap : Form
    {
        public int IDUngVien, IDBangCap;
        private frmXuLyHSUngTuyen fXLHS;

        public frmThemBangCap(int IDUngVien, frmXuLyHSUngTuyen fXLHS)
        {
            InitializeComponent();
            this.IDUngVien = IDUngVien;
            this.fXLHS = fXLHS;
        }

        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                BangCapDTO bangcap = new BangCapDTO(tb_TenBang.Text, tb_CapBac.Text, dtpk_NgayCap.Value, tb_DonViCap.Text, this.IDUngVien);
                IDBangCap = BangCapBUS.ThemBangCap(bangcap);
                fXLHS.SearchAndReloadBangCap(this.IDUngVien);
                MessageBox.Show("THÊM BẰNG CẤP THÀNH CÔNG");
                this.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btn_QuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
