using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class YeuCauChinhSuaHopDong
    {
        public string UUID { get; set; } = "";
        public HopDongChoVay HopDong { get; set; }
        public NhanVienTinDung NVTiepNhan { get; set; }
        public DateTime NgayTiepNhan { get; set; }
        public KetQuaXetDuyet KQXetDuyet { get; set; }
        public string LyDo { get; set; }
        public YeuCauChinhSuaKiHan ctKiHan { get; set; }
        public YeuCauChinhSuaLaiSuat ctLaiSuat { get; set; }
    }
}
