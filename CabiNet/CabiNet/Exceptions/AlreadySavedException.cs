using System;

namespace CabiNet
{
    public class AlreadySavedException : Exception
    {
        public override string Message
        {
            get
            {
                return "The thing is already saved on the table " + TableName;
            }
        }

        public string TableName { get; private set; }

        public AlreadySavedException(string tablename)
        {
            TableName = tablename;
        }

    }
}
