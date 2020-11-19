using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataModel;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class HoatDongBUS
    {
        private HoatDongDAO dataAccessObj = new HoatDongDAO();
        public DataTable GetAllHoatDong()
        {
            try
            {
                return dataAccessObj.GetAllHoatDong();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetHoatDongByMoTa(string MoTa)
        {
            try
            {
                return dataAccessObj.GetHoatDongByMoTa(MoTa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetHoatDongInRangeThoiDiem(DateTime startTime, DateTime endTime)
        {
            try
            {
                return dataAccessObj.GetHoatDongInRangeThoiDiem(startTime, endTime);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddHoatDong(HoatDong entry)
        {
            try
            {
                return dataAccessObj.AddHoatDong(entry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
