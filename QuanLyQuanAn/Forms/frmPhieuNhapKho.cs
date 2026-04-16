using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using Microsoft.IdentityModel.Tokens;
using QuanLyQuanAn.Data;
using static QuanLyQuanAn.Data.HoaDon;
using static QuanLyQuanAn.Data.PhieuNhapKho;

namespace QuanLyQuanAn.Forms
{
    public partial class frmPhieuNhapKho : Form
    {
        QLQADbContext context = new QLQADbContext(); // Khởi tạo biến ngữ cảnh CSDL
        int id; // Lấy mã hóa đơn (dùng cho Sửa và Xóa)
        public frmPhieuNhapKho()
        {
            InitializeComponent();
            var nv = context.NhanVien.FirstOrDefault(r => r.ID == Convert.ToInt32(Session.UserId));
            var cv = context.ChucVu.FirstOrDefault(r => r.ID == nv.ChucVuID);
            if (cv != null && cv.TenChucVu != "Quản lý")
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLoad.Enabled = false;
                btnDuyetPhieu.Enabled = false;
            }
        }
        public void LayNhanVienVaoComboBox()
        {
            cboNhanVien.DataSource = context.NhanVien.Where(r => r.TrangThai == 1).ToList();
            cboNhanVien.ValueMember = "ID";
            cboNhanVien.DisplayMember = "HoVaTen";
            cboNhanVien.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboNhanVien.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        public void LayNhaCungCapVaoComboBox()
        {
            cboNhaCungCap.DataSource = context.NhaCungCap.Where(r => r.TrangThai == 1).ToList();
            cboNhaCungCap.ValueMember = "ID";
            cboNhaCungCap.DisplayMember = "TenNhaCungCap";
            cboNhaCungCap.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboNhaCungCap.AutoCompleteSource = AutoCompleteSource.ListItems;

        }
        private void frmPhieuNhapKho_Load(object sender, EventArgs e)
        {
            LayNhanVienVaoComboBox();
            LayNhaCungCapVaoComboBox();
            helpProvider.HelpNamespace = "Help/phieunhapkho.html";
            helpProvider.SetShowHelp(this, true);
            dataGridView.AutoGenerateColumns = false;
            List<DanhSachPhieuNhapKho> p = new List<DanhSachPhieuNhapKho>();
            p = context.PhieuNhapKho.Select(r => new DanhSachPhieuNhapKho
            {
                ID = r.ID,
                NhanVienID = r.NhanVienID,
                HoVaTenNhanVien = r.NhanVien.HoVaTen,
                NhaCungCapID = r.NhaCungCapID,
                TenNhaCungCap = r.NhaCungCap.TenNhaCungCap,
                NgayNhap = r.NgayNhap,
                TongTien = r.TongTien,
                TrangThai = r.TrangThai,
                GhiChu = r.GhiChu,
                XemChiTiet = "Xem chi tiết"
            }).ToList();
            dataGridView.DataSource = p;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            var p = context.PhieuNhapKho.Find(id);
            if (p.TrangThai == "Chưa duyệt")
            {
                using (frmPhieuNhapKho_ChiTiet chiTiet = new frmPhieuNhapKho_ChiTiet(id))
                {
                    chiTiet.ShowDialog();
                    frmPhieuNhapKho_Load(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Phiếu nhập kho đã duyệt không thể chỉnh sửa", "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            if (id.ToString().IsNullOrEmpty())
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập kho càn xóa!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                if (MessageBox.Show("Xác nhận xóa phiếu nhập kho " + id + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                    PhieuNhapKho t = context.PhieuNhapKho.Find(id);
                    if (t != null && t.TrangThai == "Chưa duyệt")
                    {
                        context.PhieuNhapKho.Remove(t);
                    }
                    else if (t.TrangThai == "Đã duyệt")
                    {
                        MessageBox.Show("Phiếu nhập kho đã duyệt không thể xóa", "Thông báo");
                    }
                    context.SaveChanges();
                    frmPhieuNhapKho_Load(sender, e);
                }
            }
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            var parent = (frmMain)this.MdiParent;
            using (frmPhieuNhapKho_ChiTiet chitiet = new frmPhieuNhapKho_ChiTiet(parent.hoVaTenNhanVien))
            {
                chitiet.ShowDialog();
                context.SaveChanges();
                frmPhieuNhapKho_Load(sender, e);
            }
        }
        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất dữ liệu ra tập tin Excel";
            saveFileDialog.Filter = "Tập tin Excel|*.xls;*.xlsx";
            saveFileDialog.FileName = "PhieuNhapKho_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // --- XỬ LÝ TABLE 1: HÓA ĐƠN ---
                    DataTable tableHD = new DataTable();
                    tableHD.Columns.AddRange(new DataColumn[] {
                new DataColumn("ID", typeof(int)),
                new DataColumn("NhanVien", typeof(string)),
                new DataColumn("NhaCungCap", typeof(string)),
                new DataColumn("NgayNhap", typeof(DateTime)),
                new DataColumn("GhiChu", typeof(string)),
                new DataColumn("TrangThai",typeof(string)),
                new DataColumn("TongTien",typeof(decimal))

            });

                    var dsPhieuNhapKho = context.PhieuNhapKho.ToList();
                    if (dsPhieuNhapKho != null)
                    {
                        foreach (var p in dsPhieuNhapKho)
                        {
                            var nv = context.NhanVien.FirstOrDefault(r => r.ID == p.NhanVienID);
                            var ncc = context.NhaCungCap.FirstOrDefault(r => r.ID == p.NhaCungCapID);
                            tableHD.Rows.Add(p.ID, nv.HoVaTen, ncc.TenNhaCungCap, p.NgayNhap, p.GhiChu, p.TrangThai, p.TongTien);
                        }
                    }

                    // --- XỬ LÝ TABLE 2: CHI TIẾT HÓA ĐƠN ---
                    DataTable tableCT = new DataTable();
                    tableCT.Columns.AddRange(new DataColumn[] {
                new DataColumn("ID", typeof(int)),
                new DataColumn("NguyenLieu", typeof(string)),
                new DataColumn("SoLuongNhap", typeof(int)),
                new DataColumn("GiaNhap", typeof(int))
            });

                    var dsChiTiet = context.PhieuNhapKho_ChiTiet.ToList();
                    if (dsChiTiet != null)
                    {
                        foreach (var d in dsChiTiet)
                        {
                            var t = context.NguyenLieu.FirstOrDefault(r => r.ID == d.NguyenLieuID);
                            tableCT.Rows.Add(d.PhieuNhapKhoID, t.TenNguyenLieu, d.SoLuongNhap, d.GiaNhap);
                        }
                    }

                    // --- XUẤT RA FILE EXCEL ---
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        // Thêm Sheet 1 từ tableHD
                        var sheet1 = wb.Worksheets.Add(tableHD, "HoaDon");
                        sheet1.Columns().AdjustToContents();

                        // Thêm Sheet 2 từ tableCT
                        var sheet2 = wb.Worksheets.Add(tableCT, "HoaDonChiTiet");
                        sheet2.Columns().AdjustToContents();

                        wb.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Đã xuất dữ liệu ra 2 Sheet thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnDuyetPhieu_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            if (id.ToString().IsNullOrEmpty())
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập kho càn duyệt!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                if (MessageBox.Show("Xác nhận duyệt phiếu nhập kho " + id + "? \n Lưu ý: Phiếu nhập kho đã duyệt sẽ không thể xóa hay chỉnh sửa.", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                    PhieuNhapKho t = context.PhieuNhapKho.Find(id);
                    var chitiet = context.PhieuNhapKho_ChiTiet.Where(r => r.PhieuNhapKhoID == id).ToList();
                    if (t != null && t.TrangThai == "Chưa duyệt")
                    {
                        t.TrangThai = "Đã duyệt";
                        t.NgayNhap = DateTime.Now;
                        foreach (var ch in chitiet)
                        {
                            var nguyenlieu = context.NguyenLieu.Find(ch.NguyenLieuID);
                            if (nguyenlieu != null)
                            {
                                nguyenlieu.SoLuongTon += ch.SoLuongNhap;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Phiếu nhập kho đã được duyệt", "Thông báo");
                    }
                    context.SaveChanges();
                    frmPhieuNhapKho_Load(sender, e);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            using (frmInPhieuNhapKho inPhieuNhapKho = new frmInPhieuNhapKho(id))
            {
                inPhieuNhapKho.ShowDialog();
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Kiểm tra xem người dùng có click vào hàng dữ liệu không (tránh click vào tiêu đề cột)
            if (e.RowIndex < 0) return;

            // 2. Kiểm tra xem người dùng có click đúng vào cột Link hay không
            // Bạn có thể kiểm tra theo Tên cột hoặc Chỉ số cột
            if (dataGridView.Columns[e.ColumnIndex].Name == "XemChiTiet")
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                using (frmInPhieuNhapKho inPhieuNhapKho = new frmInPhieuNhapKho(id))
                {
                    inPhieuNhapKho.ShowDialog();
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dataGridView.AutoGenerateColumns = false;
            List<DanhSachPhieuNhapKho> p = new List<DanhSachPhieuNhapKho>();
            if (cboNhanVien.SelectedIndex >= 0)
                p = context.PhieuNhapKho
                    .Where(r => r.NhanVienID == (int)cboNhanVien.SelectedValue && r.NgayNhap.Date == dtpNgay.Value.Date)
                    .Select(r => new DanhSachPhieuNhapKho
                    {
                        ID = r.ID,
                        NhanVienID = r.NhanVienID,
                        HoVaTenNhanVien = r.NhanVien.HoVaTen,
                        NhaCungCapID = r.NhaCungCapID,
                        TenNhaCungCap = r.NhaCungCap.TenNhaCungCap,
                        NgayNhap = r.NgayNhap,
                        TongTien = r.TongTien,
                        TrangThai = r.TrangThai,
                        GhiChu = r.GhiChu,
                        XemChiTiet = "Xem chi tiết"
                    }).ToList();
            if (cboNhaCungCap.SelectedIndex >= 0)
                p = context.PhieuNhapKho
                    .Where(r => r.NhaCungCapID == (int)cboNhaCungCap.SelectedValue && r.NgayNhap.Date == dtpNgay.Value.Date)
                    .Select(r => new DanhSachPhieuNhapKho
                    {
                        ID = r.ID,
                        NhanVienID = r.NhanVienID,
                        HoVaTenNhanVien = r.NhanVien.HoVaTen,
                        NhaCungCapID = r.NhaCungCapID,
                        TenNhaCungCap = r.NhaCungCap.TenNhaCungCap,
                        NgayNhap = r.NgayNhap,
                        TongTien = r.TongTien,
                        TrangThai = r.TrangThai,
                        GhiChu = r.GhiChu,
                        XemChiTiet = "Xem chi tiết"
                    }).ToList();
            dataGridView.DataSource = p;
        }

        private void btnXemTheoNgay_Click(object sender, EventArgs e)
        {
            dataGridView.AutoGenerateColumns = false;
            List<DanhSachPhieuNhapKho> p = new List<DanhSachPhieuNhapKho>();
            p = context.PhieuNhapKho
                .Where(r => r.NgayNhap.Date == dtpNgay.Value.Date)
                .Select(r => new DanhSachPhieuNhapKho
                {
                    ID = r.ID,
                    NhanVienID = r.NhanVienID,
                    HoVaTenNhanVien = r.NhanVien.HoVaTen,
                    NhaCungCapID = r.NhaCungCapID,
                    TenNhaCungCap = r.NhaCungCap.TenNhaCungCap,
                    NgayNhap = r.NgayNhap,
                    TongTien = r.TongTien,
                    TrangThai = r.TrangThai,
                    GhiChu = r.GhiChu,
                    XemChiTiet = "Xem chi tiết"
                }).ToList();
            dataGridView.DataSource = p;


        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            frmPhieuNhapKho_Load(sender, e);
        }
    }
}
    


    
