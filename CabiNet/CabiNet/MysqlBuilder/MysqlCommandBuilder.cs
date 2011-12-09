using System;
using System.Collections.Generic;
using System.Linq;

namespace CabiNet.MysqlBuilder
{
    /// <summary>
    /// MySQL query builder
    /// </summary>
    public class MysqlCommandBuilder
    {
        /// <summary>
        /// The name of the table
        /// </summary>
        public string TableName { get; private set; }

        /// <summary>
        /// Creates a new builder for a specific table
        /// </summary>
        /// <param name="tableName">The table name</param>
        public MysqlCommandBuilder(string tableName)
        {
            TableName = tableName;
        }

        /// <summary>
        /// SELECT *
        /// </summary>
        /// <returns>SQL query</returns>
        public string BuildSelectAll()
        {
            return "SELECT * FROM `" + TableName + "`;";
        }
        /// <summary>
        /// Selection using a parent field
        /// </summary>
        /// <param name="columnName">The name of the collumn</param>
        /// <param name="id">The id</param>
        /// <returns>SQL query</returns>
        public string BuildSelectRelated(string columnName, long id)
        {
            return "SELECT * FROM `" + TableName + "` where `" + columnName + "` = " + id;
        }

        /// <summary>
        /// Select first
        /// </summary>
        /// <returns>SQL query</returns>
        public string BuildFirst()
        {
            return "SELECT * FROM `" + TableName + "` order by id ASC limit 1";
        }

        /// <summary>
        /// select last
        /// </summary>
        /// <returns>SQL query</returns>
        public string BuildLast()
        {
            return "SELECT * FROM `" + TableName + "` order by id DESC limit 1";
        }

        /// <summary>
        /// SELECT filtering by id
        /// </summary>
        /// <param name="id">the id</param>
        /// <returns>SQL query</returns>
        public string BuildFindBy(Int64 id)
        {
            return "SELECT * FROM `" + TableName + "` where id = " + id + ";";
        }

        /// <summary>
        /// The Insert for the table
        /// </summary>
        /// <param name="collumns">The collumns with the values</param>
        /// <returns>SQL query</returns>
        public string BuildInsert(IDictionary<string, object> collumns)
        {
            string insert = "INSERT INTO `" + TableName + "`(ID,{0}) values (NULL,{1});";
            IList<string> collumnsNames = new List<string>();
            IList<string> valuesNames = new List<string>();
            foreach (KeyValuePair<string, object> attr in collumns)
            {
                collumnsNames.Add("`" + attr.Key + "`");
                valuesNames.Add(NormalizeInput(attr.Value));
            }

            return string.Format(insert, string.Join(",", collumnsNames), string.Join(",", valuesNames));
        }

        /// <summary>
        /// The query for delete
        /// </summary>
        /// <param name="thing">The thing to be deleted</param>
        /// <returns>SQL query</returns>
        public string BuildDelete(IThing thing)
        {
            return "DELETE FROM " + TableName + " where id = " + thing.Id;
        }

        /// <summary>
        /// Delete everything from the table
        /// </summary>
        /// <returns>SQL query</returns>
        public string BuildDeleteAll()
        {
            return "DELETE FROM " + TableName;
        }

        /// <summary>
        /// Update a table, filtering using the thing
        /// </summary>
        /// <param name="collumns">The fields to be updated</param>
        /// <param name="item">The Thing</param>
        /// <returns>SQL query</returns>
        public string BuildUpdate(IDictionary<string, object> collumns, IThing item)
        {
            string update = "UPDATE `" + TableName + "` SET {0} where id = {1}";
            IList<string> updates = new List<string>();
            foreach (KeyValuePair<string, object> attr in collumns)
            {
                string columnName = "`" + attr.Key + "`";
                string value = NormalizeInput(attr.Value);
                updates.Add(columnName + " = " + value);
            }

            return string.Format(update, string.Join(", ", updates), item.Id);
        }

        /// <summary>
        /// Gets the Last inserted id
        /// </summary>
        /// <returns></returns>
        public string BuildLastId()
        {
            return "SELECT LAST_INSERT_ID();";
        }

        /// <summary>
        /// Count *
        /// </summary>
        /// <returns>SQL query</returns>
        public string BuildCount()
        {
            return "SELECT COUNT(*) FROM " + TableName;
        }

        /// <summary>
        /// Build custom where
        /// </summary>
        /// <param name="columnName">collumn</param>
        /// <param name="condition">condition</param>
        /// <param name="value">Value</param>
        /// <param name="comparingCollumns">True if comparing collumns</param>
        /// <returns>SQL query</returns>
        public string BuildWhere(string columnName, WhereConditions condition, object value, bool comparingCollumns)
        {
            return "SELECT * FROM " + TableName + " where `" + columnName + "` " + ConditionToString(condition) + (comparingCollumns ? value.ToString() : NormalizeInput(value));
        }

        /// <summary>
        /// Build create table
        /// </summary>
        /// <param name="rows">the rows to create</param>
        /// <returns>SQL query</returns>
        public string BuildCreate(IEnumerable<ThingProperties> rows)
        {
            const string sql = @"CREATE TABLE IF NOT EXISTS `{0}` (
              `Id` int(11) unsigned NOT NULL AUTO_INCREMENT,
                {1}
              PRIMARY KEY (`Id`)
            ) ENGINE=InnoDB  DEFAULT CHARSET=latin1;";
            const string rowFormat = @"`{0}` {1} {2},";
            string rowReturn = rows.Aggregate("", (self, row) =>
                string.Format(rowFormat, row.Property.Name, row.Type + (row.IsMaxLength ? "(" + row.MaxLength + ")" : ""), (row.IsNullable ? "NOT NULL" : ""))
               );

            return string.Format(sql, TableName, rowReturn);
        }

        private string NormalizeInput(object data)
        {
            if (data is Double || data is float)
                return ((double)data).ToString(System.Globalization.CultureInfo.InvariantCulture);

            if (data is int)
                return data.ToString();

            if (data is bool)
                return (bool)data ? "1" : "0";
            if (data == null)
                return "\"\"";

            if (data is DateTime)
                return "\"" + ((DateTime)data).ToString("yyyy-MM-dd HH:mm:ss") + "\"";

            return "\"" + data.ToString().Replace("\"", "\\\"") + "\"";
        }

        private string ConditionToString(WhereConditions condition)
        {
            string @operator = "";
            switch (condition)
            {
                case WhereConditions.Equal:
                    @operator = " = ";
                    break;
                case WhereConditions.Diferent:
                    @operator = " <> ";
                    break;
                case WhereConditions.Hihger:
                    @operator = " > ";
                    break;
                case WhereConditions.Lower:
                    @operator = " < ";
                    break;
                case WhereConditions.HigherOrEqual:
                    @operator = " >= ";
                    break;
                case WhereConditions.LowerOrEqual:
                    @operator = " <= ";
                    break;
                case WhereConditions.Like:
                    @operator = " LIKE ";
                    break;
            }
            return @operator;

        }
    }
}
