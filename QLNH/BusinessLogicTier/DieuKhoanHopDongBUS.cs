using DataAccessTier;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessLogicTier
{
    public class DieuKhoanHopDongBUS
    {
        private DieuKhoanHopDongDAO dataAccessObj = new DieuKhoanHopDongDAO();
        public DieuKhoanChoVay GetDieuKhoanHopDongByMaDieuKhoan(string MaDieuKhoan)
        {
            try
            {
                return dataAccessObj.GetDieuKhoanHopDongByMaDieuKhoan(MaDieuKhoan);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDieuKhoanByMoTa(string MoTa)
        {
            try
            {
                return dataAccessObj.GetDieuKhoanByMoTa(MoTa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddDieuKhoan(DieuKhoanChoVay entry)
        {
            try
            {
                return dataAccessObj.AddDieuKhoan(entry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
