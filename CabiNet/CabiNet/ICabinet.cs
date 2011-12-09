using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;


namespace CabiNet
{
    /// <summary>
    /// The cabinet, where the Thing are stored
    /// </summary>
    abstract public class ICabinet
    {
        protected OdbcConnection Connection;
        private readonly IDictionary<string, object> _tables = new Dictionary<string, object>();

        /// <summary>
        /// Create a new manager for the shelfs
        /// </summary>
        /// <param name="connectionString">The conection string to the database</param>
        protected ICabinet(string connectionString)
        {
            Connection = new OdbcConnection(connectionString);

            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

        }


        /// <summary>
        /// Run a non query sql on the database
        /// </summary>
        /// <param name="sql">The Query</param>
        public void ExecuteNonQuery(string sql)
        {
            try
            {
                if (Connection.State == ConnectionState.Closed)
                    Connection.Open();
                new OdbcCommand(sql, Connection).ExecuteNonQuery();
            }
            finally
            {
                if (Connection.State != ConnectionState.Closed)
                    Connection.Close();
            }
        }

        /// <summary>
        /// Cache a shelf on a variable
        /// </summary>
        /// <typeparam name="T">The type of the shelf</typeparam>
        protected void Shelve<T>() where T : IThing, new()
        {
            Shelf<T> shelf = new Shelf<T>(Connection);
            if (!_tables.ContainsKey(shelf.TableName))
                _tables.Add(shelf.TableName, shelf);
        }

        /// <summary>
        /// Cache and return a shelf maneged by this cabinet
        /// </summary>
        /// <typeparam name="T">The type of the desired shelf</typeparam>
        /// <returns>A shelf of the desired type</returns>
        protected Shelf<T> Unshelve<T>() where T : IThing, new()
        {
            string tableName = typeof(T).Name;
            if (!_tables.ContainsKey(tableName))
                Shelve<T>();

            return (Shelf<T>)_tables[tableName];
        }

    }
}
