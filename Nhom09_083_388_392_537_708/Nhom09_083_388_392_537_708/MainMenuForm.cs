using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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
        private FormDangNhap loginForm;
        public MainMenuForm()
        {
            InitializeComponent();
            random = new Random();
        }

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.Black;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //panelTitleBar.BackColor = color;
                    //panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
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
                    previousBtn.BackColor = Color.FromArgb(191, 205, 219);
                    previousBtn.ForeColor = Color.Black;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null && activeForm.GetType() == childForm.GetType())
            {
                childForm = activeForm;
            }
            else
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
            }
            childForm.BringToFront();
            childForm.Show();
            //lblTitle.Text = childForm.Text;
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {            
            btnDangTuyenDung.Visible = false;
            btnXemPDT.Visible = false;
            btnDuyetHSDaQuaXL.Visible = false;
            btnXLDTD.Visible = false;
            btnXLHSUngTuyen.Visible = false;
            btnThanhToan.Visible = false;
            btnGiaHanHD.Visible = false;
            btnLogout.Visible = false;
            ActivateButton(btnLogin);
            //CenterLabelInPanel(lblTitle, pnlTitle);
            loginForm = new FormDangNhap();
            loginForm.ButtonClicked += UI_After_Login;
            loginForm.TopLevel = false;
            loginForm.FormBorderStyle = FormBorderStyle.None;
            loginForm.Dock = DockStyle.Fill;
            pnlHomeChange.Controls.Add(loginForm);
            loginForm.Show();
        }

        private void UI_After_Login(object sender, EventArgs e)
        {
            if (e is RoleEventArgs roleEventArgs)
            {
                string role = roleEventArgs.Role;
                if (role == "NVCOBAN")
                {                   
                    pnlHomeChange.Controls.Clear();
                    btnXemPDT.Visible = true;
                    btnXLDTD.Visible = true;
                    btnXLHSUngTuyen.Visible=true;
                    btnThanhToan.Visible = true;
                    btnLogin.Visible = false;
                    btnSignup.Visible = false;
                    btnDangTuyenDung.Visible = false;
                    btnDuyetHSDaQuaXL.Visible = false;
                    btnGiaHanHD.Visible = false;
                    XemPhieuDangTuyen xpdt = new XemPhieuDangTuyen();
                    xpdt.TopLevel = false;
                    xpdt.FormBorderStyle = FormBorderStyle.None;
                    xpdt.Dock = DockStyle.Fill;
                    pnlHomeChange.Controls.Add(xpdt);
                    xpdt.Show();
                }

                else if (role == "DOANHNGHIEP")
                {
                    pnlHomeChange.Controls.Clear();
                    btnDangTuyenDung.Visible=true;
                    btnDuyetHSDaQuaXL.Visible = true;
                    btnXemPDT.Visible = true;
                    btnLogin.Visible = false;
                    btnSignup.Visible = false;
                    btnXLHSUngTuyen.Visible = false;
                    btnThanhToan.Visible = false;
                    btnGiaHanHD.Visible = false;
                    XemPhieuDangTuyen xpdt = new XemPhieuDangTuyen();
                    xpdt.TopLevel = false;
                    xpdt.FormBorderStyle = FormBorderStyle.None;
                    xpdt.Dock = DockStyle.Fill;
                    pnlHomeChange.Controls.Add(xpdt);
                    xpdt.Show();
                }
            }
            
            
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

        private void CenterLabelInPanel(System.Windows.Forms.Label lblTitle, Panel panelTitleBar)
        {
            int centerX = (panelTitleBar.Width - lblTitle.Width) / 2;
            int centerY = (panelTitleBar.Height - lblTitle.Height) / 2;
            lblTitle.Location = new Point(centerX, centerY);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            OpenChildForm(loginForm, sender);
            CenterLabelInPanel(lblTitle, pnlTitle);
        }

        private void btnXLHSUngTuyen_Click(object sender, EventArgs e)
        {
            OpenChildForm(new XULYHOSOUNGTUYEN(), sender);
            CenterLabelInPanel(lblTitle, pnlTitle);
        }

        private void btnXemPDT_Click(object sender, EventArgs e)
        {
            OpenChildForm(new XemPhieuDangTuyen(), sender);
            CenterLabelInPanel(lblTitle, pnlTitle);
        }

        
    }
}
