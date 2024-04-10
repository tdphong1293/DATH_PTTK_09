namespace Nhom09_083_388_392_537_708
{
    partial class THANHTOAN
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
            this.lb_titleBienLaiThanhToan = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_titleBienLaiThanhToan
            // 
            this.lb_titleBienLaiThanhToan.AutoSize = true;
            this.lb_titleBienLaiThanhToan.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_titleBienLaiThanhToan.Location = new System.Drawing.Point(477, 53);
            this.lb_titleBienLaiThanhToan.Name = "lb_titleBienLaiThanhToan";
            this.lb_titleBienLaiThanhToan.Size = new System.Drawing.Size(247, 30);
            this.lb_titleBienLaiThanhToan.TabIndex = 0;
            this.lb_titleBienLaiThanhToan.Text = "BIÊN LAI THANH TOÁN";
            // 
            // THANHTOAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 707);
            this.Controls.Add(this.lb_titleBienLaiThanhToan);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "THANHTOAN";
            this.Text = "THANHTOAN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_titleBienLaiThanhToan;
    }
}