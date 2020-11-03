using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessTier
{
    public class DBConnection
    {
        protected SqlConnection conn;
        public DBConnection()
        {
            try
            {
                conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\QuanLyNganHang.mdf;Integrated Security=True");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
