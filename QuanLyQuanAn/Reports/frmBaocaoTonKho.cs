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
    public partial class frmBaoCaoTonKho : Form
    {
        QLQADbContext context = new QLQADbContext();
        QLQADataSet.DanhSachNguyenLieuDataTable nguyenLieuDataTable = new QLQADataSet.DanhSachNguyenLieuDataTable();
        string reportsFolder = Application.StartupPath.Replace("bin\\Debug\\net8.0-windows", "Reports");
        public frmBaoCaoTonKho()
        {
            InitializeComponent();
        }

        private void frmBaoCaoTonKho_Load(object sender, EventArgs e)
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
            ReportParameter reportParameter = new ReportParameter("MoTaKetQuaHienThi", "(Tất cả sản phẩm)");
            reportViewer.LocalReport.SetParameters(reportParameter);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }

        private void btnLocKetQua_Click(object sender, EventArgs e)
        {
            if (txtSoLuongTon.Text == "")
            {
                frmBaoCaoTonKho_Load(sender, e);
            }
            else
            {
                var danhSachNguyenLieu = context.NguyenLieu.Select(r => new DanhSachNguyenLieu
                {
                    ID = r.ID,
                    TenNguyenLieu = r.TenNguyenLieu,
                    QuyCach = r.QuyCach,
                    SoLuongTon = r.SoLuongTon,
                    GiaNhap = r.GiaNhap,

                });

                if (txtSoLuongTon.Text != "")
                {
                    int sl = Convert.ToInt32(txtSoLuongTon.Text);
                    danhSachNguyenLieu = danhSachNguyenLieu.Where(r => r.SoLuongTon <= sl);
                }

                nguyenLieuDataTable.Clear();
                foreach (var row in danhSachNguyenLieu)
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
                ReportParameter reportParameter = new ReportParameter("MoTaKetQuaHienThi", "(Các nguyên liệu có số lượng tồn nhỏ hơn " + Convert.ToInt32(txtSoLuongTon.Text) + ")");
                reportViewer.LocalReport.SetParameters(reportParameter);
                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();
            }
        
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
           frmBaoCaoTonKho_Load(sender, e);
        }
    }
}
