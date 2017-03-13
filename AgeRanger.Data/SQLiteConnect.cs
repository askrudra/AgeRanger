using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Data.SqlClient;
using AgeRanger.Interface;
using System.Data.Common;

namespace AgeRanger.Data
{
    public class SQLiteConnect:ISqlFactory
    {
        public DbConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn = null;
            try
            {
                sqlite_conn = new SQLiteConnection("Data Source=C:\\Users\\Rudy\\Documents\\Visual Studio 2015\\Projects\\AgeRanger\\AgeRanger.Data\\DbFile\\AgeRanger.db;Version=3;Compress=True;");
               
            }
            catch (SqlException ex)
            {
                string MessageException = ex.Message;
                
            }
            
            return sqlite_conn;
        }

        public DbCommand ExecuteCommand(string sqlCommand, DbConnection conn)
        {
            SQLiteCommand sql_cmd = new SQLiteCommand();
            try
            {
                if (!string.IsNullOrEmpty(sqlCommand))
                {
                    sql_cmd =(SQLiteCommand) conn.CreateCommand();
                    
                    sql_cmd.CommandText = sqlCommand;
                }
                
            }
            catch (SqlException ex)
            {

                throw;
            }
            return sql_cmd;
        }
    }

   
}
