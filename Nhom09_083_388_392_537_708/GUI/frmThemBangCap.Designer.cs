namespace GUI
{
    partial class frmThemBangCap
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
            this.lb_TenBang = new System.Windows.Forms.Label();
            this.lb_CapBac = new System.Windows.Forms.Label();
            this.lb_DonViCap = new System.Windows.Forms.Label();
            this.lb_NgayCap = new System.Windows.Forms.Label();
            this.lb_titleNhapTTBangCap = new System.Windows.Forms.Label();
            this.tb_TenBang = new System.Windows.Forms.TextBox();
            this.dtpk_NgayCap = new System.Windows.Forms.DateTimePicker();
            this.tb_CapBac = new System.Windows.Forms.TextBox();
            this.tb_DonViCap = new System.Windows.Forms.TextBox();
            this.btn_XacNhan = new System.Windows.Forms.Button();
            this.btn_QuayLai = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_TenBang
            // 
            this.lb_TenBang.AutoSize = true;
            this.lb_TenBang.Location = new System.Drawing.Point(31, 93);
            this.lb_TenBang.Name = "lb_TenBang";
            this.lb_TenBang.Size = new System.Drawing.Size(73, 20);
            this.lb_TenBang.TabIndex = 0;
            this.lb_TenBang.Text = "Tên bằng:";
            // 
            // lb_CapBac
            // 
            this.lb_CapBac.AutoSize = true;
            this.lb_CapBac.Location = new System.Drawing.Point(31, 135);
            this.lb_CapBac.Name = "lb_CapBac";
            this.lb_CapBac.Size = new System.Drawing.Size(66, 20);
            this.lb_CapBac.TabIndex = 1;
            this.lb_CapBac.Text = "Cấp bậc:";
            // 
            // lb_DonViCap
            // 
            this.lb_DonViCap.AutoSize = true;
            this.lb_DonViCap.Location = new System.Drawing.Point(31, 216);
            this.lb_DonViCap.Name = "lb_DonViCap";
            this.lb_DonViCap.Size = new System.Drawing.Size(83, 20);
            this.lb_DonViCap.TabIndex = 2;
            this.lb_DonViCap.Text = "Đơn vị cấp:";
            // 
            // lb_NgayCap
            // 
            this.lb_NgayCap.AutoSize = true;
            this.lb_NgayCap.Location = new System.Drawing.Point(31, 174);
            this.lb_NgayCap.Name = "lb_NgayCap";
            this.lb_NgayCap.Size = new System.Drawing.Size(77, 20);
            this.lb_NgayCap.TabIndex = 3;
            this.lb_NgayCap.Text = "Ngày Cấp:";
            // 
            // lb_titleNhapTTBangCap
            // 
            this.lb_titleNhapTTBangCap.AutoSize = true;
            this.lb_titleNhapTTBangCap.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_titleNhapTTBangCap.ForeColor = System.Drawing.Color.SlateBlue;
            this.lb_titleNhapTTBangCap.Location = new System.Drawing.Point(74, 24);
            this.lb_titleNhapTTBangCap.Name = "lb_titleNhapTTBangCap";
            this.lb_titleNhapTTBangCap.Size = new System.Drawing.Size(262, 30);
            this.lb_titleNhapTTBangCap.TabIndex = 4;
            this.lb_titleNhapTTBangCap.Text = "Nhập thông tin bằng cấp";
            // 
            // tb_TenBang
            // 
            this.tb_TenBang.Location = new System.Drawing.Point(140, 90);
            this.tb_TenBang.Name = "tb_TenBang";
            this.tb_TenBang.Size = new System.Drawing.Size(238, 27);
            this.tb_TenBang.TabIndex = 5;
            // 
            // dtpk_NgayCap
            // 
            this.dtpk_NgayCap.Location = new System.Drawing.Point(140, 174);
            this.dtpk_NgayCap.Name = "dtpk_NgayCap";
            this.dtpk_NgayCap.Size = new System.Drawing.Size(238, 27);
            this.dtpk_NgayCap.TabIndex = 6;
            // 
            // tb_CapBac
            // 
            this.tb_CapBac.Location = new System.Drawing.Point(140, 132);
            this.tb_CapBac.Name = "tb_CapBac";
            this.tb_CapBac.Size = new System.Drawing.Size(238, 27);
            this.tb_CapBac.TabIndex = 7;
            // 
            // tb_DonViCap
            // 
            this.tb_DonViCap.Location = new System.Drawing.Point(140, 213);
            this.tb_DonViCap.Name = "tb_DonViCap";
            this.tb_DonViCap.Size = new System.Drawing.Size(238, 27);
            this.tb_DonViCap.TabIndex = 8;
            // 
            // btn_XacNhan
            // 
            this.btn_XacNhan.BackColor = System.Drawing.Color.SlateBlue;
            this.btn_XacNhan.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XacNhan.ForeColor = System.Drawing.Color.White;
            this.btn_XacNhan.Location = new System.Drawing.Point(78, 269);
            this.btn_XacNhan.Name = "btn_XacNhan";
            this.btn_XacNhan.Size = new System.Drawing.Size(117, 44);
            this.btn_XacNhan.TabIndex = 9;
            this.btn_XacNhan.Text = "Xác nhận";
            this.btn_XacNhan.UseVisualStyleBackColor = false;
            this.btn_XacNhan.Click += new System.EventHandler(this.btn_XacNhan_Click);
            // 
            // btn_QuayLai
            // 
            this.btn_QuayLai.BackColor = System.Drawing.SystemColors.Control;
            this.btn_QuayLai.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QuayLai.ForeColor = System.Drawing.Color.Black;
            this.btn_QuayLai.Location = new System.Drawing.Point(210, 269);
            this.btn_QuayLai.Name = "btn_QuayLai";
            this.btn_QuayLai.Size = new System.Drawing.Size(117, 44);
            this.btn_QuayLai.TabIndex = 10;
            this.btn_QuayLai.Text = "Quay lại";
            this.btn_QuayLai.UseVisualStyleBackColor = false;
            this.btn_QuayLai.Click += new System.EventHandler(this.btn_QuayLai_Click);
            // 
            // frmThemBangCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 339);
            this.Controls.Add(this.btn_QuayLai);
            this.Controls.Add(this.btn_XacNhan);
            this.Controls.Add(this.tb_DonViCap);
            this.Controls.Add(this.tb_CapBac);
            this.Controls.Add(this.dtpk_NgayCap);
            this.Controls.Add(this.tb_TenBang);
            this.Controls.Add(this.lb_titleNhapTTBangCap);
            this.Controls.Add(this.lb_NgayCap);
            this.Controls.Add(this.lb_DonViCap);
            this.Controls.Add(this.lb_CapBac);
            this.Controls.Add(this.lb_TenBang);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmThemBangCap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THEMBANGCAP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_TenBang;
        private System.Windows.Forms.Label lb_CapBac;
        private System.Windows.Forms.Label lb_DonViCap;
        private System.Windows.Forms.Label lb_NgayCap;
        private System.Windows.Forms.Label lb_titleNhapTTBangCap;
        private System.Windows.Forms.TextBox tb_TenBang;
        private System.Windows.Forms.DateTimePicker dtpk_NgayCap;
        private System.Windows.Forms.TextBox tb_CapBac;
        private System.Windows.Forms.TextBox tb_DonViCap;
        private System.Windows.Forms.Button btn_XacNhan;
        private System.Windows.Forms.Button btn_QuayLai;
    }
}