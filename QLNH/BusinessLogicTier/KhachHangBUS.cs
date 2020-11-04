using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class KhachHangBUS
    {
        private KhachHangDAO dataAccessObj = new KhachHangDAO();
        public KhachHang GetKhachHangByMaKH(string MaKH)
        {
            try
            {
                return dataAccessObj.GetKhachHangByMaKH(MaKH);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
