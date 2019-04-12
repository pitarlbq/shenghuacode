﻿
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Foresight.DataAccess.Framework
{
    /// <summary>
    /// Summary description for SqlHelper
    /// </summary>
    public partial class SqlHelperBase : IDisposable
    {
        public static string ConnectionString = string.Empty;

        protected SqlConnection _cnnSql;
        protected SqlTransaction _trnSql;
        protected SqlCommand _cmdSql;
        protected SqlDataAdapter _daSql;

        /// <summary>
        /// Default constructor.  Initialize connection using connection string from the config file.
        /// </summary>
        public SqlHelperBase()
        {
            _cnnSql = new SqlConnection(ConnectionString != string.Empty ? ConnectionString : ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
        }

        /// <summary>
        /// Initialize connection using the supplied connection string.
        /// </summary>
        /// <param name="ConnectionString"></param>
        public SqlHelperBase(string connectionString)
        {
            _cnnSql = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Begin a database transaction.
        /// </summary>
        public void BeginTransaction()
        {
            if (_cnnSql.State != ConnectionState.Open) _cnnSql.Open();
            _trnSql = _cnnSql.BeginTransaction();
        }

        /// <summary>
        /// Close the database connection and free the resources.
        /// </summary>
        public void Close()
        {
            if (_cnnSql.State != ConnectionState.Closed) _cnnSql.Close();
            _cnnSql.Dispose();
        }

        /// <summary>
        /// Commit the database transaction.
        /// </summary>
        public void Commit()
        {
            if (_trnSql == null) throw new ApplicationException("Transaction is not initialized.");
            else _trnSql.Commit();
        }

        /// <summary>
        /// Rollback the database transaction.
        /// </summary>
        public void Rollback()
        {
            if (_trnSql == null) throw new ApplicationException("Transaction is not initialized.");
            else _trnSql.Rollback();
        }

        /// <summary>
        /// Execute a Sql command that does not return a resultset.
        /// </summary>
        /// <param name="Command">The Sql command</param>
        /// <param name="CommandType">The type of command (text, stored procedure, etc.)</param>
        /// <param name="ParameterList">A list of SqlParameters</param>
        /// <returns>Rows affected</returns>
        public int Execute(string command, CommandType commandType, System.Collections.Generic.List<SqlParameter> parameterList)
        {
            return Execute(command, commandType, parameterList, 300);
        }

        /// <summary>
        /// Execute a Sql command that does not return a resultset.
        /// </summary>
        /// <param name="command">The Sql command</param>
        /// <param name="commandType">The type of command (text, stored procedure, etc.)</param>
        /// <param name="parameterList">A list of SqlParameters</param>
        /// <param name="timeout">The command timeout value</param>
        /// <returns>Rows affected</returns>
        public int Execute(string command, CommandType commandType, System.Collections.Generic.List<SqlParameter> parameterList, int timeout)
        {
            int result;

            BuildCommand(command, commandType, parameterList);
            _cmdSql.CommandTimeout = timeout;

            if (_cnnSql.State != ConnectionState.Open) _cnnSql.Open();
            OnExecuting();
            result = _cmdSql.ExecuteNonQuery();

            _cmdSql.Parameters.Clear();
            _cmdSql = null;

            OnExecuted();
            return result;
        }

        /// <summary>
        /// Execute a Sql command and return the results in a dataset.
        /// </summary>
        /// <param name="command">The Sql command</param>
        /// <param name="commandType">The type of the Sql command (text, stored procedure, etc.)</param>
        /// <param name="parameterList">A list of SqlParameters</param>
        /// <returns>Results of the Sql command in a dataset</returns>
        public DataSet ExecuteDataSet(string command, CommandType commandType, System.Collections.Generic.List<SqlParameter> parameterList)
        {
            return ExecuteDataSet(command, commandType, parameterList, 300);
        }

        /// <summary>
        /// Execute a Sql command and return the results in a dataset.
        /// </summary>
        /// <param name="command">The Sql command</param>
        /// <param name="commandType">The type of the Sql command (text, stored procedure, etc.)</param>
        /// <param name="parameterList">A list of SqlParameters</param>
        /// <param name="timeout">The command timeout value</param>
        /// <returns>Results of the Sql command in a dataset</returns>
        public DataSet ExecuteDataSet(string command, CommandType commandType, System.Collections.Generic.List<SqlParameter> parameterList, int timeout)
        {
            DataSet ds = new DataSet();

            BuildCommand(command, commandType, parameterList);
            _cmdSql.CommandTimeout = timeout;

            _daSql = new SqlDataAdapter();
            _daSql.SelectCommand = _cmdSql;

            if (_cnnSql.State != ConnectionState.Open) _cnnSql.Open();
            OnExecuting();
            _daSql.Fill(ds);

            _cmdSql.Parameters.Clear();
            _cmdSql = null;

            OnExecuted();
            return ds;
        }

        /// <summary>
        /// Execute a Sql command and return the results in a dataset.
        /// </summary>
        /// <param name="command">The Sql command</param>
        /// <param name="commandType">The type of the Sql command (text, stored procedure, etc.)</param>
        /// <param name="parameterList">A list of SqlParameters</param>
        /// <returns>Results of the Sql command in a datatable</returns>
        public DataTable ExecuteDataTable(string command, CommandType commandType, System.Collections.Generic.List<SqlParameter> parameterList)
        {
            return ExecuteDataTable(command, commandType, parameterList, 300);
        }

        /// <summary>
        /// Execute a Sql command and return the results in a dataset.
        /// </summary>
        /// <param name="command">The Sql command</param>
        /// <param name="commandType">The type of the Sql command (text, stored procedure, etc.)</param>
        /// <param name="parameterList">A list of SqlParameters</param>
        /// <param name="timeout">The command timeout value</param>
        /// <returns>Results of the Sql command in a datatable</returns>
        public DataTable ExecuteDataTable(string command, CommandType commandType, System.Collections.Generic.List<SqlParameter> parameterList, int timeout)
        {
            DataTable dt = new DataTable();

            BuildCommand(command, commandType, parameterList);
            _cmdSql.CommandTimeout = timeout;

            _daSql = new SqlDataAdapter();
            _daSql.SelectCommand = _cmdSql;

            if (_cnnSql.State != ConnectionState.Open) _cnnSql.Open();
            OnExecuting();
            _daSql.Fill(dt);

            _cmdSql.Parameters.Clear();
            _cmdSql = null;

            OnExecuted();
            return dt;
        }

        /// <summary>
        /// Execute a Sql command and return the results in a datareader.
        /// </summary>
        /// <param name="command">The Sql command</param>
        /// <param name="commandType">The type of the Sql command (text, stored procedure, etc.)</param>
        /// <param name="parameterList">A list of SqlParameters</param>
        /// <returns>Results of a Sql command in a datareader</returns>
        public SqlDataReader ExecuteDataReader(string command, CommandType commandType, System.Collections.Generic.List<SqlParameter> parameterList)
        {
            return ExecuteDataReader(command, commandType, parameterList, CommandBehavior.Default, 300);
        }

        /// <summary>
        /// Execute a Sql command and return the results in a datareader.
        /// </summary>
        /// <param name="command">The Sql command</param>
        /// <param name="commandType">The type of the Sql command (text, stored procedure, etc.)</param>
        /// <param name="parameterList">A list of SqlParameters</param>
        /// <param name="behavior">The command behavior value</param>
        /// <returns>Results of a Sql command in a datareader</returns>
        public SqlDataReader ExecuteDataReader(string command, CommandType commandType, System.Collections.Generic.List<SqlParameter> parameterList, CommandBehavior behavior)
        {
            return ExecuteDataReader(command, commandType, parameterList, behavior, 300);
        }

        /// <summary>
        /// Execute a Sql command and return the results in a datareader.
        /// </summary>
        /// <param name="command">The Sql command</param>
        /// <param name="commandType">The type of the Sql command (text, stored procedure, etc.)</param>
        /// <param name="parameterList">A list of SqlParameters</param>
        /// <param name="timeout">The command timeout value</param>
        /// <returns>Results of a Sql command in a datareader</returns>
        public SqlDataReader ExecuteDataReader(string command, CommandType commandType, System.Collections.Generic.List<SqlParameter> parameterList, int timeout)
        {
            return ExecuteDataReader(command, commandType, parameterList, CommandBehavior.Default, timeout);
        }

        /// <summary>
        /// Execute a Sql command and return the results in a datareader.
        /// </summary>
        /// <param name="command">The Sql command</param>
        /// <param name="commandType">The type of the Sql command (text, stored procedure, etc.)</param>
        /// <param name="parameterList">A list of SqlParameters</param>
        /// <param name="behavior">The command behavior value</param>
        /// <param name="timeout">The command timeout value</param>
        /// <returns>Results of a Sql command in a datareader</returns>
        public SqlDataReader ExecuteDataReader(string command, CommandType commandType, System.Collections.Generic.List<SqlParameter> parameterList, CommandBehavior behavior, int timeout)
        {
            SqlDataReader dr;

            BuildCommand(command, commandType, parameterList);
            _cmdSql.CommandTimeout = timeout;

            if (_cnnSql.State != ConnectionState.Open) _cnnSql.Open();
            OnExecuting();
            dr = _cmdSql.ExecuteReader(behavior);

            _cmdSql.Parameters.Clear();
            _cmdSql = null;

            OnExecuted();
            return dr;
        }

        /// <summary>
        /// Execute a Sql command that returns a one row, one column result.
        /// </summary>
        /// <param name="command">The Sql command</param>
        /// <param name="commandType">The type of the Sql command (text, stored procedure, etc.)</param>
        /// <param name="parameterList">A list of SqlParameters</param>
        /// <returns>Result of the Sql command</returns>
        public Object ExecuteScalar(string command, CommandType commandType, System.Collections.Generic.List<SqlParameter> parameterList)
        {
            return ExecuteScalar(command, commandType, parameterList, 300);
        }

        /// <summary>
        /// Execute a Sql command that returns a one row, one column result.
        /// </summary>
        /// <param name="command">The Sql command</param>
        /// <param name="commandType">The type of the Sql command (text, stored procedure, etc.)</param>
        /// <param name="parameterList">A list of SqlParameters</param>
        /// <param name="timeout">The command timeout value</param>
        /// <returns>Result of the Sql command</returns>
        public Object ExecuteScalar(string command, CommandType commandType, System.Collections.Generic.List<SqlParameter> parameterList, int timeout)
        {
            Object result;

            BuildCommand(command, commandType, parameterList);
            _cmdSql.CommandTimeout = timeout;

            if (_cnnSql.State != ConnectionState.Open) _cnnSql.Open();
            OnExecuting();
            result = _cmdSql.ExecuteScalar();

            _cmdSql.Parameters.Clear();
            _cmdSql = null;

            OnExecuted();
            return result;
        }

        /// <summary>
        /// Execute a Sql command and return the results in an XML reader.
        /// </summary>
        /// <param name="command">The Sql command</param>
        /// <param name="commandType">The type of the Sql command (text, stored procedure, etc.)</param>
        /// <param name="parameterList">A list of SqlParameters</param>
        /// <returns>Results of a Sql command in an XML reader</returns>
        public System.Xml.XmlReader ExecuteXmlReader(string command, CommandType commandType, System.Collections.Generic.List<SqlParameter> parameterList)
        {
            return ExecuteXmlReader(command, commandType, parameterList, 300);
        }

        /// <summary>
        /// Execute a Sql command and return the results in an XML reader.
        /// </summary>
        /// <param name="command">The Sql command</param>
        /// <param name="commandType">The type of the Sql command (text, stored procedure, etc.)</param>
        /// <param name="parameterList">A list of SqlParameters</param>
        /// <param name="timeout">The command timeout value</param>
        /// <returns>Results of a Sql command in an XML reader</returns>
        public System.Xml.XmlReader ExecuteXmlReader(string command, CommandType commandType, System.Collections.Generic.List<SqlParameter> parameterList, int timeout)
        {
            System.Xml.XmlReader xr;

            BuildCommand(command, commandType, parameterList);
            _cmdSql.CommandTimeout = timeout;

            if (_cnnSql.State != ConnectionState.Open) _cnnSql.Open();
            OnExecuting();
            xr = _cmdSql.ExecuteXmlReader();

            _cmdSql.Parameters.Clear();
            _cmdSql = null;

            OnExecuted();
            return xr;
        }

        /// <summary>
        /// Construct a Sql Command object.
        /// </summary>
        /// <param name="command">The Sql command to be executed</param>
        /// <param name="commandType">The type of the Sql command (text, stored procedure, etc.)</param>
        /// <param name="parameterList">A list of SqlParameters</param>
        private void BuildCommand(string command, CommandType commandType, System.Collections.Generic.List<SqlParameter> parameterList)
        {
            _cmdSql = new SqlCommand();
            _cmdSql.Connection = _cnnSql;
            _cmdSql.CommandText = command;
            _cmdSql.CommandType = commandType;

            foreach (SqlParameter p in parameterList)
            {
                _cmdSql.Parameters.Add(p);
            }

            if (_trnSql != null) _cmdSql.Transaction = _trnSql;
        }

        #region IDisposable Members
        /// <summary>
        /// Disposes the SqlHelper object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the SqlHelper object
        /// </summary>
        /// <param name="disposing">Determines if the object is currently disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_cnnSql.State != ConnectionState.Closed)
            {
                _cnnSql.Close();
                _cnnSql.Dispose();
            }

            if (_trnSql != null)
            {
                _trnSql.Dispose();
            }

            if (_cmdSql != null)
            {
                _cmdSql.Dispose();
            }

            if (_daSql != null)
            {
                _daSql.Dispose();
            }
        }
        #endregion

        protected event EventHandler Executing;
        protected virtual void OnExecuting()
        {
            if (Executing != null)
            {
                Executing(this, EventArgs.Empty);
            }
        }

        protected event EventHandler Executed;
        protected virtual void OnExecuted()
        {
            if (Executed != null)
            {
                Executed(this, EventArgs.Empty);
            }
        }

    }
}