using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataModel;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class HoatDongPhatTienBUS
    {
        private HoatDongPhatTienDAO dataAccessObj = new HoatDongPhatTienDAO();
        public DataTable GetHoatDongPhatTienInRangeThoiDiem(DateTime startTime, DateTime endTime)
        {
            try
            {
                return dataAccessObj.GetHoatDongPhatTienInRangeThoiDiem(startTime, endTime);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddHoatDongPhatTien(BienBanPhatTien entry)
        {
            try
            {
                return dataAccessObj.AddHoatDongPhatTien(entry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
