using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace QuanLyQuanAn.Data
{
    public class HoaDon
    {
        public int ID { get; set; }
        public int NhanVienID { get; set; }
        public int KhachHangID { get; set; }
        public int BanID { get; set; }
        public DateTime NgayLap { get; set; }
        public string? GhiChuHoaDon { get; set; }
        public int? GiamGia {  get; set; }
        public decimal TongTien { get; set; }
        public int trangthai { get; set; }
        public virtual ObservableCollectionListSource<HoaDon_ChiTiet> HoaDon_ChiTiet { get; } = new();
        public virtual KhachHang KhachHang { get; set; } = null!;
        public virtual NhanVien NhanVien { get; set; } = null!;

        public virtual Ban Ban { get; set; } = null!;
        
    }
    [NotMapped]

    public class DanhSachHoaDon
    {
        public int ID { get; set; }
        public int NhanVienID { get; set; }
        public string HoVaTenNhanVien { get; set; }
        public int KhachHangID { get; set; }
        public string HoVaTenKhachHang { get; set; }
        public int BanID { get; set; }
        public string TenBan {  get; set; }
        public DateTime NgayLap { get; set; }
        public string? GhiChuHoaDon { get; set; }
        public int? GiamGia { get; set; }
        public string? XemChiTiet { get; set; }
        public decimal? TongTienHoaDon { get; set; }
        public int trangthai { get; set; }

    }
}
