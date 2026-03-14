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
    public partial class frmBaocaoDoanhThu : Form
    {
        QLQADbContext context = new QLQADbContext();
        QLQADataSet.DanhSachHoaDonDataTable hoaDonDataTable = new QLQADataSet.DanhSachHoaDonDataTable();
        string reportsFolder = Application.StartupPath.Replace("bin\\Debug\\net5.0-windows", "Reports");
        public frmBaocaoDoanhThu()
        {
            InitializeComponent();
        }

        private void frmBaocaoDoanhThu_Load(object sender, EventArgs e)
        {
            var hoaDon= context.HoaDon.Select(r => new DanhSachHoaDon
            {
                ID = r.ID,
                NhanVienID = r.NhanVienID,
                HoVaTenNhanVien= r.NhanVien.HoVaTen,
                HoVaTenKhachHang=r.KhachHang.HoVaTen,
                BanID = r.BanID,    
                NgayLap=r.NgayLap,
                GhiChuHoaDon=r.GhiChuHoaDon,
                TongTienHoaDon=(double)r.TongTien,
                trangthai=r.trangthai,
                TenBan=r.Ban.TenBan
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
                (decimal)(row.TongTienHoaDon ?? 0.0),
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
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }
    }
    }

