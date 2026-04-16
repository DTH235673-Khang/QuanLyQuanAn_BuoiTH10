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
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.IdentityModel.Tokens;
using QuanLyQuanAn.Data;
using QuanLyQuanAn.Reports;

namespace QuanLyQuanAn.Forms
{
    public partial class frmBangCong : Form
    {
        QLQADbContext context = new QLQADbContext(); // Khởi tạo biến ngữ cảnh CSDL
        int id;
        bool xulythem = false;
        public frmBangCong()
        {
            InitializeComponent();
            var nv=context.NhanVien.FirstOrDefault(r=>r.ID==Convert.ToInt32(Session.UserId));
            var cv = context.ChucVu.FirstOrDefault(r => r.ID == nv.ChucVuID);
            if(cv!=null && cv.TenChucVu!="Quản lý")
            {
                panel.Visible=false;
                btnXuat.Visible=false;
                btnXuatBangLuong.Visible =false;
            }    
        }
        private void BatTatChucNang(bool giaTri)
        {
            btnXem.Enabled = giaTri;
            cboNhanVien.Enabled = giaTri;
            btnIn.Enabled = giaTri;
            btnOut.Enabled = giaTri;
            btnXuat.Enabled = giaTri;
            btnXoa.Enabled = giaTri;
            btnSua.Enabled = giaTri;
            txtIn.Enabled = !giaTri;
            txtOut.Enabled = !giaTri;
            btnLuu.Enabled = !giaTri;
            dtpNgay.Enabled = !giaTri;
            xulythem = false;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
        }
        public void LayNhanVienVaoComboBox()
        {
            cboNhanVien.DataSource = context.NhanVien.ToList();
            cboNhanVien.ValueMember = "ID";
            cboNhanVien.DisplayMember = "HoVaTen";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            // Kiểm tra an toàn: Nếu chưa chọn giá trị thì thoát hàm, không chạy code bên dưới
            if (dtpThoiGian.Value == null)
            {
                MessageBox.Show("Vui lòng chọn thời gian cần xem!");
                return;
            }
            try
            {
                // Ép kiểu an toàn
                int thang = Convert.ToInt32(dtpThoiGian.Value.Month);
                int nam = Convert.ToInt32(dtpThoiGian.Value.Year);
                var bc = context.BangCong.Where(r => r.Ngay.Month == thang && r.Ngay.Year == nam).ToList();
                if (bc.Count == 0 && thang != DateTime.Now.Month)
                {
                    MessageBox.Show($"Không có chấm công phát sinh trong tháng {thang} năm {nam}",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    BatTatChucNang(true);
                    var bangcong = context.BangCong.Select(bc => new
                    {
                        bc.ID,
                        bc.Ngay,
                        HoVaTenNhanVien = bc.NhanVien.HoVaTen,
                        bc.GioVaoThucTe,
                        bc.GioRaThucTe,
                        bc.SoGioLam
                    }).ToList();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = bangcong;
                    dataGridView.DataSource = bangcong;

                }

            }
            catch (Exception ex)
            {
                // Debug lỗi nếu có vấn đề về kết nối CSDL
                Console.WriteLine("Lỗi truy vấn: " + ex.Message);
            }
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboNhanVien.SelectedValue == null || cboNhanVien.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên để check-in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {

                }
                dataGridView.AutoGenerateColumns = false;
                int nhanVienId = (int)cboNhanVien.SelectedValue;
                DateTime bayGio = DateTime.Now;

                DateTime gioRaMacDinh = bayGio;

                double soGioLam = 0;

                var checkInMoi = new BangCong
                {
                    NhanVienID = nhanVienId,
                    Ngay = DateOnly.FromDateTime(bayGio.Date),
                    GioVaoThucTe = bayGio,
                    GioRaThucTe = gioRaMacDinh,
                    SoGioLam = 0
                };
                var check = context.BangCong.FirstOrDefault(b => b.Ngay == checkInMoi.Ngay && b.NhanVienID == checkInMoi.NhanVienID && b.GioRaThucTe == gioRaMacDinh);
                if (check != null)
                    MessageBox.Show("Nhân viên đã check in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    context.BangCong.Add(checkInMoi);
                    context.SaveChanges();
                    MessageBox.Show($"Check-in thành công cho nhân viên: {cboNhanVien.Text}\nGiờ vào: {bayGio.ToString("HH:mm:ss")}",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                btnXem_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmBangCong_Load(object sender, EventArgs e)
        {
            helpProvider.HelpNamespace = "Help/bangcong.html";
            helpProvider.SetShowHelp(this, true);
            LayNhanVienVaoComboBox();
            BatTatChucNang(true);
            var bangcong = context.BangCong
              .Where(r => r.Ngay.Month == DateTime.Now.Month && r.Ngay.Year == DateTime.Now.Year)
              .Select(bc => new
              {
                  bc.ID,
                  bc.Ngay,
                  HoVaTenNhanVien = bc.NhanVien.HoVaTen,
                  bc.GioVaoThucTe,
                  bc.GioRaThucTe,
                  bc.SoGioLam
              }).ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = bangcong;
            dataGridView.DataSource = bangcong;

        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboNhanVien.SelectedValue == null || cboNhanVien.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên để check-out!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dataGridView.AutoGenerateColumns = false;
                int nhanVienId = (int)cboNhanVien.SelectedValue;
                var check = context.BangCong.FirstOrDefault(b => b.Ngay == DateOnly.FromDateTime(DateTime.Now) && b.NhanVienID == nhanVienId && b.SoGioLam==0);
                if (check != null)
                {
                    check.GioRaThucTe = DateTime.Now;
                    check.SoGioLam = (float)(check.GioRaThucTe - check.GioVaoThucTe).TotalHours;
                    context.BangCong.Update(check);
                    context.SaveChanges();
                    MessageBox.Show($"Check-out thành công cho nhân viên: {cboNhanVien.Text}\nGiờ ra: {DateTime.Now.ToString("HH:mm:ss")}",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmBangCong_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Nhân viên " + cboNhanVien.SelectedText + " chưa thực hiện check-in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnXuat_Click(object sender, EventArgs e)
        {
            int thang = Convert.ToInt32(dtpThoiGian.Value.Month);
            int nam = Convert.ToInt32(dtpThoiGian.Value.Year);
            var bc = context.BangCong.Where(r => r.Ngay.Month == thang && r.Ngay.Year == nam).ToList();
            if (bc.Count == 0)
            {
                MessageBox.Show($"Không có chấm công phát sinh trong tháng {thang} năm {nam}",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var data = context.BangCong.Where(b => b.Ngay.Month == thang && b.Ngay.Year == nam)
              .GroupBy(b => b.NhanVien.HoVaTen)
              .Select(g => new
              {
                  Ten = g.Key,
                  Tong = g.Sum(x => x.SoGioLam),
                  ChiTiet = g
                  .GroupBy(r => r.Ngay.Day)
                 .Select(gNgay => new
                 {
                     Ngay = gNgay.Key,
                     TongGioNgay = gNgay.Sum(x => x.SoGioLam)
                 }).ToList()
              }).ToList();

            // Tạo DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("Tên Nhân Viên");
            dt.Columns.Add("Tổng Giờ", typeof(double));
            int ngay = 0;
            switch (thang)
            {
                case 1: ngay = 31; break;
                case 2: ngay = 28; break;
                case 3: ngay = 31; break;
                case 4: ngay = 30; break;
                case 5: ngay = 31; break;
                case 6: ngay = 30; break;
                case 7: ngay = 31; break;
                case 8: ngay = 31; break;
                case 9: ngay = 31; break;
                case 10: ngay = 30; break;
                case 11: ngay = 30; break;
                case 12: ngay = 31; break;
            }
            if (nam % 400 == 0 && thang == 2)
            {
                ngay = 29;
            }
            for (int i = 1; i <= ngay; i++) dt.Columns.Add(i + "/" + thang, typeof(double));

            // Đổ dữ liệu vào DataTable
            foreach (var item in data)
            {
                DataRow dr = dt.NewRow();
                dr["Tên Nhân Viên"] = item.Ten;
                dr["Tổng Giờ"] = Math.Round((double)item.Tong, 2);
                foreach (var c in item.ChiTiet)
                {
                    string colName = c.Ngay + "/" + thang;
                    if (dt.Columns.Contains(colName))
                    {
                        dr[colName] = Math.Round((double)c.TongGioNgay, 2);
                    }
                }
                dt.Rows.Add(dr);
            }

            SaveFileDialog sfd = new SaveFileDialog { Filter = "Excel|*.xlsx", FileName = $"BangCong_{thang}_{nam}.xlsx" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add(dt, "BangCong");

                // Format 2 số lẻ cho cột Tổng Giờ và các ngày
                ws.Range("B2:AG" + (dt.Rows.Count + 1)).Style.NumberFormat.Format = "0.00";
                ws.Columns().AdjustToContents();

                wb.SaveAs(sfd.FileName);
                MessageBox.Show("Đã xuất dữ liệu ra tập tin Excel thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa chấm công?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                BangCong bc = context.BangCong.Find(id);
                if (bc != null)
                {
                    if (bc.Ngay.Month != DateTime.Now.Month)
                    {
                        MessageBox.Show("Chỉ có thể hiệu chỉnh/thêm/xóa/sửa chấm công trong tháng hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    context.BangCong.Remove(bc);
                }
                context.SaveChanges();
                frmBangCong_Load(sender, e);
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtIn.Enabled = true;
            txtOut.Enabled = true;
            btnLuu.Enabled = true;
            xulythem = false;
            btnThem.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtIn.Text.IsNullOrEmpty())
                MessageBox.Show("Vui lòng nhập in time.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (txtOut.Text.IsNullOrEmpty())
                MessageBox.Show("Vui lòng nhập out time.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (dtpNgay.Value == null)
                MessageBox.Show("Vui lòng nhập ngày chấm công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (cboNhanVien.SelectedValue == null)
                MessageBox.Show("Vui lòng chọn nhân viên cần chấm công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (!TimeOnly.TryParse(txtIn.Text, out TimeOnly it))
                MessageBox.Show("In time sai định dạng(Định dạng đúng: 08:00).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (!TimeOnly.TryParse(txtOut.Text, out TimeOnly ot))
                MessageBox.Show("Out time sai định dạng(Định dạng đúng: 08:00).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (dtpNgay.Value.Month != DateTime.Now.Month)
                MessageBox.Show("Chỉ có thể hiệu chỉnh/thêm/xóa/sửa chấm công trong tháng hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (ot <= it)
                MessageBox.Show("Out time phải lớn hơn In time.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (xulythem == true)
            {

                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                var r = context.BangCong.FirstOrDefault(r => r.ID == id);
                if (r != null && r.Ngay>=DateOnly.FromDateTime(DateTime.Now.Date))
                {
                    MessageBox.Show("Chỉ có thể hiệu chỉnh/thêm/xóa/sửa chấm công trong thời gian đã qua.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                var kq = context.BangCong.Where(r => r.NhanVienID == (int)cboNhanVien.SelectedValue && r.Ngay == DateOnly.FromDateTime(dtpNgay.Value.Date));
                    if (kq.Any())
                    {
                        foreach (var k in kq)
                        {
                            if ((TimeOnly.FromDateTime(k.GioVaoThucTe) < it && TimeOnly.FromDateTime(k.GioRaThucTe) > it) || (TimeOnly.FromDateTime(k.GioVaoThucTe) < ot && TimeOnly.FromDateTime(k.GioRaThucTe) > ot))
                            {
                                MessageBox.Show("Khung thời gian in-out cần chấm công đã đan xen với 1 khung khác trong cùng ngày " + dtpNgay.Value.Date.Day + ".", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                            if(TimeOnly.FromDateTime(k.GioVaoThucTe)==it && TimeOnly.FromDateTime(k.GioRaThucTe)==ot)
                            {
                            MessageBox.Show("Chấm công đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }    
                        }
                    }
                    double sogio = (DateOnly.FromDateTime(dtpNgay.Value).ToDateTime(ot) - DateOnly.FromDateTime(dtpNgay.Value).ToDateTime(it)).TotalHours;
                    var chamCongMoi = new BangCong
                    {
                        NhanVienID = (int)cboNhanVien.SelectedValue,
                        Ngay = DateOnly.FromDateTime(dtpNgay.Value),
                        GioVaoThucTe = DateOnly.FromDateTime(dtpNgay.Value).ToDateTime(it),
                        GioRaThucTe = DateOnly.FromDateTime(dtpNgay.Value).ToDateTime(ot),
                        SoGioLam = (float)sogio
                    };
                    context.BangCong.Add(chamCongMoi);
                    context.SaveChanges();

                



            }
            else
            {
                if (dataGridView.CurrentRow == null)
                    MessageBox.Show("Vui lòng chọn dòng chấm công cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    DialogResult dr;
                    dr = MessageBox.Show("Xác nhận sửa chấm công cho " + dataGridView.CurrentRow.Cells["HoVaTenNhanVien"].Value.ToString() + ".", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (dr != DialogResult.OK)
                        return;
                    if (!txtIn.Text.IsNullOrEmpty() || !txtOut.Text.IsNullOrEmpty())
                    {
                        int id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                        var kq = context.BangCong.Find(id);
                        if (kq != null)
                        {
                            if (kq.Ngay.Month != DateTime.Now.Month)
                            {
                                MessageBox.Show("Chỉ có thể hiệu chỉnh/thêm/xóa/sửa chấm công trong tháng hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                            if (!txtIn.Text.IsNullOrEmpty())
                            {
                                if (TimeOnly.TryParse(txtIn.Text, out TimeOnly itime))
                                {
                                    DateOnly newIn = DateOnly.FromDateTime(kq.GioVaoThucTe);
                                    DateTime result = newIn.ToDateTime(itime);
                                    kq.GioVaoThucTe = result;
                                    kq.SoGioLam = (float)(kq.GioRaThucTe - kq.GioVaoThucTe).TotalHours;
                                    context.BangCong.Update(kq);
                                    context.SaveChanges();
                                }
                                else
                                {
                                    MessageBox.Show("Bạn chưa nhập in time hoặc in time bạn nhập sai định dạng thời gian (Định dạng đúng: 08:00).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            if (!txtOut.Text.IsNullOrEmpty())
                            {
                                if (TimeOnly.TryParse(txtOut.Text, out TimeOnly otime))
                                {
                                    DateOnly newOut = DateOnly.FromDateTime(kq.GioVaoThucTe);
                                    DateTime result = newOut.ToDateTime(otime);
                                    kq.GioRaThucTe = result;
                                    kq.SoGioLam = (float)(kq.GioRaThucTe - kq.GioVaoThucTe).TotalHours;
                                    context.BangCong.Update(kq);
                                    context.SaveChanges();
                                }
                                else
                                {
                                    MessageBox.Show("Bạn chưa nhập out time hoặc out time bạn nhập sai định dạng thời gian (Định dạng đúng: 08:00).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }

                        }

                    }
                }
            }
            frmBangCong_Load(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtIn.Enabled = true;
            txtOut.Enabled = true;
            btnLuu.Enabled = true;
            dtpNgay.Enabled = true;
            xulythem = true;
            btnSua.Enabled = false;
        }

        private void btnXuatBangLuong_Click(object sender, EventArgs e)
        {
            int thang = Convert.ToInt32(dtpThoiGian.Value.Month);
            int nam = Convert.ToInt32(dtpThoiGian.Value.Year);
            var bc = context.BangCong.Where(r => r.Ngay.Month == thang && r.Ngay.Year == nam).ToList();
            if (bc.Count == 0)
            {
                MessageBox.Show($"Không có bảng lương phát sinh trong tháng {thang} năm {nam}",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất dữ liệu ra tập tin Excel";
            saveFileDialog.Filter = "Tập tin Excel|*.xls;*.xlsx";
            saveFileDialog.FileName = "BangLuong_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[] {
          new DataColumn("Nhân viên", typeof(string)),
          new DataColumn("Tổng giờ công", typeof(float)),
          new DataColumn("Lương theo giờ", typeof(float)),
          new DataColumn("Tổng lương", typeof(decimal))
          });
                    var data = context.BangCong.Where(b => b.Ngay.Month == thang && b.Ngay.Year == nam)
                    .GroupBy(b => b.NhanVien.HoVaTen)
                    .Select(g => new
                    {
                        Ten = g.Key,

                        Tong = g.Sum(x => x.SoGioLam),


                    }).ToList();

                    if (data != null)
                    {
                        foreach (var p in data)
                        {
                            var nv = context.NhanVien.FirstOrDefault(x => x.HoVaTen == p.Ten);
                            var cv = context.ChucVu.FirstOrDefault(x => x.ID == nv.ChucVuID);
                            table.Rows.Add(p.Ten, p.Tong, cv.LuongTheoGio, Math.Round((decimal)(p.Tong) * cv.LuongTheoGio, 2));
                        }
                    }
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "BangLuong");
                        sheet.Columns().AdjustToContents();
                        wb.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Đã xuất dữ liệu ra tập tin Excel thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            frmBangCong_Load(sender, e);
        }

        private void btnXemTheoNgay_Click(object sender, EventArgs e)
        {
            // Kiểm tra an toàn: Nếu chưa chọn giá trị thì thoát hàm, không chạy code bên dưới
            if (dtpThoiGian.Value == null)
            {
                MessageBox.Show("Vui lòng chọn thời gian cần xem!");
                return;
            }
            try
            {
                // Ép kiểu an toàn
                int thang = Convert.ToInt32(dtpThoiGian.Value.Month);
                int nam = Convert.ToInt32(dtpThoiGian.Value.Year);
                int ngay = Convert.ToInt32(dtpThoiGian.Value.Day);
                var bc = context.BangCong.Where(r => r.Ngay.Month == thang && r.Ngay.Year == nam && r.Ngay.Day == ngay).ToList();
                if (bc.Count == 0)
                {
                    MessageBox.Show($"Không có chấm công phát sinh trong ngày {ngay} tháng {thang} năm {nam}",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    BatTatChucNang(true);
                    var bangcong = context.BangCong
                      .Where(r => r.Ngay.Month == thang && r.Ngay.Year == nam && r.Ngay.Day == ngay)
                      .Select(bc => new
                      {
                          bc.ID,
                          bc.Ngay,
                          HoVaTenNhanVien = bc.NhanVien.HoVaTen,
                          bc.GioVaoThucTe,
                          bc.GioRaThucTe,
                          bc.SoGioLam
                      }).ToList();
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = bangcong;
                    dataGridView.DataSource = bangcong;

                }

            }
            catch (Exception ex)
            {
                // Debug lỗi nếu có vấn đề về kết nối CSDL
                Console.WriteLine("Lỗi truy vấn: " + ex.Message);
            }
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            int thang = Convert.ToInt32(dtpThoiGian.Value.Month);
            int nam = Convert.ToInt32(dtpThoiGian.Value.Year);
            var bc = context.BangCong.Where(r => r.Ngay.Month == thang && r.Ngay.Year == nam).ToList();
            if (bc.Count == 0)
            {
                MessageBox.Show($"Không có bảng công phát sinh trong tháng {thang} năm {nam}",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất dữ liệu ra tập tin Excel";
            saveFileDialog.Filter = "Tập tin Excel|*.xls;*.xlsx";
            saveFileDialog.FileName = "KiemTraBangCong_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    DataTable table = new DataTable();
                    table.Columns.AddRange(new DataColumn[] {
          new DataColumn("Ngày", typeof(DateOnly)),
          new DataColumn("Nhân viên", typeof(string)),
          new DataColumn("Giờ vào thực tế", typeof(TimeOnly)),
          new DataColumn("Giờ ra thực tế", typeof(TimeOnly)),
          new DataColumn("Trạng thái", typeof(string))
          });
                    var data = context.BangCong.Where(b => b.Ngay.Month == thang && b.Ngay.Year == nam).ToList();

                    if (data != null)
                    {
                        foreach (var p in data)
                        {
                            string trangthai = "";
                            var nv = context.NhanVien.FirstOrDefault(x => x.ID == p.NhanVienID);
                            var ll = context.LichLam.FirstOrDefault(x => x.NgayPhanCong.Day == p.Ngay.Day && x.NgayPhanCong.Month == p.Ngay.Month && x.NhanVienID == p.NhanVienID);
                            if (ll == null)
                            {
                                trangthai = "Ca làm phát sinh";
                            }
                            else if (ll != null)
                            {
                                var cl = context.CaLam.FirstOrDefault(x => x.Id == ll.CaLamID);
                                if (TimeOnly.FromDateTime(p.GioVaoThucTe) > cl.GioBatDau)
                                    trangthai = "Đi trễ";
                            }

                            table.Rows.Add(p.Ngay, nv.HoVaTen, TimeOnly.FromDateTime(p.GioVaoThucTe), TimeOnly.FromDateTime(p.GioRaThucTe), trangthai);
                        }
                    }
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "KiemTra");
                        sheet.Columns().AdjustToContents();
                        wb.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Đã xuất dữ liệu ra tập tin Excel thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
