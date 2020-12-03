using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using DataAccessTier;
using System.Data;

namespace BusinessLogicTier
{
    public class KhachHangBUS
    {
        private KhachHangDAO dataAccessObj = new KhachHangDAO();
        public KhachHang GetKhachHangByMaKH(string MaKH)
        {
            try
            {
                return dataAccessObj.GetKhachHangByMaKH(MaKH);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetKhachHangByTieuChuanTraCuu(KhachHang query)
        {
            try
            {
                return dataAccessObj.GetKhachHangByTieuChuanTraCuu(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddKhachHang(KhachHang entry)
        {
            try
            {
                return dataAccessObj.AddKhachHang(entry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateKhachHang(KhachHang entry)
        {
            try
            {
                return dataAccessObj.UpdateKhachHang(entry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
