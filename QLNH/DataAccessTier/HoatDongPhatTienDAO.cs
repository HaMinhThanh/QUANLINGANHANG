using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DataModel;

namespace DataAccessTier
{
    public class HoatDongPhatTienDAO : DBConnection
    {
        public HoatDongPhatTienDAO() : base() { }
        public DataTable GetHoatDongPhatTienInRangeThoiDiem(DateTime startTime, DateTime endTime)
        {
            DataTable dt = new DataTable();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbHoatDongPhatTien WHERE ThoiDiemThucHien >= @ThoiDiemBatDau AND ThoiDiemThucHien <= @ThoiDiemKetThuc ", conn);
            try
            {
                cmd.Parameters.AddWithValue("@ThoiDiemBatDau", startTime);
                cmd.Parameters.AddWithValue("@ThoiDiemKetThuc", endTime);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
            }
            catch (SqlException SQLex)
            {
                throw SQLex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public bool AddHoatDongPhatTien(BienBanPhatTien entry)
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            if (entry.UUID.Equals("")) entry.UUID = Guid.NewGuid().ToString();
            SqlCommand cmd = new SqlCommand("INSERT INTO tbDieuKhoan VALUES (@MaHoatDong, @MaHopDong, @MaNV, @ThoiDiem, @MaGiaoDich)", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MaHoatDong", entry.UUID);
                cmd.Parameters.AddWithValue("@MaHopDong", entry.HopDong.MaHopDong);
                cmd.Parameters.AddWithValue("@MaNV", entry.NVThucHien.MaNV);
                cmd.Parameters.AddWithValue("@ThoiDiem", entry.GiaoDichThucHien.ThoiDiemThucHien);
                cmd.Parameters.AddWithValue("@MaGiaoDich", entry.GiaoDichThucHien.UUID);

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't add new withdraw action");
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
