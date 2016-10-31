using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SRC.Library.Data.SqlDao
{
    public class SqlQuery
    {
        public string Query { get; set; }
        public List<SqlParameter> parameters { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
