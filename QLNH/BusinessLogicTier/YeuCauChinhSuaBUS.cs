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
    }
}
