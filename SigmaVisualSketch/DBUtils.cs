using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaVisualSketch
{
    class DBUtils
    {
        //
        // Data Source=GRECHKAMIKHAIL;Initial Catalog=plr9-10DB;Integrated Security=True
        //
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"GRECHKAMIKHAIL";

            string database = "OrdersDB";
            string username = "Mikhail";
            string password = "1234";

            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }
}
