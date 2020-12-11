using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class ThamSoKHLSBUS
    {
        ThamSoKHLSDAO dataAccessObj = new ThamSoKHLSDAO();
        public double GetLaiSuatByKyHan(int KyHan)
        {
            try
            {
                return dataAccessObj.GetLaiSuatByKyHan(KyHan);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddLaiSuatByKyHan(int KyHan, double LaiSuat)
        {
            try
            {
                return dataAccessObj.AddLaiSuatByKyHan(KyHan, LaiSuat);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateLaiSuatByKyHan(int KyHan, double LaiSuat)
        {
            try
            {
                return dataAccessObj.UpdateLaiSuatByKyHan(KyHan, LaiSuat);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveLaiSuatByKyHan(int KyHan)
        {
            try
            {
                return dataAccessObj.RemoveLaiSuatByKyHan(KyHan);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
