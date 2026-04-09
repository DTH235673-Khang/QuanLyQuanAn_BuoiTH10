namespace QuanLyQuanAn.Forms
{
    partial class frmHoaDon
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            dataGridView = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            HoVaTenNhanVien = new DataGridViewTextBoxColumn();
            HoVaTenKhachHang = new DataGridViewTextBoxColumn();
            NgayLap = new DataGridViewTextBoxColumn();
            TongTienHoaDon = new DataGridViewTextBoxColumn();
            XemChiTiet = new DataGridViewLinkColumn();
            btnInHoaDon = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            btnTimKiem = new Button();
            btnXuat = new Button();
            btnNhap = new Button();
            panel = new Panel();
            dtpNgay = new DateTimePicker();
            label3 = new Label();
            cboKhachHang = new ComboBox();
            label2 = new Label();
            cboNhanVien = new ComboBox();
            label1 = new Label();
            btnLoad = new Button();
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
            groupBox1.Location = new Point(11, 8);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(819, 308);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách hóa đơn";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, HoVaTenNhanVien, HoVaTenKhachHang, NgayLap, TongTienHoaDon, XemChiTiet });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 18);
            dataGridView.Margin = new Padding(3, 2, 3, 2);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(813, 288);
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
            // HoVaTenNhanVien
            // 
            HoVaTenNhanVien.DataPropertyName = "HoVaTenNhanVien";
            HoVaTenNhanVien.HeaderText = "Nhân Viên";
            HoVaTenNhanVien.MinimumWidth = 6;
            HoVaTenNhanVien.Name = "HoVaTenNhanVien";
            // 
            // HoVaTenKhachHang
            // 
            HoVaTenKhachHang.DataPropertyName = "HoVaTenKhachHang";
            HoVaTenKhachHang.HeaderText = "Khách Hàng";
            HoVaTenKhachHang.MinimumWidth = 6;
            HoVaTenKhachHang.Name = "HoVaTenKhachHang";
            // 
            // NgayLap
            // 
            NgayLap.DataPropertyName = "NgayLap";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "dd/MM/yyyy";
            NgayLap.DefaultCellStyle = dataGridViewCellStyle4;
            NgayLap.HeaderText = "Ngày Lập";
            NgayLap.MinimumWidth = 6;
            NgayLap.Name = "NgayLap";
            // 
            // TongTienHoaDon
            // 
            TongTienHoaDon.DataPropertyName = "TongTienHoaDon";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.Blue;
            dataGridViewCellStyle5.Format = "N2";
            TongTienHoaDon.DefaultCellStyle = dataGridViewCellStyle5;
            TongTienHoaDon.HeaderText = "Tổng Tiền";
            TongTienHoaDon.MinimumWidth = 6;
            TongTienHoaDon.Name = "TongTienHoaDon";
            // 
            // XemChiTiet
            // 
            XemChiTiet.DataPropertyName = "XemChiTiet";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            XemChiTiet.DefaultCellStyle = dataGridViewCellStyle6;
            XemChiTiet.HeaderText = "Chi Tiết";
            XemChiTiet.MinimumWidth = 6;
            XemChiTiet.Name = "XemChiTiet";
            // 
            // btnInHoaDon
            // 
            btnInHoaDon.ForeColor = Color.Black;
            btnInHoaDon.Location = new Point(94, 10);
            btnInHoaDon.Margin = new Padding(3, 2, 3, 2);
            btnInHoaDon.Name = "btnInHoaDon";
            btnInHoaDon.Size = new Size(90, 22);
            btnInHoaDon.TabIndex = 2;
            btnInHoaDon.Text = "In hóa đơn...";
            btnInHoaDon.UseVisualStyleBackColor = true;
            btnInHoaDon.Click += btnInHoaDon_Click;
            // 
            // btnSua
            // 
            btnSua.ForeColor = Color.Black;
            btnSua.Location = new Point(189, 10);
            btnSua.Margin = new Padding(3, 2, 3, 2);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(66, 22);
            btnSua.TabIndex = 3;
            btnSua.Text = "Sửa...";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(260, 10);
            btnXoa.Margin = new Padding(3, 2, 3, 2);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(66, 22);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThoat
            // 
            btnThoat.ForeColor = Color.Black;
            btnThoat.Location = new Point(331, 10);
            btnThoat.Margin = new Padding(3, 2, 3, 2);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(66, 22);
            btnThoat.TabIndex = 5;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnTimKiem
            // 
            btnTimKiem.ForeColor = Color.Black;
            btnTimKiem.Location = new Point(402, 10);
            btnTimKiem.Margin = new Padding(3, 2, 3, 2);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(92, 22);
            btnTimKiem.TabIndex = 6;
            btnTimKiem.Text = "Tìm Kiếm...";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnXuat
            // 
            btnXuat.ForeColor = Color.Black;
            btnXuat.Location = new Point(499, 10);
            btnXuat.Margin = new Padding(3, 2, 3, 2);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(92, 22);
            btnXuat.TabIndex = 7;
            btnXuat.Text = "Xuất Excel...";
            btnXuat.UseVisualStyleBackColor = true;
            btnXuat.Click += btnXuat_Click;
            // 
            // btnNhap
            // 
            btnNhap.ForeColor = Color.Black;
            btnNhap.Location = new Point(596, 10);
            btnNhap.Margin = new Padding(3, 2, 3, 2);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(92, 22);
            btnNhap.TabIndex = 8;
            btnNhap.Text = "Nhập";
            btnNhap.UseVisualStyleBackColor = true;
            btnNhap.Click += btnNhap_Click;
            // 
            // panel
            // 
            panel.Controls.Add(dtpNgay);
            panel.Controls.Add(label3);
            panel.Controls.Add(cboKhachHang);
            panel.Controls.Add(label2);
            panel.Controls.Add(cboNhanVien);
            panel.Controls.Add(label1);
            panel.Controls.Add(btnLoad);
            panel.Controls.Add(btnInHoaDon);
            panel.Controls.Add(btnNhap);
            panel.Controls.Add(btnSua);
            panel.Controls.Add(btnXuat);
            panel.Controls.Add(btnXoa);
            panel.Controls.Add(btnTimKiem);
            panel.Controls.Add(btnThoat);
            panel.Dock = DockStyle.Bottom;
            panel.Location = new Point(0, 320);
            panel.Margin = new Padding(3, 2, 3, 2);
            panel.Name = "panel";
            panel.Size = new Size(841, 65);
            panel.TabIndex = 9;
            // 
            // dtpNgay
            // 
            dtpNgay.CustomFormat = "dd/MM/yyyy";
            dtpNgay.Format = DateTimePickerFormat.Custom;
            dtpNgay.Location = new Point(596, 38);
            dtpNgay.Name = "dtpNgay";
            dtpNgay.Size = new Size(189, 23);
            dtpNgay.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(533, 39);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 14;
            label3.Text = "Ngày lập:";
            // 
            // cboKhachHang
            // 
            cboKhachHang.FormattingEnabled = true;
            cboKhachHang.Location = new Point(386, 38);
            cboKhachHang.Name = "cboKhachHang";
            cboKhachHang.Size = new Size(141, 23);
            cboKhachHang.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(316, 41);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 12;
            label2.Text = "Khách hàng:";
            // 
            // cboNhanVien
            // 
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(169, 39);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(141, 23);
            cboNhanVien.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, 42);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 10;
            label1.Text = "Nhân viên:";
            // 
            // btnLoad
            // 
            btnLoad.ForeColor = Color.Black;
            btnLoad.Location = new Point(693, 10);
            btnLoad.Margin = new Padding(3, 2, 3, 2);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(92, 22);
            btnLoad.TabIndex = 9;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // frmHoaDon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(841, 385);
            Controls.Add(panel);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmHoaDon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hóa Đơn";
            Load += frmHoaDon_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn HoVaTenNhanVien;
        private DataGridViewTextBoxColumn HoVaTenKhachHang;
        private DataGridViewTextBoxColumn NgayLap;
        private DataGridViewTextBoxColumn TongTienHoaDon;
        private DataGridViewLinkColumn XemChiTiet;
        private Button btnInHoaDon;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThoat;
        private Button btnTimKiem;
        private Button btnXuat;
        private Button btnNhap;
        private Panel panel;
        private HelpProvider helpProvider;
        private Button btnLoad;
        private ComboBox comboBox2;
        private Label label3;
        private ComboBox cboKhachHang;
        private Label label2;
        private ComboBox cboNhanVien;
        private Label label1;
        private DateTimePicker dtpNgay;
    }
}