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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Nhom09_083_388_392_537_708
{
    //public static SqlConnection con = FormDangNhap.conn;

    public partial class DUYET_HS_UNGTUYEN : Form
    {
        public static SqlConnection con = FormDangNhap.conn;
        private FormDangNhap formDangNhap;
        private string id;
        public DUYET_HS_UNGTUYEN(string id)
        {
            InitializeComponent();
            formDangNhap = new FormDangNhap();
            this.id = id;
            dgv_hosoungtuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_hosoungtuyen.DataSource = LoadData_HoSoUngTuyen().Tables[0];
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
            string query = $"SELECT hsut.idungvien as IDUngVien, tv.ten as HoTen, hsut.ngayungtuyen as NgayUngTuyen, hsut.vitriungtuyen as ViTriUngTuyen, hsut.diemdanhgia as DiemDanhGia FROM HOSOUNGTUYEN hsut, THANHVIEN tv where hsut.idungvien = tv.idthanhvien and hsut.iddoanhnghiep = {this.id}";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet data_hsut = new DataSet();
            adapter.Fill(data_hsut);
            return data_hsut;
        }
        DataSet LoadData_HoSoUngTuyen_TheoTen(string name)
        {
            string query = $"SELECT tv.ten, hsut.ngayungtuyen, hsut.vitriungtuyen, hsut.điemanhgia FROM HOSOUNGTUYEN hsut, THANHVIEN tv where hsut.idungvien = tv.idthanhvien and tv.ten like '%{name}%' and hsut.iddoanhnghiep = {this.id}";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet data_hsut_theoten = new DataSet();
            adapter.Fill(data_hsut_theoten);
            return data_hsut_theoten;
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
                string query1 = $"select tv.ten, tv.email, uv.ngaysinh from THANHVIEN tv, UNGVIEN uv, where uv.idungvien = tv.idthanhvien and idthanhvien = {row.Cells["IDUngVien"].Value};";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd1.ExecuteReader();
                    if (reader.Read())
                    {
                        tb_HoTen.Text = reader["Ten"].ToString();
                        tb_Email.Text = reader["Email"].ToString();

                        string dateStr = reader["NgaySinh"].ToString();
                        DateTime date_ns = DateTime.Parse(dateStr);
                        tb_NgaySinh.Text = date_ns.ToString("dd/MM/yyyy");
                        // Continue for all other columns
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that might have occurred
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // Ensure the connection gets closed
                    con.Close();
                }
                tb_TinhTrangHoSo.Text = row.Cells["TinhTrangUngTuyen"].Value.ToString();
                DateTime date_ut = DateTime.Parse(row.Cells["NgayUngTuyen"].Value.ToString()) ;
                tb_NgayUngTuyen.Text = date_ut.ToString("dd/MM/yyyy");
                tb_ViTriUngTuyen.Text = row.Cells["ViTriUngTuyen"].Value.ToString() ;
            }
        }
    }
}
