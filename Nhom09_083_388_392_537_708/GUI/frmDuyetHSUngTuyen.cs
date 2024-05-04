using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmDuyetHSUngTuyen : Form
    {
        public static SqlConnection con = frmDangNhap.conn;
        private string id;
        private int idungvien;
        public frmDuyetHSUngTuyen(string id)
        {
            InitializeComponent();
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
            string query = $"SELECT hsut.idungvien as IDUngVien, tv.ten as HoTen, hsut.ngayungtuyen as NgayUngTuyen, hsut.vitriungtuyen as ViTriUngTuyen, hsut.diemdanhgia as DiemDanhGia , hsut.tinhtrangungtuyen as TinhTrangUngTuyen FROM HOSOUNGTUYEN hsut, THANHVIEN tv where hsut.idungvien = tv.idthanhvien and hsut.iddoanhnghiep = {this.id}";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet data_hsut = new DataSet();
            adapter.Fill(data_hsut);
            return data_hsut;
        }
        DataSet LoadData_HoSoUngTuyen_DiemDanhGia()
        {
            string query = $"SELECT hsut.idungvien as IDUngVien, tv.ten as HoTen, hsut.ngayungtuyen as NgayUngTuyen, hsut.vitriungtuyen as ViTriUngTuyen, hsut.diemdanhgia as DiemDanhGia , hsut.tinhtrangungtuyen as TinhTrangUngTuyen FROM HOSOUNGTUYEN hsut, THANHVIEN tv where hsut.idungvien = tv.idthanhvien and hsut.iddoanhnghiep = {this.id} ORDER BY hsut.diemdanhgia DESC";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet data_hsut = new DataSet();
            adapter.Fill(data_hsut);
            return data_hsut;
        }
        DataSet LoadData_HoSoUngTuyen_TheoTen(string name)
        {
            string query = $"SELECT hsut.idungvien as IDUngVien, tv.ten as HoTen, hsut.ngayungtuyen as NgayUngTuyen, hsut.vitriungtuyen as ViTriUngTuyen, hsut.diemdanhgia as DiemDanhGia , hsut.tinhtrangungtuyen as TinhTrangUngTuyen FROM HOSOUNGTUYEN hsut, THANHVIEN tv where hsut.idungvien = tv.idthanhvien and tv.ten like '%{name}%' and hsut.iddoanhnghiep = {this.id}";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet data_hsut_theoten = new DataSet();
            adapter.Fill(data_hsut_theoten);
            return data_hsut_theoten;
        }
        DataSet LoadData_BangCapUV(int iduv)
        {
            string query = $"SELECT TenBang, CapBac, NgayCap, DonViCap from BANGCAP where idungvien = {iduv}";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet data_bangcapuv = new DataSet();
            adapter.Fill(data_bangcapuv);
            return data_bangcapuv;
        }
        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string name = tb_tenuv.Text.ToString();
            MessageBox.Show(name);
            dgv_hosoungtuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_hosoungtuyen.DataSource = LoadData_HoSoUngTuyen_TheoTen(name).Tables[0];
        }
        private void dgv_hosoungtuyen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < this.dgv_hosoungtuyen.Rows.Count) // Make sure user select at least 1 row 
            {
                DataGridViewRow row = this.dgv_hosoungtuyen.Rows[e.RowIndex];
                string query1 = $"select tv.ten, tv.email, uv.ngaysinh from THANHVIEN tv, UNGVIEN uv where uv.idungvien = tv.idthanhvien and idthanhvien = {row.Cells["IDUngVien"].Value};";
                SqlCommand cmd1 = new SqlCommand(query1, con);

                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                SqlDataReader reader = cmd1.ExecuteReader();
                if (reader.Read())
                {
                    tb_HoTen.Text = reader["ten"].ToString(); // Make sure the column names match the ones in your database
                    tb_Email.Text = reader["email"].ToString();
                    string dateStr = reader["ngaysinh"].ToString();
                    DateTime date_ns = DateTime.Parse(dateStr);
                    tb_NgaySinh.Text = date_ns.ToString("dd/MM/yyyy");
                    // Continue for all other columns
                }

                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
                tb_TinhTrangHoSo.Text = row.Cells["TinhTrangUngTuyen"].Value.ToString();
                if (tb_TinhTrangHoSo.Text == "Đủ điều kiện")
                {
                    tb_TinhTrangHoSo.BackColor = Color.YellowGreen;
                }
                else if (tb_TinhTrangHoSo.Text == "Chưa đủ điều kiện")
                {
                    tb_TinhTrangHoSo.BackColor = Color.LightCoral;
                }
                else
                {
                    tb_TinhTrangHoSo.BackColor = Color.White;
                }    
                DateTime date_ut = DateTime.Parse(row.Cells["NgayUngTuyen"].Value.ToString());
                //MessageBox.Show(date_ut.ToString("dd/MM/yyyy"));
                tb_NgayUngTuyen.Text = date_ut.ToString("dd/MM/yyyy");
                tb_ViTriUngTuyen.Text = row.Cells["ViTriUngTuyen"].Value.ToString();
                tb_DiemDanhGia.Text = row.Cells["DiemDanhGia"].Value.ToString();

                this.idungvien = Convert.ToInt32(row.Cells["IDUngVien"].Value);
                dgv_BangCap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_BangCap.DataSource = LoadData_BangCapUV(this.idungvien).Tables[0];
            }
        }

        private void btn_Duyet_Click(object sender, EventArgs e)
        {
            // Create the SQL UPDATE query
            string query = $"UPDATE HOSOUNGTUYEN SET TinhTrangUngTuyen = N'Đủ điều kiện' WHERE idungvien = {this.idungvien}";

            // Create a new SqlCommand
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ThongBao("Đã duyệt thành công!");
            tb_TinhTrangHoSo.Text = "Đủ điều kiện";
            tb_TinhTrangHoSo.BackColor = Color.YellowGreen;
            dgv_hosoungtuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_hosoungtuyen.DataSource = LoadData_HoSoUngTuyen().Tables[0];
            dgv_BangCap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_BangCap.DataSource = LoadData_BangCapUV(this.idungvien).Tables[0];
        }

        public void ThongBao(string tb)
        {
            MessageBox.Show(tb);
        }

        private void btn_Loai_Click(object sender, EventArgs e)
        {
            // Create the SQL UPDATE query
            string query = $"UPDATE HOSOUNGTUYEN SET TinhTrangUngTuyen = N'Chưa đủ điều kiện' WHERE idungvien = {this.idungvien}";

            // Create a new SqlCommand
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ThongBao("Đã loại thành công!");
            tb_TinhTrangHoSo.Text = "Chưa đủ điều kiện";
            tb_TinhTrangHoSo.BackColor = Color.LightCoral;
            dgv_hosoungtuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_hosoungtuyen.DataSource = LoadData_HoSoUngTuyen().Tables[0];
            dgv_BangCap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_BangCap.DataSource = LoadData_BangCapUV(this.idungvien).Tables[0];
        }

        private void btn_sapxep_Click(object sender, EventArgs e)
        {
            dgv_hosoungtuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_hosoungtuyen.DataSource = LoadData_HoSoUngTuyen_DiemDanhGia().Tables[0];
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            dgv_hosoungtuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_hosoungtuyen.DataSource = LoadData_HoSoUngTuyen().Tables[0];
        }
    }
}
