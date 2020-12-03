using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataModel;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class DinhDanhBUS
    {
        private DinhDanhDAO dataAccessObj = new DinhDanhDAO();
        public DinhDanh GetDinhDanhByMaDinhDanh(string MaDinhDanh)
        {
            try
            {
                return dataAccessObj.GetDinhDanhByMaDinhDanh(MaDinhDanh);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
/*
        public void dummyMethod()
        {
            try
            {
                return dataAccessObj.
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
*/
        public bool AddDinhDanh(DinhDanh entry)
        {
            try
            {
                return dataAccessObj.AddDinhDanh(entry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateDinhDanh(DinhDanh entry) { 
            try
            {
                return dataAccessObj.UpdateDinhDanh(entry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
