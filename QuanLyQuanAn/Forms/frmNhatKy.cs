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
using QuanLyQuanAn.Data;

namespace QuanLyQuanAn.Forms
{
    public partial class frmNhatKy : Form
    {
        QLQADbContext context = new QLQADbContext();
        public frmNhatKy()
        {
            InitializeComponent();
        }

        private void frmNhatKy_Load(object sender, EventArgs e)
        {
            dataGridView.AutoGenerateColumns = false;
            var nhatky = context.AuditLogs
              .Select(bc => new
              {
                  bc.Id,
                  User = context.NhanVien.FirstOrDefault(r => r.ID == Convert.ToInt32(bc.UserId)).HoVaTen,
                  Table = bc.TableName,
                  Action = bc.Action,
                  OldValue = bc.OldValues,
                  NewValue = bc.NewValues,
                  AffectAt = bc.AffectedAt
              }).ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = nhatky;
            dataGridView.DataSource = nhatky;
        }

        private void btnXemTheoNgay_Click(object sender, EventArgs e)
        {
            dataGridView.AutoGenerateColumns = false;
            var nhatky = context.AuditLogs
                .Where(r => r.AffectedAt.Date == dtpNgay.Value.Date)
              .Select(bc => new
              {
                  bc.Id,
                  User = context.NhanVien.FirstOrDefault(r => r.ID == Convert.ToInt32(bc.UserId)).HoVaTen,
                  Table = bc.TableName,
                  Action = bc.Action,
                  OldValue = bc.OldValues,
                  NewValue = bc.NewValues,
                  AffectAt = bc.AffectedAt
              }).ToList();
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = nhatky;
            dataGridView.DataSource = nhatky;
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            frmNhatKy_Load(sender, e);
        }
    }
}
