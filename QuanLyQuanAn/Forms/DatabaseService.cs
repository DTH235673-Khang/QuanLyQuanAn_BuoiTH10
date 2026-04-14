using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyQuanAn.Data;

namespace QuanLyQuanAn.Forms
{
    public class DatabaseService
    {
        private readonly QLQADbContext _context;

        public DatabaseService(QLQADbContext context)
        {
            _context = context;
        }

        public void BackupDatabase(string filePath)
        {
            using (var db = new QLQADbContext())
            {
                try
                {
                    // Lấy tên database từ chuỗi kết nối
                    string dbName = db.Database.GetDbConnection().Database;

                    // Câu lệnh SQL thuần
                    string sqlCommand = $"BACKUP DATABASE [{dbName}] TO DISK = '{filePath}' WITH FORMAT, MEDIANAME = 'QLQA_Backup', NAME = 'Full Backup of QLQA'";

                    // Thực thi
                    db.Database.ExecuteSqlRaw(sqlCommand);

                    MessageBox.Show($"Sao lưu dữ liệu vào {filePath} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sao lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void RestoreDatabase(string filePath)
        {
            using (var db = new QLQADbContext())
            {
                try
                {
                    string dbName = db.Database.GetDbConnection().Database;

                    // Chuyển sang Database Master để thực hiện thao tác trên DB hiện tại
                    // SINGLE_USER WITH ROLLBACK IMMEDIATE sẽ ngắt mọi kết nối đang truy cập vào DB
                    string sqlCommand = $@"
                USE master;
                ALTER DATABASE [{dbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                RESTORE DATABASE [{dbName}] FROM DISK = '{filePath}' WITH REPLACE;
                ALTER DATABASE [{dbName}] SET MULTI_USER;";

                    db.Database.ExecuteSqlRaw(sqlCommand);

                    MessageBox.Show("Phục hồi dữ liệu thành công! Khởi động lại để xem dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi phục hồi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
