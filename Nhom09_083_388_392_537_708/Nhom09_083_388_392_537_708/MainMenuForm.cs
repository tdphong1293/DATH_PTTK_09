using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        public string username = "";
        public string role = "";
        public string id = "";
        Font SegoeUISemibold = new Font("Segoe UI Semibold", 11F);
        Font SegoeUIBold = new Font("Segoe UI", 12F, FontStyle.Bold);
        public static SqlConnection con = FormDangNhap.conn;
        public MainMenuForm()
        {
            InitializeComponent();
            random = new Random();
        }

        public MainMenuForm(string username, string role, string id)
        {
            InitializeComponent();
            random = new Random();
            this.username = username;
            this.role = role;
            this.id = id;
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
            if (activeForm != null && activeForm.GetType() == childForm.GetType())
            {
                childForm = activeForm;
            }
            else
            {
                //if (activeForm != null)
                //    activeForm.Close();

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
            btnNHSTD.Visible = false;
            btnLogout.Visible = false;
            ActivateButton(btnLogin);
            CenterLabelInPanel(lblTitle, pnlTitle);
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
                role = roleEventArgs.Role.Trim();
                username = roleEventArgs.username.Trim();
                id = roleEventArgs.id.Trim();
                if (role == "NHANVIEN")
                {
                    string nv_role = "";
                    using (SqlCommand cmd = new SqlCommand("checkNhanVien", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nv_role = reader["VaiTro"].ToString();
                            }
                        }
                    }

                    if (nv_role == "Nhân viên cơ bản")
                    {
                        pnlHomeChange.Controls.Clear();
                        btnXemPDT.Visible = true;
                        btnXLDTD.Visible = true;
                        btnXLHSUngTuyen.Visible = true;
                        btnThanhToan.Visible = true;
                        btnLogin.Visible = false;
                        btnSignupUV.Visible = false;
                        btnSignupDN.Visible = false;
                        btnDangTuyenDung.Visible = false;
                        btnDuyetHSDaQuaXL.Visible = false;
                        btnGiaHanHD.Visible = false;
                        btnNHSTD.Visible = false;
                        btnLogout.Visible = true;
                        ActivateButton(btnXLDTD);
                        DOANHNGHIEP_TIEMNANG dntn = new DOANHNGHIEP_TIEMNANG();
                        dntn.TopLevel = false;
                        dntn.FormBorderStyle = FormBorderStyle.None;
                        dntn.Dock = DockStyle.Fill;
                        pnlHomeChange.Controls.Add(dntn);
                        dntn.Show();
                    }
                    else if (nv_role == "Ban lãnh đạo")
                    {
                        pnlHomeChange.Controls.Clear();
                        btnGiaHanHD.Visible = true;
                        btnXemPDT.Visible = false;
                        btnXLDTD.Visible = false;
                        btnXLHSUngTuyen.Visible = false;
                        btnThanhToan.Visible = false;
                        btnLogin.Visible = false;
                        btnSignupUV.Visible = false;
                        btnSignupDN.Visible = false;
                        btnDangTuyenDung.Visible = false;
                        btnDuyetHSDaQuaXL.Visible = false;
                        btnNHSTD.Visible = false;
                        btnLogout.Visible = true;
                        ActivateButton(btnGiaHanHD);
                        FormGiaHanHopDong gh = new FormGiaHanHopDong();
                        gh.TopLevel = false;
                        gh.FormBorderStyle = FormBorderStyle.None;
                        gh.Dock = DockStyle.Fill;
                        pnlHomeChange.Controls.Add(gh);
                        gh.Show();
                    }
                }

                else if (role == "DOANHNGHIEP")
                {
                    pnlHomeChange.Controls.Clear();
                    btnDangTuyenDung.Visible=true;
                    btnDuyetHSDaQuaXL.Visible = true;
                    btnXemPDT.Visible = true;
                    btnLogin.Visible = false;
                    btnSignupUV.Visible = false;
                    btnSignupDN.Visible = false;
                    btnXLHSUngTuyen.Visible = false;
                    btnThanhToan.Visible = false;
                    btnGiaHanHD.Visible = false;
                    btnNHSTD.Visible = false;
                    btnLogout.Visible = true;
                    ActivateButton(btnXemPDT);
                    FormDangTuyenDung formDangTuyenDung = new FormDangTuyenDung();
                    formDangTuyenDung.TopLevel = false;
                    formDangTuyenDung.FormBorderStyle = FormBorderStyle.None;
                    formDangTuyenDung.Dock = DockStyle.Fill;
                    pnlHomeChange.Controls.Add(formDangTuyenDung);
                    formDangTuyenDung.Show();
                    //MessageBox.Show(id);
                }

                else if (role == "UNGVIEN")
                {
                    pnlHomeChange.Controls.Clear();
                    btnDangTuyenDung.Visible = false;
                    btnDuyetHSDaQuaXL.Visible = false;
                    btnXemPDT.Visible = true;
                    btnLogin.Visible = false;
                    btnSignupUV.Visible = false;
                    btnSignupDN.Visible = false;
                    btnXLHSUngTuyen.Visible = false;
                    btnThanhToan.Visible = false;
                    btnGiaHanHD.Visible = false;
                    btnNHSTD.Visible = true;
                    btnLogout.Visible = true;
                    NopHoSoUngTuyen nhs = new NopHoSoUngTuyen();
                    nhs.TopLevel = false;
                    nhs.FormBorderStyle = FormBorderStyle.None;
                    nhs.Dock = DockStyle.Fill;
                    pnlHomeChange.Controls.Add(nhs);
                    nhs.Show();
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

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new THANHTOAN(), sender);
            CenterLabelInPanel(lblTitle, pnlTitle);
        }

        private void btnXemPDT_Click(object sender, EventArgs e)
        {
            OpenChildForm(new XemPhieuDangTuyen(), sender);
            CenterLabelInPanel(lblTitle, pnlTitle);
        }

        
        private void btnXLDTD_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DOANHNGHIEP_TIEMNANG(), sender);
            CenterLabelInPanel(lblTitle, pnlTitle);
        }

        private void btnDangTuyenDung_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDangTuyenDung(username, id), sender);
            CenterLabelInPanel(lblTitle, pnlTitle);
        }

        private void btnSignupDN_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDangKyDoanhNghiep(), sender);
            CenterLabelInPanel(lblTitle, pnlTitle);
        }

        private void btnSignupUV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDangKyUngVien(), sender);
            CenterLabelInPanel(lblTitle, pnlTitle);
        }

        private void btnGiaHanHD_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormGiaHanHopDong(), sender);
            CenterLabelInPanel(lblTitle, pnlTitle);
        }

        private void btnDuyetHSDaQuaXL_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DUYET_HS_UNGTUYEN(id), sender);
            CenterLabelInPanel(lblTitle, pnlTitle);
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            con.Close();
            pnlHomeChange.Controls.Clear();
            btnDangTuyenDung.Visible = false;
            btnXemPDT.Visible = false;
            btnDuyetHSDaQuaXL.Visible = false;
            btnXLDTD.Visible = false;
            btnXLHSUngTuyen.Visible = false;
            btnThanhToan.Visible = false;
            btnGiaHanHD.Visible = false;
            btnNHSTD.Visible = false;
            btnLogout.Visible = false;
            btnLogin.Visible = true;
            btnSignupDN.Visible = true;
            btnSignupUV.Visible = true;
            ActivateButton(btnLogin);
            CenterLabelInPanel(lblTitle, pnlTitle);
            loginForm = new FormDangNhap();
            loginForm.ButtonClicked += UI_After_Login;
            loginForm.TopLevel = false;
            loginForm.FormBorderStyle = FormBorderStyle.None;
            loginForm.Dock = DockStyle.Fill;
            pnlHomeChange.Controls.Add(loginForm);
            loginForm.Show();
        }



        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            Application.Exit();
        }
    }
}
