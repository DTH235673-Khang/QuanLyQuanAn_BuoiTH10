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
using Microsoft.EntityFrameworkCore;
using QuanLyQuanAn.Data;
using QuanLyQuanAn.Reports;

namespace QuanLyQuanAn.Forms
{
    public partial class frmInPhieuNhapKho : Form
    {
        QLQADbContext context = new QLQADbContext();
        QLQADataSet.DanhSachphieuNhapKho_ChiTietDataTable danhSachPhieuNhapKho_ChiTietDataTable = new QLQADataSet.DanhSachphieuNhapKho_ChiTietDataTable();
        string reportsFolder = Application.StartupPath.Replace("bin\\Debug\\net8.0-windows", "Reports");
        int id; // Mã hóa đơn
        public frmInPhieuNhapKho(int maHoaDon = 0)
        {
            InitializeComponent();
            id = maHoaDon;
        }
        private void frmInPhieuNhapKho_Load(object sender, EventArgs e)
        {
            var phieuNhapKho = context.PhieuNhapKho.Include(r => r.NhaCungCap).Include(r => r.PhieuNhapKho_ChiTiet)
            .Where(r => r.ID == id).SingleOrDefault();
            if (phieuNhapKho != null)
            {
                var phieuNhapKhoChiTiet = context.PhieuNhapKho_ChiTiet.Where(r => r.PhieuNhapKhoID == id).Select(r => new DanhSachPhieuNhapKho_ChiTiet
                {
                    ID = r.ID,
                    NguyenLieuID = r.NguyenLieuID,
                    PhieuNhapKhoID = r.PhieuNhapKhoID,
                    TenNguyenLieu = r.NguyenLieu.TenNguyenLieu,
                    SoLuongNhap = r.SoLuongNhap,
                    GiaNhap = r.GiaNhap,
                    ThanhTien = Convert.ToInt32(r.SoLuongNhap * r.GiaNhap)
                }).ToList();
                danhSachPhieuNhapKho_ChiTietDataTable.Clear();
                foreach (var row in phieuNhapKhoChiTiet)
                {
                    danhSachPhieuNhapKho_ChiTietDataTable.AddDanhSachphieuNhapKho_ChiTietRow(row.ID,
                    row.PhieuNhapKhoID,
                    row.NguyenLieuID,
                    row.TenNguyenLieu,
                    row.SoLuongNhap,
                    row.GiaNhap,
                    row.ThanhTien);
                }
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DanhSachPhieuNhapKho_ChiTiet";
                reportDataSource.Value = danhSachPhieuNhapKho_ChiTietDataTable;
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(reportDataSource);
                reportViewer.LocalReport.ReportPath = "Reports\\rptInPhieuNhapKho.rdlc";
                IList<ReportParameter> param = new List<ReportParameter>
                {
                    new ReportParameter("NgayNhap", string.Format("Ngày {0} Tháng {1} Năm {2}",
                    phieuNhapKho.NgayNhap.Day,
                    phieuNhapKho.NgayNhap.Month,
                    phieuNhapKho.NgayNhap.Year)),
                    new ReportParameter("NguoiNhap_Ten", "Quán ăn ABC"),
                    new ReportParameter("NguoiNhap_DiaChi", "Mỹ Hòa Hưng, TP. Long Xuyên, An Giang"),
                    new ReportParameter("NguoiNhap_MaSoThue", "1602162070"),
                    new ReportParameter("NhaCungCap_Ten", phieuNhapKho.NhaCungCap.TenNhaCungCap),
                    new ReportParameter("NhaCungCap_DiaChi", phieuNhapKho.NhaCungCap.DiaChi),
                    new ReportParameter("NhaCungCap_MaSoThue", ""),
                    new ReportParameter("TongTien", phieuNhapKho.TongTien.ToString("#,##0"))                };
                reportViewer.LocalReport.SetParameters(param);
                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();
            }
        }
    
}
}
