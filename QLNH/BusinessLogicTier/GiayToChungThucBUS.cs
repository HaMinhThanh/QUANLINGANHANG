using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataModel;
using DataAccessTier;

namespace BusinessLogicTier
{
    class GiayToChungThucBUS
    {
        private GiayToChungThucDAO dataAccessObj = new GiayToChungThucDAO();
        public List<string> GetMaGiayChungThucByMaTaiSan(string MaTaiSan)
        {
            try
            {
                return dataAccessObj.GetMaGiayChungThucByMaTaiSan(MaTaiSan);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddMaGiayChungThuc(string MaTaiSan, string MaChungThuc)
        {
            try
            {
                return dataAccessObj.AddMaGiayChungThuc(MaTaiSan, MaChungThuc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
