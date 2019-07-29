using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaVisualSketch
{
    class DBSQLServerUtils
    {

        public static SqlConnection
                 GetDBConnection(string datasource, string database, string username, string password)
        {
            //
            // Data Source=GRECHKAMIKHAIL;Initial Catalog=OrdersDB;Integrated Security=True
            //
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }

    }
}
