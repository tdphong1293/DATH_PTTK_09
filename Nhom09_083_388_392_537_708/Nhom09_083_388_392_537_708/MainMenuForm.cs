using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom09_083_388_392_537_708
{
    public partial class MainMenuForm : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        Font SegoeUISemibold = new Font("Segoe UI Semibold", 9.75F);
        Font SegoeUIBold = new Font("Segoe UI", 10.5F, FontStyle.Bold);

        public MainMenuForm()
        {
            InitializeComponent();
            random = new Random();
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.MediumSlateBlue;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = SegoeUIBold;
                    //panelTitleBar.BackColor = color;
                    //panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    //ThemeColor.PrimaryColor = color;
                    //ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    //btnCloseChildForm.Visible = true;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in pnlMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.Navy;
                    previousBtn.ForeColor = Color.White;
                    previousBtn.Font = SegoeUISemibold;
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlHomeChange.Controls.Add(childForm);
            this.pnlHomeChange.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HỆ THỐNG TUYỂN DỤNG";
            //panelTitleBar.BackColor = Color.FromArgb(82, 109, 130);
            //panelLogo.BackColor = Color.FromArgb(39, 55, 77);
            //currentButton = null;
            //CenterLabelInPanel(lblTitle, panelTitleBar);
            //btnCloseChildForm.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDangNhap(), sender);
        }

        private void btnXLHSUngTuyen_Click(object sender, EventArgs e)
        {
            OpenChildForm(new XULYHOSOUNGTUYEN(), sender);

        }

        private void btnXemPDT_Click(object sender, EventArgs e)
        {
            OpenChildForm(new XemPhieuDangTuyen(), sender);
        }

        private void btnXLDTD_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }
    }
}
