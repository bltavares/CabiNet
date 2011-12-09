using System;

namespace CabiNet
{
    /// <summary>
    /// When a max lenght property reaches the limit
    /// </summary>
    public class MaxLengthOverflowException : Exception
    {
        public override string Message
        {
            get
            {
                return "A max length (" + _size + ") column is over the capacity. (" + _collumn + ")";
            }
        }

        private readonly string _collumn;
        private readonly int _size;
        /// <summary>
        /// When a max lenght property reaches the limit
        /// </summary>
        /// <param name="collumn">The name of the property</param>
        /// <param name="size">The limit</param>
        public MaxLengthOverflowException(string collumn, int size)
        {
            _collumn = collumn;
            _size = size;
        }
    }
}
