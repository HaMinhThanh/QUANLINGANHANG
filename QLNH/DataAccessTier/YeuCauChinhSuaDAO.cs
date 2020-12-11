using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataAccessTier
{
    public class YeuCauChinhSuaDAO
    {
        public YeuCauChinhSuaDAO() { }
        public YeuCauChinhSuaHopDong GetYeuCauChinhSua(String UUID)
        {
            YeuCauChinhSuaHopDong result = new YeuCauChinhSuaHopDong();
            SqlConnection conn = DBConnection.getConnection();

            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }

            string MaHD = "", MaNV = "", MaKQ = "";
            try {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbYeuCauChinhSuaHopDong WHERE MaYeuCau = @MaYeuCau", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    result.UUID = reader.GetString(0);
                    MaHD = reader.GetString(1);
                    MaNV = reader.GetString(2);
                    result.NgayTiepNhan = reader.GetDateTime(3);
                    if (reader[4] != DBNull.Value)
                        MaKQ = reader.GetString(4);
                    result.LyDo = reader.GetString(5);
                }

                if (!MaHD.Equals("")) {
                    HopDongVayDAO tempAccessObj = new HopDongVayDAO();
                    result.HopDong = tempAccessObj.GetHopDongVayByMaHopDong(MaHD);
                }

                if (!MaNV.Equals(""))
                {
                    NhanVienDAO tempAccessObj = new NhanVienDAO();
                    result.NVTiepNhan = (NhanVienTinDung) tempAccessObj.GetNhanVienByMaNV(MaNV);
                }

                if (!MaKQ.Equals(""))
                {
                    KetQuaXetDuyetDAO tempAccessObj = new KetQuaXetDuyetDAO();
                    result.KQXetDuyet = tempAccessObj.GetKQXetDuyetByMaKQ(MaKQ);
                }

                return result;
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

        public bool AddYeuCauChinhSuaHopDong (YeuCauChinhSuaHopDong entry)
        {
            SqlConnection conn = DBConnection.getConnection();

            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            if (entry.UUID.Equals("")) entry.UUID = Guid.NewGuid().ToString();
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tbYeuCauChinhSuaHopDong VALUES(@MaYeuCau, @MaHopDong, @MaNVTiepNhan, @NgayTiepNhan, @KQXetDuyet, @LyDo)", conn);

                cmd.Parameters.AddWithValue("@MaYeuCau", entry.UUID);
                cmd.Parameters.AddWithValue("@MaHopDong", entry.HopDong.MaHopDong);
                cmd.Parameters.AddWithValue("@MaNVTiepNhan", entry.NVTiepNhan.MaNV);
                cmd.Parameters.AddWithValue("@NgayTiepNhan", entry.NgayTiepNhan);
                if (entry.KQXetDuyet == null)
                    cmd.Parameters.AddWithValue("@KQXetDuyet", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@kQXetDuyet", entry.KQXetDuyet.UUID);
                cmd.Parameters.AddWithValue("@LyDo", entry.LyDo);

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't add parameter entry");
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

        public bool UpdateYeuCauChinhSuaHopDong (YeuCauChinhSuaHopDong entry)
        {
            SqlConnection conn = DBConnection.getConnection();

            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            if (entry.UUID.Equals("")) entry.UUID = Guid.NewGuid().ToString();
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE tbYeuCauChinhSuaHopDong SET MaHopDong = @MaHopDong, MaNVTiepNhan = @MaNVTiepNhan, NgayTiepNhan = @NgayTiepNhan, MaKQXetDuyet = @KQXetDuyet, LyDo = @LyDo WHERE MaYeuCauChinhSua = @MaYeuCau", conn);
                
                cmd.Parameters.AddWithValue("@MaHopDong", entry.HopDong.MaHopDong);
                cmd.Parameters.AddWithValue("@MaNVTiepNhan", entry.NVTiepNhan.MaNV);
                cmd.Parameters.AddWithValue("@NgayTiepNhan", entry.NgayTiepNhan);
                if (entry.KQXetDuyet == null)
                    cmd.Parameters.AddWithValue("@KQXetDuyet", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@kQXetDuyet", entry.KQXetDuyet.UUID);
                cmd.Parameters.AddWithValue("@LyDo", entry.LyDo);
                cmd.Parameters.AddWithValue("@MaYeuCau", entry.UUID);

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't add parameter entry");
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
