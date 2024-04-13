using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom09_083_388_392_537_708
{
    //public static SqlConnection con = FormDangNhap.conn;
    public partial class DUYET_HS_UNGTUYEN : Form
    {
        public DUYET_HS_UNGTUYEN()
        {
            InitializeComponent();
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
        DataSet LoadData_HoSoUngTuyen()
        {
            DataSet dataSet = new DataSet();
            return dataSet;
        }
        DataSet LoadData_HoSoUngTuyen_TheoTen(string name)
        {
            DataSet dataSet = new DataSet();
            return dataSet;
        }
        private void btt_timkiem_Click(object sender, EventArgs e)
        {
            string name = txt_tenuv.Text;
            dgv_hosoungtuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_hosoungtuyen.DataSource = LoadData_HoSoUngTuyen_TheoTen(name).Tables[0];
        }
        private void dgv_hosoungtuyen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < this.dgv_hosoungtuyen.Rows.Count) // Make sure user select at least 1 row 
            {
                DataGridViewRow row = this.dgv_hosoungtuyen.Rows[e.RowIndex];
                tb_HoTen.Text = row.Cells["HoTenUV"];
                tb_NgaySinh.Text = row.Cells["NgaySinh"].Value.ToString("yyyy-MM-dd");
            }
        }
    }
}
