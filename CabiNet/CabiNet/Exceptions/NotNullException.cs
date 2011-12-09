using System;

namespace CabiNet
{
    /// <summary>
    /// When trying to save on the database a null field that can't be null
    /// </summary>
    public class NotNullException : Exception
    {
        private readonly string _collumnName;
        /// <summary>
        /// The name of the collumn
        /// </summary>
        public string Collumn { get { return _collumnName; } }

        /// <summary>
        /// When trying to save on the database a null field that can't be null
        /// </summary>
        /// <param name="collumnanme">The property name</param>
        public NotNullException(string collumnanme)
        {
            _collumnName = collumnanme;
        }

        public override string Message
        {
            get
            {
                return "A not null column is null or empty. (" + _collumnName + ")";
            }
        }

    }
}
