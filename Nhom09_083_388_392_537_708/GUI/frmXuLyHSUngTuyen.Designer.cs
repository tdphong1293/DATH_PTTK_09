namespace GUI
{
    partial class frmXuLyHSUngTuyen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtgv_HSChoDuyet = new System.Windows.Forms.DataGridView();
            this.lb_HoTen = new System.Windows.Forms.Label();
            this.lb_NgaySinh = new System.Windows.Forms.Label();
            this.lb_Email = new System.Windows.Forms.Label();
            this.lb_TinhTrang = new System.Windows.Forms.Label();
            this.lb_NgayUngTuyen = new System.Windows.Forms.Label();
            this.lb_ViTriUngTuyen = new System.Windows.Forms.Label();
            this.lb_DiemDanhGia = new System.Windows.Forms.Label();
            this.pnl_TTCaNhan = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tb_Email = new System.Windows.Forms.TextBox();
            this.tb_NgaySinh = new System.Windows.Forms.TextBox();
            this.tb_HoTen = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_OutOf10 = new System.Windows.Forms.Label();
            this.btn_OpenFileCV = new System.Windows.Forms.Button();
            this.lb_FileCV = new System.Windows.Forms.Label();
            this.gb_BangCap = new System.Windows.Forms.GroupBox();
            this.btn_ThemBangCap = new System.Windows.Forms.Button();
            this.dtgv_BangCap = new System.Windows.Forms.DataGridView();
            this.tb_DoanhNghiepUngTuyen = new System.Windows.Forms.TextBox();
            this.lb_TenDoanhNghiep = new System.Windows.Forms.Label();
            this.tb_DiemDanhGia = new System.Windows.Forms.TextBox();
            this.tb_ViTriUngTuyen = new System.Windows.Forms.TextBox();
            this.tb_NgayUngTuyen = new System.Windows.Forms.TextBox();
            this.tb_TinhTrangUngTuyen = new System.Windows.Forms.TextBox();
            this.btn_Loai = new System.Windows.Forms.Button();
            this.btn_Duyet = new System.Windows.Forms.Button();
            this.lb_TimKiemDoanhNghiep1 = new System.Windows.Forms.Label();
            this.tb_SearchDN1 = new System.Windows.Forms.TextBox();
            this.gb_HSChoDuyet = new System.Windows.Forms.GroupBox();
            this.gb_HSDaDuyet = new System.Windows.Forms.GroupBox();
            this.dtgv_HSDaDuyet = new System.Windows.Forms.DataGridView();
            this.tb_SearchDN2 = new System.Windows.Forms.TextBox();
            this.lb_TimKiemDoanhNghiep2 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_HSChoDuyet)).BeginInit();
            this.pnl_TTCaNhan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.gb_BangCap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_BangCap)).BeginInit();
            this.gb_HSChoDuyet.SuspendLayout();
            this.gb_HSDaDuyet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_HSDaDuyet)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgv_HSChoDuyet
            // 
            this.dtgv_HSChoDuyet.AllowUserToAddRows = false;
            this.dtgv_HSChoDuyet.AllowUserToDeleteRows = false;
            this.dtgv_HSChoDuyet.BackgroundColor = System.Drawing.Color.White;
            this.dtgv_HSChoDuyet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_HSChoDuyet.Location = new System.Drawing.Point(20, 91);
            this.dtgv_HSChoDuyet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgv_HSChoDuyet.Name = "dtgv_HSChoDuyet";
            this.dtgv_HSChoDuyet.ReadOnly = true;
            this.dtgv_HSChoDuyet.RowHeadersWidth = 51;
            this.dtgv_HSChoDuyet.Size = new System.Drawing.Size(625, 222);
            this.dtgv_HSChoDuyet.TabIndex = 0;
            this.dtgv_HSChoDuyet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_HSChoDuyet_CellClick);
            // 
            // lb_HoTen
            // 
            this.lb_HoTen.AutoSize = true;
            this.lb_HoTen.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_HoTen.ForeColor = System.Drawing.Color.White;
            this.lb_HoTen.Location = new System.Drawing.Point(156, 20);
            this.lb_HoTen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_HoTen.Name = "lb_HoTen";
            this.lb_HoTen.Size = new System.Drawing.Size(75, 25);
            this.lb_HoTen.TabIndex = 1;
            this.lb_HoTen.Text = "Họ tên:";
            // 
            // lb_NgaySinh
            // 
            this.lb_NgaySinh.AutoSize = true;
            this.lb_NgaySinh.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_NgaySinh.ForeColor = System.Drawing.Color.White;
            this.lb_NgaySinh.Location = new System.Drawing.Point(156, 68);
            this.lb_NgaySinh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_NgaySinh.Name = "lb_NgaySinh";
            this.lb_NgaySinh.Size = new System.Drawing.Size(103, 25);
            this.lb_NgaySinh.TabIndex = 2;
            this.lb_NgaySinh.Text = "Ngày sinh:";
            // 
            // lb_Email
            // 
            this.lb_Email.AutoSize = true;
            this.lb_Email.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Email.ForeColor = System.Drawing.Color.White;
            this.lb_Email.Location = new System.Drawing.Point(156, 114);
            this.lb_Email.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Email.Name = "lb_Email";
            this.lb_Email.Size = new System.Drawing.Size(64, 25);
            this.lb_Email.TabIndex = 3;
            this.lb_Email.Text = "Email:";
            // 
            // lb_TinhTrang
            // 
            this.lb_TinhTrang.AutoSize = true;
            this.lb_TinhTrang.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TinhTrang.Location = new System.Drawing.Point(19, 64);
            this.lb_TinhTrang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_TinhTrang.Name = "lb_TinhTrang";
            this.lb_TinhTrang.Size = new System.Drawing.Size(198, 25);
            this.lb_TinhTrang.TabIndex = 5;
            this.lb_TinhTrang.Text = "Tình trạng ứng tuyển:";
            // 
            // lb_NgayUngTuyen
            // 
            this.lb_NgayUngTuyen.AutoSize = true;
            this.lb_NgayUngTuyen.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_NgayUngTuyen.Location = new System.Drawing.Point(19, 108);
            this.lb_NgayUngTuyen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_NgayUngTuyen.Name = "lb_NgayUngTuyen";
            this.lb_NgayUngTuyen.Size = new System.Drawing.Size(156, 25);
            this.lb_NgayUngTuyen.TabIndex = 6;
            this.lb_NgayUngTuyen.Text = "Ngày ứng tuyển:";
            // 
            // lb_ViTriUngTuyen
            // 
            this.lb_ViTriUngTuyen.AutoSize = true;
            this.lb_ViTriUngTuyen.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ViTriUngTuyen.Location = new System.Drawing.Point(19, 153);
            this.lb_ViTriUngTuyen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_ViTriUngTuyen.Name = "lb_ViTriUngTuyen";
            this.lb_ViTriUngTuyen.Size = new System.Drawing.Size(151, 25);
            this.lb_ViTriUngTuyen.TabIndex = 7;
            this.lb_ViTriUngTuyen.Text = "Vị trí ứng tuyển:";
            // 
            // lb_DiemDanhGia
            // 
            this.lb_DiemDanhGia.AutoSize = true;
            this.lb_DiemDanhGia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_DiemDanhGia.ForeColor = System.Drawing.Color.Red;
            this.lb_DiemDanhGia.Location = new System.Drawing.Point(291, 431);
            this.lb_DiemDanhGia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_DiemDanhGia.Name = "lb_DiemDanhGia";
            this.lb_DiemDanhGia.Size = new System.Drawing.Size(156, 28);
            this.lb_DiemDanhGia.TabIndex = 8;
            this.lb_DiemDanhGia.Text = "Điểm đánh giá:";
            // 
            // pnl_TTCaNhan
            // 
            this.pnl_TTCaNhan.BackColor = System.Drawing.Color.SlateBlue;
            this.pnl_TTCaNhan.Controls.Add(this.pictureBox1);
            this.pnl_TTCaNhan.Controls.Add(this.tb_Email);
            this.pnl_TTCaNhan.Controls.Add(this.tb_NgaySinh);
            this.pnl_TTCaNhan.Controls.Add(this.tb_HoTen);
            this.pnl_TTCaNhan.Controls.Add(this.lb_HoTen);
            this.pnl_TTCaNhan.Controls.Add(this.lb_NgaySinh);
            this.pnl_TTCaNhan.Controls.Add(this.lb_Email);
            this.pnl_TTCaNhan.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnl_TTCaNhan.Location = new System.Drawing.Point(723, 23);
            this.pnl_TTCaNhan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnl_TTCaNhan.Name = "pnl_TTCaNhan";
            this.pnl_TTCaNhan.Size = new System.Drawing.Size(567, 161);
            this.pnl_TTCaNhan.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GUI.Properties.Resources.User_Icon;
            this.pictureBox1.Location = new System.Drawing.Point(4, 32);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // tb_Email
            // 
            this.tb_Email.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Email.Location = new System.Drawing.Point(292, 114);
            this.tb_Email.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_Email.Name = "tb_Email";
            this.tb_Email.ReadOnly = true;
            this.tb_Email.Size = new System.Drawing.Size(235, 32);
            this.tb_Email.TabIndex = 13;
            // 
            // tb_NgaySinh
            // 
            this.tb_NgaySinh.Enabled = false;
            this.tb_NgaySinh.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_NgaySinh.Location = new System.Drawing.Point(292, 68);
            this.tb_NgaySinh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_NgaySinh.Name = "tb_NgaySinh";
            this.tb_NgaySinh.ReadOnly = true;
            this.tb_NgaySinh.Size = new System.Drawing.Size(235, 32);
            this.tb_NgaySinh.TabIndex = 12;
            // 
            // tb_HoTen
            // 
            this.tb_HoTen.Enabled = false;
            this.tb_HoTen.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_HoTen.Location = new System.Drawing.Point(292, 20);
            this.tb_HoTen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_HoTen.Name = "tb_HoTen";
            this.tb_HoTen.ReadOnly = true;
            this.tb_HoTen.Size = new System.Drawing.Size(235, 32);
            this.tb_HoTen.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OldLace;
            this.panel1.Controls.Add(this.lb_OutOf10);
            this.panel1.Controls.Add(this.btn_OpenFileCV);
            this.panel1.Controls.Add(this.lb_FileCV);
            this.panel1.Controls.Add(this.gb_BangCap);
            this.panel1.Controls.Add(this.tb_DoanhNghiepUngTuyen);
            this.panel1.Controls.Add(this.lb_TenDoanhNghiep);
            this.panel1.Controls.Add(this.tb_DiemDanhGia);
            this.panel1.Controls.Add(this.tb_ViTriUngTuyen);
            this.panel1.Controls.Add(this.tb_NgayUngTuyen);
            this.panel1.Controls.Add(this.tb_TinhTrangUngTuyen);
            this.panel1.Controls.Add(this.lb_TinhTrang);
            this.panel1.Controls.Add(this.lb_NgayUngTuyen);
            this.panel1.Controls.Add(this.lb_DiemDanhGia);
            this.panel1.Controls.Add(this.lb_ViTriUngTuyen);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(723, 178);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(567, 482);
            this.panel1.TabIndex = 11;
            // 
            // lb_OutOf10
            // 
            this.lb_OutOf10.AutoSize = true;
            this.lb_OutOf10.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_OutOf10.Location = new System.Drawing.Point(495, 434);
            this.lb_OutOf10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_OutOf10.Name = "lb_OutOf10";
            this.lb_OutOf10.Size = new System.Drawing.Size(39, 25);
            this.lb_OutOf10.TabIndex = 24;
            this.lb_OutOf10.Text = "/10";
            // 
            // btn_OpenFileCV
            // 
            this.btn_OpenFileCV.Enabled = false;
            this.btn_OpenFileCV.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OpenFileCV.Location = new System.Drawing.Point(292, 190);
            this.btn_OpenFileCV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_OpenFileCV.Name = "btn_OpenFileCV";
            this.btn_OpenFileCV.Size = new System.Drawing.Size(127, 39);
            this.btn_OpenFileCV.TabIndex = 23;
            this.btn_OpenFileCV.Text = "Mở file ⏬";
            this.btn_OpenFileCV.UseVisualStyleBackColor = true;
            // 
            // lb_FileCV
            // 
            this.lb_FileCV.AutoSize = true;
            this.lb_FileCV.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_FileCV.Location = new System.Drawing.Point(19, 197);
            this.lb_FileCV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_FileCV.Name = "lb_FileCV";
            this.lb_FileCV.Size = new System.Drawing.Size(156, 25);
            this.lb_FileCV.TabIndex = 22;
            this.lb_FileCV.Text = "File CV ứng viên:";
            // 
            // gb_BangCap
            // 
            this.gb_BangCap.Controls.Add(this.btn_ThemBangCap);
            this.gb_BangCap.Controls.Add(this.dtgv_BangCap);
            this.gb_BangCap.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_BangCap.Location = new System.Drawing.Point(11, 236);
            this.gb_BangCap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_BangCap.Name = "gb_BangCap";
            this.gb_BangCap.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_BangCap.Size = new System.Drawing.Size(523, 186);
            this.gb_BangCap.TabIndex = 21;
            this.gb_BangCap.TabStop = false;
            this.gb_BangCap.Text = "Bằng cấp";
            // 
            // btn_ThemBangCap
            // 
            this.btn_ThemBangCap.BackgroundImage = global::GUI.Properties.Resources.btn_plus;
            this.btn_ThemBangCap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ThemBangCap.Enabled = false;
            this.btn_ThemBangCap.Location = new System.Drawing.Point(477, 18);
            this.btn_ThemBangCap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_ThemBangCap.Name = "btn_ThemBangCap";
            this.btn_ThemBangCap.Size = new System.Drawing.Size(32, 30);
            this.btn_ThemBangCap.TabIndex = 24;
            this.btn_ThemBangCap.UseVisualStyleBackColor = true;
            this.btn_ThemBangCap.Click += new System.EventHandler(this.btn_ThemBangCap_Click);
            // 
            // dtgv_BangCap
            // 
            this.dtgv_BangCap.AllowUserToAddRows = false;
            this.dtgv_BangCap.AllowUserToDeleteRows = false;
            this.dtgv_BangCap.BackgroundColor = System.Drawing.Color.White;
            this.dtgv_BangCap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_BangCap.Location = new System.Drawing.Point(16, 55);
            this.dtgv_BangCap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgv_BangCap.Name = "dtgv_BangCap";
            this.dtgv_BangCap.ReadOnly = true;
            this.dtgv_BangCap.RowHeadersWidth = 51;
            this.dtgv_BangCap.Size = new System.Drawing.Size(493, 118);
            this.dtgv_BangCap.TabIndex = 24;
            // 
            // tb_DoanhNghiepUngTuyen
            // 
            this.tb_DoanhNghiepUngTuyen.Enabled = false;
            this.tb_DoanhNghiepUngTuyen.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_DoanhNghiepUngTuyen.ForeColor = System.Drawing.Color.Black;
            this.tb_DoanhNghiepUngTuyen.Location = new System.Drawing.Point(292, 17);
            this.tb_DoanhNghiepUngTuyen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_DoanhNghiepUngTuyen.Name = "tb_DoanhNghiepUngTuyen";
            this.tb_DoanhNghiepUngTuyen.ReadOnly = true;
            this.tb_DoanhNghiepUngTuyen.Size = new System.Drawing.Size(235, 32);
            this.tb_DoanhNghiepUngTuyen.TabIndex = 20;
            // 
            // lb_TenDoanhNghiep
            // 
            this.lb_TenDoanhNghiep.AutoSize = true;
            this.lb_TenDoanhNghiep.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TenDoanhNghiep.Location = new System.Drawing.Point(19, 21);
            this.lb_TenDoanhNghiep.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_TenDoanhNghiep.Name = "lb_TenDoanhNghiep";
            this.lb_TenDoanhNghiep.Size = new System.Drawing.Size(231, 25);
            this.lb_TenDoanhNghiep.TabIndex = 19;
            this.lb_TenDoanhNghiep.Text = "Doanh nghiệp ứng tuyển:";
            // 
            // tb_DiemDanhGia
            // 
            this.tb_DiemDanhGia.Enabled = false;
            this.tb_DiemDanhGia.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_DiemDanhGia.Location = new System.Drawing.Point(455, 431);
            this.tb_DiemDanhGia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_DiemDanhGia.Name = "tb_DiemDanhGia";
            this.tb_DiemDanhGia.Size = new System.Drawing.Size(35, 31);
            this.tb_DiemDanhGia.TabIndex = 18;
            this.tb_DiemDanhGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb_ViTriUngTuyen
            // 
            this.tb_ViTriUngTuyen.Enabled = false;
            this.tb_ViTriUngTuyen.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_ViTriUngTuyen.Location = new System.Drawing.Point(292, 149);
            this.tb_ViTriUngTuyen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_ViTriUngTuyen.Name = "tb_ViTriUngTuyen";
            this.tb_ViTriUngTuyen.ReadOnly = true;
            this.tb_ViTriUngTuyen.Size = new System.Drawing.Size(231, 32);
            this.tb_ViTriUngTuyen.TabIndex = 17;
            // 
            // tb_NgayUngTuyen
            // 
            this.tb_NgayUngTuyen.Enabled = false;
            this.tb_NgayUngTuyen.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_NgayUngTuyen.Location = new System.Drawing.Point(292, 105);
            this.tb_NgayUngTuyen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_NgayUngTuyen.Name = "tb_NgayUngTuyen";
            this.tb_NgayUngTuyen.ReadOnly = true;
            this.tb_NgayUngTuyen.Size = new System.Drawing.Size(235, 32);
            this.tb_NgayUngTuyen.TabIndex = 16;
            // 
            // tb_TinhTrangUngTuyen
            // 
            this.tb_TinhTrangUngTuyen.BackColor = System.Drawing.SystemColors.Control;
            this.tb_TinhTrangUngTuyen.Enabled = false;
            this.tb_TinhTrangUngTuyen.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_TinhTrangUngTuyen.Location = new System.Drawing.Point(292, 60);
            this.tb_TinhTrangUngTuyen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_TinhTrangUngTuyen.Name = "tb_TinhTrangUngTuyen";
            this.tb_TinhTrangUngTuyen.ReadOnly = true;
            this.tb_TinhTrangUngTuyen.Size = new System.Drawing.Size(235, 32);
            this.tb_TinhTrangUngTuyen.TabIndex = 15;
            // 
            // btn_Loai
            // 
            this.btn_Loai.Enabled = false;
            this.btn_Loai.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Loai.ForeColor = System.Drawing.Color.Red;
            this.btn_Loai.Location = new System.Drawing.Point(1015, 668);
            this.btn_Loai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Loai.Name = "btn_Loai";
            this.btn_Loai.Size = new System.Drawing.Size(123, 43);
            this.btn_Loai.TabIndex = 12;
            this.btn_Loai.Text = "LOẠI";
            this.btn_Loai.UseVisualStyleBackColor = true;
            // 
            // btn_Duyet
            // 
            this.btn_Duyet.Enabled = false;
            this.btn_Duyet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Duyet.ForeColor = System.Drawing.Color.ForestGreen;
            this.btn_Duyet.Location = new System.Drawing.Point(885, 668);
            this.btn_Duyet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Duyet.Name = "btn_Duyet";
            this.btn_Duyet.Size = new System.Drawing.Size(123, 43);
            this.btn_Duyet.TabIndex = 14;
            this.btn_Duyet.Text = "DUYỆT";
            this.btn_Duyet.UseVisualStyleBackColor = true;
            this.btn_Duyet.Click += new System.EventHandler(this.btn_Duyet_Click);
            // 
            // lb_TimKiemDoanhNghiep1
            // 
            this.lb_TimKiemDoanhNghiep1.AutoSize = true;
            this.lb_TimKiemDoanhNghiep1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TimKiemDoanhNghiep1.Location = new System.Drawing.Point(221, 57);
            this.lb_TimKiemDoanhNghiep1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_TimKiemDoanhNghiep1.Name = "lb_TimKiemDoanhNghiep1";
            this.lb_TimKiemDoanhNghiep1.Size = new System.Drawing.Size(207, 25);
            this.lb_TimKiemDoanhNghiep1.TabIndex = 21;
            this.lb_TimKiemDoanhNghiep1.Text = "Tìm tên doanh nghiệp:";
            // 
            // tb_SearchDN1
            // 
            this.tb_SearchDN1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_SearchDN1.Location = new System.Drawing.Point(452, 50);
            this.tb_SearchDN1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_SearchDN1.Name = "tb_SearchDN1";
            this.tb_SearchDN1.Size = new System.Drawing.Size(192, 32);
            this.tb_SearchDN1.TabIndex = 21;
            this.tb_SearchDN1.TextChanged += new System.EventHandler(this.tb_SearchDN1_TextChanged);
            // 
            // gb_HSChoDuyet
            // 
            this.gb_HSChoDuyet.Controls.Add(this.dtgv_HSChoDuyet);
            this.gb_HSChoDuyet.Controls.Add(this.tb_SearchDN1);
            this.gb_HSChoDuyet.Controls.Add(this.lb_TimKiemDoanhNghiep1);
            this.gb_HSChoDuyet.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_HSChoDuyet.Location = new System.Drawing.Point(16, 25);
            this.gb_HSChoDuyet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_HSChoDuyet.Name = "gb_HSChoDuyet";
            this.gb_HSChoDuyet.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_HSChoDuyet.Size = new System.Drawing.Size(665, 326);
            this.gb_HSChoDuyet.TabIndex = 22;
            this.gb_HSChoDuyet.TabStop = false;
            this.gb_HSChoDuyet.Text = "Hồ sơ ứng tuyển chờ duyệt";
            // 
            // gb_HSDaDuyet
            // 
            this.gb_HSDaDuyet.Controls.Add(this.dtgv_HSDaDuyet);
            this.gb_HSDaDuyet.Controls.Add(this.tb_SearchDN2);
            this.gb_HSDaDuyet.Controls.Add(this.lb_TimKiemDoanhNghiep2);
            this.gb_HSDaDuyet.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_HSDaDuyet.Location = new System.Drawing.Point(16, 384);
            this.gb_HSDaDuyet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_HSDaDuyet.Name = "gb_HSDaDuyet";
            this.gb_HSDaDuyet.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_HSDaDuyet.Size = new System.Drawing.Size(665, 326);
            this.gb_HSDaDuyet.TabIndex = 23;
            this.gb_HSDaDuyet.TabStop = false;
            this.gb_HSDaDuyet.Text = "Hồ sơ ứng tuyển đã duyệt";
            // 
            // dtgv_HSDaDuyet
            // 
            this.dtgv_HSDaDuyet.AllowUserToAddRows = false;
            this.dtgv_HSDaDuyet.AllowUserToDeleteRows = false;
            this.dtgv_HSDaDuyet.BackgroundColor = System.Drawing.Color.White;
            this.dtgv_HSDaDuyet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_HSDaDuyet.Location = new System.Drawing.Point(20, 91);
            this.dtgv_HSDaDuyet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgv_HSDaDuyet.Name = "dtgv_HSDaDuyet";
            this.dtgv_HSDaDuyet.ReadOnly = true;
            this.dtgv_HSDaDuyet.RowHeadersWidth = 51;
            this.dtgv_HSDaDuyet.Size = new System.Drawing.Size(625, 222);
            this.dtgv_HSDaDuyet.TabIndex = 0;
            this.dtgv_HSDaDuyet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_HSDaDuyet_CellClick);
            // 
            // tb_SearchDN2
            // 
            this.tb_SearchDN2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_SearchDN2.Location = new System.Drawing.Point(452, 50);
            this.tb_SearchDN2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tb_SearchDN2.Name = "tb_SearchDN2";
            this.tb_SearchDN2.Size = new System.Drawing.Size(192, 32);
            this.tb_SearchDN2.TabIndex = 21;
            this.tb_SearchDN2.TextChanged += new System.EventHandler(this.tb_SearchDN2_TextChanged);
            // 
            // lb_TimKiemDoanhNghiep2
            // 
            this.lb_TimKiemDoanhNghiep2.AutoSize = true;
            this.lb_TimKiemDoanhNghiep2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TimKiemDoanhNghiep2.Location = new System.Drawing.Point(221, 57);
            this.lb_TimKiemDoanhNghiep2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_TimKiemDoanhNghiep2.Name = "lb_TimKiemDoanhNghiep2";
            this.lb_TimKiemDoanhNghiep2.Size = new System.Drawing.Size(207, 25);
            this.lb_TimKiemDoanhNghiep2.TabIndex = 21;
            this.lb_TimKiemDoanhNghiep2.Text = "Tìm tên doanh nghiệp:";
            // 
            // frmXuLyHSUngTuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 735);
            this.Controls.Add(this.gb_HSDaDuyet);
            this.Controls.Add(this.gb_HSChoDuyet);
            this.Controls.Add(this.btn_Duyet);
            this.Controls.Add(this.btn_Loai);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_TTCaNhan);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmXuLyHSUngTuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XỬ LÝ HỒ SƠ ỨNG TUYỂN";
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_HSChoDuyet)).EndInit();
            this.pnl_TTCaNhan.ResumeLayout(false);
            this.pnl_TTCaNhan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gb_BangCap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_BangCap)).EndInit();
            this.gb_HSChoDuyet.ResumeLayout(false);
            this.gb_HSChoDuyet.PerformLayout();
            this.gb_HSDaDuyet.ResumeLayout(false);
            this.gb_HSDaDuyet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_HSDaDuyet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgv_HSChoDuyet;
        private System.Windows.Forms.Label lb_HoTen;
        private System.Windows.Forms.Label lb_NgaySinh;
        private System.Windows.Forms.Label lb_Email;
        private System.Windows.Forms.Label lb_TinhTrang;
        private System.Windows.Forms.Label lb_NgayUngTuyen;
        private System.Windows.Forms.Label lb_ViTriUngTuyen;
        private System.Windows.Forms.Label lb_DiemDanhGia;
        private System.Windows.Forms.Panel pnl_TTCaNhan;
        private System.Windows.Forms.TextBox tb_Email;
        private System.Windows.Forms.TextBox tb_NgaySinh;
        private System.Windows.Forms.TextBox tb_HoTen;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_DiemDanhGia;
        private System.Windows.Forms.TextBox tb_ViTriUngTuyen;
        private System.Windows.Forms.TextBox tb_NgayUngTuyen;
        private System.Windows.Forms.TextBox tb_TinhTrangUngTuyen;
        private System.Windows.Forms.Label lb_TenDoanhNghiep;
        private System.Windows.Forms.TextBox tb_DoanhNghiepUngTuyen;
        private System.Windows.Forms.Button btn_Loai;
        private System.Windows.Forms.Button btn_Duyet;
        private System.Windows.Forms.Label lb_TimKiemDoanhNghiep1;
        private System.Windows.Forms.TextBox tb_SearchDN1;
        private System.Windows.Forms.GroupBox gb_HSChoDuyet;
        private System.Windows.Forms.GroupBox gb_HSDaDuyet;
        private System.Windows.Forms.DataGridView dtgv_HSDaDuyet;
        private System.Windows.Forms.TextBox tb_SearchDN2;
        private System.Windows.Forms.Label lb_TimKiemDoanhNghiep2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox gb_BangCap;
        private System.Windows.Forms.DataGridView dtgv_BangCap;
        private System.Windows.Forms.Button btn_ThemBangCap;
        private System.Windows.Forms.Label lb_FileCV;
        private System.Windows.Forms.Button btn_OpenFileCV;
        private System.Windows.Forms.Label lb_OutOf10;
    }
}

