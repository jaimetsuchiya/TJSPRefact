using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SGDAU.Repository.Infrastructure
{
    public interface IDatabaseQueryCommand
    {
        T GetEntity<T>(string procedure, List<SqlParameter> parameters = null);
        DataSet Select(string procedure, List<SqlParameter> parameters = null);
        ICollection<T> Select<T>(string procedure, List<SqlParameter> parameters = null);
    }
}