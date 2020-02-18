using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace SGDAU.Repository.Infrastructure
{

    public interface IDatabaseCommandCommit
    {
        int Insert(string procedure, List<SqlParameter> parameters);
        int Update(string procedure, List<SqlParameter> parameters);
        int UpdateWithOutTransaction(string procedure, List<SqlParameter> parameters);
        object UpdateScalar(string procedure, List<SqlParameter> parameters);
        T UpdateReader<T>(string procedure, List<SqlParameter> parameters);
        ICollection<T> UpdateReaderList<T>(string procedure, List<SqlParameter> parameters);
        int Delete(string procedure, List<SqlParameter> parameters);
        SqlConnection GetConnection();
        bool Commit();
        bool RollBack();
    }

    public class DatabaseCommandCommit : IDatabaseCommandCommit
    {
        private SqlConnection cn;
        private SqlCommand cmd;
        private SqlTransaction transaction;
        private IConfiguration config;

        public DatabaseCommandCommit(IConfiguration config)
        {
            this.config = config;
            this.cn = new SqlConnection(config.GetSection("ConnectionStrings:REFIConnectionString").Value);            
        }

        public SqlConnection GetConnection()
        {
            return this.cn;
        }

        public int Insert(string procedure, List<SqlParameter> parameters)
        {
            try
            {
                int id = 0;

                if (cmd == null)
                {
                    cmd = new SqlCommand("", cn, transaction);
                }

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = procedure;
                cmd.Parameters.Clear();

                if (cn.State != System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Open();
                    this.transaction = cn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                    cmd.Transaction = transaction;
                    cmd.CommandTimeout = 300;
                }

                if (parameters != null)
                {
                    parameters.ForEach(x => cmd.Parameters.Add(x));
                }

                id = Convert.ToInt32(cmd.ExecuteScalar());

                return id;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
        }

        public int Update(string procedure, List<SqlParameter> parameters)
        {
            try
            {
                int totalRecords = 0;

                if (cmd == null)
                {
                    cmd = new SqlCommand("", cn, transaction);
                }

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = procedure;
                cmd.Parameters.Clear();

                if (cn.State != System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Open();
                    this.transaction = cn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                    cmd.Transaction = transaction;
                    cmd.CommandTimeout = 300;
                }

                if (parameters != null)
                {
                    parameters.ForEach(x => cmd.Parameters.Add(x));
                }

                totalRecords = Convert.ToInt32(cmd.ExecuteNonQuery());

                return totalRecords;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
        }

        public object UpdateScalar(string procedure, List<SqlParameter> parameters)
        {
            try
            {

                if (cmd == null)
                {
                    cmd = new SqlCommand("", cn, transaction);
                }

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = procedure;
                cmd.Parameters.Clear();

                if (cn.State != System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Open();
                    this.transaction = cn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                    cmd.Transaction = transaction;
                    cmd.CommandTimeout = 300;
                }

                if (parameters != null)
                {
                    parameters.ForEach(x => cmd.Parameters.Add(x));
                }

                object result = cmd.ExecuteScalar();

                return result;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
        }

        public T UpdateReader<T>(string procedure, List<SqlParameter> parameters)
        {
            try
            {

                if (cmd == null)
                {
                    cmd = new SqlCommand("", cn, transaction);
                }

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = procedure;
                cmd.Parameters.Clear();

                if (cn.State != System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Open();
                    this.transaction = cn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                    cmd.Transaction = transaction;
                    cmd.CommandTimeout = 300;
                }

                if (parameters != null)
                {
                    parameters.ForEach(x => cmd.Parameters.Add(x));
                }

                T obj = default(T);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    obj = Helper.DataReaderMapToEntityUpdateReader<T>(dr);
                }

                return obj;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
        }

        public ICollection<T> UpdateReaderList<T>(string procedure, List<SqlParameter> parameters)
        {
            try
            {

                if (cmd == null)
                {
                    cmd = new SqlCommand("", cn, transaction);
                }

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = procedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Clear();

                if (cn.State != System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Open();
                    this.transaction = cn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                    cmd.Transaction = transaction;
                }

                if (parameters != null)
                {
                    parameters.ForEach(x => cmd.Parameters.Add(x));
                }

                List<T> list = new List<T>();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    list = Helper.DataReaderMapToListUpdateReader<T>(dr);
                }

                return list;
            }
            catch(SqlException err)
            {
                transaction.Rollback();
                throw;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
        }


        public int Delete(string procedure, List<SqlParameter> parameters)
        {
            try
            {
                int totalRecords = 0;

                if (cmd == null)
                {
                    cmd = new SqlCommand("", cn, transaction);
                }

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = procedure;
                cmd.Parameters.Clear();

                if (cn.State != System.Data.ConnectionState.Open)
                {
                    cmd.Connection.Open();
                    this.transaction = cn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                    cmd.Transaction = transaction;
                    cmd.CommandTimeout = 300;
                }

                if (parameters != null)
                {
                    parameters.ForEach(x => cmd.Parameters.Add(x));
                }

                totalRecords = Convert.ToInt32(cmd.ExecuteScalar());

                return totalRecords;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
        }

        public bool Commit()
        {
            try
            {
                transaction.Commit();
                cn.Close();
                cmd.Dispose();
                cn.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
        }

        public bool RollBack()
        {
            try
            {
                if (transaction != null)
                {
                    if (transaction.Connection != null)
                    {
                        transaction.Rollback();
                    }
                }

                if (cmd != null)
                {
                    cmd.Connection.Close();
                    cmd.Dispose();
                }

                if (cn != null)
                {
                    cn.Close();
                    cn.Dispose();
                }

                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
        }


        public int UpdateWithOutTransaction(string procedure, List<SqlParameter> parameters)
        {
            int totalRecords = 0;

            using (SqlCommand cmdWithOutTransaction = new SqlCommand("", new SqlConnection(config.GetSection("ConnectionStrings:REFIConnectionString").Value)))
            {


                cmdWithOutTransaction.CommandType = System.Data.CommandType.StoredProcedure;
                cmdWithOutTransaction.CommandText = procedure;
                cmdWithOutTransaction.Parameters.Clear();

                cmdWithOutTransaction.Connection.Open();
                cmdWithOutTransaction.CommandTimeout = 300;

                if (parameters != null)
                {
                    parameters.ForEach(x => cmdWithOutTransaction.Parameters.Add(x));
                }

                totalRecords = Convert.ToInt32(cmdWithOutTransaction.ExecuteNonQuery());
            }

            return totalRecords;
         
        }
    }
}

