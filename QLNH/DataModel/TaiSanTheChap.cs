using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class TaiSanTheChap
    {
        public string MaTSTC { get; set; }
        public string MoTa { get; set; }
        public double DinhGia { get; set; }
        public TrangThaiTaiSan TrangThai { get; set; }
        public List<string> DSMaGiayToChungThuc { get; set; }
    }
}
