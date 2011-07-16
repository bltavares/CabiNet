using System;

namespace CabiNet
{
    /// <summary>
    /// Defines the max length of attribute
    /// </summary>
    public class MaxLengthAttribute : Attribute
    {
        public int Size { get; private set; }
        public MaxLengthAttribute(int size)
        {
            Size = size;
        }
    }
}
