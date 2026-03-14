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

namespace QuanLyQuanAn.Reports
{
    public partial class frmBaocaoTonKho : Form
    {
        QLQADbContext context = new QLQADbContext();
        QLQADataSet.DanhSachNguyenLieuDataTable nguyenLieuDataTable = new QLQADataSet.DanhSachNguyenLieuDataTable();
        string reportsFolder = Application.StartupPath.Replace("bin\\Debug\\net5.0-windows", "Reports");
        public frmBaocaoTonKho()
        {
            InitializeComponent();
        }

        private void frmBaocaoTonKho_Load(object sender, EventArgs e)
        {
            var nguyenLieu = context.NguyenLieu.Select(r => new DanhSachNguyenLieu
            {
                ID = r.ID,
                TenNguyenLieu = r.TenNguyenLieu,
                QuyCach = r.QuyCach,
                SoLuongTon = r.SoLuongTon,
                GiaNhap = r.GiaNhap
               
            }).ToList();
            nguyenLieuDataTable.Clear();
            foreach (var row in nguyenLieu)
            {
                nguyenLieuDataTable.AddDanhSachNguyenLieuRow(row.ID,
                row.TenNguyenLieu,
                row.QuyCach,
                row.SoLuongTon,
                row.GiaNhap);
            }
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DanhSachNguyenLieu";
            reportDataSource.Value = nguyenLieuDataTable;
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.LocalReport.ReportPath = "Reports//rptBaoCaoTonKho.rdlc";
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }
    }
}
