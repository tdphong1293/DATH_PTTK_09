﻿namespace Nhom09_083_388_392_537_708
{
    partial class NopHoSoUngTuyen
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
            this.lbNHSUT = new System.Windows.Forms.Label();
            this.lbTenUV = new System.Windows.Forms.Label();
            this.txtTenUV = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbCTUT = new System.Windows.Forms.Label();
            this.lbVTUT = new System.Windows.Forms.Label();
            this.cbVTUT = new System.Windows.Forms.ComboBox();
            this.lbHSDK = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnHuyNHS = new System.Windows.Forms.Button();
            this.btnXNNopHS = new System.Windows.Forms.Button();
            this.llbFileName = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lbNHSUT
            // 
            this.lbNHSUT.AutoSize = true;
            this.lbNHSUT.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNHSUT.Location = new System.Drawing.Point(515, 9);
            this.lbNHSUT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNHSUT.Name = "lbNHSUT";
            this.lbNHSUT.Size = new System.Drawing.Size(269, 30);
            this.lbNHSUT.TabIndex = 0;
            this.lbNHSUT.Text = "NỘP HỒ SƠ ỨNG TUYỂN";
            // 
            // lbTenUV
            // 
            this.lbTenUV.AutoSize = true;
            this.lbTenUV.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenUV.Location = new System.Drawing.Point(22, 107);
            this.lbTenUV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTenUV.Name = "lbTenUV";
            this.lbTenUV.Size = new System.Drawing.Size(124, 20);
            this.lbTenUV.TabIndex = 1;
            this.lbTenUV.Text = "Họ Tên Ứng Viên:";
            // 
            // txtTenUV
            // 
            this.txtTenUV.Enabled = false;
            this.txtTenUV.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenUV.Location = new System.Drawing.Point(180, 102);
            this.txtTenUV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTenUV.Name = "txtTenUV";
            this.txtTenUV.ReadOnly = true;
            this.txtTenUV.Size = new System.Drawing.Size(278, 27);
            this.txtTenUV.TabIndex = 2;
            this.txtTenUV.Text = "Nguyễn Văn A";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(180, 160);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(278, 27);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Gout Goo";
            // 
            // lbCTUT
            // 
            this.lbCTUT.AutoSize = true;
            this.lbCTUT.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCTUT.Location = new System.Drawing.Point(22, 162);
            this.lbCTUT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCTUT.Name = "lbCTUT";
            this.lbCTUT.Size = new System.Drawing.Size(137, 20);
            this.lbCTUT.TabIndex = 3;
            this.lbCTUT.Text = "Công ty ứng tuyển: ";
            // 
            // lbVTUT
            // 
            this.lbVTUT.AutoSize = true;
            this.lbVTUT.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVTUT.Location = new System.Drawing.Point(22, 221);
            this.lbVTUT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbVTUT.Name = "lbVTUT";
            this.lbVTUT.Size = new System.Drawing.Size(113, 20);
            this.lbVTUT.TabIndex = 5;
            this.lbVTUT.Text = "Vị trí ứng tuyển:";
            // 
            // cbVTUT
            // 
            this.cbVTUT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVTUT.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVTUT.FormattingEnabled = true;
            this.cbVTUT.Items.AddRange(new object[] {
            "Front End",
            "BackEnd",
            "DevOps"});
            this.cbVTUT.Location = new System.Drawing.Point(180, 219);
            this.cbVTUT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbVTUT.Name = "cbVTUT";
            this.cbVTUT.Size = new System.Drawing.Size(92, 27);
            this.cbVTUT.TabIndex = 6;
            // 
            // lbHSDK
            // 
            this.lbHSDK.AutoSize = true;
            this.lbHSDK.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHSDK.Location = new System.Drawing.Point(22, 282);
            this.lbHSDK.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbHSDK.Name = "lbHSDK";
            this.lbHSDK.Size = new System.Drawing.Size(115, 20);
            this.lbHSDK.TabIndex = 7;
            this.lbHSDK.Text = "Đính kèm hồ sơ:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(379, 278);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(78, 28);
            this.btnBrowse.TabIndex = 8;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnHuyNHS
            // 
            this.btnHuyNHS.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyNHS.Location = new System.Drawing.Point(1078, 668);
            this.btnHuyNHS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnHuyNHS.Name = "btnHuyNHS";
            this.btnHuyNHS.Size = new System.Drawing.Size(61, 28);
            this.btnHuyNHS.TabIndex = 10;
            this.btnHuyNHS.Text = "Huỷ";
            this.btnHuyNHS.UseVisualStyleBackColor = true;
            this.btnHuyNHS.Click += new System.EventHandler(this.btnHuyNHS_Click);
            // 
            // btnXNNopHS
            // 
            this.btnXNNopHS.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXNNopHS.Location = new System.Drawing.Point(1143, 668);
            this.btnXNNopHS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnXNNopHS.Name = "btnXNNopHS";
            this.btnXNNopHS.Size = new System.Drawing.Size(86, 28);
            this.btnXNNopHS.TabIndex = 11;
            this.btnXNNopHS.Text = "Xác nhận";
            this.btnXNNopHS.UseVisualStyleBackColor = true;
            this.btnXNNopHS.Click += new System.EventHandler(this.btnXNNopHS_Click);
            // 
            // llbFileName
            // 
            this.llbFileName.AutoSize = true;
            this.llbFileName.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbFileName.Location = new System.Drawing.Point(176, 282);
            this.llbFileName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.llbFileName.Name = "llbFileName";
            this.llbFileName.Size = new System.Drawing.Size(0, 20);
            this.llbFileName.TabIndex = 12;
            // 
            // NopHoSoUngTuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 707);
            this.Controls.Add(this.llbFileName);
            this.Controls.Add(this.btnXNNopHS);
            this.Controls.Add(this.btnHuyNHS);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lbHSDK);
            this.Controls.Add(this.cbVTUT);
            this.Controls.Add(this.lbVTUT);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbCTUT);
            this.Controls.Add(this.txtTenUV);
            this.Controls.Add(this.lbTenUV);
            this.Controls.Add(this.lbNHSUT);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "NopHoSoUngTuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NopHoSoUngTuyen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNHSUT;
        private System.Windows.Forms.Label lbTenUV;
        private System.Windows.Forms.TextBox txtTenUV;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbCTUT;
        private System.Windows.Forms.Label lbVTUT;
        private System.Windows.Forms.ComboBox cbVTUT;
        private System.Windows.Forms.Label lbHSDK;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnHuyNHS;
        private System.Windows.Forms.Button btnXNNopHS;
        private System.Windows.Forms.LinkLabel llbFileName;
    }
}