using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public NopHoSoUngTuyen()
        {
            InitializeComponent();
        }

        public string IdUngVien = "UV01";
        public string IdHoSo = "HS05";

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a file to upload";
            openFileDialog.Filter = "All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                llbFileName.Text = Path.GetFileName(selectedFilePath);

                // Thư mục chứa tất cả các tệp được tải lên
                string uploadFolderPath = Path.Combine(Application.StartupPath, "Upload");

                // Thư mục chứa tệp của mỗi ID ứng viên
                string idUngVienFolderPath = Path.Combine(uploadFolderPath, IdUngVien);
                if (!Directory.Exists(idUngVienFolderPath))
                {
                    Directory.CreateDirectory(idUngVienFolderPath);
                }

                // Thư mục chứa tệp của mỗi ID hồ sơ trong thư mục của ID ứng viên
                string idHoSoFolderPath = Path.Combine(idUngVienFolderPath, IdHoSo);
                if (!Directory.Exists(idHoSoFolderPath))
                {
                    Directory.CreateDirectory(idHoSoFolderPath);
                }

                // Tạo đường dẫn tệp đích
                string destinationFilePath = Path.Combine(idHoSoFolderPath, llbFileName.Text);

                // Sao chép tệp vào thư mục đích
                File.Copy(selectedFilePath, destinationFilePath, true);
            }
        }



        private void btnXNNopHS_Click(object sender, EventArgs e)
        {
            if (llbFileName.Text != "" && cbVTUT.Text != "")
            {
                MessageBox.Show("Nộp hồ sơ thành công");
            }
            else
                MessageBox.Show("Thông tin không được để trống!");
        }

        private void btnHuyNHS_Click(object sender, EventArgs e)
        {

        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            // Thư mục chứa tất cả các tệp được tải lên
            string uploadFolderPath = Path.Combine(Application.StartupPath, "Upload");

            // Thư mục chứa tệp của mỗi ID ứng viên
            string idUngVienFolderPath = Path.Combine(uploadFolderPath, IdUngVien);

            // Thư mục chứa tệp của mỗi ID hồ sơ trong thư mục của ID ứng viên
            string idHoSoFolderPath = Path.Combine(idUngVienFolderPath, IdHoSo);

            // Mở thư mục trong File Explorer
            Process.Start("explorer.exe", idHoSoFolderPath);
        }
    }
}
