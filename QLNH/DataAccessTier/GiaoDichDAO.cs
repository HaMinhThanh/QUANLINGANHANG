using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DataModel;

namespace DataAccessTier
{
    public class GiaoDichDAO
    {
        public GiaoDichDAO() { }
        public GiaoDich GetGiaoDichByMaGiaoDich(string MaGD)
        {
            GiaoDich result = null;
            SqlConnection conn = DBConnection.getConnection();
            string MaDVGiaoDich = "";

            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbGiaoDich WHERE MaGiaoDich = @MaGiaoDich", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MaGiaoDich", MaGD);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    byte tranType = (byte)reader["LoaiGiaoDich"];
                    if (tranType == 1) result = new GiaoDichThu();
                    else if (tranType == 2) result = new GiaoDichChi();
                    else throw new Exception("Unknown transaction type");
                    result.UUID = reader.GetString(0);
                    MaDVGiaoDich = reader.GetString(2);
                    result.GiaTri = reader.GetDouble(3);
                    result.ThoiDiemThucHien = reader.GetDateTime(4);
                    result.MoTa = reader.GetString(5);
                }
                reader.Close();

                KhachHangDAO tempAccessObj = new KhachHangDAO();
                result.DonViGiaoDich = tempAccessObj.GetKhachHangByMaKH(MaDVGiaoDich);
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

        public bool AddGiaoDich(GiaoDich entry)
        {
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            if (entry.UUID.Equals("")) entry.UUID = Guid.NewGuid().ToString();
            int LoaiGiaoDich = 0;

            SqlCommand cmd = new SqlCommand("INSERT INTO tbGiaoDich VALUES (@MaGiaoDich, @LoaiGiaoDich, @DonViGiaoDich, @GiaTri, @ThoiDiem, @MoTa)", conn);
            try
            {
                if (entry is GiaoDichThu) LoaiGiaoDich = 1;
                else if (entry is GiaoDichChi) LoaiGiaoDich = 2;
                else throw new Exception("Unknown transaction type");

                cmd.Parameters.AddWithValue("@MaGiaoDich", entry.UUID);
                cmd.Parameters.AddWithValue("@LoaiGiaoDich", LoaiGiaoDich);
                cmd.Parameters.AddWithValue("@DonViGiaoDich", entry.DonViGiaoDich.MaKH);
                cmd.Parameters.AddWithValue("@GiaTri", entry.GiaTri);
                cmd.Parameters.AddWithValue("@ThoiDiem", entry.ThoiDiemThucHien);
                cmd.Parameters.AddWithValue("@MoTa", entry.MoTa);

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't add new transaction");
                return true;
            }
            catch (SqlException SQLex)
            {
                Console.WriteLine(SQLex.StackTrace);
                throw SQLex;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
