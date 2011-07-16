using System;

namespace CabiNet
{
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
