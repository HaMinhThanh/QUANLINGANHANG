using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataAccessTier
{
    public class YeuCauVayDAO 
    {
        public YeuCauVayDAO() { }
        public YeuCauChoVay GetYeuCauChoVayByMaYC(String MaYeuCau)
        {
            YeuCauChoVay result = new YeuCauChoVay();
            String MaKHYC = "";
            String MaNVTiepNhan = "";
            String MaKQXetDuyet = "";
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbYeuCauChoVay WHERE MaYeuCau = @MaYeuCau", conn);

            try
            {
                cmd.Parameters.AddWithValue("@MaYeuCau", MaYeuCau);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result.MaYeuCau = reader.GetString(0);
                    MaKHYC = reader.GetString(1);
                    MaNVTiepNhan = reader.GetString(2);
                    result.SoTienVay = reader.GetDouble(3);
                    result.LaiSuat = reader.GetDouble(4);
                    result.KyHan = reader.GetInt32(5);
                    MaKQXetDuyet = reader.GetString(6);
                    result.ThoiDiemTiepNhan = reader.GetDateTime(7);
                }
                reader.Close();
                KhachHangDAO tempAccessObj0 = new KhachHangDAO();
                if (!MaKHYC.Equals(""))
                {
                    result.KHYeuCau = tempAccessObj0.GetKhachHangByMaKH(MaKHYC);
                }

                NhanVienDAO tempAccessObj1 = new NhanVienDAO();
                if (!MaNVTiepNhan.Equals(""))
                {
                    result.NVTiepNhan = (NhanVienTinDung)tempAccessObj1.GetNhanVienByMaNV(MaNVTiepNhan);
                }

                KetQuaXetDuyetDAO tempAccessObj2 = new KetQuaXetDuyetDAO();
                if (!MaKQXetDuyet.Equals(""))
                {
                    result.KQXetDuyet = tempAccessObj2.GetKQXetDuyetByMaKQ(MaKQXetDuyet);
                }
                TaiSanTheChapDAO tempAccessObj3 = new TaiSanTheChapDAO();
                result.DSTaiSanTheChap = tempAccessObj3.GetTaiSanTheChapByMaYeuCauChoVay(MaYeuCau);                  
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


        public bool AddYeuCauChoVay(YeuCauChoVay entry)
        {
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            if (entry.MaYeuCau.Equals("")) entry.MaYeuCau = Guid.NewGuid().ToString();
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tbKhachHang VALUES (@MaYeuCau, @MaKHYeuCau, @MaNVTiepNhan, @SoTienVay, @LaiSuat, @KiHan,@MaKQXetDuyet)", conn);

                cmd.Parameters.AddWithValue("@MaYeuCau", entry.MaYeuCau);
                cmd.Parameters.AddWithValue("@MaKHYeuCau", entry.KHYeuCau.MaKH);
                cmd.Parameters.AddWithValue("@MaNVTiepNhan", entry.NVTiepNhan.MaNV);
                cmd.Parameters.AddWithValue("@SoTienVay", entry.SoTienVay);
                cmd.Parameters.AddWithValue("@LaiSuat", entry.LaiSuat);
                cmd.Parameters.AddWithValue("@KiHan", entry.KHYeuCau);
                cmd.Parameters.AddWithValue("@MaKQXetDuyet", entry.KQXetDuyet.UUID);

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't add new YeuCauVay");

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
