using DataModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccessTier
{
    public class TrangThaiTaiSanDAO
    {
        public TrangThaiTaiSanDAO() { }
        public TrangThaiTaiSan GetTrangThaiByMaTrangThai(string MaTrangThai)
        {
            TrangThaiTaiSan result = new TrangThaiTaiSan();
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbTrangThaiTaiSan WHERE MaTrangThai = @MaTrangThai", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MaTrangThai", MaTrangThai);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result.UUID = reader.GetString(0);
                    result.TenTrangThai= reader.GetString(1);
                    result.MucDanhGia = reader.GetDouble(2);
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

        public bool AddTrangThaiTaiSan(TrangThaiTaiSan entry)
        {
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            if (entry.UUID.Equals("")) entry.UUID = Guid.NewGuid().ToString();
            SqlCommand cmd = new SqlCommand("INSERT INTO tbTrangThaiTaiSan VALUES (@MaTrangThai, @TenTrangThai, @MucDanhGia)", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MaKQ", entry.UUID);
                cmd.Parameters.AddWithValue("@TenTrangThai", entry.TenTrangThai);
                cmd.Parameters.AddWithValue("@MucDanhGia", entry.MucDanhGia);

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't add new property status");
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
