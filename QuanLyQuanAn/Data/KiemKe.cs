using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace QuanLyQuanAn.Data
{
    public class KiemKe
    {
        public int ID { get; set; }
        public int NguyenLieuID { get; set; }
        public int SoLuongThucTe { get; set; }
        public DateTime NgayKiemKe { get; set; }
        public string? GhiChu { get; set; }
        public virtual NguyenLieu NguyenLieu { get; set; }

    }
    [NotMapped]
    public class DanhSachKiemKe
    {
        public int ID { get; set; }
        public int NguyenLieuID { get; set; }
        public string TenNguyenLieu { get; set; }
        public int SoLuongThucTe { get; set; }
        public DateTime NgayKiemKe { get; set; }
        public string? GhiChu { get; set; }

    }
}
