using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgeRanger.Test
{
    [TestClass]
    public class SQLiteDbUnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            AgeRanger.Data.SQLiteConnect conn = new Data.SQLiteConnect();
            conn.CreateConnection();
        }
    }
}
