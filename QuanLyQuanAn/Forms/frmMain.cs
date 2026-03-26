using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.IdentityModel.Tokens;
using QuanLyQuanAn.Data;
using QuanLyQuanAn.Reports;
using BC= BCrypt.Net.BCrypt;
namespace QuanLyQuanAn.Forms
{

    public partial class frmMain : Form
    {
        QLQADbContext context = new QLQADbContext();
        frmBan ban = null;
        frmBangCong bangCong = null;
        frmCaLam caLam = null;
        frmChucVu chucVu = null;
        frmDanhMuc danhMuc = null;
        frmDonViTinh donViTinh = null;
        frmLichLam lichLam = null;
        frmNguyenLieu nguyenLieu = null;
        frmNhaCungCap nhaCungCap = null;
        frmPhieuNhapKho phieuNhapKho = null;
        frmThucAn thucAn = null;
        frmKhachHang khachHang = null;
        frmNhanVien nhanVien = null;
        frmHoaDon hoaDon = null;
        frmDangNhap dangNhap = null;
        public string hoVaTenNhanVien = ""; // Lấy tên người dùng hiển thị vào thanh Status.
        public frmMain()
        {
            InitializeComponent();
        }

        private void mnuBan_Click(object sender, EventArgs e)
        {

            if (ban == null || ban.IsDisposed)
            {
                ban = new frmBan(hoVaTenNhanVien);
                ban.MdiParent = this;
                ban.FormBorderStyle = FormBorderStyle.None;
                ban.Dock = DockStyle.Fill;
                ban.Show();
            }
            else
                ban.Activate();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ChuaDangNhap();
            DangNhap();
            pictureBox1.SendToBack();
            mnuBan_Click(sender, e);
        }

        private void mnuBangCong_Click(object sender, EventArgs e)
        {
            if (bangCong == null || bangCong.IsDisposed)
            {
                bangCong = new frmBangCong();
                bangCong.MdiParent = this;
                bangCong.FormBorderStyle = FormBorderStyle.None;
                bangCong.Dock = DockStyle.Fill;
                bangCong.Show();
            }
            else
                bangCong.Activate();
        }

        private void mnuCaLam_Click(object sender, EventArgs e)
        {
            if (caLam == null || caLam.IsDisposed)
            {
                caLam = new frmCaLam();
                caLam.MdiParent = this;
                caLam.FormBorderStyle = FormBorderStyle.None;
                caLam.Dock = DockStyle.Fill;
                caLam.Show();
            }
            else
                caLam.Activate();

        }

        private void mnuChucVu_Click(object sender, EventArgs e)
        {
            if (chucVu == null || chucVu.IsDisposed)
            {
                chucVu = new frmChucVu();
                chucVu.MdiParent = this;
                chucVu.FormBorderStyle = FormBorderStyle.None;
                chucVu.Dock = DockStyle.Fill;
                chucVu.Show();
            }
            else
                chucVu.Activate();
        }

        private void mnuDanhMuc_Click(object sender, EventArgs e)
        {
            if (danhMuc == null || danhMuc.IsDisposed)
            {
                danhMuc = new frmDanhMuc();
                danhMuc.MdiParent = this;
                danhMuc.FormBorderStyle = FormBorderStyle.None;
                danhMuc.Dock = DockStyle.Fill;
                danhMuc.Show();
            }
            else
                danhMuc.Activate();
        }

        private void mnuDonViTinh_Click(object sender, EventArgs e)
        {
            if (donViTinh == null || donViTinh.IsDisposed)
            {
                donViTinh = new frmDonViTinh();
                donViTinh.MdiParent = this;
                donViTinh.FormBorderStyle = FormBorderStyle.None;
                donViTinh.Dock = DockStyle.Fill;
                donViTinh.Show();
            }
            else
                donViTinh.Activate();
        }

        private void mnuHoaDon_Click(object sender, EventArgs e)
        {
            if (hoaDon == null || hoaDon.IsDisposed)
            {
                hoaDon = new frmHoaDon();
                hoaDon.MdiParent = this;
                hoaDon.FormBorderStyle = FormBorderStyle.None;
                hoaDon.Dock = DockStyle.Fill;
                hoaDon.Show();
            }
            else
                hoaDon.Activate();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            if (khachHang == null || khachHang.IsDisposed)
            {
                khachHang = new frmKhachHang();
                khachHang.MdiParent = this;
                khachHang.FormBorderStyle = FormBorderStyle.None;
                khachHang.Dock = DockStyle.Fill;
                khachHang.Show();
            }
            else
                khachHang.Activate();
        }

        private void mnuLichLam_Click(object sender, EventArgs e)
        {
            if (lichLam == null || lichLam.IsDisposed)
            {
                lichLam = new frmLichLam();
                lichLam.MdiParent = this;
                lichLam.FormBorderStyle = FormBorderStyle.None;
                lichLam.Dock = DockStyle.Fill;
                lichLam.Show();
            }
            else
                lichLam.Activate();
        }

        private void mnuNguyenLieu_Click(object sender, EventArgs e)
        {
            if (nguyenLieu == null || nguyenLieu.IsDisposed)
            {
                nguyenLieu = new frmNguyenLieu();
                nguyenLieu.MdiParent = this;
                nguyenLieu.FormBorderStyle = FormBorderStyle.None;
                nguyenLieu.Dock = DockStyle.Fill;
                nguyenLieu.Show();
            }
            else
                nguyenLieu.Activate();
        }

        private void mnuNhaCungCap_Click(object sender, EventArgs e)
        {
            if (nhaCungCap == null || nhaCungCap.IsDisposed)
            {
                nhaCungCap = new frmNhaCungCap();
                nhaCungCap.MdiParent = this;
                nhaCungCap.FormBorderStyle = FormBorderStyle.None;
                nhaCungCap.Dock = DockStyle.Fill;
                nhaCungCap.Show();
            }
            else
                nhaCungCap.Activate();
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            if (nhanVien == null || nhanVien.IsDisposed)
            {
                nhanVien = new frmNhanVien();
                nhanVien.MdiParent = this;
                nhanVien.FormBorderStyle = FormBorderStyle.None;
                nhanVien.Dock = DockStyle.Fill;
                nhanVien.Show();
            }
            else
                nhanVien.Activate();
        }

        private void mnuPhieuNhapKho_Click(object sender, EventArgs e)
        {
            if (phieuNhapKho == null || phieuNhapKho.IsDisposed)
            {
                phieuNhapKho = new frmPhieuNhapKho();
                phieuNhapKho.MdiParent = this;
                phieuNhapKho.FormBorderStyle = FormBorderStyle.None;
                phieuNhapKho.Dock = DockStyle.Fill;
                phieuNhapKho.Show();
            }
            else
                phieuNhapKho.Activate();
        }

        private void mnuThucAn_Click(object sender, EventArgs e)
        {
            if (thucAn == null || thucAn.IsDisposed)
            {
                thucAn = new frmThucAn();
                thucAn.MdiParent = this;
                thucAn.FormBorderStyle = FormBorderStyle.None;
                thucAn.Dock = DockStyle.Fill;
                thucAn.Show();
            }
            else
                thucAn.Activate();
        }
        private void DangNhap()
        {
            QLQADbContext context = new QLQADbContext();
        LamLai:
            if (dangNhap == null || dangNhap.IsDisposed)
                dangNhap = new frmDangNhap();
            if (dangNhap.ShowDialog() == DialogResult.OK)
            {
                string tenDangNhap = dangNhap.txtTenDangNhap.Text;
                string matKhau = dangNhap.txtMatKhau.Text;
                if (tenDangNhap.Trim() == "")
                {
                    MessageBox.Show("Tên đăng nhập không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dangNhap.txtTenDangNhap.Focus();
                    goto LamLai;
                }
                else if (matKhau.Trim() == "")
                {
                    MessageBox.Show("Mật khẩu không được bỏ trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dangNhap.txtMatKhau.Focus();
                    goto LamLai;
                }
                else
                {
                    var nhanVien = context.NhanVien.Where(r => r.TenDangNhap == tenDangNhap).SingleOrDefault();
                    if (nhanVien == null)
                    {
                        MessageBox.Show("Tên đăng nhập không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dangNhap.txtTenDangNhap.Focus();
                        goto LamLai;
                    }
                    else
                    {

                        if (BC.Verify(matKhau, nhanVien.MatKhau))
                        {
                            hoVaTenNhanVien = nhanVien.HoVaTen;
                            Session.UserId = nhanVien.ID.ToString();
                            Session.UserName = nhanVien.HoVaTen;
                            if (nhanVien.QuyenHan == true)
                                QuyenQuanLy();
                            else if (nhanVien.QuyenHan == false)
                            {
                                var cv = context.ChucVu.FirstOrDefault(r => r.ID == nhanVien.ChucVuID);
                                if (cv != null && cv.TenChucVu == "Thu ngân")
                                    QuyenThuNgan();
                                else if (cv.TenChucVu == "Bếp trưởng")
                                    QuyenBepTruong();
                                else
                                    QuyenNhanVien();
                            }
                            else
                                ChuaDangNhap();
                            dangNhap.txtMatKhau.Clear();

                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dangNhap.txtMatKhau.Focus();
                            goto LamLai;
                        }
                    }
                }
            }
        }
        private void ChuaDangNhap()
        {
            mnuDangNhap.Enabled = true;

            mnuDangXuat.Enabled = false;
            mnuDoiMatKhau.Enabled = false;

            mnuBan.Enabled = false;
            mnuBangCong.Enabled = false;
            mnuCaLam.Enabled = false;
            mnuChucVu.Enabled = false;
            mnuDanhMuc.Enabled = false;
            mnuDonViTinh.Enabled = false;
            mnuHoaDon.Enabled = false;
            mnuKhachHang.Enabled = false;
            mnuLichLam.Enabled = false;
            mnuNguyenLieu.Enabled = false;
            mnuNhaCungCap.Enabled = false;
            mnuNhanVien.Enabled = false;
            mnuPhieuNhapKho.Enabled = false;
            mnuThucAn.Enabled = false;

            mnuBaoCaoTonKho.Enabled = false;
            mnuBaoCaoDoanhThu.Enabled = false;

            lblTrangThai.Text = "Chưa đăng nhập";
        }
        private void QuyenQuanLy()
        {
            mnuDangNhap.Enabled = false;

            mnuDangXuat.Enabled = true;
            mnuDoiMatKhau.Enabled = true;
            mnuBan.Enabled = true;
            mnuBangCong.Enabled = true;
            mnuCaLam.Enabled = true;
            mnuChucVu.Enabled = true;
            mnuDanhMuc.Enabled = true;
            mnuDonViTinh.Enabled = true;
            mnuHoaDon.Enabled = true;
            mnuKhachHang.Enabled = true;
            mnuLichLam.Enabled = true;
            mnuNguyenLieu.Enabled = true;
            mnuNhaCungCap.Enabled = true;
            mnuNhanVien.Enabled = true;
            mnuPhieuNhapKho.Enabled = true;
            mnuThucAn.Enabled = true;

            mnuBaoCaoTonKho.Enabled = true;
            mnuBaoCaoDoanhThu.Enabled = true;

            lblTrangThai.Text = "Quản lý: " + hoVaTenNhanVien;


        }
        private void QuyenThuNgan()
        {
            mnuDangNhap.Enabled = false;

            mnuDangXuat.Enabled = true;
            mnuDoiMatKhau.Enabled = true;
            mnuBan.Enabled = true;
            mnuBangCong.Enabled = false;
            mnuCaLam.Enabled = false;
            mnuChucVu.Enabled = false;
            mnuDanhMuc.Enabled = false;
            mnuDonViTinh.Enabled = false;
            mnuHoaDon.Enabled = true;
            mnuKhachHang.Enabled = true;
            mnuLichLam.Enabled = true;
            mnuNguyenLieu.Enabled = false;
            mnuNhaCungCap.Enabled = false;
            mnuNhanVien.Enabled = false;
            mnuPhieuNhapKho.Enabled = false;
            mnuThucAn.Enabled = false;

            mnuBaoCaoTonKho.Enabled = false;
            mnuBaoCaoDoanhThu.Enabled = true;

            lblTrangThai.Text = "Thu ngân: " + hoVaTenNhanVien;
        }
        private void QuyenBepTruong()
        {
            mnuDangNhap.Enabled = false;

            mnuDangXuat.Enabled = true;
            mnuDoiMatKhau.Enabled = true;
            mnuBan.Enabled = false;
            mnuBangCong.Enabled = false;
            mnuCaLam.Enabled = false;
            mnuChucVu.Enabled = false;
            mnuDanhMuc.Enabled = false;
            mnuDonViTinh.Enabled = false;
            mnuHoaDon.Enabled = false;
            mnuKhachHang.Enabled = false;
            mnuLichLam.Enabled = false;
            mnuNguyenLieu.Enabled = true;
            mnuNhaCungCap.Enabled = true;
            mnuNhanVien.Enabled = false;
            mnuPhieuNhapKho.Enabled = true;
            mnuThucAn.Enabled = true;

            mnuBaoCaoTonKho.Enabled = true;
            mnuBaoCaoDoanhThu.Enabled = false;

            lblTrangThai.Text = "Bếp trưởng: " + hoVaTenNhanVien;

        }
        private void QuyenNhanVien()
        {
            mnuDangNhap.Enabled = false;

            mnuDangXuat.Enabled = true;
            mnuDoiMatKhau.Enabled = true;
            mnuBan.Enabled = false;
            mnuBangCong.Enabled = false;
            mnuCaLam.Enabled = false;
            mnuChucVu.Enabled = false;
            mnuDanhMuc.Enabled = false;
            mnuDonViTinh.Enabled = false;
            mnuHoaDon.Enabled = false;
            mnuKhachHang.Enabled = false;
            mnuLichLam.Enabled = false;
            mnuNguyenLieu.Enabled = false;
            mnuNhaCungCap.Enabled = false;
            mnuNhanVien.Enabled = false;
            mnuPhieuNhapKho.Enabled = false;
            mnuThucAn.Enabled = false;

            mnuBaoCaoTonKho.Enabled = false;
            mnuBaoCaoDoanhThu.Enabled = false;

            lblTrangThai.Text = "Nhân viên: " + hoVaTenNhanVien;
        }


        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.Close();
            }
            ChuaDangNhap();
            pictureBox1.BringToFront();
        }

        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();
            pictureBox1.SendToBack();
            mnuBan_Click(sender, e);
        }
        private void mnuHeThong_Click(object sender, EventArgs e)
        {
            frmNhatKy f = new frmNhatKy();
            f.MdiParent = this;
            f.Dock = DockStyle.Fill;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Show();
        }

        private void mnuBaoCaoTonKho_Click(object sender, EventArgs e)
        {
            frmBaoCaoTonKho f = new frmBaoCaoTonKho();
            f.MdiParent = this;
            f.Dock = DockStyle.Fill;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Show();
        }

        private void mnuBaoCaoDoanhThu_Click(object sender, EventArgs e)
        {
            frmBaoCaoDoanhThu f = new frmBaoCaoDoanhThu();
            f.MdiParent = this;
            f.Dock = DockStyle.Fill;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Show();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có thật sự muốn thoát?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (r == DialogResult.OK)
                this.Close();
        }

        private void mnuBaoCaoLoiNhuan_Click(object sender, EventArgs e)
        {
            frmBaoCaoLoiNhuan f = new frmBaoCaoLoiNhuan();
            f.MdiParent = this;
            f.Dock = DockStyle.Fill;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Show();
        }

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau(hoVaTenNhanVien);
            frm.ShowDialog();
        }

        private void mnuHuongDanSuDung_Click(object sender, EventArgs e)
        {
            // Lấy đường dẫn đầy đủ đến file HTML
            string url = Path.Combine(Application.StartupPath, "Help", "main.html");

            try
            {
                if (File.Exists(url))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show("Không tìm thấy file tại: " + url, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở liên kết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void mnuThongTinPhanMem_Click(object sender, EventArgs e)
        {
            string url = Path.Combine(Application.StartupPath, "Help", "thongtinphanmem.html");

            try
            {
                if (File.Exists(url))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show("Không tìm thấy file tại: " + url, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở liên kết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuNhatKyHeThong_Click(object sender, EventArgs e)
        {
            frmNhatKy f = new frmNhatKy();
            f.MdiParent = this;
            f.Dock = DockStyle.Fill;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Show();
        }
    }
}
