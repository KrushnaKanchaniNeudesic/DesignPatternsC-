using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Builder
{
     public class FluentbuilderSqlParameter
    {
        public ICollection<SqlParameter> parameters;
        public FluentbuilderSqlParameter(ICollection<SqlParameter> sqlParameters)
        {
            this.parameters = sqlParameters;
        }

        public FluentbuilderSqlParameter Add(string name, object value)
        {
            parameters.Add(new SqlParameter(name, value));
            return this;
        }
    }
}
