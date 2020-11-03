using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class KetQuaXetDuyet
    {
        public string UUID { get; set; }
        public NhanVienXetDuyet NVXetDuyet { get; set; }
        public DateTime ThoiDiemXetDuyet { get; set; }
        public bool isChapNhan { get; set; }
        public string LyDo { get; set; }
    }
}
