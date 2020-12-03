using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataModel;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class HopDongVayBUS
    {
        private HopDongVayDAO dataAccessObj = new HopDongVayDAO();
        public HopDongChoVay GetHopDongVayByMaHopDong(string MaHopDong)
        {
            try
            {
                return dataAccessObj.GetHopDongVayByMaHopDong(MaHopDong);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddHopDongVay(HopDongChoVay entry)
        {
            try
            {
                return dataAccessObj.AddHopDongVay(entry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateHopDongVay(HopDongChoVay entry)
        {
            try
            {
                return dataAccessObj.UpdateHopDongVay(entry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
