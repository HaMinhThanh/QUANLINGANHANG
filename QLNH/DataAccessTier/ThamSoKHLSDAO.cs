using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataModel;

namespace DataAccessTier
{
    public class ThamSoKHLSDAO
    {
        public double GetLaiSuatByKyHan(int KyHan)
        {
            double result = 0.0;
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbThamSoKyHanLaiSuat WHERE KyHan = @KyHan", conn);
            try
            {
                cmd.Parameters.AddWithValue("@KyHan", KyHan);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result = (Double)reader.GetDecimal(1);
                }
                reader.Close();
            }
            catch (SqlException SQLex)
            {
                throw SQLex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public bool AddLaiSuatByKyHan(int KyHan, double LaiSuat)
        {
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }

            SqlCommand cmd = new SqlCommand("INSERT INTO tbThamSoKyHanLaiSuat VALUES(@KyHan, @LaiSuat)", conn);
            try
            {
                cmd.Parameters.AddWithValue("@KyHan", KyHan);
                cmd.Parameters.AddWithValue("@LaiSuat", LaiSuat);
                SqlDataReader reader = cmd.ExecuteReader();

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't add new interest parameter");
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

        public bool UpdateLaiSuatByKyHan(int KyHan, double LaiSuat)
        {
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }

            SqlCommand cmd = new SqlCommand("UPDATE tbThamSoKyHanLaiSuat SET LaiSuat = @LaiSuat WHERE KyHan = @KyHan", conn);
            try
            {
                cmd.Parameters.AddWithValue("@KyHan", KyHan);
                cmd.Parameters.AddWithValue("@LaiSuat", LaiSuat);
                SqlDataReader reader = cmd.ExecuteReader();

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't update interest parameter");
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

        public bool RemoveLaiSuatByKyHan(int KyHan)
        {
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }

            SqlCommand cmd = new SqlCommand("DELETE tbThamSoKyHanLaiSuat WHERE KyHan = @KyHan", conn);
            try
            {
                cmd.Parameters.AddWithValue("@KyHan", KyHan);
                SqlDataReader reader = cmd.ExecuteReader();

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't remove interest parameter");
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
