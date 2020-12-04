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
                    if (reader[6] == DBNull.Value)
                        MaKQXetDuyet = "";
                    else
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

                //FIXME: 
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


        public string AddYeuCauChoVay(YeuCauChoVay entry)
        {
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            if (entry.MaYeuCau.Equals("")) entry.MaYeuCau = Guid.NewGuid().ToString();
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tbYeuCauChoVay VALUES (@MaYeuCau, @MaKHYeuCau, @MaNVTiepNhan, @SoTienVay, @LaiSuat, @KiHan, @MaKQXetDuyet, @ThoiDiemTiepNhan)", conn);

                cmd.Parameters.AddWithValue("@MaYeuCau", entry.MaYeuCau);
                cmd.Parameters.AddWithValue("@MaKHYeuCau", entry.KHYeuCau.MaKH);
                cmd.Parameters.AddWithValue("@MaNVTiepNhan", entry.NVTiepNhan.MaNV);
                cmd.Parameters.AddWithValue("@SoTienVay", entry.SoTienVay);
                cmd.Parameters.AddWithValue("@LaiSuat", entry.LaiSuat);
                cmd.Parameters.AddWithValue("@KiHan", entry.KyHan);
                if (entry.KQXetDuyet == null)
                    cmd.Parameters.AddWithValue("@MaKQXetDuyet", DBNull.Value);
                else cmd.Parameters.AddWithValue("@MaKQXetDuyet", entry.KQXetDuyet.UUID);
                cmd.Parameters.AddWithValue("@ThoiDiemTiepNhan", entry.ThoiDiemTiepNhan);

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't add new YeuCauVay");

                return entry.MaYeuCau;
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

        public string UpdateYeuCauChoVay(YeuCauChoVay entry)
        {
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            if (entry.MaYeuCau.Equals("")) entry.MaYeuCau = Guid.NewGuid().ToString();
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE tbYeuCauChoVay SET MaKHYeuCau = @MaKHYeuCau, MaNVTiepNhan = @MaNVTiepNhan, SoTienVay = @SoTienVay, LaiSuat = @LaiSuat, KiHan = @KiHan, MaKQXetDuyet = @MaKQXetDuyet, ThoiDiemTiepNhan = @ThoiDiemTiepNhan WHERE MaYeuCau = @MaYeuCau", conn);

                cmd.Parameters.AddWithValue("@MaYeuCau", entry.MaYeuCau);
                cmd.Parameters.AddWithValue("@MaKHYeuCau", entry.KHYeuCau.MaKH);
                cmd.Parameters.AddWithValue("@MaNVTiepNhan", entry.NVTiepNhan.MaNV);
                cmd.Parameters.AddWithValue("@SoTienVay", entry.SoTienVay);
                cmd.Parameters.AddWithValue("@LaiSuat", entry.LaiSuat);
                cmd.Parameters.AddWithValue("@KiHan", entry.KyHan);
                if (entry.KQXetDuyet == null)
                    cmd.Parameters.AddWithValue("@MaKQXetDuyet", DBNull.Value);
                else cmd.Parameters.AddWithValue("@MaKQXetDuyet", entry.KQXetDuyet.UUID);
                cmd.Parameters.AddWithValue("@ThoiDiemTiepNhan", entry.ThoiDiemTiepNhan);

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't update YeuCauVay");

                return entry.MaYeuCau;
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
