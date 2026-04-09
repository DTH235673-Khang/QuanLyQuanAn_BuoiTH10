namespace QuanLyQuanAn.Forms
{
    partial class frmMain
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
            menuStrip = new MenuStrip();
            mnuHeThong = new ToolStripMenuItem();
            mnuDangNhap = new ToolStripMenuItem();
            mnuDangXuat = new ToolStripMenuItem();
            mnuDoiMatKhau = new ToolStripMenuItem();
            mnuThoat = new ToolStripMenuItem();
            mnuNhatKyHeThong = new ToolStripMenuItem();
            mnuQuanLy = new ToolStripMenuItem();
            mnuBan = new ToolStripMenuItem();
            mnuBangCong = new ToolStripMenuItem();
            mnuCaLam = new ToolStripMenuItem();
            mnuChucVu = new ToolStripMenuItem();
            mnuDanhMuc = new ToolStripMenuItem();
            mnuDonViTinh = new ToolStripMenuItem();
            mnuHoaDon = new ToolStripMenuItem();
            mnuKhachHang = new ToolStripMenuItem();
            mnuLichLam = new ToolStripMenuItem();
            mnuNguyenLieu = new ToolStripMenuItem();
            mnuNhaCungCap = new ToolStripMenuItem();
            mnuNhanVien = new ToolStripMenuItem();
            mnuPhieuNhapKho = new ToolStripMenuItem();
            mnuThucAn = new ToolStripMenuItem();
            mnuBaoCaoThongKe = new ToolStripMenuItem();
            mnuBaoCaoTonKho = new ToolStripMenuItem();
            mnuBaoCaoDoanhThu = new ToolStripMenuItem();
            mnuBaoCaoLoiNhuan = new ToolStripMenuItem();
            mnuTroGiup = new ToolStripMenuItem();
            mnuHuongDanSuDung = new ToolStripMenuItem();
            mnuThongTinPhanMem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblTrangThai = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lblKLienKet = new ToolStripStatusLabel();
            pictureBox1 = new PictureBox();
            mnuFont = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { mnuHeThong, mnuQuanLy, mnuBaoCaoThongKe, mnuTroGiup });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(6, 3, 0, 3);
            menuStrip.Size = new Size(1023, 30);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // mnuHeThong
            // 
            mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] { mnuDangNhap, mnuDangXuat, mnuDoiMatKhau, mnuThoat, mnuNhatKyHeThong, mnuFont });
            mnuHeThong.Name = "mnuHeThong";
            mnuHeThong.Size = new Size(85, 24);
            mnuHeThong.Text = "Hệ thống";
            // 
            // mnuDangNhap
            // 
            mnuDangNhap.Name = "mnuDangNhap";
            mnuDangNhap.Size = new Size(224, 26);
            mnuDangNhap.Text = "Đăng nhập";
            mnuDangNhap.Click += mnuDangNhap_Click;
            // 
            // mnuDangXuat
            // 
            mnuDangXuat.Name = "mnuDangXuat";
            mnuDangXuat.Size = new Size(224, 26);
            mnuDangXuat.Text = "Đăng xuất";
            mnuDangXuat.Click += mnuDangXuat_Click;
            // 
            // mnuDoiMatKhau
            // 
            mnuDoiMatKhau.Name = "mnuDoiMatKhau";
            mnuDoiMatKhau.Size = new Size(224, 26);
            mnuDoiMatKhau.Text = "Đổi mật khẩu";
            mnuDoiMatKhau.Click += mnuDoiMatKhau_Click;
            // 
            // mnuThoat
            // 
            mnuThoat.Name = "mnuThoat";
            mnuThoat.ShortcutKeys = Keys.Alt | Keys.F4;
            mnuThoat.Size = new Size(224, 26);
            mnuThoat.Text = "Thoát";
            mnuThoat.Click += mnuThoat_Click;
            // 
            // mnuNhatKyHeThong
            // 
            mnuNhatKyHeThong.Name = "mnuNhatKyHeThong";
            mnuNhatKyHeThong.Size = new Size(224, 26);
            mnuNhatKyHeThong.Text = "Nhật ký hệ thống";
            mnuNhatKyHeThong.Click += mnuNhatKyHeThong_Click;
            // 
            // mnuQuanLy
            // 
            mnuQuanLy.DropDownItems.AddRange(new ToolStripItem[] { mnuBan, mnuBangCong, mnuCaLam, mnuChucVu, mnuDanhMuc, mnuDonViTinh, mnuHoaDon, mnuKhachHang, mnuLichLam, mnuNguyenLieu, mnuNhaCungCap, mnuNhanVien, mnuPhieuNhapKho, mnuThucAn });
            mnuQuanLy.Name = "mnuQuanLy";
            mnuQuanLy.Size = new Size(73, 24);
            mnuQuanLy.Text = "Quản lý";
            // 
            // mnuBan
            // 
            mnuBan.Name = "mnuBan";
            mnuBan.Size = new Size(214, 26);
            mnuBan.Text = "Bàn";
            mnuBan.Click += mnuBan_Click;
            // 
            // mnuBangCong
            // 
            mnuBangCong.Name = "mnuBangCong";
            mnuBangCong.Size = new Size(214, 26);
            mnuBangCong.Text = "Bảng công";
            mnuBangCong.Click += mnuBangCong_Click;
            // 
            // mnuCaLam
            // 
            mnuCaLam.Name = "mnuCaLam";
            mnuCaLam.Size = new Size(214, 26);
            mnuCaLam.Text = "Ca làm";
            mnuCaLam.Click += mnuCaLam_Click;
            // 
            // mnuChucVu
            // 
            mnuChucVu.Name = "mnuChucVu";
            mnuChucVu.Size = new Size(214, 26);
            mnuChucVu.Text = "Chức vụ";
            mnuChucVu.Click += mnuChucVu_Click;
            // 
            // mnuDanhMuc
            // 
            mnuDanhMuc.Name = "mnuDanhMuc";
            mnuDanhMuc.Size = new Size(214, 26);
            mnuDanhMuc.Text = "Danh mục";
            mnuDanhMuc.Click += mnuDanhMuc_Click;
            // 
            // mnuDonViTinh
            // 
            mnuDonViTinh.Name = "mnuDonViTinh";
            mnuDonViTinh.Size = new Size(214, 26);
            mnuDonViTinh.Text = "Đơn vị tính";
            mnuDonViTinh.Click += mnuDonViTinh_Click;
            // 
            // mnuHoaDon
            // 
            mnuHoaDon.Name = "mnuHoaDon";
            mnuHoaDon.Size = new Size(214, 26);
            mnuHoaDon.Text = "Hóa đơn";
            mnuHoaDon.Click += mnuHoaDon_Click;
            // 
            // mnuKhachHang
            // 
            mnuKhachHang.Name = "mnuKhachHang";
            mnuKhachHang.Size = new Size(214, 26);
            mnuKhachHang.Text = "Khách hàng";
            mnuKhachHang.Click += mnuKhachHang_Click;
            // 
            // mnuLichLam
            // 
            mnuLichLam.Name = "mnuLichLam";
            mnuLichLam.Size = new Size(214, 26);
            mnuLichLam.Text = "Lịch làm";
            mnuLichLam.Click += mnuLichLam_Click;
            // 
            // mnuNguyenLieu
            // 
            mnuNguyenLieu.Name = "mnuNguyenLieu";
            mnuNguyenLieu.Size = new Size(214, 26);
            mnuNguyenLieu.Text = "Nguyên liệu";
            mnuNguyenLieu.Click += mnuNguyenLieu_Click;
            // 
            // mnuNhaCungCap
            // 
            mnuNhaCungCap.Name = "mnuNhaCungCap";
            mnuNhaCungCap.Size = new Size(214, 26);
            mnuNhaCungCap.Text = "Nhà cung cấp";
            mnuNhaCungCap.Click += mnuNhaCungCap_Click;
            // 
            // mnuNhanVien
            // 
            mnuNhanVien.Name = "mnuNhanVien";
            mnuNhanVien.Size = new Size(214, 26);
            mnuNhanVien.Text = "Nhân viên";
            mnuNhanVien.Click += mnuNhanVien_Click;
            // 
            // mnuPhieuNhapKho
            // 
            mnuPhieuNhapKho.Name = "mnuPhieuNhapKho";
            mnuPhieuNhapKho.Size = new Size(214, 26);
            mnuPhieuNhapKho.Text = "Phiếu nhập kho";
            mnuPhieuNhapKho.Click += mnuPhieuNhapKho_Click;
            // 
            // mnuThucAn
            // 
            mnuThucAn.Name = "mnuThucAn";
            mnuThucAn.Size = new Size(214, 26);
            mnuThucAn.Text = "Danh sách món ăn";
            mnuThucAn.Click += mnuThucAn_Click;
            // 
            // mnuBaoCaoThongKe
            // 
            mnuBaoCaoThongKe.DropDownItems.AddRange(new ToolStripItem[] { mnuBaoCaoTonKho, mnuBaoCaoDoanhThu, mnuBaoCaoLoiNhuan });
            mnuBaoCaoThongKe.Name = "mnuBaoCaoThongKe";
            mnuBaoCaoThongKe.Size = new Size(139, 24);
            mnuBaoCaoThongKe.Text = "Báo cáo thống kê";
            // 
            // mnuBaoCaoTonKho
            // 
            mnuBaoCaoTonKho.Name = "mnuBaoCaoTonKho";
            mnuBaoCaoTonKho.Size = new Size(217, 26);
            mnuBaoCaoTonKho.Text = "Báo cáo tồn kho";
            mnuBaoCaoTonKho.Click += mnuBaoCaoTonKho_Click;
            // 
            // mnuBaoCaoDoanhThu
            // 
            mnuBaoCaoDoanhThu.Name = "mnuBaoCaoDoanhThu";
            mnuBaoCaoDoanhThu.Size = new Size(217, 26);
            mnuBaoCaoDoanhThu.Text = "Báo cáo doanh thu";
            mnuBaoCaoDoanhThu.Click += mnuBaoCaoDoanhThu_Click;
            // 
            // mnuBaoCaoLoiNhuan
            // 
            mnuBaoCaoLoiNhuan.Name = "mnuBaoCaoLoiNhuan";
            mnuBaoCaoLoiNhuan.Size = new Size(217, 26);
            mnuBaoCaoLoiNhuan.Text = "Báo cáo lợi nhuận";
            mnuBaoCaoLoiNhuan.Click += mnuBaoCaoLoiNhuan_Click;
            // 
            // mnuTroGiup
            // 
            mnuTroGiup.DropDownItems.AddRange(new ToolStripItem[] { mnuHuongDanSuDung, mnuThongTinPhanMem });
            mnuTroGiup.Name = "mnuTroGiup";
            mnuTroGiup.Size = new Size(78, 24);
            mnuTroGiup.Text = "Trợ giúp";
            // 
            // mnuHuongDanSuDung
            // 
            mnuHuongDanSuDung.Name = "mnuHuongDanSuDung";
            mnuHuongDanSuDung.Size = new Size(287, 26);
            mnuHuongDanSuDung.Text = "Hướng dẫn sử dụng";
            mnuHuongDanSuDung.Click += mnuHuongDanSuDung_Click;
            // 
            // mnuThongTinPhanMem
            // 
            mnuThongTinPhanMem.Name = "mnuThongTinPhanMem";
            mnuThongTinPhanMem.ShortcutKeys = Keys.Control | Keys.F1;
            mnuThongTinPhanMem.Size = new Size(287, 26);
            mnuThongTinPhanMem.Text = "Thông tin phần mềm";
            mnuThongTinPhanMem.Click += mnuThongTinPhanMem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblTrangThai, toolStripStatusLabel1, lblKLienKet });
            statusStrip1.Location = new Point(0, 553);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1023, 26);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblTrangThai
            // 
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(118, 20);
            lblTrangThai.Text = "Chưa đăng nhập";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(809, 20);
            toolStripStatusLabel1.Spring = true;
            // 
            // lblKLienKet
            // 
            lblKLienKet.IsLink = true;
            lblKLienKet.Name = "lblKLienKet";
            lblKLienKet.Size = new Size(81, 20);
            lblKLienKet.Text = "© FIT 2026";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.banner1;
            pictureBox1.Location = new Point(0, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1023, 524);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // mnuFont
            // 
            mnuFont.Name = "mnuFont";
            mnuFont.Size = new Size(224, 26);
            mnuFont.Text = "Đổi font";
            mnuFont.Click += mnuFont_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1023, 579);
            Controls.Add(pictureBox1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip);
            Font = new Font("Segoe UI", 9F);
            ForeColor = Color.Black;
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý quán ăn";
            WindowState = FormWindowState.Maximized;
            FormClosing += frmMain_FormClosing;
            Load += frmMain_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem mnuHeThong;
        private ToolStripMenuItem mnuQuanLy;
        private ToolStripMenuItem mnuBaoCaoThongKe;
        private ToolStripMenuItem mnuTroGiup;
        private ToolStripMenuItem mnuDangNhap;
        private ToolStripMenuItem mnuDangXuat;
        private ToolStripMenuItem mnuDoiMatKhau;
        private ToolStripMenuItem mnuThoat;
        private ToolStripMenuItem mnuBan;
        private ToolStripMenuItem mnuThucAn;
        private ToolStripMenuItem mnuNguyenLieu;
        private ToolStripMenuItem mnuDonViTinh;
        private ToolStripMenuItem mnuDanhMuc;
        private ToolStripMenuItem mnuBangCong;
        private ToolStripMenuItem mnuCaLam;
        private ToolStripMenuItem mnuLichLam;
        private ToolStripMenuItem mnuChucVu;
        private ToolStripMenuItem mnuNhanVien;
        private ToolStripMenuItem mnuKhachHang;
        private ToolStripMenuItem mnuHoaDon;
        private ToolStripMenuItem mnuPhieuNhapKho;
        private ToolStripMenuItem mnuBaoCaoTonKho;
        private ToolStripMenuItem mnuBaoCaoDoanhThu;
        private ToolStripMenuItem mnuHuongDanSuDung;
        private ToolStripMenuItem mnuThongTinPhanMem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblTrangThai;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel lblKLienKet;
        private ToolStripMenuItem mnuNhaCungCap;
        private ToolStripMenuItem mnuBaoCaoLoiNhuan;
        private PictureBox pictureBox1;
        private ToolStripMenuItem mnuNhatKyHeThong;
        private ToolStripMenuItem mnuFont;
    }
}