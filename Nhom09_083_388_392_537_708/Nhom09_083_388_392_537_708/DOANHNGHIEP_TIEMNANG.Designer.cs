﻿namespace Nhom09_083_388_392_537_708
{
    partial class DOANHNGHIEP_TIEMNANG
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_tiemnang
            // 
            this.lb_tiemnang.AutoSize = true;
            this.lb_tiemnang.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tiemnang.ForeColor = System.Drawing.Color.SlateBlue;
            this.lb_tiemnang.Location = new System.Drawing.Point(416, 57);
            this.lb_tiemnang.Name = "lb_tiemnang";
            this.lb_tiemnang.Size = new System.Drawing.Size(441, 36);
            this.lb_tiemnang.TabIndex = 0;
            this.lb_tiemnang.Text = "DOANH NGHIỆP TIỀM NĂNG";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(255, 145);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(767, 428);
            this.dataGridView1.TabIndex = 1;
            // 
            // DOANHNGHIEP_TIEMNANG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 699);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lb_tiemnang);
            this.Name = "DOANHNGHIEP_TIEMNANG";
            this.Text = "DOANHNGHIEP_TIEMNANG";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_tiemnang;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}