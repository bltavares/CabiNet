using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CabiNet
{
    public class ThingProperties
    {
        public PropertyInfo property { get; set; }
        public bool IsNullable { get; set; }
        public bool IsMaxLength { get; set; }
        public int MaxLength { get; set; }
        public string type { get; set; }
    }
}
