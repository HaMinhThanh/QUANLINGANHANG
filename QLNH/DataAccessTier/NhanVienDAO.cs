using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataAccessTier
{
    public class NhanVienDAO
    {
        public NhanVienDAO() { }
        public NhanVien GetNhanVienByMaNV(string MaNV)
        {
            NhanVien result = new NhanVien();
            string MaDinhDanh = "";
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbNhanVien WHERE MaNV = @MaNV", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MaNV", MaNV);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int employeeType = (byte)reader["LoaiNhanVien"];

                    if (employeeType == 1) result = new NhanVienTinDung();
                    else if (employeeType == 2) result = new NhanVienKeToan();
                    else if (employeeType == 3) result = new NhanVienXetDuyet();
                    else if (employeeType == 4) result = new NhanVienQuanLy();
                    else throw new Exception("Unknown Employee Type");

                    result.MaNV = reader.GetString(0);
                    result.HoTen = reader.GetString(1);
                    result.NgaySinh = reader.GetDateTime(4);
                    result.SDT = reader.GetString(5);
                    result.DiaChi = reader.GetString(6);
                    result.NgayVaoLam = reader.GetDateTime(7);
                    MaDinhDanh = reader.GetString(8);
                }
                reader.Close();

                DinhDanhDAO tempAccessObj = new DinhDanhDAO();
                if (!MaDinhDanh.Equals(""))
                {
                    result.DinhDanhNV = tempAccessObj.GetDinhDanhByMaDinhDanh(MaDinhDanh);
                }
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
            return result;
        }

        public NhanVien GetNhanVienByDangNhap(string TenDangNhap, string MatKhau)
        {
            NhanVien result = null;
            string MaDinhDanh = "";
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbNhanVien WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau", conn);
            try
            {
                cmd.Parameters.AddWithValue("@TenDangNhap", TenDangNhap);
                cmd.Parameters.AddWithValue("@MatKhau", MatKhau);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int employeeType = (byte) reader["LoaiNhanVien"];

                    if (employeeType == 1) result = new NhanVienTinDung();
                    else if (employeeType == 2) result = new NhanVienKeToan(); 
                    else if (employeeType == 3) result = new NhanVienXetDuyet(); 
                    else if (employeeType == 4) result = new NhanVienQuanLy(); 
                    else throw new Exception("Unknown Employee Type");

                    result.MaNV = reader.GetString(0);
                    result.HoTen = reader.GetString(1);
                    result.NgaySinh = reader.GetDateTime(4);
                    result.SDT = reader.GetString(5);
                    result.DiaChi = reader.GetString(6);
                    result.NgayVaoLam = reader.GetDateTime(7);
                    MaDinhDanh = reader.GetString(8);
                }
                reader.Close();

                DinhDanhDAO tempAccessObj = new DinhDanhDAO();
                if (!MaDinhDanh.Equals(""))
                {
                    result.DinhDanhNV = tempAccessObj.GetDinhDanhByMaDinhDanh(MaDinhDanh);
                }
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
            return result;
        }
    }
}
