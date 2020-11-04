using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;


namespace DataAccessTier
{
    public class DieuKhoanHopDongDAO : DBConnection
    {
        public DieuKhoanHopDongDAO() : base() { }
        public DieuKhoanChoVay GetDieuKhoanHopDongByMaDieuKhoan(string MaDieuKhoan)
        {
            DieuKhoanChoVay result = new DieuKhoanChoVay();
            return null;
        }
    }
}
