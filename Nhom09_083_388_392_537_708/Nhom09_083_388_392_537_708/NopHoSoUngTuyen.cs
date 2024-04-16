using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom09_083_388_392_537_708
{
    public partial class NopHoSoUngTuyen : Form
    {
        public static SqlConnection con = FormDangNhap.conn;
        public string IdUngVien = "";
        public string IdDoanhNghiep = "";
        public string IdPDT = "";

        public NopHoSoUngTuyen(string idUser, string idpdt)
        {
            InitializeComponent();
            this.IdUngVien = idUser;
            this.IdPDT = idpdt;
            IdDoanhNghiep = Lay_IdDN_Tu_IDPDT(IdPDT);
        }

        private void NopHoSoUngTuyen_Load(object sender, EventArgs e)
        {
            LayThongTinUngVien(IdUngVien);
            LayThongTinDoanhNghiep(IdDoanhNghiep);
            LoadViTriDangTuyen();
        }

        private void LoadViTriDangTuyen()
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlCommand command = new SqlCommand("LayViTriDangTuyen", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", IdPDT);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
                cbVTUT.DataSource = dt;
                cbVTUT.DisplayMember = "DanhSachViTriDangTuyen";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách vị trí đăng tuyển: " + ex.Message);
            }
        }

        private void LayThongTinUngVien(string idUngVien)
        {
            SqlCommand commandUngVien = new SqlCommand("LayTTUngVien", con);
            SqlDataReader reader;
            commandUngVien.CommandType = CommandType.StoredProcedure;
            commandUngVien.Parameters.AddWithValue("@ID", idUngVien);
            reader = commandUngVien.ExecuteReader();
            if (reader.Read())
            {
                txtTenUV.Text = reader["Ten"].ToString();
            }
            reader.Close();
        }

        private void LayThongTinDoanhNghiep(string idPhieuDangTuyen)
        {
            SqlCommand commandDoanhNghiep = new SqlCommand("LayTTDoanhNghiep", con);
            SqlDataReader reader;
            commandDoanhNghiep.CommandType = CommandType.StoredProcedure;
            commandDoanhNghiep.Parameters.AddWithValue("@ID", idPhieuDangTuyen);
            reader = commandDoanhNghiep.ExecuteReader();
            if (reader.Read())
            {
                txtTenDN.Text = reader["Ten"].ToString();
                IdDoanhNghiep = reader["IDDoanhNghiep"].ToString();
            }
            reader.Close();
        }

        private string Lay_IdDN_Tu_IDPDT(string idPDT)
        {
            string idDoanhNghiep = "";
            using (SqlCommand command = new SqlCommand("TimIDDoanhNghiepTuIDPDT", con))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IDPDT", idPDT);
                SqlParameter outputParam = new SqlParameter("@IDDoanhNghiep", SqlDbType.Int);
                outputParam.Direction = ParameterDirection.Output;
                command.Parameters.Add(outputParam);
                command.ExecuteNonQuery();
                idDoanhNghiep = command.Parameters["@IDDoanhNghiep"].Value.ToString();
            }
            return idDoanhNghiep;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a file to upload";
            openFileDialog.Filter = "All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                llbFileName.Text = Path.GetFileName(selectedFilePath);
            }
        }


        private void btnXNNopHS_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(llbFileName.Text) && cbVTUT.SelectedItem != null)
            {
                string viTriUngTuyen = cbVTUT.SelectedItem.ToString();
                try
                {
                    // Khởi tạo và thực thi SqlCommand để gọi stored procedure
                    using (SqlCommand command = new SqlCommand("ThemHoSoUngTuyen", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@IDDoanhNghiep", IdDoanhNghiep);
                        command.Parameters.AddWithValue("@IDUngVien", IdUngVien);
                        command.Parameters.AddWithValue("@NgayUngTuyen", DateTime.Now.Date);
                        command.Parameters.AddWithValue("@ViTriUngTuyen", viTriUngTuyen);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Nộp hồ sơ thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi nộp hồ sơ: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Thông tin không được để trống!");
            }
        }
    }
}
