using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DataModel;

namespace DataAccessTier
{
    public class HoatDongDAO
    {
        public HoatDongDAO() { }
        public DataTable GetAllHoatDong()
        {
            SqlConnection conn = DBConnection.getConnection();
            DataTable dt = new DataTable();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbHoatDong", conn);
            try
            {
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

        public DataTable GetHoatDongByMoTa(string MoTa)
        {
            SqlConnection conn = DBConnection.getConnection();
            DataTable dt = new DataTable();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbDieuKhoan WHERE MoTa LIKE @MoTa", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MoTa", "%" + MoTa + "%");
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

        public DataTable GetHoatDongInRangeThoiDiem(DateTime startTime, DateTime endTime)
        {
            SqlConnection conn = DBConnection.getConnection();
            DataTable dt = new DataTable();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbDieuKhoan WHERE ThoiDiemThucHien >= @ThoiDiemBatDau AND ThoiDiemThucHien <= @ThoiDiemKetThuc ", conn);
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

        public bool AddHoatDong(HoatDong entry)
        {
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            if (entry.UUID.Equals("")) entry.UUID = Guid.NewGuid().ToString();
            SqlCommand cmd = new SqlCommand("INSERT INTO tbDieuKhoan VALUES (@MaHoatDong, @MaNV, @ThoiDiem, @MoTa)", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MaHoatDong", entry.UUID);
                cmd.Parameters.AddWithValue("@MaNV", entry.NhanVienThucHien.MaNV);
                cmd.Parameters.AddWithValue("@ThoiDiem", entry.ThoiDiem);
                cmd.Parameters.AddWithValue("@MoTa", entry.MoTa);

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't log new action");
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
