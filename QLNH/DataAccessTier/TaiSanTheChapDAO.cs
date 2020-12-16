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
    public class TaiSanTheChapDAO
    {
        public TaiSanTheChapDAO() { }

        public TaiSanTheChap GetTaiSanTheChapByMaTSTC(string MaTaiSan)
        {
            TaiSanTheChap result = new TaiSanTheChap();
            string matrangthai = "";
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * from tbTaiSanTheChap WHERE MaTaiSan = @MaTaiSan ", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MaTaiSan", MaTaiSan);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result.MaTSTC = reader.GetString(0);
                    result.MoTa = reader.GetString(2);
                    if (reader[3] == DBNull.Value)
                        result.DinhGia = 0;
                    else
                        result.DinhGia = (Double) reader.GetDecimal(3);
                    matrangthai = reader.GetString(4);
                }
                reader.Close();

                TrangThaiTaiSanDAO tempAccessObj = new TrangThaiTaiSanDAO();
                if (!matrangthai.Equals(""))
                {
                    result.TrangThai = tempAccessObj.GetTrangThaiByMaTrangThai(matrangthai);
                }
                GiayToChungThucDAO tempAccessObj2 = new GiayToChungThucDAO();
                result.DSMaGiayToChungThuc = tempAccessObj2.GetMaGiayChungThucByMaTaiSan(MaTaiSan);
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


        public List<TaiSanTheChap> GetTaiSanTheChapByMaYeuCauChoVay(String MaYC)
        {
            List<TaiSanTheChap> results = new List<TaiSanTheChap>();
            List<string> DSMaTrangThai = new List<string>();
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbTaiSanTheChap WHERE MaYeuCau = @MaYeuCauChoVay", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MaYeuCauChoVay", MaYC);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TaiSanTheChap taiSanTheChap = new TaiSanTheChap();
                    string matrangthai = "";
                    taiSanTheChap.MaTSTC = reader.GetString(0);
                    taiSanTheChap.MoTa = reader.GetString(2);
                    if (reader[3] == DBNull.Value)
                        taiSanTheChap.DinhGia = 0;
                    else
                        taiSanTheChap.DinhGia = (Double) reader.GetDecimal(3);
                    matrangthai = reader.GetString(4);

                    results.Add(taiSanTheChap);
                    DSMaTrangThai.Add(matrangthai);
                }
                reader.Close();
                TrangThaiTaiSanDAO tempAccessObj = new TrangThaiTaiSanDAO();
                GiayToChungThucDAO tempAccessObj2 = new GiayToChungThucDAO();
                for (int i = 0; i < results.Count; i++)
                {
                    results[i].DSMaGiayToChungThuc = tempAccessObj2.GetMaGiayChungThucByMaTaiSan(results[i].MaTSTC);
                }
                for (int i = 0; i < DSMaTrangThai.Count; i++)
                {
                    results[i].TrangThai = tempAccessObj.GetTrangThaiByMaTrangThai(DSMaTrangThai[i]);
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
            return results;

        }

        public bool AddTaiSanTheChap(TaiSanTheChap entry, string MaYeuCau = null)
        {
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            if (entry.MaTSTC.Equals("")) entry.MaTSTC = Guid.NewGuid().ToString();
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tbTaiSanTheChap VALUES (@MaTaiSan, @MaYeuCau, @MoTa, @DinhGia, @MaTrangThai)", conn);
                cmd.Parameters.AddWithValue("@MaTaiSan", entry.MaTSTC);
                cmd.Parameters.AddWithValue("@MaYeuCau", MaYeuCau);
                cmd.Parameters.AddWithValue("@MoTa", entry.MoTa);
                if (entry.DinhGia == -1)
                    cmd.Parameters.AddWithValue("@DinhGia", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@DinhGia", entry.DinhGia);
                cmd.Parameters.AddWithValue("@MaTrangThai", entry.TrangThai.UUID);

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't add new TaiSanTheChap");

                GiayToChungThucDAO tempDataObj = new GiayToChungThucDAO();
                foreach (string val in entry.DSMaGiayToChungThuc)
                {
                    tempDataObj.AddMaGiayChungThuc(entry.MaTSTC, val);
                }

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

        public bool UpdateTaiSanTheChap(TaiSanTheChap entry)
        {
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            if (entry.MaTSTC.Equals("")) entry.MaTSTC = Guid.NewGuid().ToString();
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE tbTaiSanTheChap SET MoTa = @MoTa, DinhGia = @DinhGia, MaTrangThai = @MaTrangThai WHERE MaTaiSan = @MaTaiSan", conn);
                cmd.Parameters.AddWithValue("@MaTaiSan", entry.MaTSTC);
                cmd.Parameters.AddWithValue("@MoTa", entry.MoTa);
                if (entry.DinhGia == -1)
                    cmd.Parameters.AddWithValue("@DinhGia", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@DinhGia", entry.DinhGia);
                cmd.Parameters.AddWithValue("@MaTrangThai", entry.TrangThai.UUID);

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't update TaiSanTheChap");

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
