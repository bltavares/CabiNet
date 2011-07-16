using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;


namespace CabiNet
{
    abstract public class ICabinet
    {
        protected OdbcConnection connection;
        private IDictionary<string, object> Tables = new Dictionary<string, object>();

        /// <summary>
        /// Create a new manager for the shelfs
        /// </summary>
        /// <param name="ConnectionString">The conection string to the database</param>
        public ICabinet(string ConnectionString)
        {
            connection = new OdbcConnection(ConnectionString);

            if (connection.State == ConnectionState.Closed)
                connection.Open();

        }


        /// <summary>
        /// Run a non query sql on the database
        /// </summary>
        /// <param name="sql">The Query</param>
        public void ExecuteNonQuery(string sql)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                ((OdbcCommand)new OdbcCommand(sql, connection)).ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }

        /// <summary>
        /// Cache a shelf on a variable
        /// </summary>
        /// <typeparam name="I">The type of the shelf</typeparam>
        protected void Shelve<I>() where I : IThing, new()
        {
            Shelf<I> shelf = new Shelf<I>(connection);
            if (!Tables.ContainsKey(shelf.TableName))
                Tables.Add(shelf.TableName, shelf);
        }

        /// <summary>
        /// Cache and return a shelf maneged by this cabinet
        /// </summary>
        /// <typeparam name="T">The type of the desired shelf</typeparam>
        /// <returns>A shelf of the desired type</returns>
        protected Shelf<T> Unshelve<T>() where T : IThing, new()
        {
            string TableName = typeof(T).Name;
            if (!Tables.ContainsKey(TableName))
                Shelve<T>();

            return (Shelf<T>)Tables[TableName];
        }

    }
}
