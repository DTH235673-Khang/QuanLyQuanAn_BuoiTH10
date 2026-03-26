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
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.IdentityModel.Tokens;
using QuanLyQuanAn.Data;
using static QuanLyQuanAn.Data.HoaDon;

namespace QuanLyQuanAn.Forms
{
    public partial class frmHoaDon : Form
    {
        QLQADbContext context = new QLQADbContext(); // Khởi tạo biến ngữ cảnh CSDL
        int id; // Lấy mã hóa đơn (dùng cho Sửa và Xóa)
        public frmHoaDon()
        {
            InitializeComponent();

        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            helpProvider.HelpNamespace = "Help/hoadon.html";
            helpProvider.SetShowHelp(this, true);
            dataGridView.AutoGenerateColumns = false;
            List<DanhSachHoaDon> hd = new List<DanhSachHoaDon>();
            hd = context.HoaDon.Select(r => new DanhSachHoaDon
            {
                ID = r.ID,
                NhanVienID = r.NhanVienID,
                HoVaTenNhanVien = r.NhanVien.HoVaTen,
                KhachHangID = r.KhachHangID,
                HoVaTenKhachHang = r.KhachHang.HoVaTen,
                BanID = r.BanID,
                NgayLap = r.NgayLap,
                GhiChuHoaDon = r.GhiChuHoaDon,
                TongTienHoaDon = r.TongTien,
                XemChiTiet = "Xem chi tiết"
            }).ToList();
            dataGridView.DataSource = hd;
        }



        private void btnSua_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            if (id.ToString().IsNullOrEmpty())
            {
                MessageBox.Show("Vui lòng chọn hóa đơn càn sửa!", "Thông báo", MessageBoxButtons.OK);
            }
            DateTime check = Convert.ToDateTime(dataGridView.CurrentRow.Cells["NgayLap"].Value.ToString());
            if (check.Date != DateTime.Now.Date)
            {
                MessageBox.Show("Chỉ có thể hiệu chỉnh hóa đơn trong ngày!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            using (frmHoaDon_ChiTiet chiTiet = new frmHoaDon_ChiTiet(id))
            {
                chiTiet.ShowDialog();
                frmHoaDon_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            if (id.ToString().IsNullOrEmpty())
            {
                MessageBox.Show("Vui lòng chọn hóa đơn càn xóa!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                DateTime check = Convert.ToDateTime(dataGridView.CurrentRow.Cells["NgayLap"].Value.ToString());
                if (check.Date != DateTime.Now.Date)
                {
                    MessageBox.Show("Chỉ có thể hiệu chỉnh hóa đơn trong ngày!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                if (MessageBox.Show("Xác nhận xóa hóa đơn " + id + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                    HoaDon t = context.HoaDon.Find(id);
                    if (t != null)
                    {
                        context.HoaDon.Remove(t);
                    }
                    context.SaveChanges();
                    frmHoaDon_Load(sender, e);
                }
            }

        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Nhập dữ liệu từ tập tin Excel";
            openFileDialog.Filter = "Tập tin Excel|*.xls;*.xlsx";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XLWorkbook workbook = new XLWorkbook(openFileDialog.FileName))
                    {
                        DataTable table1 = new DataTable();
                        IXLWorksheet worksheet1 = workbook.Worksheet(1); // Lấy sheet 1
                        bool firstRow1 = true;
                        foreach (IXLRow row in worksheet1.RowsUsed())
                        {
                            if (firstRow1)
                            {
                                foreach (IXLCell cell in row.CellsUsed()) table1.Columns.Add(cell.Value.ToString());
                                firstRow1 = false;
                            }
                            else
                            {
                                table1.Rows.Add(row.Cells(1, table1.Columns.Count).Select(c => c.Value.ToString()).ToArray());
                            }
                        }
                        int thanhcong = 0;
                        int thatbai = 0;
                        if (table1.Rows.Count > 0)
                        {

                            foreach (DataRow r in table1.Rows)
                            {
                                try
                                {
                                    var nv = context.NhanVien.FirstOrDefault(x => x.HoVaTen == r["NhanVien"].ToString());
                                    var kh = context.KhachHang.FirstOrDefault(x => x.HoVaTen == r["KhachHang"].ToString());
                                    var ban = context.Ban.FirstOrDefault(x => x.TenBan == r["Ban"].ToString());
                                    DateTime dt = Convert.ToDateTime(r["NgayLap"]);
                                    string ghichu = r["GhiChuHoaDon"].ToString();
                                    double tongtien = Convert.ToDouble(r["TongTien"]);
                                    if (nv == null || kh == null || ban == null || dt == null || tongtien <= 0)
                                    {
                                        throw new Exception("Không lấy được dữ liệu");
                                    }

                                    if (nv != null && kh != null && ban != null)
                                    {
                                        HoaDon hd = new HoaDon();
                                        hd.NhanVienID = nv.ID;
                                        hd.KhachHangID = kh.ID;
                                        hd.NgayLap = dt;
                                        hd.GhiChuHoaDon = ghichu;
                                        hd.TongTien = (decimal)tongtien;
                                        hd.BanID = ban.ID;
                                        context.HoaDon.Add(hd);
                                        context.SaveChanges();
                                        thanhcong++;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    thatbai++;
                                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi");

                                }

                            }
                            context.SaveChanges(); // Lưu hóa đơn trước để có ID
                        }

                        DataTable table2 = new DataTable();
                        IXLWorksheet worksheet2 = workbook.Worksheet(2); // Lấy sheet 2
                        bool firstRow2 = true;
                        foreach (IXLRow row in worksheet2.RowsUsed())
                        {
                            if (firstRow2)
                            {
                                foreach (IXLCell cell in row.CellsUsed()) table2.Columns.Add(cell.Value.ToString());
                                firstRow2 = false;
                            }
                            else
                            {
                                table2.Rows.Add(row.Cells(1, table2.Columns.Count).Select(c => c.Value.ToString()).ToArray());
                            }
                        }

                        if (table2.Rows.Count > 0)
                        {
                            foreach (DataRow r2 in table2.Rows) // Chạy vòng lặp riêng cho bảng 2
                            {
                                try
                                {
                                    string tenTA = r2["TenThucAn"].ToString();
                                    var t = context.ThucAn.FirstOrDefault(x => x.TenThucAn == tenTA);

                                    if (t != null)
                                    {
                                        HoaDon_ChiTiet ct = new HoaDon_ChiTiet();
                                        ct.HoaDonID = Convert.ToInt32(r2["ID"]); // Cột liên kết trong Excel
                                        ct.ThucAnID = t.ID;
                                        ct.SoLuongBan = Convert.ToInt32(r2["SoLuong"]);
                                        ct.DonGiaBan = Convert.ToInt32(r2["DonGia"]);
                                        context.HoaDon_ChiTiet.Add(ct);
                                        context.SaveChanges();
                                    }
                                }
                                catch
                                {

                                }

                            }
                            context.SaveChanges();
                        }

                        MessageBox.Show(string.Format("Kết quả nhập dữ liệu:\n- Thành công: {0}\n- Thất bại: {1}", thanhcong, thatbai),
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmHoaDon_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi");
                }
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất dữ liệu ra tập tin Excel";
            saveFileDialog.Filter = "Tập tin Excel|*.xls;*.xlsx";
            saveFileDialog.FileName = "BaoCaoHoaDon_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // --- XỬ LÝ TABLE 1: HÓA ĐƠN ---
                    DataTable tableHD = new DataTable();
                    tableHD.Columns.AddRange(new DataColumn[] {
                new DataColumn("ID", typeof(int)),
                new DataColumn("NhanVien", typeof(string)),
                new DataColumn("KhachHang", typeof(string)),
                new DataColumn("NgayLap", typeof(DateTime)),
                new DataColumn("GhiChuHoaDon", typeof(string)),
                new DataColumn("Ban", typeof(string)),
                new DataColumn("TongTien",typeof(decimal))
            });

                    var dsHoaDon = context.HoaDon.ToList();
                    if (dsHoaDon != null)
                    {
                        foreach (var p in dsHoaDon)
                        {
                            var nv = context.NhanVien.FirstOrDefault(r => r.ID == p.NhanVienID);
                            var kh = context.KhachHang.FirstOrDefault(r => r.ID == p.KhachHangID);
                            var ban = context.Ban.FirstOrDefault(r => r.ID == p.BanID);
                            tableHD.Rows.Add(p.ID, nv.HoVaTen, kh.HoVaTen, p.NgayLap, p.GhiChuHoaDon, ban.TenBan, p.TongTien);
                        }
                    }

                    // --- XỬ LÝ TABLE 2: CHI TIẾT HÓA ĐƠN ---
                    DataTable tableCT = new DataTable();
                    tableCT.Columns.AddRange(new DataColumn[] {
                new DataColumn("ID", typeof(int)),
                new DataColumn("ThucAn", typeof(string)),
                new DataColumn("SoLuong", typeof(int)),
                new DataColumn("DonGia", typeof(int))
            });

                    var dsChiTiet = context.HoaDon_ChiTiet.ToList();
                    if (dsChiTiet != null)
                    {
                        foreach (var d in dsChiTiet)
                        {
                            var t = context.ThucAn.FirstOrDefault(r => r.ID == d.ThucAnID);
                            tableCT.Rows.Add(d.HoaDonID, t.TenThucAn, d.SoLuongBan, d.DonGiaBan);
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

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
            using (frmInHoaDon inHoaDon = new frmInHoaDon(id))
            {
                inHoaDon.ShowDialog();
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
                using (frmInHoaDon inHoaDon = new frmInHoaDon(id))
                {
                    inHoaDon.ShowDialog();
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            frmHoaDon_Load(sender, e);
        }
    }
}
    

