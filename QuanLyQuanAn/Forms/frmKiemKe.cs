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
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.IdentityModel.Tokens;
using QuanLyQuanAn.Data;

namespace QuanLyQuanAn.Forms
{
    public partial class frmKiemKe : Form
    {
        QLQADbContext context = new QLQADbContext(); // Khởi tạo biến ngữ cảnh CSDL

        public frmKiemKe()
        {
            InitializeComponent();
        }

        private void frmKiemKe_Load(object sender, EventArgs e)
        {
            dataGridView.AutoGenerateColumns = false;
            List<DanhSachKiemKe> kk = new List<DanhSachKiemKe>();
            kk = context.KiemKe
                .Where(r => r.NgayKiemKe.Date == DateTime.Now.Date)
                .Select(r => new DanhSachKiemKe
                {
                    ID = r.ID,
                    NguyenLieuID = r.NguyenLieuID,
                    TenNguyenLieu = r.NguyenLieu.TenNguyenLieu,
                    SoLuongThucTe = r.SoLuongThucTe,
                    NgayKiemKe = r.NgayKiemKe,
                    GhiChu = r.GhiChu,

                })
                .ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = kk;
            dataGridView.DataSource = bindingSource;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            var kk = context.KiemKe.Where(r => r.NgayKiemKe.Date == dtpNgay.Value.Date).ToList();
            if (kk.Count == 0 && dtpNgay.Value.Month != DateTime.Now.Month)
            {
                MessageBox.Show($"Không có kiểm kê phát sinh trong ngày {dtpNgay.Value.Day} tháng {dtpNgay.Value.Month} năm {dtpNgay.Value.Year}",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            var kiemke = context.KiemKe
               .Where(r => r.NgayKiemKe.Date.Date == dtpNgay.Value.Date)
                .Select(r => new DanhSachKiemKe
                {
                    ID = r.ID,
                    NguyenLieuID = r.NguyenLieuID,
                    TenNguyenLieu = r.NguyenLieu.TenNguyenLieu,
                    SoLuongThucTe = r.SoLuongThucTe,
                    NgayKiemKe=r.NgayKiemKe,
                    GhiChu = r.GhiChu,

                })
                .ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = kiemke;
            dataGridView.DataSource = bindingSource;
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
                    DataTable table = new DataTable();
                    using (XLWorkbook workbook = new XLWorkbook(openFileDialog.FileName))
                    {
                        IXLWorksheet worksheet = workbook.Worksheet(1);
                        var rows = worksheet.RowsUsed();
                        if (!rows.Any()) return;

                        // 1. Xác định vị trí các cột cần thiết
                        IXLRow headerRow = worksheet.FirstRowUsed();
                        int colTenNL = -1;
                        int colSoLuong = -1;

                        // Duyệt qua các cell của dòng đầu tiên để tìm cột theo tên
                        foreach (var cell in headerRow.Cells())
                        {
                            string headerText = cell.Value.ToString().Trim();
                            if (headerText == "TenNguyenLieu") colTenNL = cell.Address.ColumnNumber;
                            if (headerText == "SoLuongTon") colSoLuong = cell.Address.ColumnNumber;
                        }

                        // Kiểm tra xem file có đủ cột yêu cầu không
                        if (colTenNL == -1 || colSoLuong == -1)
                        {
                            MessageBox.Show("File Excel thiếu cột 'TenNguyenLieu' hoặc 'SoLuongTon'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Tạo cấu trúc DataTable chỉ với 2 cột cần dùng
                        table.Columns.Add("TenNguyenLieu");
                        table.Columns.Add("SoLuongTon");

                        // 2. Đọc dữ liệu từ các dòng tiếp theo (bỏ qua dòng tiêu đề)
                        foreach (IXLRow row in rows.Skip(1))
                        {
                            DataRow newRow = table.NewRow();
                            newRow["TenNguyenLieu"] = row.Cell(colTenNL).Value.ToString().Trim();
                            newRow["SoLuongTon"] = row.Cell(colSoLuong).Value.ToString().Trim();
                            table.Rows.Add(newRow);
                        }

                        // 3. Xử lý lưu vào Database (Giữ nguyên logic của bạn nhưng tối ưu vòng lặp)
                        if (table.Rows.Count > 0)
                        {
                            int thanhcong = 0;
                            int thatbai = 0;

                            foreach (DataRow r in table.Rows)
                            {
                                try
                                {
                                    string ten = r["TenNguyenLieu"].ToString();
                                    int s = Convert.ToInt32(r["SoLuongTon"]);

                                    var nl = context.NguyenLieu.FirstOrDefault(x => x.TenNguyenLieu == ten);
                                   

                                    if (string.IsNullOrEmpty(ten) || nl == null || s < 0) 
                                    {
                                        thatbai++;
                                        throw new Exception();
                                    }
                                    if (s>nl.SoLuongTon)
                                    {
                                        thatbai++;
                                        throw new Exception();
                                    }

                                    bool daTonTai = context.KiemKe.Any(x => x.NguyenLieuID == nl.ID
                                                    && x.NgayKiemKe.Date == DateTime.Now.Date
                                                    && x.SoLuongThucTe==s);

                                    if (daTonTai)
                                    {
                                        thatbai++;
                                        throw new Exception();
                                    }
                                    KiemKe t = new KiemKe();
                                    t.NguyenLieuID = nl.ID;
                                    t.SoLuongThucTe = s;
                                    t.NgayKiemKe = DateTime.Now;
                                    t.GhiChu = "Nhập từ Excel";
                                    var kk = context.KiemKe.ToList();                                  
                                    foreach (var x in kk) 
                                        if (x.NguyenLieuID == nl.ID && x.NgayKiemKe.Date == DateTime.Now.Date)
                                            context.KiemKe.Remove(x);

                                    context.KiemKe.Add(t);
                                    context.SaveChanges(); 
                                    thanhcong++;
                                }
                                catch (Exception ex)
                                {
                                    thatbai++;
                                }
                            }

                            MessageBox.Show($"Kết quả:\n- Thành công: {thanhcong}\n- Thất bại: {thatbai}",
                                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmKiemKe_Load(sender, e);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    } 
}
