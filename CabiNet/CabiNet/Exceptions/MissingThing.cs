using System;

namespace CabiNet
{
    /// <summary>
    /// When trying to delete a thing not in the database
    /// </summary>
    public class MissingThing : Exception
    {
        private readonly string _tableName;

        /// <summary>
        /// When trying to delete a thing not in the database
        /// </summary>
        /// <param name="tablename">The table name</param>
        public MissingThing(string tablename)
        {
            _tableName = tablename;
        }

        public override string Message
        {
            get
            {
                return "This thing is not saved on table " + _tableName + "; Have you saved it?";
            }
        }

    }
}
