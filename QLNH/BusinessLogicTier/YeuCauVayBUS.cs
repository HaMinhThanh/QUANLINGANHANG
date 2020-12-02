using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class YeuCauVayBUS
    {
        private YeuCauVayDAO dataAccessObj = new YeuCauVayDAO();

        public YeuCauChoVay GetYeuCauChoVayByMaYC(string MaYC)
        {
            try
            {
                return dataAccessObj.GetYeuCauChoVayByMaYC(MaYC);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public string AddYeuCauChoVay(YeuCauChoVay entry)
        {
            try
            {
                return dataAccessObj.AddYeuCauChoVay(entry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
