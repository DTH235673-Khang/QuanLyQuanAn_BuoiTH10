using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanAn.Data;

namespace QuanLyQuanAn.Forms
{
    public partial class frmChiTietBan : Form
    {
        QLQADbContext context = new QLQADbContext(); // Khởi tạo biến ngữ cảnh CSDL
        string tablename; // Lấy mã hóa đơn (dùng cho Sửa và Xóa)
        public frmChiTietBan(string ban)
        {
            InitializeComponent();
            tablename=ban;
        }
        public frmChiTietBan(int s)
        {
            InitializeComponent();
            btnMoBan.Enabled = false;
        }

        private void btnMoBan_Click(object sender, EventArgs e)
        {
            
            using (frmHoaDon_ChiTiet chiTiet = new frmHoaDon_ChiTiet(tablename))
            {
                chiTiet.ShowDialog();
            }
            this.Close();
        }
    }
}
