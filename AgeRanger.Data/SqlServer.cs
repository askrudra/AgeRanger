using AgeRanger.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;

namespace AgeRanger.Data
{
    public class SqlServer : ISqlFactory
    {
        public DbConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection();
            throw new NotImplementedException();
        }

        public DbCommand ExecuteCommand(string sqlCommand, DbConnection conn)
        {
            throw new NotImplementedException();
        }
    }
}
