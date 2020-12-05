using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataAccessTier
{
    public class YeuCauChinhSuaDAO
    {
        public YeuCauChinhSuaDAO() { }
        public YeuCauChinhSuaHopDong GetYeuCauChinhSua(String UUID)
        {
            YeuCauChinhSuaHopDong result = new YeuCauChinhSuaHopDong();
            SqlConnection conn = DBConnection.getConnection();
            try {
                
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddYeuCauChinhSuaHopDong (YeuCauChinhSuaHopDong entry)
        {
            return false;
        }

        public bool UpdateYeuCauChinhSuaHopDong (YeuCauChinhSuaHopDong entry)
        {
            return false;
        }
    }
}
