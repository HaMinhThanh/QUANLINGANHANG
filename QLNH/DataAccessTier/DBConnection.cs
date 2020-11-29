using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataModel;

namespace DataAccessTier
{
    public class DBConnection
    {
        protected static SqlConnection conn;

        public static SqlConnection getConnection()
        {
            if (conn == null)
            {
                try
                {
                    conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\QuanLyNganHang.mdf;Integrated Security=True");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return conn;
        }
    }
}
