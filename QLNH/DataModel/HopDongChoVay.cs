using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class HopDongChoVay
    {
        public YeuCauChoVay YeuCauVay { get; set; }
        public List<DieuKhoanChoVay> DSDieuKhoan { get; set; }
        public NhanVienTinDung NVThietLap { get; set; }
        public DateTime NgayThietLap { get; set; }
        public double GiaTriConLai { get; set; }
        public TrangThaiKhoanVay TrangThai { get; set; }
    }
}
