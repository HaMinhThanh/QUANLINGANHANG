using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;
using DataAccessTier;

namespace BusinessLogicTier
{
    class ThamSoBUS
    {
        ThamSoDAO dataAccessObj;
        public ThamSoBUS()
        {
            dataAccessObj = new ThamSoDAO();
        }
        public ThamSo GetLatestThamSo()
        {
            return dataAccessObj.GetLatestThamSo();
        }
        public bool AddThamSo(ThamSo entry)
        {
            return dataAccessObj.AddThamSo(entry);
        }
    }
}
