namespace GUI
{
    partial class frmDoanhNghiepTiemNang
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
            this.lb_tiemnang = new System.Windows.Forms.Label();
            this.dgv_DoanhNghiepTN = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DoanhNghiepTN)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_tiemnang
            // 
            this.lb_tiemnang.AutoSize = true;
            this.lb_tiemnang.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tiemnang.ForeColor = System.Drawing.Color.SlateBlue;
            this.lb_tiemnang.Location = new System.Drawing.Point(420, 64);
            this.lb_tiemnang.Name = "lb_tiemnang";
            this.lb_tiemnang.Size = new System.Drawing.Size(430, 41);
            this.lb_tiemnang.TabIndex = 0;
            this.lb_tiemnang.Text = "DOANH NGHIỆP TIỀM NĂNG";
            // 
            // dgv_DoanhNghiepTN
            // 
            this.dgv_DoanhNghiepTN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DoanhNghiepTN.Location = new System.Drawing.Point(121, 141);
            this.dgv_DoanhNghiepTN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_DoanhNghiepTN.Name = "dgv_DoanhNghiepTN";
            this.dgv_DoanhNghiepTN.RowHeadersWidth = 51;
            this.dgv_DoanhNghiepTN.RowTemplate.Height = 24;
            this.dgv_DoanhNghiepTN.Size = new System.Drawing.Size(1059, 483);
            this.dgv_DoanhNghiepTN.TabIndex = 1;
            // 
            // DOANHNGHIEP_TIEMNANG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 699);
            this.Controls.Add(this.dgv_DoanhNghiepTN);
            this.Controls.Add(this.lb_tiemnang);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DOANHNGHIEP_TIEMNANG";
            this.Text = "DOANHNGHIEP_TIEMNANG";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DoanhNghiepTN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_tiemnang;
        private System.Windows.Forms.DataGridView dgv_DoanhNghiepTN;
    }
}