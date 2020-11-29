using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DataModel;

namespace DataAccessTier
{
    public class GiaoDichDAO : DBConnection
    {
        public GiaoDichDAO() : base() { }
        public GiaoDich GetGiaoDichByMaGiaoDich(string MaGD)
        {
            GiaoDich result = new GiaoDich();

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
                    switch (reader.GetInt32(1))
                    {
                        case 1: result = new GiaoDichThu(); break;
                        case 2: result = new GiaoDichChi(); break;
                    }
                    result.UUID = reader.GetString(0);
                    result.DonViGiaoDich = reader.GetString(2);
                    result.GiaTri = reader.GetDouble(3);
                    result.ThoiDiemThucHien = reader.GetDateTime(4);
                    result.MoTa = reader.GetString(5);
                }
                reader.Close();
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
                cmd.Parameters.AddWithValue("@DonViGiaoDich", entry.DonViGiaoDich);
                cmd.Parameters.AddWithValue("@GiaTri", entry.GiaTri);
                cmd.Parameters.AddWithValue("@ThoiDiem", entry.ThoiDiemThucHien);
                cmd.Parameters.AddWithValue("@MoTa", entry.MoTa);

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't add new transaction");
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
            finally
            {
                conn.Close();
            }
        }
    }
}
