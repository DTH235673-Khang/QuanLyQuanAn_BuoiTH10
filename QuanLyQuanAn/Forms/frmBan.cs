using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QuanLyQuanAn.Data;

namespace QuanLyQuanAn.Forms
{
    public partial class frmBan : Form
    {
        QLQADbContext context = new QLQADbContext(); // Khởi tạo biến ngữ cảnh CSDL
        string nv = "";
        public frmBan(string nv)
        {
            InitializeComponent();
            nv = nv;
        }

        private void frmBan_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string originalTableName = btn.Text.Split('\n')[0];
            var result = context.Ban.FirstOrDefault(r => r.TenBan.Contains(originalTableName));
            if (result != null && result.TrangThai.Contains("1"))
            {
                int tn = Convert.ToInt32(originalTableName);
                using (frmChiTietBan chiTiet = new frmChiTietBan(tn))
                {
                    chiTiet.ShowDialog();
                }
            }
            else
            {
                var parent=(frmMain)this.MdiParent;
                using (frmChiTietBan chiTiet = new frmChiTietBan(originalTableName,parent.hoVaTenNhanVien))
                {
                    chiTiet.ShowDialog();
                }
            }
            var re = context.Ban.FirstOrDefault(r => r.TenBan.Contains(originalTableName));
            var hd = context.HoaDon.FirstOrDefault(r => r.BanID.Equals(re.ID));
            context = new QLQADbContext();

            if (hd != null)
            {
                btn.BackColor = Color.Orange;
                btn.Text = $"{originalTableName}\n{hd.TongTien:#,##0} VNĐ";
            }
            frmBan_Load(sender, e);
        }

        private void frmBan_Load(object sender, EventArgs e)
        {
            helpProvider.HelpNamespace = "Help/ban.html";
            helpProvider.SetShowHelp(this, true);
            LoadTrangThaiBan();
        }

        private void LoadTrangThaiBan()
        {
            // Lấy toàn bộ danh sách bàn và hóa đơn hiện có để tránh truy vấn quá nhiều lần trong vòng lặp
            var danhSachBan = context.Ban.ToList();

            foreach (Control ctr in this.tableLayoutPanel1.Controls)
            {
                if (ctr is Button btn)
                {
                    // Lấy tên bàn gốc (giả sử tên bàn không chứa ký tự xuống dòng)
                    string tenBan = btn.Text.Split('\n')[0].Trim();

                    // Tìm thông tin bàn trong database dựa trên tên
                    var ban = danhSachBan.FirstOrDefault(b => b.TenBan == tenBan);

                    if (ban != null)
                    {
                        // Tìm hóa đơn chưa thanh toán của bàn này (Giả sử TrangThai "1" là có khách)
                        if (ban.TrangThai == "1")
                        {
                            var hoaDon = context.HoaDon.FirstOrDefault(hd => hd.BanID == ban.ID && hd.trangthai == 0);

                            decimal tongTien = hoaDon != null ? (decimal)hoaDon.TongTien : 0;

                            btn.BackColor = Color.Orange;
                            btn.Text = $"{tenBan}\n{tongTien:#,##0} VNĐ";
                        }
                        else
                        {
                            btn.BackColor = Color.Red;
                            btn.Text = tenBan;
                        }
                    }
                }
            }
        }

    }
}
