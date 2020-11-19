using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataModel;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class GiaoDichBUS
    {
        private GiaoDichDAO dataAccessObj = new GiaoDichDAO();
        public GiaoDich GetGiaoDichByMaGiaoDich(string MaGD)
        {
            try
            {
                return dataAccessObj.GetGiaoDichByMaGiaoDich(MaGD);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddGiaoDich(GiaoDich entry)
        {
            try
            {
                return dataAccessObj.AddGiaoDich(entry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
