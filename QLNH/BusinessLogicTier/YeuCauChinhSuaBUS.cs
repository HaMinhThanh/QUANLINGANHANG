using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class YeuCauChinhSuaBUS
    {
        YeuCauChinhSuaDAO dataAccessObj = new YeuCauChinhSuaDAO();
        public YeuCauChinhSuaHopDong GetYeuCauChinhSuaHopDong(string MaYC)
        {
            try
            {
                return dataAccessObj.GetYeuCauChinhSua(MaYC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddYeuCauChinhSuaHopDong(YeuCauChinhSuaHopDong entry)
        {
            try
            {
                return dataAccessObj.AddYeuCauChinhSuaHopDong(entry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateYeuCauChinhSuaHopDong(YeuCauChinhSuaHopDong entry)
        {
            try
            {
                return dataAccessObj.UpdateYeuCauChinhSuaHopDong(entry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
