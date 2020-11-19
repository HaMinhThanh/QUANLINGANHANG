using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModel
{
    public class KhachHangDoanhNghiep : KhachHang
    {
        public string MaDKDoanhNghiep { get; set; } = "";
        public string ChucVuKHDaiDien { get; set; } = "";
        public string TenDoanhNghiep { get; set; } = "";
        public string LinhVuc { get; set; } = "";

        public KhachHangDoanhNghiep() : base() { }
    }
}
