using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DataAccessTier
{
    public class DinhDanhDAO : DBConnection
    {
        public DinhDanhDAO() : base() { }
        public DinhDanh GetDinhDanhByMaDinhDanh(string MaDinhDanh)
        {
            DinhDanh result = new DinhDanh();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbDinhDanh WHERE MaDinhDanh = @MaDinhDanh", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MaDinhDanh", MaDinhDanh);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result.MaDinhDanh = reader.GetString(0);
                    result.LoaiDinhDanh = (DinhDanh.DANH_SACH_LOAI_DINH_DANH)reader.GetInt32(1);
                    result.GiaTriDinhDanh = reader.GetString(2);
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

        public bool AddDinhDanh(DinhDanh entry)
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            if(entry.MaDinhDanh.Equals("")) entry.MaDinhDanh = Guid.NewGuid().ToString();
            SqlCommand cmd = new SqlCommand("INSERT INTO tbDinhDanh VALUES(@MaDinhDanh, @LoaiDinhDanh, @GiaTri)", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MaDinhDanh", entry.MaDinhDanh);
                cmd.Parameters.AddWithValue("@LoaiDinhDanh", (int) entry.LoaiDinhDanh);
                cmd.Parameters.AddWithValue("@GiaTri", entry.GiaTriDinhDanh);

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't add new identity entry");
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
