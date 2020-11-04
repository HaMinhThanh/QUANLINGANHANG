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
                SqlCommand cmd = new SqlCommand("INSERT INTO tbKhachHang VALUES (@MaKH, @HoTen, @NgaySinh, @SDT, @DiaChi, @MaDinhDanh)", conn);

                cmd.Parameters.AddWithValue("@MaKH", entry.MaKH);
                cmd.Parameters.AddWithValue("@HoTen", entry.HoTen);
                cmd.Parameters.AddWithValue("@NgaySinh", entry.NgaySinh);
                cmd.Parameters.AddWithValue("@SDT", entry.SDT);
                cmd.Parameters.AddWithValue("@DiaChi", entry.DiaChi);
                cmd.Parameters.AddWithValue("@MaDinhDanh", entry.DinhDanhKH.MaDinhDanh);

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

        public bool UpdateKhachHang(KhachHang entry, string MaKH)
        {
            return true;
        }
    }
}
