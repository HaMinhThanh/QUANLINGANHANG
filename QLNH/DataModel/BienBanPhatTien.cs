using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class BienBanPhatTien
    {
        public string UUID { get; set; } = "";
        public NhanVienKeToan NVThucHien { get; set; }
        public HopDongChoVay HopDong { get; set; }
        public GiaoDichChi GiaoDichThucHien { get; set; }
    }
}
