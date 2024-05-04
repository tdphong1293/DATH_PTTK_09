namespace GUI
{
    partial class frmGiaHanHopDong
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
                debounceTimer.Dispose();
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
            this.panel_FormGiaHanHopDong = new System.Windows.Forms.Panel();
            this.grpbox_dn = new System.Windows.Forms.GroupBox();
            this.txt_discount_dn = new System.Windows.Forms.TextBox();
            this.lb_discount_dn = new System.Windows.Forms.Label();
            this.txt_diachi_dn = new System.Windows.Forms.TextBox();
            this.txt_daidien_dn = new System.Windows.Forms.TextBox();
            this.txt_tax_dn = new System.Windows.Forms.TextBox();
            this.lb_diachi_dn = new System.Windows.Forms.Label();
            this.lb_daidien_dn = new System.Windows.Forms.Label();
            this.lb_tax_dn = new System.Windows.Forms.Label();
            this.txt_email_dn = new System.Windows.Forms.TextBox();
            this.txt_name_dn = new System.Windows.Forms.TextBox();
            this.lb_email_dn = new System.Windows.Forms.Label();
            this.lb_name_dn = new System.Windows.Forms.Label();
            this.btn_luudiscount = new System.Windows.Forms.Button();
            this.status_bar = new System.Windows.Forms.StatusStrip();
            this.status_itemselect = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_timkiem_dn = new System.Windows.Forms.Label();
            this.txt_timkiem = new System.Windows.Forms.TextBox();
            this.lb_dtgv = new System.Windows.Forms.Label();
            this.dtgv_KetQuaTuyenDung = new System.Windows.Forms.DataGridView();
            this.lb_explain = new System.Windows.Forms.Label();
            this.lb_FormGiaHanHopDong = new System.Windows.Forms.Label();
            this.panel_FormGiaHanHopDong.SuspendLayout();
            this.grpbox_dn.SuspendLayout();
            this.status_bar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_KetQuaTuyenDung)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_FormGiaHanHopDong
            // 
            this.panel_FormGiaHanHopDong.BackColor = System.Drawing.Color.OldLace;
            this.panel_FormGiaHanHopDong.Controls.Add(this.grpbox_dn);
            this.panel_FormGiaHanHopDong.Controls.Add(this.btn_luudiscount);
            this.panel_FormGiaHanHopDong.Controls.Add(this.status_bar);
            this.panel_FormGiaHanHopDong.Controls.Add(this.lb_timkiem_dn);
            this.panel_FormGiaHanHopDong.Controls.Add(this.txt_timkiem);
            this.panel_FormGiaHanHopDong.Controls.Add(this.lb_dtgv);
            this.panel_FormGiaHanHopDong.Controls.Add(this.dtgv_KetQuaTuyenDung);
            this.panel_FormGiaHanHopDong.Controls.Add(this.lb_explain);
            this.panel_FormGiaHanHopDong.Controls.Add(this.lb_FormGiaHanHopDong);
            this.panel_FormGiaHanHopDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_FormGiaHanHopDong.Location = new System.Drawing.Point(0, 0);
            this.panel_FormGiaHanHopDong.Name = "panel_FormGiaHanHopDong";
            this.panel_FormGiaHanHopDong.Size = new System.Drawing.Size(1000, 561);
            this.panel_FormGiaHanHopDong.TabIndex = 0;
            // 
            // grpbox_dn
            // 
            this.grpbox_dn.BackColor = System.Drawing.Color.Cornsilk;
            this.grpbox_dn.Controls.Add(this.txt_discount_dn);
            this.grpbox_dn.Controls.Add(this.lb_discount_dn);
            this.grpbox_dn.Controls.Add(this.txt_diachi_dn);
            this.grpbox_dn.Controls.Add(this.txt_daidien_dn);
            this.grpbox_dn.Controls.Add(this.txt_tax_dn);
            this.grpbox_dn.Controls.Add(this.lb_diachi_dn);
            this.grpbox_dn.Controls.Add(this.lb_daidien_dn);
            this.grpbox_dn.Controls.Add(this.lb_tax_dn);
            this.grpbox_dn.Controls.Add(this.txt_email_dn);
            this.grpbox_dn.Controls.Add(this.txt_name_dn);
            this.grpbox_dn.Controls.Add(this.lb_email_dn);
            this.grpbox_dn.Controls.Add(this.lb_name_dn);
            this.grpbox_dn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbox_dn.Location = new System.Drawing.Point(570, 134);
            this.grpbox_dn.Name = "grpbox_dn";
            this.grpbox_dn.Size = new System.Drawing.Size(418, 324);
            this.grpbox_dn.TabIndex = 1;
            this.grpbox_dn.TabStop = false;
            this.grpbox_dn.Text = "Thông tin chi tiết Doanh Nghiệp";
            // 
            // txt_discount_dn
            // 
            this.txt_discount_dn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_discount_dn.Location = new System.Drawing.Point(162, 277);
            this.txt_discount_dn.Name = "txt_discount_dn";
            this.txt_discount_dn.Size = new System.Drawing.Size(250, 27);
            this.txt_discount_dn.TabIndex = 1;
            // 
            // lb_discount_dn
            // 
            this.lb_discount_dn.AutoSize = true;
            this.lb_discount_dn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_discount_dn.Location = new System.Drawing.Point(11, 277);
            this.lb_discount_dn.Name = "lb_discount_dn";
            this.lb_discount_dn.Size = new System.Drawing.Size(131, 20);
            this.lb_discount_dn.TabIndex = 75;
            this.lb_discount_dn.Text = "Ưu đãi (%) (0 - 50)";
            // 
            // txt_diachi_dn
            // 
            this.txt_diachi_dn.Cursor = System.Windows.Forms.Cursors.No;
            this.txt_diachi_dn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_diachi_dn.Location = new System.Drawing.Point(162, 226);
            this.txt_diachi_dn.Name = "txt_diachi_dn";
            this.txt_diachi_dn.ReadOnly = true;
            this.txt_diachi_dn.Size = new System.Drawing.Size(250, 27);
            this.txt_diachi_dn.TabIndex = 69;
            this.txt_diachi_dn.TabStop = false;
            // 
            // txt_daidien_dn
            // 
            this.txt_daidien_dn.Cursor = System.Windows.Forms.Cursors.No;
            this.txt_daidien_dn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_daidien_dn.Location = new System.Drawing.Point(162, 178);
            this.txt_daidien_dn.Name = "txt_daidien_dn";
            this.txt_daidien_dn.ReadOnly = true;
            this.txt_daidien_dn.Size = new System.Drawing.Size(250, 27);
            this.txt_daidien_dn.TabIndex = 68;
            this.txt_daidien_dn.TabStop = false;
            // 
            // txt_tax_dn
            // 
            this.txt_tax_dn.Cursor = System.Windows.Forms.Cursors.No;
            this.txt_tax_dn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_tax_dn.Location = new System.Drawing.Point(162, 130);
            this.txt_tax_dn.Name = "txt_tax_dn";
            this.txt_tax_dn.ReadOnly = true;
            this.txt_tax_dn.Size = new System.Drawing.Size(250, 27);
            this.txt_tax_dn.TabIndex = 67;
            this.txt_tax_dn.TabStop = false;
            // 
            // lb_diachi_dn
            // 
            this.lb_diachi_dn.AutoSize = true;
            this.lb_diachi_dn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_diachi_dn.Location = new System.Drawing.Point(11, 226);
            this.lb_diachi_dn.Name = "lb_diachi_dn";
            this.lb_diachi_dn.Size = new System.Drawing.Size(108, 20);
            this.lb_diachi_dn.TabIndex = 74;
            this.lb_diachi_dn.Text = "Địa chỉ công ty";
            // 
            // lb_daidien_dn
            // 
            this.lb_daidien_dn.AutoSize = true;
            this.lb_daidien_dn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_daidien_dn.Location = new System.Drawing.Point(12, 178);
            this.lb_daidien_dn.Name = "lb_daidien_dn";
            this.lb_daidien_dn.Size = new System.Drawing.Size(109, 20);
            this.lb_daidien_dn.TabIndex = 73;
            this.lb_daidien_dn.Text = "Người đại diện";
            // 
            // lb_tax_dn
            // 
            this.lb_tax_dn.AutoSize = true;
            this.lb_tax_dn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_tax_dn.Location = new System.Drawing.Point(12, 130);
            this.lb_tax_dn.Name = "lb_tax_dn";
            this.lb_tax_dn.Size = new System.Drawing.Size(82, 20);
            this.lb_tax_dn.TabIndex = 72;
            this.lb_tax_dn.Text = "Mã số thuế";
            // 
            // txt_email_dn
            // 
            this.txt_email_dn.Cursor = System.Windows.Forms.Cursors.No;
            this.txt_email_dn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_email_dn.Location = new System.Drawing.Point(162, 81);
            this.txt_email_dn.Name = "txt_email_dn";
            this.txt_email_dn.ReadOnly = true;
            this.txt_email_dn.Size = new System.Drawing.Size(250, 27);
            this.txt_email_dn.TabIndex = 66;
            this.txt_email_dn.TabStop = false;
            // 
            // txt_name_dn
            // 
            this.txt_name_dn.Cursor = System.Windows.Forms.Cursors.No;
            this.txt_name_dn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_name_dn.Location = new System.Drawing.Point(162, 32);
            this.txt_name_dn.Name = "txt_name_dn";
            this.txt_name_dn.ReadOnly = true;
            this.txt_name_dn.Size = new System.Drawing.Size(250, 27);
            this.txt_name_dn.TabIndex = 65;
            this.txt_name_dn.TabStop = false;
            // 
            // lb_email_dn
            // 
            this.lb_email_dn.AutoSize = true;
            this.lb_email_dn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_email_dn.Location = new System.Drawing.Point(12, 81);
            this.lb_email_dn.Name = "lb_email_dn";
            this.lb_email_dn.Size = new System.Drawing.Size(142, 20);
            this.lb_email_dn.TabIndex = 71;
            this.lb_email_dn.Text = "Email doanh nghiệp";
            // 
            // lb_name_dn
            // 
            this.lb_name_dn.AutoSize = true;
            this.lb_name_dn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_name_dn.Location = new System.Drawing.Point(12, 32);
            this.lb_name_dn.Name = "lb_name_dn";
            this.lb_name_dn.Size = new System.Drawing.Size(85, 20);
            this.lb_name_dn.TabIndex = 70;
            this.lb_name_dn.Text = "Tên công ty";
            // 
            // btn_luudiscount
            // 
            this.btn_luudiscount.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_luudiscount.Enabled = false;
            this.btn_luudiscount.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_luudiscount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btn_luudiscount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_luudiscount.Location = new System.Drawing.Point(704, 474);
            this.btn_luudiscount.Name = "btn_luudiscount";
            this.btn_luudiscount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_luudiscount.Size = new System.Drawing.Size(150, 50);
            this.btn_luudiscount.TabIndex = 2;
            this.btn_luudiscount.Text = "Lưu ưu đãi";
            this.btn_luudiscount.UseVisualStyleBackColor = false;
            this.btn_luudiscount.Click += new System.EventHandler(this.btn_luudiscount_Click);
            // 
            // status_bar
            // 
            this.status_bar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status_itemselect});
            this.status_bar.Location = new System.Drawing.Point(0, 536);
            this.status_bar.Name = "status_bar";
            this.status_bar.Size = new System.Drawing.Size(1000, 25);
            this.status_bar.TabIndex = 65;
            this.status_bar.Text = "statusStrip1";
            // 
            // status_itemselect
            // 
            this.status_itemselect.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status_itemselect.Name = "status_itemselect";
            this.status_itemselect.Size = new System.Drawing.Size(161, 20);
            this.status_itemselect.Text = "Chưa chọn công ty nào";
            this.status_itemselect.ToolTipText = "Hiển thị tên công ty đang được chọn";
            // 
            // lb_timkiem_dn
            // 
            this.lb_timkiem_dn.AutoSize = true;
            this.lb_timkiem_dn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_timkiem_dn.Location = new System.Drawing.Point(12, 104);
            this.lb_timkiem_dn.Name = "lb_timkiem_dn";
            this.lb_timkiem_dn.Size = new System.Drawing.Size(70, 20);
            this.lb_timkiem_dn.TabIndex = 64;
            this.lb_timkiem_dn.Text = "Tìm kiếm";
            // 
            // txt_timkiem
            // 
            this.txt_timkiem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_timkiem.Location = new System.Drawing.Point(88, 101);
            this.txt_timkiem.Name = "txt_timkiem";
            this.txt_timkiem.Size = new System.Drawing.Size(299, 27);
            this.txt_timkiem.TabIndex = 0;
            this.txt_timkiem.TextChanged += new System.EventHandler(this.txt_timkiem_dn_TextChanged);
            // 
            // lb_dtgv
            // 
            this.lb_dtgv.AutoSize = true;
            this.lb_dtgv.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_dtgv.Location = new System.Drawing.Point(12, 78);
            this.lb_dtgv.Name = "lb_dtgv";
            this.lb_dtgv.Size = new System.Drawing.Size(375, 20);
            this.lb_dtgv.TabIndex = 52;
            this.lb_dtgv.Text = "Danh sách kết quả tuyển dụng của các doanh nghiệp";
            // 
            // dtgv_KetQuaTuyenDung
            // 
            this.dtgv_KetQuaTuyenDung.AllowUserToAddRows = false;
            this.dtgv_KetQuaTuyenDung.AllowUserToDeleteRows = false;
            this.dtgv_KetQuaTuyenDung.AllowUserToOrderColumns = true;
            this.dtgv_KetQuaTuyenDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_KetQuaTuyenDung.Location = new System.Drawing.Point(12, 134);
            this.dtgv_KetQuaTuyenDung.MultiSelect = false;
            this.dtgv_KetQuaTuyenDung.Name = "dtgv_KetQuaTuyenDung";
            this.dtgv_KetQuaTuyenDung.ReadOnly = true;
            this.dtgv_KetQuaTuyenDung.RowHeadersVisible = false;
            this.dtgv_KetQuaTuyenDung.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgv_KetQuaTuyenDung.Size = new System.Drawing.Size(552, 390);
            this.dtgv_KetQuaTuyenDung.TabIndex = 51;
            this.dtgv_KetQuaTuyenDung.TabStop = false;
            this.dtgv_KetQuaTuyenDung.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_KetQuaTuyenDung_CellClick);
            // 
            // lb_explain
            // 
            this.lb_explain.AutoSize = true;
            this.lb_explain.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_explain.Location = new System.Drawing.Point(343, 46);
            this.lb_explain.Name = "lb_explain";
            this.lb_explain.Size = new System.Drawing.Size(313, 25);
            this.lb_explain.TabIndex = 50;
            this.lb_explain.Text = "Chỉnh sửa ưu đãi cho doanh nghiệp";
            // 
            // lb_FormGiaHanHopDong
            // 
            this.lb_FormGiaHanHopDong.AutoSize = true;
            this.lb_FormGiaHanHopDong.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_FormGiaHanHopDong.Location = new System.Drawing.Point(400, 9);
            this.lb_FormGiaHanHopDong.Name = "lb_FormGiaHanHopDong";
            this.lb_FormGiaHanHopDong.Size = new System.Drawing.Size(199, 30);
            this.lb_FormGiaHanHopDong.TabIndex = 47;
            this.lb_FormGiaHanHopDong.Text = "Gia Hạn Hợp Đồng";
            // 
            // FormGiaHanHopDong
            // 
            this.AcceptButton = this.btn_luudiscount;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 561);
            this.Controls.Add(this.panel_FormGiaHanHopDong);
            this.Name = "FormGiaHanHopDong";
            this.Text = "Gia Hạn Hợp Đồng";
            this.panel_FormGiaHanHopDong.ResumeLayout(false);
            this.panel_FormGiaHanHopDong.PerformLayout();
            this.grpbox_dn.ResumeLayout(false);
            this.grpbox_dn.PerformLayout();
            this.status_bar.ResumeLayout(false);
            this.status_bar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_KetQuaTuyenDung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_FormGiaHanHopDong;
        private System.Windows.Forms.Button btn_luudiscount;
        private System.Windows.Forms.StatusStrip status_bar;
        private System.Windows.Forms.ToolStripStatusLabel status_itemselect;
        private System.Windows.Forms.Label lb_timkiem_dn;
        private System.Windows.Forms.TextBox txt_timkiem;
        private System.Windows.Forms.Label lb_dtgv;
        private System.Windows.Forms.DataGridView dtgv_KetQuaTuyenDung;
        private System.Windows.Forms.Label lb_explain;
        private System.Windows.Forms.Label lb_FormGiaHanHopDong;
        private System.Windows.Forms.GroupBox grpbox_dn;
        private System.Windows.Forms.TextBox txt_discount_dn;
        private System.Windows.Forms.Label lb_discount_dn;
        private System.Windows.Forms.TextBox txt_diachi_dn;
        private System.Windows.Forms.TextBox txt_daidien_dn;
        private System.Windows.Forms.TextBox txt_tax_dn;
        private System.Windows.Forms.Label lb_diachi_dn;
        private System.Windows.Forms.Label lb_daidien_dn;
        private System.Windows.Forms.Label lb_tax_dn;
        private System.Windows.Forms.TextBox txt_email_dn;
        private System.Windows.Forms.TextBox txt_name_dn;
        private System.Windows.Forms.Label lb_email_dn;
        private System.Windows.Forms.Label lb_name_dn;
    }
}