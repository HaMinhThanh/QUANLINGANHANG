using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DataModel;


namespace DataAccessTier
{
    public class DieuKhoanHopDongDAO
    {
        public DieuKhoanHopDongDAO() { }
        public DieuKhoanChoVay GetDieuKhoanHopDongByMaDieuKhoan(string MaDieuKhoan)
        {
            DieuKhoanChoVay result = new DieuKhoanChoVay();

            SqlConnection conn = DBConnection.getConnection();

            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbDieuKhoan WHERE MaDieuKhoan = @MaDieuKhoan", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MaDieuKhoan", MaDieuKhoan);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result.MaDieuKhoan = reader.GetString(0);
                    result.MoTa = reader.GetString(1);
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

        public DataTable GetDieuKhoanByMoTa(string MoTa)
        {
            SqlConnection conn = DBConnection.getConnection();
            DataTable dt = new DataTable();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbDieuKhoan WHERE MoTa LIKE @MoTa", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MoTa", "%" + MoTa + "%");
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
            }
            catch (SqlException SQLex)
            {
                throw SQLex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public bool AddDieuKhoan(DieuKhoanChoVay entry)
        {
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            if (entry.MaDieuKhoan.Equals("")) entry.MaDieuKhoan = Guid.NewGuid().ToString();
            SqlCommand cmd = new SqlCommand("INSERT INTO tbDieuKhoan VALUES (@MaDieuKhoan, @MoTa)", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MaDieuKhoan", entry.MaDieuKhoan);
                cmd.Parameters.AddWithValue("@MoTa", entry.MoTa);

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't add new term");
                return true;
            }
            catch (SqlException SQLex)
            {
                throw SQLex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
