using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessTier
{
    public class KetQuaXetDuyetDAO
    {
        public KetQuaXetDuyetDAO()  { }
        public KetQuaXetDuyet GetKQXetDuyetByMaKQ(string MaKQ)
        {
            KetQuaXetDuyet result = new KetQuaXetDuyet();
            string MaNV = "";

            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbKQXetDuyet WHERE MaKQXetDuyet = @MaKQXetDuyet", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MaKQXetDuyet", MaKQ);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result.UUID = reader.GetString(0);
                    MaNV = reader.GetString(1);
                    result.isChapNhan = reader.GetBoolean(2);
                    result.LyDo = reader.GetString(3);
                }
                reader.Close();

                result.NVXetDuyet = (NhanVienXetDuyet)new NhanVienDAO().GetNhanVienByMaNV(MaNV);
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

        public bool AddKQXetDuyet(KetQuaXetDuyet entry)
        {
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            if (entry.UUID.Equals("")) entry.UUID = Guid.NewGuid().ToString();
            SqlCommand cmd = new SqlCommand("INSERT INTO tbKQXetDuyet VALUES (@MaKQ, @MaNV, @KetQua, @LyDo)", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MaKQ", entry.UUID);
                cmd.Parameters.AddWithValue("@MaNV", entry.NVXetDuyet.MaNV);
                cmd.Parameters.AddWithValue("@KetQua", entry.isChapNhan);
                cmd.Parameters.AddWithValue("@LyDo", entry.LyDo);

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't add new approval action");
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
