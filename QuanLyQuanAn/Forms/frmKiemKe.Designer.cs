namespace QuanLyQuanAn.Forms
{
    partial class frmKiemKe
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            label1 = new Label();
            dtpNgay = new DateTimePicker();
            btnNhap = new Button();
            btnXem = new Button();
            groupBox1 = new GroupBox();
            dataGridView = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            TenNguyenLieu = new DataGridViewTextBoxColumn();
            SoLuongThucTe = new DataGridViewTextBoxColumn();
            NgayKiemKe = new DataGridViewTextBoxColumn();
            GhiChu = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 19);
            label1.Name = "label1";
            label1.Size = new Size(102, 20);
            label1.TabIndex = 0;
            label1.Text = "Ngày kiểm kê:";
            // 
            // dtpNgay
            // 
            dtpNgay.CustomFormat = "dd/MM/yyyy";
            dtpNgay.Format = DateTimePickerFormat.Custom;
            dtpNgay.Location = new Point(132, 14);
            dtpNgay.Name = "dtpNgay";
            dtpNgay.Size = new Size(129, 27);
            dtpNgay.TabIndex = 1;
            // 
            // btnNhap
            // 
            btnNhap.Location = new Point(306, 14);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(118, 29);
            btnNhap.TabIndex = 2;
            btnNhap.Text = "Nhập kiểm kê";
            btnNhap.UseVisualStyleBackColor = true;
            btnNhap.Click += btnNhap_Click;
            // 
            // btnXem
            // 
            btnXem.Location = new Point(461, 14);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(118, 29);
            btnXem.TabIndex = 3;
            btnXem.Text = "Xem kiểm kê";
            btnXem.UseVisualStyleBackColor = true;
            btnXem.Click += btnXem_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridView);
            groupBox1.Location = new Point(19, 51);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(820, 387);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách kiểm kê";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, TenNguyenLieu, SoLuongThucTe, NgayKiemKe, GhiChu });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 23);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(814, 361);
            dataGridView.TabIndex = 0;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            // 
            // TenNguyenLieu
            // 
            TenNguyenLieu.DataPropertyName = "TenNguyenLieu";
            TenNguyenLieu.HeaderText = "Nguyên liệu";
            TenNguyenLieu.MinimumWidth = 6;
            TenNguyenLieu.Name = "TenNguyenLieu";
            // 
            // SoLuongThucTe
            // 
            SoLuongThucTe.DataPropertyName = "SoLuongThucTe";
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Blue;
            SoLuongThucTe.DefaultCellStyle = dataGridViewCellStyle1;
            SoLuongThucTe.HeaderText = "Số lượng thực tế";
            SoLuongThucTe.MinimumWidth = 6;
            SoLuongThucTe.Name = "SoLuongThucTe";
            // 
            // NgayKiemKe
            // 
            NgayKiemKe.DataPropertyName = "NgayKiemKe";
            NgayKiemKe.HeaderText = "Ngày kiểm kê";
            NgayKiemKe.MinimumWidth = 6;
            NgayKiemKe.Name = "NgayKiemKe";
            // 
            // GhiChu
            // 
            GhiChu.DataPropertyName = "GhiChu";
            GhiChu.HeaderText = "Ghi chú";
            GhiChu.MinimumWidth = 6;
            GhiChu.Name = "GhiChu";
            // 
            // frmKiemKe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(847, 450);
            Controls.Add(groupBox1);
            Controls.Add(btnXem);
            Controls.Add(btnNhap);
            Controls.Add(dtpNgay);
            Controls.Add(label1);
            Name = "frmKiemKe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kiểm kê";
            Load += frmKiemKe_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpNgay;
        private Button btnNhap;
        private Button btnXem;
        private GroupBox groupBox1;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn TenNguyenLieu;
        private DataGridViewTextBoxColumn SoLuongThucTe;
        private DataGridViewTextBoxColumn NgayKiemKe;
        private DataGridViewTextBoxColumn GhiChu;
    }
}