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
        public string TableName { get; private set; }
        protected OdbcConnection connection;
        protected MysqlBuilder.MysqlCommandBuilder MySqlBuilder;

        /// <summary>
        /// Initialize with conection
        /// </summary>
        /// <param name="con">the ODBC connection</param>
        public Shelf(OdbcConnection con)
        {
            TableName = typeof(T).Name;
            connection = con;
            MySqlBuilder = new MysqlBuilder.MysqlCommandBuilder(TableName);
        }

        /// <summary>
        /// Get all the registers ont the database
        /// </summary>
        /// <returns>Array of the shelved things</returns>
        virtual public T[] All()
        {
            try
            {
                return EnumerableFor(MySqlBuilder.BuildSelectAll()).ToArray();
            }
            catch (Exception e)
            {
                throw e;
            }
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

            return Insert(new T[] { thing }).First();
        }

        /// <summary>
        /// Insert a the shelved thing on the database
        /// </summary>
        /// <param name="things">The new thing's list to be inserted</param>
        /// <param name="safe">Only insert the not saved things</param>
        /// <returns>The same thing updated</returns>
        /// <exception cref="AlreadySavedException">If the thing already have an id</exception>
        public IEnumerable<T> Insert(IEnumerable<T> things, bool safe = true)
        {
            if (!safe)
            {
                if (things.Any(thing => thing.Id != 0))
                    throw new AlreadySavedException(TableName);
            }
            IEnumerable<T> safe_things = things.Where(thing => thing.Id != 0);
            try
            {

                PrepareConnection();
                foreach (T thing in things)
                {
                    thing.Validate();
                    AttributesExtractor<T> Properties = new AttributesExtractor<T>(thing);
                    string query = MySqlBuilder.BuildInsert(Properties.PersistentAttributes());
                    OdbcCommand command = new OdbcCommand(query, connection);
                    command.ExecuteNonQuery();
                    command.CommandText = MySqlBuilder.BuildLastID();
                    Int64 lastId = (Int64)command.ExecuteScalar();
                    thing.Id = lastId;
                    thing.SetConnection(connection);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                CloseConnection();
            }
            return safe_things;
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

            Update<TItem>(new TItem[] { thing });
        }

        /// <summary>
        /// Update a thing on the database
        /// </summary>
        /// <typeparam name="TItem">The current shelf type</typeparam>
        /// <param name="things">The things list to be inserted</param>
        /// <param name="safe">Update only already saved things</param>
        /// <exception cref="MissingThing">If there the thing to be inserted has no Id</exception>
        public void Update<TItem>(IEnumerable<TItem> things, bool safe = true) where TItem : T
        {
            if (!safe)
            {
                if (things.Any(thing => thing.Id == 0))
                    throw new MissingThing(TableName);
            }
            IEnumerable<TItem> safe_things = things.Where(thing => thing.Id != 0);

            try
            {
                PrepareConnection();
                foreach (TItem thing in safe_things)
                {
                    thing.Validate();
                    AttributesExtractor<T> Properties = new AttributesExtractor<T>(thing);
                    string query = MySqlBuilder.BuildUpdate(Properties.PersistentAttributes(), thing);
                    OdbcCommand command = new OdbcCommand(query, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
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
            try
            {
                return EnumerableFor(MySqlBuilder.BuildFindBy(id)).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public T[] Where(string collumn, object value)
        {
            return Where(collumn, WhereConditions.EQUAL, value);
        }

        public T[] Where(string collumn, WhereConditions condition, object value)
        {
            try
            {
                return EnumerableFor(MySqlBuilder.BuildWhere(collumn, condition, value)).ToArray();
            }
            catch (Exception e)
            {
                throw e;
            }
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
            Delete<TItem>(new TItem[] { thing });
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
            if (!safe)
            {
                if (things.Any(thing => thing.Id == 0))
                    throw new MissingThing(TableName);

            }

            try
            {
                PrepareConnection();
                foreach (TItem thing in things.Where(thing => thing.Id != 0))
                {
                    string query = MySqlBuilder.BuildDelete(thing);
                    OdbcCommand command = new OdbcCommand(query, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
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
                OdbcCommand command = new OdbcCommand(MySqlBuilder.BuildCount(), connection);
                Int64 size = (Int64)command.ExecuteScalar();
                return size;
            }
            catch (Exception e)
            {
                throw e;
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
                OdbcCommand command = new OdbcCommand(query, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
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
            if (connection.State == ConnectionState.Closed)
                connection.Open();
        }

        /// <summary>
        /// Close the conectin
        /// </summary>
        protected void CloseConnection()
        {
            if (connection.State != ConnectionState.Open)
                connection.Close();
        }

        protected IEnumerable<T> EnumerableFor(string query)
        {
            try
            {
                PrepareConnection();
                OdbcCommand command = new OdbcCommand(query, connection);
                OdbcDataReader reader = command.ExecuteReader();
                T output;

                while (reader.Read())
                {
                    output = new T();
                    AttributesExtractor<T> Properties = new AttributesExtractor<T>(output);
                    output.Id = Convert.ToInt64(reader["Id"]);
                    foreach (PropertyInfo prop in Properties.PersistentProperties())
                        prop.SetValue(output, reader[prop.Name], null);

                    output.SetConnection(connection);
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
