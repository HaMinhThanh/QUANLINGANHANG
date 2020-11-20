using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class TaiSanTheChapBUS
    {
        private TaiSanTheChapDAO dataAccessObj = new TaiSanTheChapDAO();
        public TaiSanTheChap GetTaiSanTheChapByMaTSTC(string MaTSTC)
        {
            try
            {
                return dataAccessObj.GetTaiSanTheChapByMaTSTC(MaTSTC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TaiSanTheChap> GetTaiSanTheChapByMaYeuCauChoVay(string MaYC)
        {
            try
            {
                return dataAccessObj.GetTaiSanTheChapByMaYeuCauChoVay(MaYC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddTaiSanTheChap(TaiSanTheChap entry)
        {
            try
            {
                return dataAccessObj.AddTaiSanTheChap(entry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateTaiSanTheChap(string target, TaiSanTheChap newEntry)
        {
            try
            {
                return dataAccessObj.UpdateTaiSanTheChap(newEntry, target);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
