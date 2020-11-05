using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataModel;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class TrangThaiKhoanVayBUS
    {
        private TrangThaiKhoanVayDAO dataAccessObj = new TrangThaiKhoanVayDAO();
        public TrangThaiKhoanVay GetTrangThaiByMaTrangThai(string MaTrangThai)
        {
            try
            {
                return dataAccessObj.GetTrangThaiByMaTrangThai(MaTrangThai);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddTrangThaiKhoanVay(TrangThaiKhoanVay entry)
        {
            try
            {
                return dataAccessObj.AddTrangThaiKhoanVay(entry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
