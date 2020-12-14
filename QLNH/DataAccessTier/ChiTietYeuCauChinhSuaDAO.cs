using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessTier
{
    public class ChiTietYeuCauChinhSuaDAO
    {
        public YeuCauChinhSuaKiHan getYCKiHan()
        {
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {

            }
            catch (SqlException SQLex)
            {
                throw SQLex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            YeuCauChinhSuaKiHan result = null;
            return result;
        }
        public YeuCauChinhSuaLaiSuat getYCLaiSuat()
        {
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {

            }
            catch (SqlException SQLex)
            {
                throw SQLex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            YeuCauChinhSuaLaiSuat result = null;
            return result;
        }

        public bool addYCKiHan(YeuCauChinhSuaKiHan entry)
        {
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {

            }
            catch (SqlException SQLex)
            {
                throw SQLex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public bool addYCLaiSuat(YeuCauChinhSuaLaiSuat entry)
        {
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {

            }
            catch (SqlException SQLex)
            {
                throw SQLex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
