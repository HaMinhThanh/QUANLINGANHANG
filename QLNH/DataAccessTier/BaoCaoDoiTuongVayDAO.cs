using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DataModel;

namespace DataAccessTier
{
    public class BaoCaoDoiTuongVayDAO
    {
        public bool AddBaoCaoDoiTuongVay(BaoCaoTaiChinh entry)
        {
            SqlConnection conn = DBConnection.getConnection();
            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            if (entry.MaBaoCao.Equals("")) entry.MaBaoCao = Guid.NewGuid().ToString();
            SqlCommand cmd = new SqlCommand("INSERT INTO tbBaoCaoDoiTuongVay VALUES (@MaBaoCao, @MaKHBaoCao, @NgayBaoCao, @SuDungVon, @TSTCDamBao, @DanhGia)", conn);
            try
            {
                cmd.Parameters.AddWithValue("@MaBaoCao", entry.MaBaoCao);
                cmd.Parameters.AddWithValue("@MaKHBaoCao", entry.DoiTuongBaoCao.DinhDanhKH);
                cmd.Parameters.AddWithValue("@NgayBaoCao", DateTime.Now);
                cmd.Parameters.AddWithValue("@SuDungVon", entry.suDungVonDungMucDich);
                cmd.Parameters.AddWithValue("@TSTCDamBao", entry.trangThaiTaiSanDamBao);
                cmd.Parameters.AddWithValue("@DanhGia", entry.DanhGia);

                int res = cmd.ExecuteNonQuery();
                if (res != 1) throw new Exception("Can't add new customer report");
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
