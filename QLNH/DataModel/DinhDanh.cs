using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class DinhDanh
    {
        public string MaDinhDanh { get; set; } = "";
        public enum DANH_SACH_LOAI_DINH_DANH { CMND, CCCD, PASSPORT }
        public DANH_SACH_LOAI_DINH_DANH LoaiDinhDanh { get; set; }
        public string GiaTriDinhDanh { get; set; }
    }
}
