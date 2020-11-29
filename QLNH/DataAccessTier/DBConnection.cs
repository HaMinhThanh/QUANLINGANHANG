using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataModel;

namespace DataAccessTier
{
    public class DBConnection
    {
        protected static SqlConnection conn;
        public DBConnection()
        {
            try
            {
                conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\QuanLyNganHang.mdf;Integrated Security=True");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SqlConnection getConnection()
        {
            return conn;
        }
        public YeuCauChinhSuaHopDong GetYeuCauChinhSua(String UUID)
        {
            YeuCauChinhSuaHopDong result = new YeuCauChinhSuaHopDong();
            String MaHD = "";
            String MaNV = "";
            String MaKQ = "";

            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbChiTietYeuCauChinhSua WHERE MaYeuCauChinhSua = @MaYeuCauChinhSua", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MaYeuCauChinhSua", UUID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    switch (reader.GetInt32(1))
                    {
                        case 1:
                            result = new YeuCauChinhSuaKiHan();
                            ((YeuCauChinhSuaKiHan)result).GiaTriMoi = reader.GetInt32(3);
                            break;
                        case 2:
                            result = new YeuCauChinhSuaLaiSuat();
                            ((YeuCauChinhSuaLaiSuat)result).GiaTriMoi = reader.GetInt32(2);
                            break;
                        default: throw new Exception("unknow yeucauchinhsua type");
                    }

                }
                reader.Close();
                return result;

            } catch (Exception) 
            {
                
            }
            return result;
        }
    }
}
