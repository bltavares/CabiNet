using System;
using System.Collections.Generic;
using System.Linq;

namespace CabiNet.MysqlBuilder
{
    public class MysqlCommandBuilder
    {
        public string TableName { get; private set; }

        public MysqlCommandBuilder(string tableName)
        {
            TableName = tableName;
        }

        public string BuildSelectAll()
        {
            return "SELECT * FROM `" + TableName + "`;";
        }
        public string BuildSelectRelated(string ColumnName, long id)
        {
            return "SELECT * FROM `" + TableName + "` where `" + ColumnName + "` = " + id;
        }

        public string BuildFirst()
        {
            return "SELECT * FROM `" + TableName + "` order by id ASC limit 1";
        }

        public string BuildLast()
        {
            return "SELECT * FROM `" + TableName + "` order by id DESC limit 1";
        }

        public string BuildFindBy(Int64 id)
        {
            return "SELECT * FROM `" + TableName + "` where id = " + id + ";";
        }

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

        public string BuildDelete(IThing thing)
        {
            return "DELETE FROM " + TableName + " where id = " + thing.Id;
        }

        public string BuildDeleteAll()
        {
            return "DELETE FROM " + TableName;
        }

        public string BuildUpdate(IDictionary<string, object> collumns, IThing item)
        {
            string update = "UPDATE `" + TableName + "` SET {0} where id = {1}";
            IList<string> updates = new List<string>();
            foreach (KeyValuePair<string, object> attr in collumns)
            {
                string column_name = "`" + attr.Key + "`";
                string value = NormalizeInput(attr.Value);
                updates.Add(column_name + " = " + value);
            }

            return string.Format(update, string.Join(", ", updates), item.Id);
        }

        public string BuildLastID()
        {
            return "SELECT LAST_INSERT_ID();";
        }

        public string BuildCount()
        {
            return "SELECT COUNT(*) FROM " + TableName;
        }

        public string BuildWhere(string columnName, WhereConditions condition, object value)
        {
            return "SELECT * FROM " + TableName + "where `" + columnName + "` " + ConditionToString(condition) + NormalizeInput(value);
        }

        public string BuildCreate(IEnumerable<ThingProperties> rows)
        {
            string sql = @"CREATE TABLE IF NOT EXISTS `{0}` (
              `Id` int(11) unsigned NOT NULL AUTO_INCREMENT,
                {1}
              PRIMARY KEY (`Id`)
            ) ENGINE=InnoDB  DEFAULT CHARSET=latin1;";
            string row_format = @"`{0}` {1} {2},";
            string row_return = rows.Aggregate("", (self, row) =>
                self += string.Format(row_format, row.property.Name, row.type + (row.IsMaxLength ? "(" + row.MaxLength + ")" : ""), (row.IsNullable ? "NOT NULL" : ""))
               );

            return string.Format(sql, TableName, row_return);
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
                case WhereConditions.EQUAL:
                    @operator = " = ";
                    break;
                case WhereConditions.DIFERENT:
                    @operator = " <> ";
                    break;
                case WhereConditions.HIHGER:
                    @operator = " > ";
                    break;
                case WhereConditions.LOWER:
                    @operator = " < ";
                    break;
                case WhereConditions.HIGHERorEQUAL:
                    @operator = " >= ";
                    break;
                case WhereConditions.LOWERorEQUAL:
                    @operator = " <= ";
                    break;
                case WhereConditions.LIKE:
                    @operator = " LIKE ";
                    break;
            }
            return @operator;

        }
    }
}
