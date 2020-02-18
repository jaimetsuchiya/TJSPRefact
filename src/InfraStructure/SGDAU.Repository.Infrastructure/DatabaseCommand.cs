using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace SGDAU.Repository.Infrastructure
{
    public class DatabaseCommand<T> : IDatabaseCommand<T> where T : class
    {
        private DatabaseQueryCommand cmd = null;
        public DatabaseCommand(IDbConnection connection)
        {
            cmd = new DatabaseQueryCommand(connection);
        }

        public virtual ICollection<T> Select(string procedure, List<SqlParameter> parameters = null)
        {
            return cmd.Select<T>(procedure, parameters);
        }

        public virtual T GetEntity(string procedure, List<SqlParameter> parameters = null)
        {
            return cmd.GetEntity<T>(procedure, parameters);
        }
    }

    public class DatabaseQueryCommand : IDatabaseQueryCommand
    {
        private SqlConnection connection;

        public DatabaseQueryCommand(IDbConnection connection)
        {
            this.connection = (SqlConnection)connection;
        }

        private SqlConnection GetConnection()
        {
            return connection;
        }

        public virtual ICollection<T> Select<T>(string procedure, List<SqlParameter> parameters = null)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                List<T> list = new List<T>();
                using (cmd)
                {
                    cmd.Connection = GetConnection();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = procedure;
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    cmd.Transaction = cmd.Connection.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);

                    if (parameters != null)
                    {
                        parameters.ForEach(x => cmd.Parameters.Add(x));
                    }

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        list = Helper.DataReaderMapToList<T>(dr);
                    }
                    cmd.Transaction.Commit();
                    cmd.Connection.Close();

                }

                return list;
            }
            catch (Exception ex)
            {
                cmd.Transaction.Rollback();
                cmd.Connection.Close();
                cmd.Dispose();
                throw new Exception(ex.Message);
            }
        }

        [Obsolete]
        public virtual DataSet Select(string procedure, List<SqlParameter> parameters = null)
        {
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            try
            {
                using (cmd)
                {
                    cmd.Connection = GetConnection();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = procedure;
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    cmd.Transaction = cmd.Connection.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);

                    if (parameters != null)
                    {
                        parameters.ForEach(x => cmd.Parameters.Add(x));
                    }
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);

                    cmd.Transaction.Commit();
                    cmd.Connection.Close();
                }
                return ds;
            }
            catch (Exception ex)
            {
                cmd.Transaction.Rollback();
                cmd.Connection.Close();
                cmd.Dispose();
                throw new Exception(ex.Message);
            }
        }

        public virtual T GetEntity<T>(string procedure, List<SqlParameter> parameters = null)
        {

            SqlCommand cmd = new SqlCommand();
            try
            {
                T obj = default(T);
                using (cmd)
                {
                    cmd.Connection = GetConnection();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = procedure;
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    cmd.Transaction = cmd.Connection.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);

                    if (parameters != null)
                    {
                        parameters.ForEach(x => cmd.Parameters.Add(x));
                    }

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        obj = Helper.DataReaderMapToEntity<T>(dr);
                    }
                    cmd.Transaction.Commit();
                    cmd.Connection.Close();

                }

                return obj;
            }
            catch (Exception ex)
            {
                cmd.Transaction.Rollback();
                cmd.Connection.Close();
                cmd.Dispose();
                throw new Exception(ex.Message);
            }
        }
    }
}
