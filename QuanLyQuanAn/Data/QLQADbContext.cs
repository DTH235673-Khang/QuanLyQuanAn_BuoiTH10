
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using QuanLyQuanAn.Forms;

namespace QuanLyQuanAn.Data
{
    public class QLQADbContext : DbContext
    {
        public DbSet<Ban> Ban { get; set; }
        public DbSet<BangCong> BangCong { get; set; }
        public DbSet<CaLam> CaLam { get; set; }
        public DbSet<ChucVu> ChucVu { get; set; }
        public DbSet<DanhMuc> DanhMuc { get; set; }
        public DbSet<DonViTinh> DonViTinh { get; set; }
        public DbSet<ThucAn> ThucAn { get; set; }
        public DbSet<NhanVien> NhanVien { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<KiemKe> KiemKe { get; set; }

        public DbSet<LichLam> LichLam { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<HoaDon_ChiTiet> HoaDon_ChiTiet { get; set; }
        public DbSet<NhaCungCap> NhaCungCap { get; set; }
        public DbSet<NguyenLieu> NguyenLieu { get; set; }
        public DbSet<PhieuNhapKho> PhieuNhapKho { get; set; }
        public DbSet<PhieuNhapKho_ChiTiet> PhieuNhapKho_ChiTiet { get; set; }

        // Tạo Constructor nhận UserId
        public QLQADbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["QLQAConnection"].ConnectionString);
        }
        public DbSet<AuditLog> AuditLogs { get; set; }


        // Ghi đè hàm SaveChanges (Đồng bộ)
        public override int SaveChanges()
        {
            OnBeforeSaveChanges();
            return base.SaveChanges();
        }

        // Ghi đè hàm SaveChanges (Bất đồng bộ - khuyên dùng)
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSaveChanges();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();

            foreach (var entry in ChangeTracker.Entries())
            {
                // Không lưu log cho chính bảng AuditLogs hoặc dữ liệu không đổi
                if (entry.Entity is AuditLog || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                var auditEntry = new AuditEntry
                {
                    TableName = entry.Metadata.GetTableName(),
                    Action = entry.State.ToString(),
                    UserId =Session.UserId ?? "System"
                };

                foreach (var property in entry.Properties)
                {
                    string propertyName = property.Metadata.Name;

                    // Bỏ qua các trường Primary Key nếu bạn không muốn log chúng trong NewValues khi Update
                    if (property.Metadata.IsPrimaryKey()) continue;

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;

                        case EntityState.Deleted:
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;

                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                    }
                }
                auditEntries.Add(auditEntry);
            }

            // Lưu các bản ghi log vào DbSet
            foreach (var entry in auditEntries)
            {
                AuditLogs.Add(entry.ToAuditLog());
            }
        }
        }
}
