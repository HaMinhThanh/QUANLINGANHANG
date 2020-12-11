using DataAccessTier;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessLogicTier
{
    public class DieuKhoanBUS
    {
        private DieuKhoanDAO dataAccessObj = new DieuKhoanDAO();
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

        public bool UpdateDieuKhoan(DieuKhoanChoVay entry)
        {
            try
            {
                return dataAccessObj.UpdateDieuKhoan(entry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveDieuKhoan(string entry_id)
        {
            try
            {
                return dataAccessObj.RemoveDieuKhoan(entry_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
