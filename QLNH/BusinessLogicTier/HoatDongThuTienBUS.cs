using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataModel;
using DataAccessTier;

namespace BusinessLogicTier
{
    class HoatDongThuTienBUS
    {
        private HoatDongThuTienDAO dataAccessObj = new HoatDongThuTienDAO();
        public DataTable GetHoatDongThuTienInRangeThoiDiem(DateTime startTime, DateTime endTime)
        {
            try
            {
                return dataAccessObj.GetHoatDongThuTienInRangeThoiDiem(startTime, endTime);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddHoatDongThuTien(BienBanThuTien entry)
        {
            try
            {
                return dataAccessObj.AddHoatDongThuTien(entry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
