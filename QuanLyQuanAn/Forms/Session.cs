using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.Forms
{
    public static class Session
    {
        // Biến lưu ID người dùng đăng nhập
        public static string UserId { get; set; }

        // Bạn có thể lưu thêm tên hiển thị nếu muốn
        public static string UserName { get; set; }
    }

}
