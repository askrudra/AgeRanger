using AgeRanger.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeRanger.Data
{
    public class AgeRangerDataFactory
    {
        public ISqlFactory GetReposotory()
        {
            ISqlFactory sqlFactory = new SQLiteConnect();
            return sqlFactory;
        }
    }
}
