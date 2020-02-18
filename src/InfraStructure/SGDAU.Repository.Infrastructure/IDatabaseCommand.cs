using System.Collections.Generic;
using System.Data.SqlClient;

namespace SGDAU.Repository.Infrastructure
{
    public interface IDatabaseCommand<T> where T : class
    {
        T GetEntity(string procedure, List<SqlParameter> parameters = null);
        ICollection<T> Select(string procedure, List<SqlParameter> parameters = null);
    }
}