using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class YeuCauChoVay
    {
        public string MaYeuCau { get; set; } = "";
        public KhachHang KHYeuCau { get; set; }
        public NhanVienTinDung NVTiepNhan { get; set; }
        public DateTime ThoiDiemTiepNhan { get; set; }
        public double SoTienVay { get; set; }
        public double LaiSuat { get; set; }
        public int KyHan { get; set; }
        public List<TaiSanTheChap> DSTaiSanTheChap { get; set; }
        public KetQuaXetDuyet KQXetDuyet { get; set; }
    }
}
