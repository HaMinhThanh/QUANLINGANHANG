using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataModel;
using DataAccessTier;

namespace BusinessLogicTier
{
    class KetQuaXetDuyetBUS
    {
        private KetQuaXetDuyetDAO dataAccessObj = new KetQuaXetDuyetDAO();
        public KetQuaXetDuyet GetKQXetDuyetByMaKQ(string MaKQ)
        {
            try
            {
                return dataAccessObj.GetKQXetDuyetByMaKQ(MaKQ);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddKQXetDuyet(KetQuaXetDuyet entry)
        {
            try
            {
                return dataAccessObj.AddKQXetDuyet(entry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
