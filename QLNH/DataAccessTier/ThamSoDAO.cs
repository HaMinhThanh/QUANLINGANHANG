using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DataAccessTier
{
    public class ThamSoDAO
    {
        public ThamSo GetLatestThamSo()
        {
            SqlConnection conn = DBConnection.getConnection();
            ThamSo result = new ThamSo();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM tbThamSo ORDER BY ThoiGianApDung DESC", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result.ThoiGianApDung = reader.GetDateTime(0);
                    result.VonVayCaNhanToiDa = (Double) reader.GetDecimal(1);
                    result.VonVayToChucToiDa = (Double) reader.GetDecimal(2);
                    result.YeuCauGiayToXacThuc = reader.GetBoolean(3);
                    result.TuoiDuocVayToiThieu = reader.GetInt32(4);
                    result.KyHanToiDa = reader.GetInt32(5);
                    result.KyHanToiThieu = reader.GetInt32(6);
                    result.DinhGiaToiThieu = (Double) reader.GetDecimal(7);
                    result.LaiSuatToiThieu = (Double) reader.GetDecimal(8);
                    result.LaiSuatToiDa = (Double)reader.GetDecimal(9);
                    result.ThoiGianThongBaoTraNo = (Int32) reader.GetDecimal(10);
                }
                reader.Close();
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
        public bool AddThamSo(ThamSo entry)
        {
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tbThamSo VALUES " +
                    "(@ThoiGianApDung, @VonVayCaNhanToiDa, @VonVayToChucToiDa, @YeuCauGiayToXacThuc, @TuoiDuocVayToiThieu, @KyHanToiDa, @KyHanToiThieu, @DinhGiaToiThieu, @LaiSuatToiThieu, @LaiSuatToiDa, @ThoiGianThongBaoTraNo)", 
                    conn);
                cmd.Parameters.AddWithValue("@ThoiGianApDung", entry.ThoiGianApDung);
                cmd.Parameters.AddWithValue("@VonVayCaNhanToiDa", entry.VonVayCaNhanToiDa);
                cmd.Parameters.AddWithValue("@VonVayToChucToiDa", entry.VonVayToChucToiDa);
                cmd.Parameters.AddWithValue("@YeuCauGiayToXacThuc", entry.YeuCauGiayToXacThuc);
                cmd.Parameters.AddWithValue("@TuoiDuocVayToiThieu", entry.TuoiDuocVayToiThieu);
                cmd.Parameters.AddWithValue("@KyHanToiDa", entry.KyHanToiDa);
                cmd.Parameters.AddWithValue("@KyHanToiThieu", entry.KyHanToiThieu);
                cmd.Parameters.AddWithValue("@DinhGiaToiThieu", entry.DinhGiaToiThieu);
                cmd.Parameters.AddWithValue("@LaiSuatToiDa", entry.LaiSuatToiDa);
                cmd.Parameters.AddWithValue("@LaiSuatToiThieu", entry.LaiSuatToiThieu);
                cmd.Parameters.AddWithValue("@ThoiGianThongBaoTraNo", entry.ThoiGianThongBaoTraNo);

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
