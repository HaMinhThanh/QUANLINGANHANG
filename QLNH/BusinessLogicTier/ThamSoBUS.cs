using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class ThamSoBUS
    {
        ThamSoDAO dataAccessObj;

        public ThamSoBUS()
        {
            dataAccessObj = new ThamSoDAO();
        }
        public ThamSo GetLatestThamSo()
        {
            try
            {
                return dataAccessObj.GetLatestThamSo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddThamSo(ThamSo entry)
        {
            try
            {
                return dataAccessObj.AddThamSo(entry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
