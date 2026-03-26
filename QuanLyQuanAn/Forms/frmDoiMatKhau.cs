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
using BC = BCrypt.Net.BCrypt;

namespace QuanLyQuanAn.Forms
{
    public partial class frmDoiMatKhau : Form
    {
        QLQADbContext context = new QLQADbContext();

        string nv;
        public frmDoiMatKhau(string s)
        {
            InitializeComponent();
            nv = s;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            
           if (txtMatKhauMoi.Text == "")
                MessageBox.Show("Mật khẩu mới không được để trống", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            else if (txtXacNhanMatKhau.Text == "")
                MessageBox.Show("Xác nhận mật khẩu không được để trống", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            else if (txtMatKhauMoi.Text != txtXacNhanMatKhau.Text)
                MessageBox.Show("Xác nhận mật khẩu không khớp", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            else
            {

                var nv = context.NhanVien.FirstOrDefault(r => r.TenDangNhap == txtTenDangNhap.Text);
                if (nv != null)
                {
                    nv.MatKhau = BC.HashPassword(txtMatKhauMoi.Text);
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    this.Close();
                    context.NhanVien.Update(nv);
                    context.SaveChanges();
                }
                
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            var ten = context.NhanVien.FirstOrDefault(r => r.HoVaTen == nv);
            txtTenDangNhap.Text = ten.TenDangNhap;
            txtTenDangNhap.Enabled = false;
        }
    }
}
