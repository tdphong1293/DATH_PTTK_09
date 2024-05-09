namespace GUI
{
    partial class frmDangKyUngVien
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
            this.panel_FormDangKyUngVien = new System.Windows.Forms.Panel();
            this.txt_inputvalidation = new System.Windows.Forms.TextBox();
            this.dtp_birth_uv = new System.Windows.Forms.DateTimePicker();
            this.lb_birth_uv = new System.Windows.Forms.Label();
            this.txt_email_uv = new System.Windows.Forms.TextBox();
            this.txt_name_uv = new System.Windows.Forms.TextBox();
            this.txt_repassword_uv = new System.Windows.Forms.TextBox();
            this.txt_password_uv = new System.Windows.Forms.TextBox();
            this.txt_username_uv = new System.Windows.Forms.TextBox();
            this.btn_DangKyUngVien = new System.Windows.Forms.Button();
            this.lb_email_uv = new System.Windows.Forms.Label();
            this.lb_name_uv = new System.Windows.Forms.Label();
            this.lb_repassword_uv = new System.Windows.Forms.Label();
            this.lb_password_uv = new System.Windows.Forms.Label();
            this.lb_username_uv = new System.Windows.Forms.Label();
            this.lb_FormDangKyUngVien = new System.Windows.Forms.Label();
            this.panel_FormDangKyUngVien.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_FormDangKyUngVien
            // 
            this.panel_FormDangKyUngVien.BackColor = System.Drawing.Color.OldLace;
            this.panel_FormDangKyUngVien.Controls.Add(this.txt_inputvalidation);
            this.panel_FormDangKyUngVien.Controls.Add(this.dtp_birth_uv);
            this.panel_FormDangKyUngVien.Controls.Add(this.lb_birth_uv);
            this.panel_FormDangKyUngVien.Controls.Add(this.txt_email_uv);
            this.panel_FormDangKyUngVien.Controls.Add(this.txt_name_uv);
            this.panel_FormDangKyUngVien.Controls.Add(this.txt_repassword_uv);
            this.panel_FormDangKyUngVien.Controls.Add(this.txt_password_uv);
            this.panel_FormDangKyUngVien.Controls.Add(this.txt_username_uv);
            this.panel_FormDangKyUngVien.Controls.Add(this.btn_DangKyUngVien);
            this.panel_FormDangKyUngVien.Controls.Add(this.lb_email_uv);
            this.panel_FormDangKyUngVien.Controls.Add(this.lb_name_uv);
            this.panel_FormDangKyUngVien.Controls.Add(this.lb_repassword_uv);
            this.panel_FormDangKyUngVien.Controls.Add(this.lb_password_uv);
            this.panel_FormDangKyUngVien.Controls.Add(this.lb_username_uv);
            this.panel_FormDangKyUngVien.Controls.Add(this.lb_FormDangKyUngVien);
            this.panel_FormDangKyUngVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_FormDangKyUngVien.Location = new System.Drawing.Point(0, 0);
            this.panel_FormDangKyUngVien.Name = "panel_FormDangKyUngVien";
            this.panel_FormDangKyUngVien.Size = new System.Drawing.Size(1000, 561);
            this.panel_FormDangKyUngVien.TabIndex = 17;
            // 
            // txt_inputvalidation
            // 
            this.txt_inputvalidation.BackColor = System.Drawing.Color.OldLace;
            this.txt_inputvalidation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_inputvalidation.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_inputvalidation.ForeColor = System.Drawing.Color.Red;
            this.txt_inputvalidation.Location = new System.Drawing.Point(728, 146);
            this.txt_inputvalidation.Multiline = true;
            this.txt_inputvalidation.Name = "txt_inputvalidation";
            this.txt_inputvalidation.ReadOnly = true;
            this.txt_inputvalidation.Size = new System.Drawing.Size(218, 172);
            this.txt_inputvalidation.TabIndex = 59;
            this.txt_inputvalidation.Text = "* Lưu ý: \r\nTên đăng nhập và mật khẩu chỉ chấp nhận kí tự chữ và số, có độ dài khô" +
    "ng quá 30 ký tự\r\n\r\nCác trường còn lại không được để trống và độ dài không quá 50" +
    " ký tự";
            // 
            // dtp_birth_uv
            // 
            this.dtp_birth_uv.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtp_birth_uv.Location = new System.Drawing.Point(555, 381);
            this.dtp_birth_uv.MaxDate = new System.DateTime(2024, 5, 8, 0, 0, 0, 0);
            this.dtp_birth_uv.Name = "dtp_birth_uv";
            this.dtp_birth_uv.Size = new System.Drawing.Size(143, 27);
            this.dtp_birth_uv.TabIndex = 50;
            this.dtp_birth_uv.Value = new System.DateTime(2003, 1, 1, 0, 0, 0, 0);
            // 
            // lb_birth_uv
            // 
            this.lb_birth_uv.AutoSize = true;
            this.lb_birth_uv.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_birth_uv.Location = new System.Drawing.Point(54, 381);
            this.lb_birth_uv.Name = "lb_birth_uv";
            this.lb_birth_uv.Size = new System.Drawing.Size(76, 20);
            this.lb_birth_uv.TabIndex = 58;
            this.lb_birth_uv.Text = "Ngày Sinh";
            // 
            // txt_email_uv
            // 
            this.txt_email_uv.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_email_uv.Location = new System.Drawing.Point(225, 331);
            this.txt_email_uv.Name = "txt_email_uv";
            this.txt_email_uv.Size = new System.Drawing.Size(473, 27);
            this.txt_email_uv.TabIndex = 49;
            // 
            // txt_name_uv
            // 
            this.txt_name_uv.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_name_uv.Location = new System.Drawing.Point(225, 281);
            this.txt_name_uv.Name = "txt_name_uv";
            this.txt_name_uv.Size = new System.Drawing.Size(473, 27);
            this.txt_name_uv.TabIndex = 48;
            // 
            // txt_repassword_uv
            // 
            this.txt_repassword_uv.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_repassword_uv.Location = new System.Drawing.Point(225, 231);
            this.txt_repassword_uv.Name = "txt_repassword_uv";
            this.txt_repassword_uv.Size = new System.Drawing.Size(473, 27);
            this.txt_repassword_uv.TabIndex = 47;
            this.txt_repassword_uv.UseSystemPasswordChar = true;
            // 
            // txt_password_uv
            // 
            this.txt_password_uv.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_password_uv.Location = new System.Drawing.Point(225, 181);
            this.txt_password_uv.Name = "txt_password_uv";
            this.txt_password_uv.Size = new System.Drawing.Size(473, 27);
            this.txt_password_uv.TabIndex = 46;
            this.txt_password_uv.UseSystemPasswordChar = true;
            // 
            // txt_username_uv
            // 
            this.txt_username_uv.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_username_uv.Location = new System.Drawing.Point(225, 131);
            this.txt_username_uv.Name = "txt_username_uv";
            this.txt_username_uv.Size = new System.Drawing.Size(473, 27);
            this.txt_username_uv.TabIndex = 45;
            // 
            // btn_DangKyUngVien
            // 
            this.btn_DangKyUngVien.BackColor = System.Drawing.Color.SpringGreen;
            this.btn_DangKyUngVien.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_DangKyUngVien.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btn_DangKyUngVien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DangKyUngVien.Location = new System.Drawing.Point(425, 484);
            this.btn_DangKyUngVien.Name = "btn_DangKyUngVien";
            this.btn_DangKyUngVien.Size = new System.Drawing.Size(150, 50);
            this.btn_DangKyUngVien.TabIndex = 51;
            this.btn_DangKyUngVien.Text = "Đăng ký";
            this.btn_DangKyUngVien.UseVisualStyleBackColor = false;
            this.btn_DangKyUngVien.Click += new System.EventHandler(this.btn_DangKyUngVien_Click);
            // 
            // lb_email_uv
            // 
            this.lb_email_uv.AutoSize = true;
            this.lb_email_uv.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_email_uv.Location = new System.Drawing.Point(54, 331);
            this.lb_email_uv.Name = "lb_email_uv";
            this.lb_email_uv.Size = new System.Drawing.Size(46, 20);
            this.lb_email_uv.TabIndex = 57;
            this.lb_email_uv.Text = "Email";
            // 
            // lb_name_uv
            // 
            this.lb_name_uv.AutoSize = true;
            this.lb_name_uv.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_name_uv.Location = new System.Drawing.Point(54, 281);
            this.lb_name_uv.Name = "lb_name_uv";
            this.lb_name_uv.Size = new System.Drawing.Size(93, 20);
            this.lb_name_uv.TabIndex = 56;
            this.lb_name_uv.Text = "Tên ứng viên";
            // 
            // lb_repassword_uv
            // 
            this.lb_repassword_uv.AutoSize = true;
            this.lb_repassword_uv.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_repassword_uv.Location = new System.Drawing.Point(54, 231);
            this.lb_repassword_uv.Name = "lb_repassword_uv";
            this.lb_repassword_uv.Size = new System.Drawing.Size(130, 20);
            this.lb_repassword_uv.TabIndex = 55;
            this.lb_repassword_uv.Text = "Nhập lại mật khẩu";
            // 
            // lb_password_uv
            // 
            this.lb_password_uv.AutoSize = true;
            this.lb_password_uv.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_password_uv.Location = new System.Drawing.Point(54, 181);
            this.lb_password_uv.Name = "lb_password_uv";
            this.lb_password_uv.Size = new System.Drawing.Size(70, 20);
            this.lb_password_uv.TabIndex = 54;
            this.lb_password_uv.Text = "Mật khẩu";
            // 
            // lb_username_uv
            // 
            this.lb_username_uv.AutoSize = true;
            this.lb_username_uv.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_username_uv.Location = new System.Drawing.Point(54, 131);
            this.lb_username_uv.Name = "lb_username_uv";
            this.lb_username_uv.Size = new System.Drawing.Size(107, 20);
            this.lb_username_uv.TabIndex = 53;
            this.lb_username_uv.Text = "Tên đăng nhập";
            // 
            // lb_FormDangKyUngVien
            // 
            this.lb_FormDangKyUngVien.AutoSize = true;
            this.lb_FormDangKyUngVien.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_FormDangKyUngVien.Location = new System.Drawing.Point(403, 27);
            this.lb_FormDangKyUngVien.Name = "lb_FormDangKyUngVien";
            this.lb_FormDangKyUngVien.Size = new System.Drawing.Size(193, 30);
            this.lb_FormDangKyUngVien.TabIndex = 52;
            this.lb_FormDangKyUngVien.Text = "Đăng Ký Ứng Viên";
            // 
            // frmDangKyUngVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 561);
            this.Controls.Add(this.panel_FormDangKyUngVien);
            this.Name = "frmDangKyUngVien";
            this.Text = "Đăng Ký Ứng Viên";
            this.panel_FormDangKyUngVien.ResumeLayout(false);
            this.panel_FormDangKyUngVien.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_FormDangKyUngVien;
        private System.Windows.Forms.TextBox txt_inputvalidation;
        private System.Windows.Forms.DateTimePicker dtp_birth_uv;
        private System.Windows.Forms.Label lb_birth_uv;
        private System.Windows.Forms.TextBox txt_email_uv;
        private System.Windows.Forms.TextBox txt_name_uv;
        private System.Windows.Forms.TextBox txt_repassword_uv;
        private System.Windows.Forms.TextBox txt_password_uv;
        private System.Windows.Forms.TextBox txt_username_uv;
        private System.Windows.Forms.Button btn_DangKyUngVien;
        private System.Windows.Forms.Label lb_email_uv;
        private System.Windows.Forms.Label lb_name_uv;
        private System.Windows.Forms.Label lb_repassword_uv;
        private System.Windows.Forms.Label lb_password_uv;
        private System.Windows.Forms.Label lb_username_uv;
        private System.Windows.Forms.Label lb_FormDangKyUngVien;
    }
}