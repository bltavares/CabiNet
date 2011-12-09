using System;

namespace CabiNet
{
    /// <summary>
    /// An Thing already existing on the database, but trying to INSERT again
    /// </summary>
    public class AlreadySavedException : Exception
    {
        public override string Message
        {
            get
            {
                return "The thing is already saved on the table " + TableName;
            }
        }

        /// <summary>
        /// The table name
        /// </summary>
        public string TableName { get; private set; }
        /// <summary>
        /// An Thing already existing on the database, but trying to INSERT again
        /// </summary>
        /// <param name="tablename">The table name</param>
        public AlreadySavedException(string tablename)
        {
            TableName = tablename;
        }

    }
}
