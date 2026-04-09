using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanAn.Data;
namespace QuanLyQuanAn.Forms
{
    public partial class frmHoaDon_ChiTiet : Form
    {
        QLQADbContext context = new QLQADbContext(); // Khởi tạo biến ngữ cảnh CSDL
        int id; // Lấy mã hóa đơn (dùng cho Sửa và Xóa)
        string tablename = "";
        string nv;
        BindingList<DanhSachHoaDon_ChiTiet> hoaDonChiTiet = new BindingList<DanhSachHoaDon_ChiTiet>();
        public frmHoaDon_ChiTiet()
        {
            InitializeComponent();
        }
        public frmHoaDon_ChiTiet(string ban, string nv)
        {
            InitializeComponent();
            tablename = ban;
            this.nv = nv;
        }
        public frmHoaDon_ChiTiet(int maHoaDon = 0)
        {
            InitializeComponent();
            id = maHoaDon;
        }
        public void LayNhanVienVaoComboBox()
        {
            cboNhanVien.DataSource = context.NhanVien.Where(r => r.TrangThai == 1).ToList();
            cboNhanVien.ValueMember = "ID";
            cboNhanVien.DisplayMember = "HoVaTen";
        }
        public void LayKhachHangVaoComboBox()
        {
            var kh = context.KhachHang.Where(r => r.TrangThai == 1).ToList();
            var hd = context.HoaDon.Where(r => r.NgayLap.Date == DateTime.Now.Date).ToList();

            // Tìm bàn hiện tại TRƯỚC khi vào vòng lặp
            var b = context.Ban.FirstOrDefault(r => r.TenBan == tablename);

            // Chỉ thực hiện lọc nếu tìm thấy bàn (b != null)
            if (b != null)
            {
                foreach (var d in hd)
                {
                    // Sử dụng ToList() để tránh lỗi "Collection was modified" đã gặp trước đó
                    foreach (var c in kh.ToList())
                    {
                        if (d.KhachHangID == c.ID && d.trangthai == 0 && d.BanID != b.ID)
                        {
                            kh.Remove(c);
                        }
                    }
                }
            }
            cboKhachHang.DataSource = kh;
            cboKhachHang.ValueMember = "ID";
            cboKhachHang.DisplayMember = "HoVaTen";
            cboKhachHang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboKhachHang.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        public void LayThucAnVaoComboBox()
        {
            cboMonAn.DataSource = context.ThucAn.Where(r => r.TrangThai == "Đang hoạt động").ToList();
            cboMonAn.ValueMember = "ID";
            cboMonAn.DisplayMember = "TenThucAn";
            cboMonAn.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboMonAn.AutoCompleteSource = AutoCompleteSource.ListItems;

        }
        public void BatTatChucNang()
        {
            if (id == 0 && dataGridView.Rows.Count == 0) // Thêm
            {
                // Xóa trắng các trường
                cboKhachHang.Text = "";
                cboMonAn.Text = "";
                numSoLuongBan.Value = 1;
                numDonGiaBan.Value = 0;
            }
            // Nút lưu và xóa chỉ sáng khi có sản phẩm
            btnLuuHoaDon.Enabled = dataGridView.Rows.Count > 0;
            btnXoa.Enabled = dataGridView.Rows.Count > 0;
        }
        private void frmHoaDon_ChiTiet_Load(object sender, EventArgs e)
        {
            LayNhanVienVaoComboBox();
            LayKhachHangVaoComboBox();
            LayThucAnVaoComboBox();
            cboKhachHang.SelectedValue = -1;
            dataGridView.AutoGenerateColumns = false;

            if (id != 0) // Đã tồn tại chi tiết
            {
                var hoaDon = context.HoaDon.Where(r => r.ID == id).SingleOrDefault();
                cboNhanVien.SelectedValue = hoaDon.NhanVienID;
                cboKhachHang.SelectedValue = hoaDon.KhachHangID;
                var kh =context.KhachHang.Find(hoaDon.KhachHangID);
                cboKhachHang.SelectedIndex=cboKhachHang.FindStringExact(kh.HoVaTen.ToString());
                txtDienThoai.Text = kh.DienThoai;
                txtDiaChi.Text = kh.DiaChi;
                txtGhiChuHoaDon.Text = hoaDon.GhiChuHoaDon;
                var ct = context.HoaDon_ChiTiet.Where(r => r.HoaDonID == id).Select(r => new DanhSachHoaDon_ChiTiet
                {
                    ID = r.ID,
                    HoaDonID = r.HoaDonID,
                    ThucAnID = r.ThucAnID,
                    TenThucAn = r.ThucAn.TenThucAn,
                    SoLuongBan = r.SoLuongBan,
                    DonGiaBan = r.DonGiaBan,
                    ThanhTien = Convert.ToInt32(r.SoLuongBan * r.DonGiaBan)
                }).ToList();
                hoaDonChiTiet = new BindingList<DanhSachHoaDon_ChiTiet>(ct);
            }
            dataGridView.DataSource = hoaDonChiTiet;
            BatTatChucNang();
            int index = cboNhanVien.FindStringExact(nv);
            if (index != -1)
            {
                cboNhanVien.SelectedIndex = index;

            }
            cboNhanVien.Enabled = false;
        }

        private void btnXacNhanBan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboMonAn.Text))
                MessageBox.Show("Vui lòng chọn món ăn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numSoLuongBan.Value <= 0)
                MessageBox.Show("Số lượng bán phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numDonGiaBan.Value <= 0)
                MessageBox.Show("Đơn giá bán sản phẩm phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                int maSanPham = Convert.ToInt32(cboMonAn.SelectedValue.ToString());
                var chiTiet = hoaDonChiTiet.FirstOrDefault(x => x.ThucAnID == maSanPham);
                // Nếu đã tồn tại sản phẩm thì cập nhật thông tin 
                if (chiTiet != null)
                {
                    chiTiet.SoLuongBan = Convert.ToInt32(numSoLuongBan.Value);
                    chiTiet.DonGiaBan = Convert.ToInt32(numDonGiaBan.Value);
                    chiTiet.ThanhTien = Convert.ToInt32(numSoLuongBan.Value * numDonGiaBan.Value);
                    dataGridView.Refresh();
                }
                else // Nếu chưa có sản phẩm thì thêm vào
                {
                    // Nếu chưa có sản phẩm nào
                    DanhSachHoaDon_ChiTiet ct = new DanhSachHoaDon_ChiTiet
                    {
                        ID = 0,
                        HoaDonID = id,
                        ThucAnID = maSanPham,
                        TenThucAn = cboMonAn.Text,
                        SoLuongBan = Convert.ToInt32(numSoLuongBan.Value),
                        DonGiaBan = Convert.ToInt32(numDonGiaBan.Value),
                        ThanhTien = Convert.ToInt32(numSoLuongBan.Value * numDonGiaBan.Value)
                    };
                    hoaDonChiTiet.Add(ct);
                }
                BatTatChucNang();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maThucAn = Convert.ToInt32(dataGridView.CurrentRow.Cells["ThucAnID"].Value.ToString());
            var chiTiet = hoaDonChiTiet.FirstOrDefault(x => x.ThucAnID == maThucAn);
            if (chiTiet != null)
            {
                hoaDonChiTiet.Remove(chiTiet);
            }
            BatTatChucNang();
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboNhanVien.Text))
                MessageBox.Show("Vui lòng chọn nhân viên lập hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(cboKhachHang.Text))
                MessageBox.Show("Vui lòng chọn khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (id != 0) // Đã tồn tại chi tiết thì chỉ cập nhật
                {
                    HoaDon hd = context.HoaDon.Find(id);
                    if (hd != null)
                    {
                        if (cboKhachHang.SelectedItem!=null)
                            hd.KhachHangID = Convert.ToInt32(cboKhachHang.SelectedValue.ToString());
                        else
                        {
                            if (txtDienThoai.Text.Length != 10 || txtDienThoai.Text[0] != '0')
                            {
                                for (int i = 0; i < txtDienThoai.Text.Length; i++)
                                {
                                    if (!char.IsDigit(txtDienThoai.Text[i]))
                                    {
                                        MessageBox.Show("Số điện thoại phải là số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                MessageBox.Show("Sai định dạng số điện thoại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            KhachHang kh = new KhachHang();
                            kh.HoVaTen = cboKhachHang.Text;
                            kh.DienThoai = txtDienThoai.Text;
                            kh.DiaChi = txtDiaChi.Text;
                            kh.TrangThai = 1;
                            context.KhachHang.Add(kh);
                            context.SaveChanges();
                            hd.KhachHangID = kh.ID;
                        }
                        hd.NhanVienID = Convert.ToInt32(cboNhanVien.SelectedValue.ToString());
                        hd.GhiChuHoaDon = txtGhiChuHoaDon.Text;
                        context.HoaDon.Update(hd);
                        // Xóa chi tiết cũ
                        var old = context.HoaDon_ChiTiet.Where(r => r.HoaDonID == id).ToList();
                        context.HoaDon_ChiTiet.RemoveRange(old);
                        // Thêm lại chi tiết mới
                        decimal tongtien = 0;
                        foreach (var item in hoaDonChiTiet.ToList())
                        {
                            HoaDon_ChiTiet ct = new HoaDon_ChiTiet();
                            ct.HoaDonID = (id != 0) ? id : hd.ID;
                            ct.ThucAnID = item.ThucAnID;
                            ct.SoLuongBan = item.SoLuongBan;
                            ct.DonGiaBan = item.DonGiaBan;
                            tongtien += (decimal)(ct.DonGiaBan * ct.SoLuongBan);

                            context.HoaDon_ChiTiet.Add(ct);
                        }
                        hd.TongTien = tongtien;
                        context.SaveChanges();

                    }
                }
                else // Thêm mới
                {
                    HoaDon hd = new HoaDon();
                    hd.NhanVienID = Convert.ToInt32(cboNhanVien.SelectedValue.ToString());
                    if (cboKhachHang.SelectedItem!=null)
                        hd.KhachHangID = Convert.ToInt32(cboKhachHang.SelectedValue.ToString());
                    else
                    {
                        if (txtDienThoai.Text.Length != 10 || txtDienThoai.Text[0] != '0')
                        {
                            for (int i = 0; i < txtDienThoai.Text.Length; i++)
                            {
                                if (!char.IsDigit(txtDienThoai.Text[i]))
                                {
                                    MessageBox.Show("Số điện thoại phải là số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            MessageBox.Show("Sai định dạng số điện thoại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        KhachHang kh = new KhachHang();
                        kh.HoVaTen = cboKhachHang.Text;
                        kh.DienThoai = txtDienThoai.Text;
                        kh.DiaChi = txtDiaChi.Text;
                        kh.TrangThai = 1;
                        context.KhachHang.Add(kh);
                        context.SaveChanges();
                        hd.KhachHangID = kh.ID;
                    }
                    hd.NgayLap = DateTime.Now;
                    hd.GhiChuHoaDon = txtGhiChuHoaDon.Text;
                    hd.trangthai = 0;
                    var result = context.Ban.FirstOrDefault(r => r.TenBan.Contains(tablename));
                    if (result != null)
                    {
                        hd.BanID = result.ID;
                    }
                    context.HoaDon.Add(hd);
                    context.SaveChanges();
                    // Thêm chi tiết
                    decimal tongtien = 0;
                    foreach (var item in hoaDonChiTiet.ToList())
                    {
                        HoaDon_ChiTiet ct = new HoaDon_ChiTiet();
                        ct.HoaDonID = hd.ID;
                        ct.ThucAnID = item.ThucAnID;
                        ct.SoLuongBan = item.SoLuongBan;
                        ct.DonGiaBan = item.DonGiaBan;
                        tongtien += (decimal)(ct.DonGiaBan * ct.SoLuongBan);
                        context.HoaDon_ChiTiet.Add(ct);
                    }
                    hd.TongTien = tongtien;
                    context.SaveChanges();
                }
                MessageBox.Show("Đã lưu thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }

        private void cboMonAn_SelectionChangeCommitted(object sender, EventArgs e)
        {
            {
                int maThucAn = Convert.ToInt32(cboMonAn.SelectedValue.ToString());
                var thucAn = context.ThucAn.Find(maThucAn);
                numDonGiaBan.Value = thucAn.Gia;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboKhachHang_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int makh = Convert.ToInt32(cboKhachHang.SelectedValue.ToString());
            var KH=context.KhachHang.Find(makh);
            txtDiaChi.Text = KH.DiaChi;
            txtDienThoai.Text = KH.DienThoai;
        }
    }
}
