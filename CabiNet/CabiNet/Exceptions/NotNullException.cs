using System;

namespace CabiNet
{
    public class NotNullException : Exception
    {
        private string CollumnName;
        public string Collumn { get { return CollumnName; } }

        public NotNullException(string collumnanme)
        {
            CollumnName = collumnanme;
        }

        public override string Message
        {
            get
            {
                return "A not null column is null or empty. (" + CollumnName + ")";
            }
        }

    }
}
