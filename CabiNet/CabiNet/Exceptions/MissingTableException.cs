using System;

namespace CabiNet
{
    /// <summary>
    /// When a table is missing
    /// </summary>
    public class MissingTableException : Exception
    {
        private readonly string _tableName;

        /// <summary>
        /// When a table is missing
        /// </summary>
        /// <param name="tableName">The table name</param>
        public MissingTableException(string tableName)
        {
            _tableName = tableName;
        }

        public override string Message
        {
            get
            {
                return "Missing table: " + _tableName;
            }
        }
    }
}
