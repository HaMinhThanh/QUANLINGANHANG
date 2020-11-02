using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class BienBanThuTien
    {
        public NhanVienKeToan NVThucHien { get; set; }
        public KhachHang KHChiTra { get; set; }
        public HopDongChoVay HopDong { get; set; }
        public GiaoDichThu GiaoDichThucHien { get; set; }
    }
}
