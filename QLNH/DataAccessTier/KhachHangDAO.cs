using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DataAccessTier
{
    public class KhachHangDAO : DBConnection
    {
        public KhachHangDAO() : base() { }
        public KhachHang GetKhachHangByMaKH(string MaKH)
        {
            KhachHang result = new KhachHang();
            string MaDinhDanh = "";
            
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbKhachHang WHERE MaKH = @MaKH");
            try
            {
                cmd.Parameters.AddWithValue("@MaKH", MaKH);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result.MaKH = reader.GetString(0);
                    result.HoTen = reader.GetString(1);
                    result.NgaySinh = reader.GetDateTime(2);
                    result.SDT = reader.GetString(3);
                    result.DiaChi = reader.GetString(4);
                    MaDinhDanh = reader.GetString(5);
                }
                reader.Close();

                DinhDanhDAO tempAccessObj = new DinhDanhDAO();
                if (!MaDinhDanh.Equals(""))
                {
                    result.DinhDanhKH = tempAccessObj.GetDinhDanhByMaDinhDanh(MaDinhDanh);
                }
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
    }
}
