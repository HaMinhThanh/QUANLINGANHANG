using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataModel;
using DataAccessTier;

namespace BusinessLogicTier
{
    class TrangThaiTaiSanBUS
    {
        private TrangThaiTaiSanDAO dataAccessObj = new TrangThaiTaiSanDAO();

        public TrangThaiTaiSan GetTrangThaiByMaTrangThai(string MaTrangThai)
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
        public bool AddTrangThaiTaiSan(TrangThaiTaiSan entry)
        {
            try
            {
                return dataAccessObj.AddTrangThaiTaiSan(entry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
