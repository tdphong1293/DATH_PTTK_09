using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a file to upload";
            openFileDialog.Filter = "All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                llbFileName.Text = Path.GetFileName(selectedFilePath);
                string uploadFolderPath = Path.Combine(Application.StartupPath, "Upload");
                if (!Directory.Exists(uploadFolderPath))
                {
                    Directory.CreateDirectory(uploadFolderPath);
                }
                string destinationFilePath = Path.Combine(uploadFolderPath, llbFileName.Text);
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
    }
}
