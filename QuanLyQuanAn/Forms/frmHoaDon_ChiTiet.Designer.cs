namespace QuanLyQuanAn.Forms
{
    partial class frmHoaDon_ChiTiet
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            txtDienThoai = new TextBox();
            label8 = new Label();
            txtDiaChi = new TextBox();
            label7 = new Label();
            txtGhiChuHoaDon = new TextBox();
            label3 = new Label();
            cboKhachHang = new ComboBox();
            cboNhanVien = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dataGridView = new DataGridView();
            ThucAnID = new DataGridViewTextBoxColumn();
            TenThucAn = new DataGridViewTextBoxColumn();
            DonGiaBan = new DataGridViewTextBoxColumn();
            SoLuongBan = new DataGridViewTextBoxColumn();
            ThanhTien = new DataGridViewTextBoxColumn();
            btnXoa = new Button();
            btnXacNhanBan = new Button();
            numSoLuongBan = new NumericUpDown();
            label6 = new Label();
            numDonGiaBan = new NumericUpDown();
            label5 = new Label();
            cboMonAn = new ComboBox();
            label4 = new Label();
            btnLuuHoaDon = new Button();
            btnThoat = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuongBan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDonGiaBan).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(txtDienThoai);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtDiaChi);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtGhiChuHoaDon);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cboKhachHang);
            groupBox1.Controls.Add(cboNhanVien);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(10, 10);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(806, 126);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin hóa đơn";
            // 
            // txtDienThoai
            // 
            txtDienThoai.Location = new Point(500, 55);
            txtDienThoai.Margin = new Padding(3, 2, 3, 2);
            txtDienThoai.Name = "txtDienThoai";
            txtDienThoai.Size = new Size(266, 23);
            txtDienThoai.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(415, 58);
            label8.Name = "label8";
            label8.Size = new Size(64, 15);
            label8.TabIndex = 8;
            label8.Text = "Điện thoại:";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(77, 55);
            txtDiaChi.Margin = new Padding(3, 2, 3, 2);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(321, 23);
            txtDiaChi.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(25, 58);
            label7.Name = "label7";
            label7.Size = new Size(46, 15);
            label7.TabIndex = 6;
            label7.Text = "Địa chỉ:";
            // 
            // txtGhiChuHoaDon
            // 
            txtGhiChuHoaDon.Location = new Point(132, 91);
            txtGhiChuHoaDon.Margin = new Padding(3, 2, 3, 2);
            txtGhiChuHoaDon.Name = "txtGhiChuHoaDon";
            txtGhiChuHoaDon.Size = new Size(633, 23);
            txtGhiChuHoaDon.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 94);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 4;
            label3.Text = "Ghi chú hóa đơn:";
            // 
            // cboKhachHang
            // 
            cboKhachHang.FormattingEnabled = true;
            cboKhachHang.Location = new Point(500, 25);
            cboKhachHang.Margin = new Padding(3, 2, 3, 2);
            cboKhachHang.Name = "cboKhachHang";
            cboKhachHang.Size = new Size(266, 23);
            cboKhachHang.TabIndex = 3;
            cboKhachHang.SelectionChangeCommitted += cboKhachHang_SelectionChangeCommitted;
            // 
            // cboNhanVien
            // 
            cboNhanVien.FormattingEnabled = true;
            cboNhanVien.Location = new Point(132, 25);
            cboNhanVien.Margin = new Padding(3, 2, 3, 2);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(266, 23);
            cboNhanVien.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(402, 27);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 1;
            label2.Text = "Khách hàng(*):";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 27);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 0;
            label1.Text = "Nhân viên lập(*):";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(dataGridView);
            groupBox2.Controls.Add(btnXoa);
            groupBox2.Controls.Add(btnXacNhanBan);
            groupBox2.Controls.Add(numSoLuongBan);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(numDonGiaBan);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(cboMonAn);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(9, 150);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(806, 220);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin chi tiết hóa đơn";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ThucAnID, TenThucAn, DonGiaBan, SoLuongBan, ThanhTien });
            dataGridView.Location = new Point(10, 86);
            dataGridView.Margin = new Padding(3, 2, 3, 2);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(789, 141);
            dataGridView.TabIndex = 13;
            // 
            // ThucAnID
            // 
            ThucAnID.DataPropertyName = "ThucAnID";
            ThucAnID.HeaderText = "ID";
            ThucAnID.MinimumWidth = 6;
            ThucAnID.Name = "ThucAnID";
            // 
            // TenThucAn
            // 
            TenThucAn.DataPropertyName = "TenThucAn";
            TenThucAn.HeaderText = "Tên Món";
            TenThucAn.MinimumWidth = 6;
            TenThucAn.Name = "TenThucAn";
            // 
            // DonGiaBan
            // 
            DonGiaBan.DataPropertyName = "DonGiaBan";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            DonGiaBan.DefaultCellStyle = dataGridViewCellStyle1;
            DonGiaBan.HeaderText = "Đơn Giá Bán";
            DonGiaBan.MinimumWidth = 6;
            DonGiaBan.Name = "DonGiaBan";
            // 
            // SoLuongBan
            // 
            SoLuongBan.DataPropertyName = "SoLuongBan";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            SoLuongBan.DefaultCellStyle = dataGridViewCellStyle2;
            SoLuongBan.HeaderText = "Số Lượng Bán";
            SoLuongBan.MinimumWidth = 6;
            SoLuongBan.Name = "SoLuongBan";
            // 
            // ThanhTien
            // 
            ThanhTien.DataPropertyName = "ThanhTien";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Blue;
            dataGridViewCellStyle3.Format = "N2";
            ThanhTien.DefaultCellStyle = dataGridViewCellStyle3;
            ThanhTien.HeaderText = "Thành Tiền";
            ThanhTien.MinimumWidth = 6;
            ThanhTien.Name = "ThanhTien";
            // 
            // btnXoa
            // 
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(691, 45);
            btnXoa.Margin = new Padding(3, 2, 3, 2);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(108, 22);
            btnXoa.TabIndex = 12;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnXacNhanBan
            // 
            btnXacNhanBan.Location = new Point(578, 44);
            btnXacNhanBan.Margin = new Padding(3, 2, 3, 2);
            btnXacNhanBan.Name = "btnXacNhanBan";
            btnXacNhanBan.Size = new Size(108, 22);
            btnXacNhanBan.TabIndex = 11;
            btnXacNhanBan.Text = "Xác nhận bán";
            btnXacNhanBan.UseVisualStyleBackColor = true;
            btnXacNhanBan.Click += btnXacNhanBan_Click;
            // 
            // numSoLuongBan
            // 
            numSoLuongBan.Location = new Point(392, 46);
            numSoLuongBan.Margin = new Padding(3, 2, 3, 2);
            numSoLuongBan.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numSoLuongBan.Name = "numSoLuongBan";
            numSoLuongBan.Size = new Size(167, 23);
            numSoLuongBan.TabIndex = 10;
            numSoLuongBan.ThousandsSeparator = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(392, 28);
            label6.Name = "label6";
            label6.Size = new Size(93, 15);
            label6.TabIndex = 9;
            label6.Text = "Số lượng bán(*):";
            // 
            // numDonGiaBan
            // 
            numDonGiaBan.Location = new Point(219, 46);
            numDonGiaBan.Margin = new Padding(3, 2, 3, 2);
            numDonGiaBan.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numDonGiaBan.Name = "numDonGiaBan";
            numDonGiaBan.Size = new Size(167, 23);
            numDonGiaBan.TabIndex = 8;
            numDonGiaBan.ThousandsSeparator = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(219, 28);
            label5.Name = "label5";
            label5.Size = new Size(108, 15);
            label5.TabIndex = 7;
            label5.Text = "Đơn giá món ăn(*):";
            // 
            // cboMonAn
            // 
            cboMonAn.FormattingEnabled = true;
            cboMonAn.Location = new Point(24, 46);
            cboMonAn.Margin = new Padding(3, 2, 3, 2);
            cboMonAn.Name = "cboMonAn";
            cboMonAn.Size = new Size(190, 23);
            cboMonAn.TabIndex = 6;
            cboMonAn.SelectionChangeCommitted += cboMonAn_SelectionChangeCommitted;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 28);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 6;
            label4.Text = "Món ăn(*):";
            // 
            // btnLuuHoaDon
            // 
            btnLuuHoaDon.ForeColor = Color.Blue;
            btnLuuHoaDon.Location = new Point(288, 385);
            btnLuuHoaDon.Margin = new Padding(3, 2, 3, 2);
            btnLuuHoaDon.Name = "btnLuuHoaDon";
            btnLuuHoaDon.Size = new Size(108, 22);
            btnLuuHoaDon.TabIndex = 14;
            btnLuuHoaDon.Text = "Lưu hóa đơn...";
            btnLuuHoaDon.UseVisualStyleBackColor = true;
            btnLuuHoaDon.Click += btnLuuHoaDon_Click;
            // 
            // btnThoat
            // 
            btnThoat.ForeColor = Color.Red;
            btnThoat.Location = new Point(402, 385);
            btnThoat.Margin = new Padding(3, 2, 3, 2);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(108, 22);
            btnThoat.TabIndex = 15;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // frmHoaDon_ChiTiet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(827, 418);
            Controls.Add(btnThoat);
            Controls.Add(btnLuuHoaDon);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmHoaDon_ChiTiet";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hóa Đơn Chi Tiết";
            Load += frmHoaDon_ChiTiet_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuongBan).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDonGiaBan).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private TextBox txtGhiChuHoaDon;
        private Label label3;
        private ComboBox cboKhachHang;
        private ComboBox cboNhanVien;
        private GroupBox groupBox2;
        private Label label5;
        private ComboBox cboMonAn;
        private Label label4;
        private Button btnXoa;
        private Button btnXacNhanBan;
        private NumericUpDown numSoLuongBan;
        private Label label6;
        private NumericUpDown numDonGiaBan;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn ThucAnID;
        private DataGridViewTextBoxColumn TenThucAn;
        private DataGridViewTextBoxColumn DonGiaBan;
        private DataGridViewTextBoxColumn SoLuongBan;
        private DataGridViewTextBoxColumn ThanhTien;
        private Button btnLuuHoaDon;
        private Button btnThoat;
        private TextBox txtDienThoai;
        private Label label8;
        private TextBox txtDiaChi;
        private Label label7;
    }
}