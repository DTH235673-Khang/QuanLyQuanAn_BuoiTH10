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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
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
            btnNhap = new Button();
            btnDuyetPhieu = new Button();
            panel = new Panel();
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
            groupBox1.Location = new Point(10, 9);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(843, 289);
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
            dataGridView.Location = new Point(3, 18);
            dataGridView.Margin = new Padding(3, 2, 3, 2);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(837, 269);
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
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            NgayNhap.DefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.ForeColor = Color.Blue;
            dataGridViewCellStyle2.Format = "N2";
            TongTien.DefaultCellStyle = dataGridViewCellStyle2;
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
            btnXuat.Location = new Point(547, 0);
            btnXuat.Margin = new Padding(3, 2, 3, 2);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(92, 22);
            btnXuat.TabIndex = 14;
            btnXuat.Text = "Xuất Excel...";
            btnXuat.UseVisualStyleBackColor = true;
            btnXuat.Click += btnXuat_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.ForeColor = Color.Black;
            btnTimKiem.Location = new Point(450, 0);
            btnTimKiem.Margin = new Padding(3, 2, 3, 2);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(92, 22);
            btnTimKiem.TabIndex = 13;
            btnTimKiem.Text = "Tìm Kiếm...";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnThoat
            // 
            btnThoat.ForeColor = Color.Black;
            btnThoat.Location = new Point(379, 0);
            btnThoat.Margin = new Padding(3, 2, 3, 2);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(66, 22);
            btnThoat.TabIndex = 12;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnXoa
            // 
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(308, 0);
            btnXoa.Margin = new Padding(3, 2, 3, 2);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(66, 22);
            btnXoa.TabIndex = 11;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.ForeColor = Color.Black;
            btnSua.Location = new Point(237, 0);
            btnSua.Margin = new Padding(3, 2, 3, 2);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(66, 22);
            btnSua.TabIndex = 10;
            btnSua.Text = "Sửa...";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnInPhieu
            // 
            btnInPhieu.ForeColor = Color.Black;
            btnInPhieu.Location = new Point(142, 0);
            btnInPhieu.Margin = new Padding(3, 2, 3, 2);
            btnInPhieu.Name = "btnInPhieu";
            btnInPhieu.Size = new Size(90, 22);
            btnInPhieu.TabIndex = 9;
            btnInPhieu.Text = "In phiếu...";
            btnInPhieu.UseVisualStyleBackColor = true;
            btnInPhieu.Click += btnInPhieu_Click;
            // 
            // btnTaoPhieu
            // 
            btnTaoPhieu.ForeColor = Color.Black;
            btnTaoPhieu.Location = new Point(27, 0);
            btnTaoPhieu.Margin = new Padding(3, 2, 3, 2);
            btnTaoPhieu.Name = "btnTaoPhieu";
            btnTaoPhieu.Size = new Size(110, 22);
            btnTaoPhieu.TabIndex = 15;
            btnTaoPhieu.Text = "Tạo phiếu mới";
            btnTaoPhieu.UseVisualStyleBackColor = true;
            btnTaoPhieu.Click += btnTaoPhieu_Click;
            // 
            // btnNhap
            // 
            btnNhap.ForeColor = Color.Black;
            btnNhap.Location = new Point(644, 0);
            btnNhap.Margin = new Padding(3, 2, 3, 2);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(92, 22);
            btnNhap.TabIndex = 16;
            btnNhap.Text = "Nhập";
            btnNhap.UseVisualStyleBackColor = true;
            btnNhap.Click += btnNhap_Click;
            // 
            // btnDuyetPhieu
            // 
            btnDuyetPhieu.BackColor = SystemColors.ControlLightLight;
            btnDuyetPhieu.ForeColor = Color.FromArgb(0, 0, 192);
            btnDuyetPhieu.Location = new Point(741, 0);
            btnDuyetPhieu.Margin = new Padding(3, 2, 3, 2);
            btnDuyetPhieu.Name = "btnDuyetPhieu";
            btnDuyetPhieu.Size = new Size(92, 22);
            btnDuyetPhieu.TabIndex = 17;
            btnDuyetPhieu.Text = "Duyệt phiếu";
            btnDuyetPhieu.UseVisualStyleBackColor = false;
            btnDuyetPhieu.Click += btnDuyetPhieu_Click;
            // 
            // panel
            // 
            panel.Controls.Add(dtpNgay);
            panel.Controls.Add(label3);
            panel.Controls.Add(cboNhaCungCap);
            panel.Controls.Add(label2);
            panel.Controls.Add(cboNhanVien);
            panel.Controls.Add(label1);
            panel.Controls.Add(btnTaoPhieu);
            panel.Controls.Add(btnDuyetPhieu);
            panel.Controls.Add(btnInPhieu);
            panel.Controls.Add(btnNhap);
            panel.Controls.Add(btnSua);
            panel.Controls.Add(btnXoa);
            panel.Controls.Add(btnThoat);
            panel.Controls.Add(btnXuat);
            panel.Controls.Add(btnTimKiem);
            panel.Dock = DockStyle.Bottom;
            panel.Location = new Point(0, 302);
            panel.Margin = new Padding(3, 2, 3, 2);
            panel.Name = "panel";
            panel.Size = new Size(864, 70);
            panel.TabIndex = 18;
            // 
            // dtpNgay
            // 
            dtpNgay.CustomFormat = "dd/MM/yyyy";
            dtpNgay.Format = DateTimePickerFormat.Custom;
            dtpNgay.Location = new Point(544, 29);
            dtpNgay.Name = "dtpNgay";
            dtpNgay.Size = new Size(189, 23);
            dtpNgay.TabIndex = 23;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(481, 32);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 22;
            label3.Text = "Ngày nhập:";
            // 
            // cboNhaCungCap
            // 
            cboNhaCungCap.FormattingEnabled = true;
            cboNhaCungCap.Location = new Point(334, 29);
            cboNhaCungCap.Name = "cboNhaCungCap";
            cboNhaCungCap.Size = new Size(141, 23);
            cboNhaCungCap.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(244, 32);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 20;
            label2.Text = "Nhà cung cấp:";
            // 
            // cboNhanVien
            // 
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(97, 30);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(141, 23);
            cboNhanVien.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 33);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 18;
            label1.Text = "Nhân viên:";
            // 
            // frmPhieuNhapKho
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(864, 372);
            Controls.Add(panel);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
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
        private Button btnNhap;
        private Button btnDuyetPhieu;
        private Panel panel;
        private HelpProvider helpProvider;
        private DateTimePicker dtpNgay;
        private Label label3;
        private ComboBox cboNhaCungCap;
        private Label label2;
        private ComboBox cboNhanVien;
        private Label label1;
    }
}