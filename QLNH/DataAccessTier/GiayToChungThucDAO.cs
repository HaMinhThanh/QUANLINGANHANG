using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccessTier
{
    public class GiayToChungThucDAO : DBConnection
    {
        public GiayToChungThucDAO() : base() {}
        public List<string> GetMaGiayChungThucByMaTaiSan(string MaTaiSan)
        {
            List<string> result = new List<string>();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbGiayToChungThuc WHERE MaTaiSan = @MaTaiSan", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MaTaiSan", MaTaiSan);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(reader.GetString(0));
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

        public bool AddMaGiayChungThuc(string MaTaiSan, string MaChungThuc)
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("INSERT INTO tbGiayToChungThuc VALUES(@MaChungThuc, @MaTaiSan)", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MaDinhDanh", MaChungThuc);
                cmd.Parameters.AddWithValue("@LoaiDinhDanh", MaTaiSan);

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't add new ownership paper");
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
