using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class NhanVien
    {
        public string MaNV { get; set; } = "";
        public string HoTen { get; set; }
        public DinhDanh DinhDanhNV { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayVaoLam { get; set; }
    }
}
