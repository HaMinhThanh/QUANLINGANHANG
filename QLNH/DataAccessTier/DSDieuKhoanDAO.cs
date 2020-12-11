using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataModel;

namespace DataAccessTier
{
    public class DSDieuKhoanDAO
    {
        public DSDieuKhoanDAO() { }
        public List<DieuKhoanChoVay> GetDieuKhoanHopDongByMaYeuCau(string MaYeuCau)
        {
            List<DieuKhoanChoVay> result = new List<DieuKhoanChoVay>();
            List<string> DSMaDieuKhoan = new List<string>();

            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbDieuKhoanHopDong WHERE MaYeuCau = @MaYeuCau", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MaYeuCau", MaYeuCau);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DSMaDieuKhoan.Add(reader.GetString(1));
                }

                DieuKhoanDAO tempAccessObj = new DieuKhoanDAO();
                foreach(string val in DSMaDieuKhoan)
                {
                    result.Add(tempAccessObj.GetDieuKhoanHopDongByMaDieuKhoan(val));
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

        public bool AddDieuKhoanToHopDong(string MaDieuKhoan, string MaYeuCau)
        {
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("INSERT INTO tbDieuKhoanHopDong VALUES (@MaYeuCau, @MaDieuKhoan)", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MaYeuCau", MaYeuCau);
                cmd.Parameters.AddWithValue("@MaDieuKhoan", MaDieuKhoan);

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't add new term to contract");

            }
            catch (SqlException SQLex)
            {
                throw SQLex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public bool RemoveDieuKhoanFromHopDong(string MaDieuKhoan, string MaYeuCau)
        {
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("DELETE FROM tbDieuKhoanHopDong WHERE MaYeuCau = @MaYeuCau, MaDieuKhoan = @MaDieuKhoan)", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MaYeuCau", MaYeuCau);
                cmd.Parameters.AddWithValue("@MaDieuKhoan", MaDieuKhoan);

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't remove term from contract");

            }
            catch (SqlException SQLex)
            {
                throw SQLex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

    }
}
