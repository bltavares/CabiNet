using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Reflection;

namespace CabiNet
{
    /// <summary>
    /// Wrapper for managing the data on the database
    /// </summary>
    /// <typeparam name="T">The IThing class to be managed</typeparam>
    public class Shelf<T> where T : IThing, new()
    {
        /// <summary>
        /// The name of the table of this shelf
        /// </summary>
        public string TableName { get; private set; }
        protected OdbcConnection Connection;
        protected MysqlBuilder.MysqlCommandBuilder MySqlBuilder;

        /// <summary>
        /// Initialize with conection
        /// </summary>
        /// <param name="con">the ODBC connection</param>
        public Shelf(OdbcConnection con)
        {
            TableName = typeof(T).Name;
            Connection = con;
            MySqlBuilder = new MysqlBuilder.MysqlCommandBuilder(TableName);
        }

        /// <summary>
        /// Get all the registers ont the database
        /// </summary>
        /// <returns>Array of the shelved things</returns>
        virtual public T[] All()
        {
            return EnumerableFor(MySqlBuilder.BuildSelectAll()).ToArray();
        }

        /// <summary>
        /// Insert a the shelved thing on the database
        /// </summary>
        /// <param name="thing">The new thing to be inserted</param>
        /// <returns>The same thing updated</returns>
        /// <exception cref="AlreadySavedException">If the thing already have an id</exception>
        public T Insert(T thing)
        {
            if (thing.Id != 0)
                throw new AlreadySavedException(TableName);

            return Insert(new[] { thing }, true).First();
        }

        /// <summary>
        /// Insert a the shelved thing on the database
        /// </summary>
        /// <param name="things">The new thing's list to be inserted</param>
        /// <param name="safe">Only insert the not saved things</param>
        /// <returns>The same thing updated</returns>
        /// <exception cref="AlreadySavedException">If the thing already have an id</exception>
        public IEnumerable<T> Insert(IEnumerable<T> things, bool safe)
        {
            T[] allThings;
            if (safe)
            {
                allThings = things.Where(thing => thing.Id != 0).ToArray();

            }
            else
            {
                allThings = things.ToArray();
                if (allThings.Any(thing => thing.Id != 0))
                    throw new AlreadySavedException(TableName);
            }
            try
            {

                PrepareConnection();
                foreach (T thing in allThings)
                {
                    thing.Validate();
                    AttributesExtractor<T> properties = new AttributesExtractor<T>(thing);
                    string query = MySqlBuilder.BuildInsert(properties.PersistentAttributes());
                    OdbcCommand command = new OdbcCommand(query, Connection);
                    command.ExecuteNonQuery();
                    command.CommandText = MySqlBuilder.BuildLastId();
                    Int64 lastId = (Int64)command.ExecuteScalar();
                    thing.Id = lastId;
                    thing.SetConnection(Connection);
                }
            }
            finally
            {
                CloseConnection();
            }
            return allThings;
        }

        /// <summary>
        /// Update a thing on the database
        /// </summary>
        /// <typeparam name="TItem">The current shelf type</typeparam>
        /// <param name="thing">The thing to be inserted</param>
        /// <exception cref="MissingThing">If there the thing to be inserted has no Id</exception>
        public void Update<TItem>(TItem thing) where TItem : T
        {
            if (thing.Id == 0)
                throw new MissingThing(TableName);

            Update(new[] { thing }, true);
        }

        /// <summary>
        /// Update a thing on the database
        /// </summary>
        /// <typeparam name="TItem">The current shelf type</typeparam>
        /// <param name="things">The things list to be inserted</param>
        /// <param name="safe">Update only already saved things</param>
        /// <exception cref="MissingThing">If there the thing to be inserted has no Id</exception>
        public void Update<TItem>(IEnumerable<TItem> things, bool safe) where TItem : T
        {
            T[] allThings;
            if (safe)
            {
                allThings = things.Where(thing => thing.Id != 0).ToArray();
            }
            else
            {
                allThings = things.ToArray();
                if (allThings.Any(thing => thing.Id == 0))
                    throw new MissingThing(TableName);
            }

            try
            {
                PrepareConnection();
                foreach (TItem thing in allThings)
                {
                    thing.Validate();
                    AttributesExtractor<T> properties = new AttributesExtractor<T>(thing);
                    string query = MySqlBuilder.BuildUpdate(properties.PersistentAttributes(), thing);
                    OdbcCommand command = new OdbcCommand(query, Connection);
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Gets a thing from the shelve
        /// </summary>
        /// <param name="id">The id of the thing</param>
        /// <returns>The thing or null</returns>
        public T FindById(Int64 id)
        {
            return EnumerableFor(MySqlBuilder.BuildFindBy(id)).FirstOrDefault();
        }


        /// <summary>
        /// Filters the query using the = comparison on mysql
        /// </summary>
        /// <param name="collumn">the column to be checked</param>
        /// <param name="value">The value to be used on the comparison</param>
        /// <returns>Array of Things</returns>
        public T[] Where(string collumn, object value)
        {
            return Where(collumn, WhereConditions.Equal, value, false);
        }
        /// <summary>
        /// Filters the query using the defined comparison on mysql
        /// </summary>
        /// <param name="collumn">the column to be checked</param>
        /// <param name="condition">The type onf comparison</param>
        /// <param name="value">The value to be used on the comparison</param>
        /// <returns>Array of Things</returns>
        public T[] Where(string collumn, WhereConditions condition, object value)
        {
            return Where(collumn, condition, value, false);
        }
        /// <summary>
        /// Filters the query using the defined comparison on mysql, defining to skip the injection filter
        /// You can compare columns that way
        /// </summary>
        /// <param name="collumn">the column to be checked</param>
        /// <param name="condition">The type onf comparison</param>
        /// <param name="value">The name of the column to be used</param>
        /// <param name="comparingCollumns">True skip the injection filter</param>
        /// <returns></returns>
        public T[] Where(string collumn, WhereConditions condition, object value, bool comparingCollumns)
        {
            return EnumerableFor(MySqlBuilder.BuildWhere(collumn, condition, value, comparingCollumns)).ToArray();
        }

        /// <summary>
        /// Delete the thing from the database
        /// </summary>
        /// <typeparam name="TItem">The current shelf type</typeparam>
        /// <param name="thing">The thing to be deleted</param>
        /// <exception cref="MissingThing">If the id of the thing is 0</exception>
        public void Delete<TItem>(TItem thing) where TItem : T
        {
            if (thing.Id == 0)
                throw new MissingThing(TableName);
            Delete<TItem>(new[] { thing });
        }

        /// <summary>
        /// Delete the thing from the database
        /// </summary>
        /// <typeparam name="TItem">The current shelf type</typeparam>
        /// <param name="things">The thing's list to be deleted</param>
        /// <param name="safe">Delete only the already saved things</param>
        /// <exception cref="MissingThing">If the any id of the thing is 0</exception>
        public void Delete<TItem>(IEnumerable<TItem> things, bool safe = true) where TItem : T
        {
            T[] allThings;
            if (safe)
            {
                allThings = things.Where(thing => thing.Id != 0).ToArray();
            }
            else
            {
                allThings = things.ToArray();
                if (allThings.Any(thing => thing.Id == 0))
                    throw new MissingThing(TableName);
            }

            try
            {
                PrepareConnection();
                foreach (TItem thing in allThings)
                {
                    string query = MySqlBuilder.BuildDelete(thing);
                    OdbcCommand command = new OdbcCommand(query, Connection);
                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Count the size of the shelf
        /// </summary>
        /// <returns>The size</returns>
        public long Count()
        {
            try
            {
                PrepareConnection();
                OdbcCommand command = new OdbcCommand(MySqlBuilder.BuildCount(), Connection);
                Int64 size = (Int64)command.ExecuteScalar();
                return size;
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Delete all the things on the shelf
        /// </summary>
        public void DeleteAll()
        {
            try
            {
                PrepareConnection();
                string query = MySqlBuilder.BuildDeleteAll();
                OdbcCommand command = new OdbcCommand(query, Connection);
                command.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Return the first inserted collumn ( By the id )
        /// </summary>
        /// <returns>The first thing</returns>
        public T First()
        {
            return EnumerableFor(MySqlBuilder.BuildFirst()).FirstOrDefault();
        }

        /// <summary>
        /// Return the last inserted collumn ( By the id )
        /// </summary>
        /// <returns>The last thing</returns>
        public T Last()
        {
            return EnumerableFor(MySqlBuilder.BuildLast()).FirstOrDefault();
        }

        /// <summary>
        /// Prepare the connection
        /// </summary>
        protected void PrepareConnection()
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();
        }

        /// <summary>
        /// Close the conectin
        /// </summary>
        protected void CloseConnection()
        {
            if (Connection.State != ConnectionState.Open)
                Connection.Close();
        }

        protected IEnumerable<T> EnumerableFor(string query)
        {
            try
            {
                PrepareConnection();
                OdbcCommand command = new OdbcCommand(query, Connection);
                OdbcDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    T output = new T();
                    AttributesExtractor<T> properties = new AttributesExtractor<T>(output);
                    output.Id = Convert.ToInt64(reader["Id"]);
                    foreach (PropertyInfo prop in properties.PersistentProperties())
                        prop.SetValue(output, reader[prop.Name], null);

                    output.SetConnection(Connection);
                    yield return output;
                }
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
