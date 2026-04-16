namespace QuanLyQuanAn.Forms
{
    partial class frmPhieuNhapKho
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            dataGridView = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            NgayNhap = new DataGridViewTextBoxColumn();
            HoVaTenNhanVien = new DataGridViewTextBoxColumn();
            TenNhaCungCap = new DataGridViewTextBoxColumn();
            TongTien = new DataGridViewTextBoxColumn();
            TrangThai = new DataGridViewTextBoxColumn();
            XemChiTiet = new DataGridViewLinkColumn();
            btnXuat = new Button();
            btnTimKiem = new Button();
            btnThoat = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnInPhieu = new Button();
            btnTaoPhieu = new Button();
            btnLoad = new Button();
            btnDuyetPhieu = new Button();
            panel = new Panel();
            btnXemTheoNgay = new Button();
            dtpNgay = new DateTimePicker();
            label3 = new Label();
            cboNhaCungCap = new ComboBox();
            label2 = new Label();
            cboNhanVien = new ComboBox();
            label1 = new Label();
            helpProvider = new HelpProvider();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(dataGridView);
            groupBox1.Location = new Point(11, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(963, 385);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách phiếu nhập kho";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, NgayNhap, HoVaTenNhanVien, TenNhaCungCap, TongTien, TrangThai, XemChiTiet });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 23);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(957, 359);
            dataGridView.TabIndex = 0;
            dataGridView.CellContentClick += dataGridView_CellContentClick;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            // 
            // NgayNhap
            // 
            NgayNhap.DataPropertyName = "NgayNhap";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            NgayNhap.DefaultCellStyle = dataGridViewCellStyle3;
            NgayNhap.FillWeight = 85.47237F;
            NgayNhap.HeaderText = "Ngày nhập";
            NgayNhap.MinimumWidth = 6;
            NgayNhap.Name = "NgayNhap";
            // 
            // HoVaTenNhanVien
            // 
            HoVaTenNhanVien.DataPropertyName = "HoVaTenNhanVien";
            HoVaTenNhanVien.FillWeight = 85.47237F;
            HoVaTenNhanVien.HeaderText = "Nhân viên";
            HoVaTenNhanVien.MinimumWidth = 6;
            HoVaTenNhanVien.Name = "HoVaTenNhanVien";
            // 
            // TenNhaCungCap
            // 
            TenNhaCungCap.DataPropertyName = "TenNhaCungCap";
            TenNhaCungCap.FillWeight = 85.47237F;
            TenNhaCungCap.HeaderText = "Nhà cung cấp";
            TenNhaCungCap.MinimumWidth = 6;
            TenNhaCungCap.Name = "TenNhaCungCap";
            // 
            // TongTien
            // 
            TongTien.DataPropertyName = "TongTien";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.ForeColor = Color.Blue;
            dataGridViewCellStyle4.Format = "N2";
            TongTien.DefaultCellStyle = dataGridViewCellStyle4;
            TongTien.FillWeight = 85.47237F;
            TongTien.HeaderText = "Tổng tiền";
            TongTien.MinimumWidth = 6;
            TongTien.Name = "TongTien";
            // 
            // TrangThai
            // 
            TrangThai.DataPropertyName = "TrangThai";
            TrangThai.FillWeight = 85.47237F;
            TrangThai.HeaderText = "Trạng thái";
            TrangThai.MinimumWidth = 6;
            TrangThai.Name = "TrangThai";
            // 
            // XemChiTiet
            // 
            XemChiTiet.DataPropertyName = "XemChiTiet";
            XemChiTiet.FillWeight = 85.47237F;
            XemChiTiet.HeaderText = "Chi tiết";
            XemChiTiet.MinimumWidth = 6;
            XemChiTiet.Name = "XemChiTiet";
            // 
            // btnXuat
            // 
            btnXuat.ForeColor = Color.Black;
            btnXuat.Location = new Point(625, 0);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(105, 29);
            btnXuat.TabIndex = 14;
            btnXuat.Text = "Xuất Excel...";
            btnXuat.UseVisualStyleBackColor = true;
            btnXuat.Click += btnXuat_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.ForeColor = Color.Black;
            btnTimKiem.Location = new Point(514, 0);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(105, 29);
            btnTimKiem.TabIndex = 13;
            btnTimKiem.Text = "Tìm Kiếm...";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnThoat
            // 
            btnThoat.ForeColor = Color.Black;
            btnThoat.Location = new Point(433, 0);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(75, 29);
            btnThoat.TabIndex = 12;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnXoa
            // 
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(352, 0);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 29);
            btnXoa.TabIndex = 11;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.ForeColor = Color.Black;
            btnSua.Location = new Point(271, 0);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(75, 29);
            btnSua.TabIndex = 10;
            btnSua.Text = "Sửa...";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnInPhieu
            // 
            btnInPhieu.ForeColor = Color.Black;
            btnInPhieu.Location = new Point(162, 0);
            btnInPhieu.Name = "btnInPhieu";
            btnInPhieu.Size = new Size(103, 29);
            btnInPhieu.TabIndex = 9;
            btnInPhieu.Text = "In phiếu...";
            btnInPhieu.UseVisualStyleBackColor = true;
            btnInPhieu.Click += btnInPhieu_Click;
            // 
            // btnTaoPhieu
            // 
            btnTaoPhieu.ForeColor = Color.Black;
            btnTaoPhieu.Location = new Point(31, 0);
            btnTaoPhieu.Name = "btnTaoPhieu";
            btnTaoPhieu.Size = new Size(126, 29);
            btnTaoPhieu.TabIndex = 15;
            btnTaoPhieu.Text = "Tạo phiếu mới";
            btnTaoPhieu.UseVisualStyleBackColor = true;
            btnTaoPhieu.Click += btnTaoPhieu_Click;
            // 
            // btnLoad
            // 
            btnLoad.ForeColor = Color.Black;
            btnLoad.Location = new Point(736, 0);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(105, 29);
            btnLoad.TabIndex = 16;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnDuyetPhieu
            // 
            btnDuyetPhieu.BackColor = SystemColors.ControlLightLight;
            btnDuyetPhieu.ForeColor = Color.FromArgb(0, 0, 192);
            btnDuyetPhieu.Location = new Point(847, 0);
            btnDuyetPhieu.Name = "btnDuyetPhieu";
            btnDuyetPhieu.Size = new Size(124, 29);
            btnDuyetPhieu.TabIndex = 17;
            btnDuyetPhieu.Text = "Duyệt phiếu";
            btnDuyetPhieu.UseVisualStyleBackColor = false;
            btnDuyetPhieu.Click += btnDuyetPhieu_Click;
            // 
            // panel
            // 
            panel.Controls.Add(btnXemTheoNgay);
            panel.Controls.Add(dtpNgay);
            panel.Controls.Add(label3);
            panel.Controls.Add(cboNhaCungCap);
            panel.Controls.Add(label2);
            panel.Controls.Add(cboNhanVien);
            panel.Controls.Add(label1);
            panel.Controls.Add(btnTaoPhieu);
            panel.Controls.Add(btnDuyetPhieu);
            panel.Controls.Add(btnInPhieu);
            panel.Controls.Add(btnLoad);
            panel.Controls.Add(btnSua);
            panel.Controls.Add(btnXoa);
            panel.Controls.Add(btnThoat);
            panel.Controls.Add(btnXuat);
            panel.Controls.Add(btnTimKiem);
            panel.Dock = DockStyle.Bottom;
            panel.Location = new Point(0, 403);
            panel.Name = "panel";
            panel.Size = new Size(987, 93);
            panel.TabIndex = 18;
            // 
            // btnXemTheoNgay
            // 
            btnXemTheoNgay.ForeColor = Color.Black;
            btnXemTheoNgay.Location = new Point(847, 37);
            btnXemTheoNgay.Name = "btnXemTheoNgay";
            btnXemTheoNgay.Size = new Size(124, 29);
            btnXemTheoNgay.TabIndex = 24;
            btnXemTheoNgay.Text = "Xem theo ngày";
            btnXemTheoNgay.UseVisualStyleBackColor = true;
            btnXemTheoNgay.Click += btnXemTheoNgay_Click;
            // 
            // dtpNgay
            // 
            dtpNgay.CustomFormat = "dd/MM/yyyy";
            dtpNgay.Format = DateTimePickerFormat.Custom;
            dtpNgay.Location = new Point(637, 39);
            dtpNgay.Margin = new Padding(3, 4, 3, 4);
            dtpNgay.Name = "dtpNgay";
            dtpNgay.Size = new Size(204, 27);
            dtpNgay.TabIndex = 23;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(550, 43);
            label3.Name = "label3";
            label3.Size = new Size(84, 20);
            label3.TabIndex = 22;
            label3.Text = "Ngày nhập:";
            // 
            // cboNhaCungCap
            // 
            cboNhaCungCap.FormattingEnabled = true;
            cboNhaCungCap.Location = new Point(382, 39);
            cboNhaCungCap.Margin = new Padding(3, 4, 3, 4);
            cboNhaCungCap.Name = "cboNhaCungCap";
            cboNhaCungCap.Size = new Size(161, 28);
            cboNhaCungCap.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(279, 43);
            label2.Name = "label2";
            label2.Size = new Size(103, 20);
            label2.TabIndex = 20;
            label2.Text = "Nhà cung cấp:";
            // 
            // cboNhanVien
            // 
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(111, 40);
            cboNhanVien.Margin = new Padding(3, 4, 3, 4);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(161, 28);
            cboNhanVien.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 44);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 18;
            label1.Text = "Nhân viên:";
            // 
            // frmPhieuNhapKho
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(987, 496);
            Controls.Add(panel);
            Controls.Add(groupBox1);
            Name = "frmPhieuNhapKho";
            Text = "Phiếu nhập kho";
            Load += frmPhieuNhapKho_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnXuat;
        private Button btnTimKiem;
        private Button btnThoat;
        private Button btnXoa;
        private Button btnSua;
        private Button btnInPhieu;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn NgayNhap;
        private DataGridViewTextBoxColumn HoVaTenNhanVien;
        private DataGridViewTextBoxColumn TenNhaCungCap;
        private DataGridViewTextBoxColumn TongTien;
        private DataGridViewTextBoxColumn TrangThai;
        private DataGridViewLinkColumn XemChiTiet;
        private Button btnTaoPhieu;
        private Button btnLoad;
        private Button btnDuyetPhieu;
        private Panel panel;
        private HelpProvider helpProvider;
        private DateTimePicker dtpNgay;
        private Label label3;
        private ComboBox cboNhaCungCap;
        private Label label2;
        private ComboBox cboNhanVien;
        private Label label1;
        private Button btnXemTheoNgay;
    }
}