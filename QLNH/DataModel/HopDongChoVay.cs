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
        public DateTime ngayCapNhatGanNhat { get; set; } = DateTime.Now;

        public bool ApplyModification(YeuCauChinhSuaHopDong entry)
        {
            if (entry.ctKiHan != null)
            {
                this.YeuCauVay.KyHan += entry.ctKiHan.GiaTriMoi;
            }
            else if (entry.ctLaiSuat != null)
            {
                this.YeuCauVay.LaiSuat = entry.ctLaiSuat.GiaTriMoi;
            }
            return true;
        }
    }
}
