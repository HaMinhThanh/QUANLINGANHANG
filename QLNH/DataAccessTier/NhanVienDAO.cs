using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataAccessTier
{
    public class NhanVienDAO : DBConnection
    {
        public NhanVienDAO() : base() { }
        public NhanVien GetNhanVienByMaNV(string MaNV)
        {
            NhanVien result = new NhanVienTinDung();
            string MaDinhDanh = "";
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbNhanVien WHERE MaNV = @MaNV");
            try
            {
                cmd.Parameters.AddWithValue("@MaNV", MaNV);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    switch (reader.GetInt32(9))
                    {
                        case 1: result = new NhanVienTinDung(); break;
                        case 2: result = new NhanVienKeToan(); break;
                        case 3: result = new NhanVienXetDuyet(); break;
                        case 4: result = new NhanVienQuanLy(); break;
                        default: throw new Exception("Unknown Employee Type");
                    }
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
                throw ex;
            }
            return result;
        }
    }
}
