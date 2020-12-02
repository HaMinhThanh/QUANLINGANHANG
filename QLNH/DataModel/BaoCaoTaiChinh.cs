using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModel
{
    public class BaoCaoTaiChinh
    {
        public string MaBaoCao { get; set; } = "";
        public KhachHang DoiTuongBaoCao { get; set; }
        public bool suDungVonDungMucDich { get; set; }
        public bool trangThaiTaiSanDamBao { get; set; }
        public string DanhGia { get; set; }
        
    }
}
