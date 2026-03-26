namespace QuanLyQuanAn.Reports
{
    partial class frmBaoCaoLoiNhuan
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
            reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            label1 = new Label();
            dtpNgay = new DateTimePicker();
            btnXemTheoThang = new Button();
            SuspendLayout();
            // 
            // reportViewer
            // 
            reportViewer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            reportViewer.Location = new Point(0, 62);
            reportViewer.Name = "reportViewer";
            reportViewer.ServerReport.BearerToken = null;
            reportViewer.Size = new Size(800, 388);
            reportViewer.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(183, 26);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 1;
            label1.Text = "Thời gian:";
            // 
            // dtpNgay
            // 
            dtpNgay.CustomFormat = "dd/MM/yyyy";
            dtpNgay.Format = DateTimePickerFormat.Custom;
            dtpNgay.Location = new Point(263, 21);
            dtpNgay.Name = "dtpNgay";
            dtpNgay.Size = new Size(133, 27);
            dtpNgay.TabIndex = 2;
            // 
            // btnXemTheoThang
            // 
            btnXemTheoThang.Location = new Point(454, 19);
            btnXemTheoThang.Name = "btnXemTheoThang";
            btnXemTheoThang.Size = new Size(126, 29);
            btnXemTheoThang.TabIndex = 4;
            btnXemTheoThang.Text = "Xem theo tháng";
            btnXemTheoThang.UseVisualStyleBackColor = true;
            btnXemTheoThang.Click += btnXemTheoThang_Click;
            // 
            // frmBaoCaoLoiNhuan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnXemTheoThang);
            Controls.Add(dtpNgay);
            Controls.Add(label1);
            Controls.Add(reportViewer);
            Name = "frmBaoCaoLoiNhuan";
            Text = "Báo cáo lợi nhuận";
            Load += frmBaoCaoLoiNhuan_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private Label label1;
        private DateTimePicker dtpNgay;
        private Button btnXemTheoThang;
    }
}