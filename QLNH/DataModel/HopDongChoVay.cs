using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class HopDongChoVay
    {
        public string MaHopDong { get; set; } = "";
        public YeuCauChoVay YeuCauVay { get; set; }
        public NhanVienTinDung NVThietLap { get; set; }
        public DateTime NgayThietLap { get; set; }
        public double GiaTriConLai { get; set; }
        public TrangThaiKhoanVay TrangThai { get; set; }

        public bool ApplyModification(YeuCauChinhSuaHopDong entry)
        {
            if (entry is YeuCauChinhSuaKiHan)
            {
                this.YeuCauVay.KyHan += ((YeuCauChinhSuaKiHan)entry).GiaTriMoi;
            }
            else if (entry is YeuCauChinhSuaLaiSuat)
            {
                this.YeuCauVay.LaiSuat = ((YeuCauChinhSuaLaiSuat)entry).GiaTriMoi;
            }
            return true;
        }
    }
}
