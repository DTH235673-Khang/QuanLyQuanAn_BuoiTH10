namespace QuanLyQuanAn.Reports
{
    partial class frmBaoCaoTonKho
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
            txtSoLuongTon = new TextBox();
            btnLocKetQua = new Button();
            btnHienTatCa = new Button();
            SuspendLayout();
            // 
            // reportViewer
            // 
            reportViewer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            reportViewer.Location = new Point(0, 75);
            reportViewer.Name = "reportViewer";
            reportViewer.ServerReport.BearerToken = null;
            reportViewer.Size = new Size(800, 375);
            reportViewer.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(95, 22);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 1;
            label1.Text = "Số lượng tồn:";
            // 
            // txtSoLuongTon
            // 
            txtSoLuongTon.Location = new Point(199, 19);
            txtSoLuongTon.Name = "txtSoLuongTon";
            txtSoLuongTon.Size = new Size(125, 27);
            txtSoLuongTon.TabIndex = 2;
            // 
            // btnLocKetQua
            // 
            btnLocKetQua.Location = new Point(355, 17);
            btnLocKetQua.Name = "btnLocKetQua";
            btnLocKetQua.Size = new Size(115, 29);
            btnLocKetQua.TabIndex = 3;
            btnLocKetQua.Text = "Lọc kết quả";
            btnLocKetQua.UseVisualStyleBackColor = true;
            btnLocKetQua.Click += btnLocKetQua_Click;
            // 
            // btnHienTatCa
            // 
            btnHienTatCa.Location = new Point(514, 17);
            btnHienTatCa.Name = "btnHienTatCa";
            btnHienTatCa.Size = new Size(115, 29);
            btnHienTatCa.TabIndex = 4;
            btnHienTatCa.Text = "Hiện tất cả";
            btnHienTatCa.UseVisualStyleBackColor = true;
            btnHienTatCa.Click += btnHienTatCa_Click;
            // 
            // frmBaocaoTonKho
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnHienTatCa);
            Controls.Add(btnLocKetQua);
            Controls.Add(txtSoLuongTon);
            Controls.Add(label1);
            Controls.Add(reportViewer);
            Name = "frmBaocaoTonKho";
            Text = "Báo cáo tồn kho";
            Load += frmBaoCaoTonKho_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private Label label1;
        private TextBox txtSoLuongTon;
        private Button btnLocKetQua;
        private Button btnHienTatCa;
    }
}