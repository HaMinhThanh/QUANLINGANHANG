using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessTier;
using DataModel;

namespace BusinessLogicTier
{
    public class BaoCaoDoiTuongVayBUS
    {
        BaoCaoDoiTuongVayDAO dataAccessObj = new BaoCaoDoiTuongVayDAO();
        public bool AddBaoCaoDoiTuongVay(BaoCaoTaiChinh entry)
        {
            try
            {
                return dataAccessObj.AddBaoCaoDoiTuongVay(entry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
