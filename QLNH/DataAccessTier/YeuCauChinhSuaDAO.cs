using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataAccessTier
{
    public class YeuCauChinhSuaDAO : DBConnection
    {
        public YeuCauChinhSuaDAO() : base() { }
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
                        default: throw new Exception("Unknown yeucauchinhsua type");
                    }
                    
                }
                reader.Close();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
