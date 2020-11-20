using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace DataAccessTier
{
    public class KhachHangDAO : DBConnection
    {
        public KhachHangDAO() : base() { }
        public KhachHang GetKhachHangByMaKH(string MaKH)
        {
            KhachHang result = new KhachHang();
            string MaDinhDanh = "";
            string MaDoanhNghiep = "";
            
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbKhachHang WHERE MaKH = @MaKH", conn);
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
                    MaDoanhNghiep = reader.GetString(6);
                    result.GioiTinh = reader.GetString(7);
                }
                reader.Close();

                DinhDanhDAO tempAccessObj = new DinhDanhDAO();
                if (!MaDinhDanh.Equals(""))
                {
                    result.DinhDanhKH = tempAccessObj.GetDinhDanhByMaDinhDanh(MaDinhDanh);
                }
                if (!MaDoanhNghiep.Equals(""))
                {
                    KhachHangDoanhNghiep new_result = new KhachHangDoanhNghiep();
                    new_result.MaKH = result.MaKH;
                    new_result.HoTen = result.HoTen;
                    new_result.NgaySinh = result.NgaySinh;
                    new_result.SDT = result.SDT;
                    new_result.DiaChi = result.DiaChi;
                    new_result.DinhDanhKH = result.DinhDanhKH;
                    this.AppendKhachHangDoanhNghiepByMaDN(MaDoanhNghiep, ref new_result);
                    return new_result;
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

        public void AppendKhachHangDoanhNghiepByMaDN(string MaDN, ref KhachHangDoanhNghiep result)
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbKhachHangDoanhNghiep WHERE MaDoanhNghiep = @MaDN", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MaDN", MaDN);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result.MaDKDoanhNghiep = reader.GetString(1);
                    result.TenDoanhNghiep = reader.GetString(2);
                    result.LinhVuc = reader.GetString(3);
                    result.ChucVuKHDaiDien = reader.GetString(4);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetKhachHangByTieuChuanTraCuu(KhachHang queryObj)
        {
            DataTable dt = new DataTable();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {
                SqlCommandTextBuilder cmdTextBuilder = new SqlCommandTextBuilder("SELECT * FROM tbKhachHang");
                if (!queryObj.MaKH.Equals("")) cmdTextBuilder.AppendColumn("MaKH");
                if (!queryObj.HoTen.Equals("")) cmdTextBuilder.AppendColumn("HoTen");
                if (queryObj.NgaySinh != null) cmdTextBuilder.AppendColumn("NgaySinh");
                if (!queryObj.SDT.Equals("")) cmdTextBuilder.AppendColumn("SDT");
                if (!queryObj.DiaChi.Equals("")) cmdTextBuilder.AppendColumn("DiaChi");
                if (queryObj.DinhDanhKH != null) cmdTextBuilder.AppendColumn("MaDinhDanh");

                SqlCommand cmd = new SqlCommand(cmdTextBuilder.commandText, conn);

                cmd.Parameters.AddWithValue("@MaKH", queryObj.MaKH);
                cmd.Parameters.AddWithValue("@HoTen", queryObj.MaKH);
                if (queryObj.NgaySinh != null)
                    cmd.Parameters.AddWithValue("@NgaySinh", queryObj.NgaySinh);
                cmd.Parameters.AddWithValue("@SDT", queryObj.SDT);
                cmd.Parameters.AddWithValue("@DiaChi", queryObj.DiaChi);
                if (queryObj.DinhDanhKH != null)
                    cmd.Parameters.AddWithValue("@MaDinhDanh", queryObj.DinhDanhKH.MaDinhDanh);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                return dt;
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

        public bool AddKhachHang(KhachHang entry)
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            if (entry.MaKH.Equals("")) entry.MaKH = Guid.NewGuid().ToString();
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tbKhachHang VALUES (@MaKH, @HoTen, @NgaySinh, @SDT, @DiaChi, @MaDinhDanh, @MaDoanhNghiep, @GioiTinh)", conn);

                cmd.Parameters.AddWithValue("@MaKH", entry.MaKH);
                cmd.Parameters.AddWithValue("@HoTen", entry.HoTen);
                cmd.Parameters.AddWithValue("@NgaySinh", entry.NgaySinh);
                cmd.Parameters.AddWithValue("@SDT", entry.SDT);
                cmd.Parameters.AddWithValue("@DiaChi", entry.DiaChi);
                cmd.Parameters.AddWithValue("@MaDinhDanh", entry.DinhDanhKH.MaDinhDanh);
                if (entry is KhachHangDoanhNghiep)
                {
                    cmd.Parameters.AddWithValue("@MaDoanhNghiep", this.AddKhachHangDoanhNghiep((KhachHangDoanhNghiep)entry));
                }
                else cmd.Parameters.AddWithValue("@MaDoanhNghiep", null);
                cmd.Parameters.AddWithValue("@GioiTinh", entry.GioiTinh);

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't add new customer");

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

        public string AddKhachHangDoanhNghiep(KhachHangDoanhNghiep entry)
        {
            string MaDN = Guid.NewGuid().ToString();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tbChiTietDoanhNghiep VALUES (@MaDoanhNghiep, @MaDKDoanhNghiep, @TenDoanhNghiep, @LinhVuc, @ChucVuDaiDien)", conn);
                cmd.Parameters.AddWithValue("@MaDoanhNghiep", MaDN);
                cmd.Parameters.AddWithValue("@MaDKDoanhNghiep", entry.MaDKDoanhNghiep);
                cmd.Parameters.AddWithValue("@TenDoanhNghiep", entry.TenDoanhNghiep);
                cmd.Parameters.AddWithValue("@LinhVuc", entry.LinhVuc);
                cmd.Parameters.AddWithValue("@ChucVuDaiDien", entry.ChucVuKHDaiDien);

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't add new cooperate customer");

                return MaDN;
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

            public bool UpdateKhachHang(KhachHang entry, string MaKH)
        {
            return true;
        }
    }
}
