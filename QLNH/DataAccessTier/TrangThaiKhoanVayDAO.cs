using DataModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccessTier
{
    public class TrangThaiKhoanVayDAO : DBConnection
    {
        public TrangThaiKhoanVayDAO() : base() { }
        public TrangThaiKhoanVay GetTrangThaiByMaTrangThai(string MaTrangThai)
        {
            TrangThaiKhoanVay result = new TrangThaiKhoanVay();

            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbTrangThaiHopDongVay WHERE MaTrangThai = @MaTrangThai", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MaTrangThai", MaTrangThai);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result.UUID = reader.GetString(0);
                    result.TenTrangThai = reader.GetString(1);
                    result.MucRuiRo = reader.GetInt32(2);
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

        public bool AddTrangThaiKhoanVay(TrangThaiKhoanVay entry)
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            if (entry.UUID.Equals("")) entry.UUID = Guid.NewGuid().ToString();
            SqlCommand cmd = new SqlCommand("INSERT INTO tbTrangThaiHopDongVay VALUES (@MaTrangThai, @TenTrangThai, @MucRuiRo)", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MaKQ", entry.UUID);
                cmd.Parameters.AddWithValue("@TenTrangThai", entry.TenTrangThai);
                cmd.Parameters.AddWithValue("@MucRuiRo", entry.MucRuiRo);

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't add new loan status");
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
