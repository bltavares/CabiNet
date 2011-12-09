using System;

namespace CabiNet
{
    /// <summary>
    /// Defines the max length of attribute
    /// </summary>
    public class MaxLengthAttribute : Attribute
    {
        /// <summary>
        /// Size of the max-length
        /// </summary>
        public int Size { get; private set; }
        /// <summary>
        /// Create an max-length attribute
        /// </summary>
        /// <param name="size">The limit size</param>
        public MaxLengthAttribute(int size)
        {
            Size = size;
        }
    }
}
