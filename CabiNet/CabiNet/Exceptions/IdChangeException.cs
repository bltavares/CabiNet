using System;

namespace CabiNet
{
    /// <summary>
    /// Raised when an id is going to be updated
    /// </summary>
    public class IdChangeException : Exception
    {
        public override string Message
        {
            get
            {
                return "Can't change the Id";
            }
        }
    }
}
