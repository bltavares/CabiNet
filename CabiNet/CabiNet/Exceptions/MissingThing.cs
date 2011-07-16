using System;

namespace CabiNet
{
    public class MissingThing : Exception
    {
        private string TableName;

        public MissingThing(string tablename)
        {
            TableName = tablename;
        }

        public override string Message
        {
            get
            {
                return "This thing is not saved on table " + TableName + "; Have you saved it?";
            }
        }

    }
}
