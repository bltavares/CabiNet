using System.Reflection;

namespace CabiNet
{
    /// <summary>
    /// List of the properties of the fields
    /// </summary>
    public class ThingProperties
    {
        /// <summary>
        /// The property info
        /// </summary>
        public PropertyInfo Property { get; set; }
        /// <summary>
        /// If the field can be null
        /// </summary>
        public bool IsNullable { get; set; }
        /// <summary>
        /// If the filed has max length attribute
        /// </summary>
        public bool IsMaxLength { get; set; }
        /// <summary>
        /// The max length size
        /// </summary>
        public int MaxLength { get; set; }
        /// <summary>
        /// The type of the field
        /// </summary>
        public string Type { get; set; }
    }
}
