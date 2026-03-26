using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Reporting.WinForms;
using QuanLyQuanAn.Data;

namespace QuanLyQuanAn.Reports
{
    public partial class frmBaoCaoLoiNhuan : Form
    {
        QLQADbContext context = new QLQADbContext();

        public frmBaoCaoLoiNhuan()
        {
            InitializeComponent();
        }

        private void frmBaoCaoLoiNhuan_Load(object sender, EventArgs e)
        {
            using (var context = new QLQADbContext())
            {
                // 1. Tính toán số liệu từ Database
                decimal doanhthu = 0;
                var hd = context.HoaDon
                    .Where(x => x.NgayLap.Month == dtpNgay.Value.Month && x.NgayLap.Year == dtpNgay.Value.Year)
                    .ToList();
                foreach (var x in hd)
                    if (x != null)
                        doanhthu += x.TongTien;

                decimal giaVon = 0;
                var d = context.KiemKe.Where(r => r.NgayKiemKe.Day == 1 && r.NgayKiemKe.Month == dtpNgay.Value.Month).ToList();
                var y = context.KiemKe.Where(r => r.NgayKiemKe.Day == dtpNgay.Value.Day-1 && r.NgayKiemKe.Month == dtpNgay.Value.Month).ToList();
                foreach(var a in d)
                    foreach(var b in y)
                        if(a.NguyenLieuID==b.NguyenLieuID)
                        {
                            var z=context.NguyenLieu.FirstOrDefault(r=>r.ID==b.NguyenLieuID);
                            giaVon += (a.SoLuongThucTe - b.SoLuongThucTe) * z.GiaNhap;
                        }    
                var n=context.PhieuNhapKho.Where(r=>r.NgayNhap.Day>=1 &&r.NgayNhap.Day<dtpNgay.Value.Day && r.NgayNhap.Month==dtpNgay.Value.Month && r.TrangThai=="Đã duyệt");
                if(n!=null)
                    foreach (var a in n)
                        giaVon += (decimal)a.TongTien;


                decimal luong = context.BangCong
                   .Where(b => b.Ngay.Month == DateTime.Now.Month && b.Ngay.Year == DateTime.Now.Year)
                   .Sum(b => (decimal?)b.SoGioLam * b.NhanVien.ChucVu.LuongTheoGio) ?? 0;
                // 2. Tạo danh sách dữ liệu khớp với cấu trúc DataTable trong Dataset
                var data = new List<object>
                {
                    new { DoanhThu= doanhthu,COL = luong ,COS = giaVon  },
                };

                // 3. Nạp dữ liệu vào ReportViewer
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "BaoCaoLoiNhuan";
                reportDataSource.Value = data;
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(reportDataSource);
                reportViewer.LocalReport.ReportPath = "Reports//rptLoiNhuan.rdlc";
                ReportParameter reportParameter = new ReportParameter("MoTaKetQuaHienThi", "Tháng " + dtpNgay.Value.Month + " năm " + dtpNgay.Value.Year);
                reportViewer.LocalReport.SetParameters(reportParameter);
                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();
            }
        }

        private void btnXemTheoThang_Click(object sender, EventArgs e)
        {
            var kk = context.KiemKe.Where(x => x.NgayKiemKe.Month == DateTime.Now.Month);
            if (kk.Count() > 0)
                MessageBox.Show("Bạn chưa thực hiện kiểm kê! Vui lòng thự hiện kiểm kê trước khi xem lợi nhuận", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                frmBaoCaoLoiNhuan_Load(sender, e);

        }
    }
}
