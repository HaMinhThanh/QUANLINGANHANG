using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataModel;
using DataAccessTier;

namespace BusinessLogicTier
{
    class NhanVienBUS
    {
        private NhanVienDAO dataAccessObj = new NhanVienDAO();
        public NhanVien GetNhanVienByMaNV(string MaNV)
        {
            try
            {
                return dataAccessObj.GetNhanVienByMaNV(MaNV);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public NhanVien GetNhanVienByDangNhap(string TenDangNhap, string MatKhau)
        {
            try
            {
                return dataAccessObj.GetNhanVienByDangNhap(TenDangNhap, MatKhau);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
