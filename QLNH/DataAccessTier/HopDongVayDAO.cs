using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DataModel;

namespace DataAccessTier
{
    public class HopDongVayDAO
    {
        public HopDongVayDAO() { }
        public HopDongChoVay GetHopDongVayByMaHopDong(string MaHopDong)
        {
            SqlConnection conn = DBConnection.getConnection();
            HopDongChoVay result = new HopDongChoVay();
            string MaNV = "";
            string MaYC = "";
            string MaTrangThai = "";

            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbHopDongVay WHERE MaHopDong = @MaHopDong", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MaHopDong", MaHopDong);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result.MaHopDong = reader.GetString(0);
                    MaYC = reader.GetString(1);
                    MaNV = reader.GetString(2);
                    result.NgayThietLap = reader.GetDateTime(3);
                    result.GiaTriConLai = reader.GetDouble(4);
                    MaTrangThai = reader.GetString(5);
                    result.ngayCapNhatGanNhat = reader.GetDateTime(6);
                }
                reader.Close();

                result.YeuCauVay = new YeuCauVayDAO().GetYeuCauChoVayByMaYC(MaYC);
                result.NVThietLap = (NhanVienTinDung) new NhanVienDAO().GetNhanVienByMaNV(MaNV);
                result.TrangThai = new TrangThaiKhoanVayDAO().GetTrangThaiByMaTrangThai(MaTrangThai);
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

        public bool AddHopDongVay(HopDongChoVay entry)
        {
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            if (entry.MaHopDong.Equals("")) entry.MaHopDong = Guid.NewGuid().ToString();
            entry.ngayCapNhatGanNhat = DateTime.Now;
            SqlCommand cmd = new SqlCommand("INSERT INTO tbHopDongVay VALUES (@MaHopDong, @MaYeuCau, @MaNV, @NgayLap, @GiaTri, @MaTrangThai, @NgayCapNhat)", conn);
            try
            {
                
                cmd.Parameters.AddWithValue("@MaHopDong", entry.MaHopDong);
                cmd.Parameters.AddWithValue("@MaYeuCau", entry.YeuCauVay.MaYeuCau);
                cmd.Parameters.AddWithValue("@MaNV", entry.NVThietLap.MaNV);
                cmd.Parameters.AddWithValue("@NgayLap", entry.NgayThietLap);
                cmd.Parameters.AddWithValue("@GiaTri", entry.GiaTriConLai);
                cmd.Parameters.AddWithValue("@MaTrangThai", entry.TrangThai.UUID);
                cmd.Parameters.AddWithValue("@NgayCapNhat", entry.ngayCapNhatGanNhat);

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't add new contract");
                return true;
            }
            catch (SqlException SQLex)
            {
                throw SQLex;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw ex;
            }
        }

        public bool UpdateHopDongVay(HopDongChoVay entry)
        {
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            if (entry.MaHopDong.Equals("")) throw new Exception("Unknown contract");
            entry.ngayCapNhatGanNhat = DateTime.Now;
            SqlCommand cmd = new SqlCommand("UPDATE tbHopDongVay SET MaYeuCau = @MaYeuCau, MaNVTiepNhan = @MaNV, NgayThietLap = @NgayLap, GiaTriHienTai = @GiaTri, MaTrangThai = @MaTrangThai, NgayCapNhatCuoi = @NgayCapNhat WHERE MaHopDong = @MaHopDong,", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MaYeuCau", entry.YeuCauVay.MaYeuCau);
                cmd.Parameters.AddWithValue("@MaNV", entry.NVThietLap.MaNV);
                cmd.Parameters.AddWithValue("@NgayLap", entry.NgayThietLap);
                cmd.Parameters.AddWithValue("@GiaTri", entry.GiaTriConLai);
                cmd.Parameters.AddWithValue("@MaTrangThai", entry.TrangThai.UUID);
                cmd.Parameters.AddWithValue("@MaHopDong", entry.MaHopDong);
                cmd.Parameters.AddWithValue("@NgayCapNhat", entry.ngayCapNhatGanNhat);

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't update contract");
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
