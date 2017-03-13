using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Common;

namespace AgeRanger.Interface
{
    public interface ISqlFactory
    {
        DbConnection CreateConnection();

        DbCommand ExecuteCommand(string sqlCommand, DbConnection conn);

       
    }
}
