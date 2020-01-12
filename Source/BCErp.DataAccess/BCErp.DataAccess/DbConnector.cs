using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace BCErp.DataAccess
{
   public class DbConnector
    {
        private static SqlConnection con = null;
        public static SqlConnection Connect()
        {
            string connectionString= @"Data Source=AAM;Initial Catalog=BCErpDb;User ID=sa; Password=sa";

            if (con == null)
            {
                con = new SqlConnection(connectionString);

            }
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            return con;
        }
    }
}
