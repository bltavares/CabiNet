using System;

namespace CabiNet
{
    public class MaxLengthOverflowException : Exception
    {
        public override string Message
        {
            get
            {
                return "A max length (" + Size + ") column is over the capacity. (" + Collumn + ")";
            }
        }

        private string Collumn;
        private int Size;
        public MaxLengthOverflowException(string collumn, int size)
        {
            Collumn = collumn;
            Size = size;
        }
    }
}
