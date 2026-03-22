using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using QuanLyQuanAn.Data;
using static QuanLyQuanAn.Reports.QLQADataSet;

namespace QuanLyQuanAn.Reports
{
    public partial class frmBaoCaoDoanhThu : Form
    {
        QLQADbContext context = new QLQADbContext();
        QLQADataSet.DanhSachHoaDonDataTable hoaDonDataTable = new QLQADataSet.DanhSachHoaDonDataTable();
        string reportsFolder = Application.StartupPath.Replace("bin\\Debug\\net8.0-windows", "Reports");
        public frmBaoCaoDoanhThu()
        {
            InitializeComponent();
        }

        private void frmBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            var hoaDon = context.HoaDon.Select(r => new DanhSachHoaDon
            {
                ID = r.ID,
                NhanVienID = r.NhanVienID,
                HoVaTenNhanVien = r.NhanVien.HoVaTen,
                HoVaTenKhachHang = r.KhachHang.HoVaTen,
                BanID = r.BanID,
                NgayLap = r.NgayLap,
                GhiChuHoaDon = r.GhiChuHoaDon,
                TongTienHoaDon = r.TongTien,
                trangthai = r.trangthai,
                TenBan = r.Ban.TenBan
            }).ToList();
            hoaDonDataTable.Clear();
            foreach (var row in hoaDon)
            {
                var tenban = context.Ban.FirstOrDefault(r => r.ID == row.BanID);
                hoaDonDataTable.AddDanhSachHoaDonRow(row.ID,
                row.NhanVienID,
                row.KhachHangID,
                row.BanID,
                row.NgayLap,
                row.GhiChuHoaDon,
                row.TongTienHoaDon ?? 0,
                row.trangthai,
                row.HoVaTenNhanVien,
                row.HoVaTenKhachHang,
                row.TenBan);
            }
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DanhSachHoaDon";
            reportDataSource.Value = hoaDonDataTable;
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.LocalReport.ReportPath = "Reports//rptBaoCaoDoanhThu.rdlc";
            ReportParameter reportParameter = new ReportParameter("MoTaKetQuaHienThi", "(Tất cả thời gian)");
            reportViewer.LocalReport.SetParameters(reportParameter);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }

        private void btnLocKetQua_Click(object sender, EventArgs e)
        {
            var danhSachHoaDon = context.HoaDon.Select(r => new DanhSachHoaDon
            {
                ID = r.ID,
                NhanVienID = r.NhanVienID,
                HoVaTenNhanVien = r.NhanVien.HoVaTen,
                HoVaTenKhachHang = r.KhachHang.HoVaTen,
                BanID = r.BanID,
                NgayLap = r.NgayLap,
                GhiChuHoaDon = r.GhiChuHoaDon,
                TongTienHoaDon = r.TongTien,
                trangthai = r.trangthai,
                TenBan = r.Ban.TenBan
            });
            danhSachHoaDon = danhSachHoaDon.Where(r => r.NgayLap >= dtpTuNgay.Value && r.NgayLap <= dtpDenNgay.Value);
            hoaDonDataTable.Clear();
            foreach (var row in danhSachHoaDon)
            {
                var tenban = context.Ban.FirstOrDefault(r => r.ID == row.BanID);
                hoaDonDataTable.AddDanhSachHoaDonRow(row.ID,
                row.NhanVienID,
                row.KhachHangID,
                row.BanID,
                row.NgayLap,
                row.GhiChuHoaDon,
                row.TongTienHoaDon ?? 0,
                row.trangthai,
                row.HoVaTenNhanVien,
                row.HoVaTenKhachHang,
                row.TenBan);
            }
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DanhSachHoaDon";
            reportDataSource.Value = hoaDonDataTable;
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.LocalReport.ReportPath = "Reports//rptBaoCaoDoanhThu.rdlc";
            ReportParameter reportParameter = new ReportParameter("MoTaKetQuaHienThi", "Từ ngày " + dtpTuNgay.Text + " - Đến ngày: " + dtpDenNgay.Text);
            reportViewer.LocalReport.SetParameters(reportParameter);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            frmBaoCaoDoanhThu_Load(sender, e);
        }
    }
}

