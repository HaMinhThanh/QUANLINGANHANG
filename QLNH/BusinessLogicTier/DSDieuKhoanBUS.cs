using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class DSDieuKhoanBUS
    {
        private DSDieuKhoanDAO dataAccessObj = new DSDieuKhoanDAO();
        public List<DieuKhoanChoVay> GetDieuKhoanHopDongByMaYeuCau(string MaYeuCau)
        {
            try
            {
                return dataAccessObj.GetDieuKhoanHopDongByMaYeuCau(MaYeuCau);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddDieuKhoanToHopDong(string MaDieuKhoan, string MaYeuCau)
        {
            try
            {
                return dataAccessObj.AddDieuKhoanToHopDong(MaDieuKhoan, MaYeuCau);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveDieuKhoanFromHopDong(string MaDieuKhoan, string MaYeuCau)
        {
            try
            {
                return dataAccessObj.RemoveDieuKhoanFromHopDong(MaDieuKhoan, MaYeuCau);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
