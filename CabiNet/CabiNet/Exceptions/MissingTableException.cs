using System;

namespace CabiNet
{
    public class MissingTableException : Exception
    {
        private string TableName;

        public MissingTableException(string tableName)
        {
            TableName = tableName;
        }

        public override string Message
        {
            get
            {
                return "Missing table: " + TableName;
            }
        }
    }
}
